import { Component, OnInit } from '@angular/core';
import { SalatService } from './salat.service';

@Component({
  selector: 'app-salat',
  templateUrl: './salat.component.html',
  styleUrls: ['./salat.component.scss'],
})
export class SalatComponent implements OnInit {
  salatTimes: any = null; // Holds the fetched prayer times
  location: string = '';
  latitude: number | null = null;
  longitude: number | null = null;
  currentDate: string = '';
  currentTime: string = ''; // Current time in AM/PM format
  nextPrayerName: string = ''; // Holds the name of the next prayer
  currentPrayerName: string = ''; // Holds the current prayer for display
  filteredPrayers: { name: string; time: string }[] = []; // Stores the list of prayers with times
  prayerTimesForSelection: string[] = []; // Options for the prayer time dropdown
  selectedTime: string = ''; // User-selected time for the prayer
  duaAfterPrayer: string = ''; // Holds the Dua after prayer

  constructor(private salatService: SalatService) {}

  ngOnInit(): void {
    this.updateCurrentDateTime();
    this.getLocationAndFetchTimes();
    this.setDuaAfterPrayer();
    setInterval(() => this.updateCurrentDateTime(), 1000); // Update the time every second
  }

  // Updates the current date and time
  updateCurrentDateTime(): void {
    const now = new Date();
    this.currentDate = now.toLocaleDateString('en-US', {
      weekday: 'long',
      year: 'numeric',
      month: 'long',
      day: 'numeric',
    });
    this.currentTime = now.toLocaleTimeString('en-US', {
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit',
      hour12: true,
    });
  }

  // Fetches the user's location and retrieves prayer times
  getLocationAndFetchTimes(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.latitude = position.coords.latitude;
          this.longitude = position.coords.longitude;
          this.fetchSalatTimes();
        },
        (error) => {
          console.error('Error fetching location:', error);
        }
      );
    } else {
      console.error('Geolocation is not supported by this browser.');
    }
  }

  // Fetches prayer times from the SalatService using latitude and longitude
  fetchSalatTimes(): void {
    if (this.latitude !== null && this.longitude !== null) {
      this.salatService.getSalatTimes(this.latitude, this.longitude).subscribe({
        next: (data) => {
          if (data.results) {
            this.salatTimes = data.results;

            // Extract and format prayer times into the filteredPrayers array
            this.filteredPrayers = [
              { name: 'Fajr', time: this.formatTime(this.salatTimes['Fajr']) },
              { name: 'Dhuhr', time: this.formatTime(this.salatTimes['Dhuhr']) },
              { name: 'Asr', time: this.formatTime(this.salatTimes['Asr']) },
              { name: 'Maghrib', time: this.formatTime(this.salatTimes['Maghrib']) },
              { name: 'Isha', time: this.formatTime(this.salatTimes['Isha']) },
            ];

            this.setNextPrayer();
          } else {
            console.error('No prayer times received.');
          }
        },
        error: (error) => {
          console.error('Error fetching prayer times:', error);
        },
      });
    }
  }

  // Formats time to ensure it's in the correct format
  formatTime(time: string): string {
    return time.replace(/[^0-9:]/g, ''); // Remove any unwanted characters
  }

  // Determines the next prayer based on the current time
  setNextPrayer(): void {
    const now = new Date();
    console.log(`Current time: ${now.toLocaleTimeString('en-US')}`);

    // Parse prayer times into Date objects for accurate comparison
    const prayerTimes = this.filteredPrayers.map((prayer) => {
      const [hours, minutes] = prayer.time.split(':').map(Number);
      const prayerDate = new Date();
      prayerDate.setHours(hours, minutes, 0, 0); // Set the time for today
      console.log(`Parsed ${prayer.name} time: ${prayerDate.toLocaleTimeString('en-US')}`);
      return { name: prayer.name, time: prayerDate };
    });

    // Sort prayer times in chronological order
    prayerTimes.sort((a, b) => a.time.getTime() - b.time.getTime());

    console.log('Parsed prayer times:', prayerTimes);

    // Find the next prayer
    let nextPrayer = null;

    for (const prayer of prayerTimes) {
      console.log(
        `Checking if now (${now.toLocaleTimeString('en-US')}) < ${prayer.name} (${prayer.time.toLocaleTimeString('en-US')})`
      );
      if (now < prayer.time) {
        nextPrayer = prayer;
        break;
      }
    }

    // If no future prayer is found, set the next prayer to Fajr
    if (!nextPrayer) {
      console.log('Current time is after Isha. Next prayer is Fajr.');
      nextPrayer = prayerTimes[0]; // First prayer of the next day
    }

    this.nextPrayerName = nextPrayer.name;

    // Set the current prayer name for the UI
    const currentPrayerIndex = prayerTimes.findIndex((prayer) => prayer.name === nextPrayer.name) - 1;
    this.currentPrayerName =
      currentPrayerIndex >= 0 ? prayerTimes[currentPrayerIndex].name : prayerTimes[prayerTimes.length - 1].name;

    console.log(`Next prayer: ${this.nextPrayerName}`);
    console.log(`Current prayer for question: ${this.currentPrayerName}`);

    // Populate prayer times dropdown for user selection
    this.generatePrayerTimeOptions(nextPrayer.time);
  }

  // Populates dropdown options for "Kies een tijd"
  generatePrayerTimeOptions(prayerTime: Date): void {
    const options = [];
    const now = new Date();
    for (let i = 0; i < 5; i++) {
      const newTime = new Date(prayerTime.getTime());
      newTime.setMinutes(newTime.getMinutes() + i * 10);
      if (newTime > now) {
        options.push(newTime.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit', hour12: true }));
      }
    }
    options.push('Later');
    this.prayerTimesForSelection = options;

    console.log('Generated prayer times for dropdown:', this.prayerTimesForSelection);
  }

  // Sets a Dua to be displayed after the prayer
  setDuaAfterPrayer(): void {
    this.duaAfterPrayer = `اللهم أنت السلام ومنك السلام تباركت يا ذا الجلال والإكرام 
    Translation: "O Allah, You are peace and from You comes peace. Blessed are You, O Owner of Majesty and Honor."`;
  }

  // Handles when the user answers the prayer question
  onPrayerAnswered(): void {
    console.log(`User answered for prayer: ${this.currentPrayerName}`);
    console.log(`Selected time: ${this.selectedTime}`);
  }

  // Refreshes the location and prayer times
  refresh(): void {
    console.log('Refreshing location and prayer times...');
    this.getLocationAndFetchTimes();
  }
}
