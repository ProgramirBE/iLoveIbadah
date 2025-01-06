import { Component, OnInit } from '@angular/core';
import { IslamicFinderService } from 'src/app/infrastructure/services/proxies/external/islamic-finder.service';

@Component({
  selector: 'app-salat',
  templateUrl: './salat.component.html',
  styleUrls: ['./salat.component.scss'],
})
export class SalatComponent implements OnInit {
  salatTimes: any = null;
  location: string = '';
  latitude: number | null = null;
  longitude: number | null = null;
  currentDate: string = '';
  currentTime: Date = new Date();
  nextPrayerName: string = '';
  currentPrayerName: string = '';
  filteredPrayers: { name: string; time: Date }[] = [];
  prayerTimesForSelection: string[] = [];
  duaAfterPrayer: string = '';
  selectedTime: string = '';
  prayerPercentages: { [key: string]: number } = {
    Fajr: 0,
    Dhuhr: 0,
    Asr: 0,
    Maghrib: 0,
    Isha: 0,
  };

  constructor(private islamicFinderService: IslamicFinderService) {}

  ngOnInit(): void {
    this.updateCurrentDateTime();
    this.getLocationAndFetchTimes();
    this.setDuaAfterPrayer();

    setInterval(() => {
      this.updateCurrentDateTime();
      this.determineNextPrayer();
      this.determineCurrentPrayer();
    }, 60000); // Update toutes les 60 secondes
  }

  updateCurrentDateTime(): void {
    this.currentDate = new Date().toLocaleDateString('en-US', {
      weekday: 'long',
      year: 'numeric',
      month: 'long',
      day: 'numeric',
    });
    this.currentTime = new Date();
  }

  getLocationAndFetchTimes(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.latitude = position.coords.latitude;
          this.longitude = position.coords.longitude;
          this.fetchSalatTimes();
        },
        (error) => {
          console.error('Location error:', error);
        }
      );
    } else {
      console.error('Geolocation is not supported by this browser.');
    }
  }

  fetchSalatTimes(): void {
    if (this.latitude !== null && this.longitude !== null) {
      this.islamicFinderService
        .getSalatTimes(this.latitude, this.longitude)
        .subscribe({
          next: (data) => {
            console.log('Raw salat times from API:', data.results);
            if (data.results) {
              this.salatTimes = data.results;
              this.filteredPrayers = [
                {
                  name: 'Fajr',
                  time: this.convertToDate(data.results['Fajr']),
                },
                {
                  name: 'Dhuhr',
                  time: this.convertToDate(data.results['Dhuhr']),
                },
                { name: 'Asr', time: this.convertToDate(data.results['Asr']) },
                {
                  name: 'Maghrib',
                  time: this.convertToDate(data.results['Maghrib']),
                },
                {
                  name: 'Isha',
                  time: this.convertToDate(data.results['Isha']),
                },
              ];
              console.log(
                'Filtered prayers with Date objects:',
                this.filteredPrayers
              );
              this.determineNextPrayer();
              this.determineCurrentPrayer();
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

  convertToDate(time: string): Date {
    try {
      const now = new Date();
      const [hours, minutes] = time.split(':').map((t) => parseInt(t, 10));
      const isPM = time.toLowerCase().includes('pm');
      const finalHours = isPM && hours < 12 ? hours + 12 : hours;

      const date = new Date(
        now.getFullYear(),
        now.getMonth(),
        now.getDate(),
        finalHours,
        minutes
      );
      return date;
    } catch (error) {
      console.error('Error converting time to Date:', time, error);
      return new Date();
    }
  }

  determineNextPrayer(): void {
    const now = this.currentTime;

    for (let i = 0; i < this.filteredPrayers.length; i++) {
      const currentPrayer = this.filteredPrayers[i];
      const nextPrayer =
        this.filteredPrayers[(i + 1) % this.filteredPrayers.length];

      if (now >= currentPrayer.time && now < nextPrayer.time) {
        this.nextPrayerName = nextPrayer.name;
        return;
      }
    }

    // Special : after Isha or before Fajr
    this.nextPrayerName = 'Fajr';
  }

  determineCurrentPrayer(): void {
    const now = this.currentTime;

    for (let i = 0; i < this.filteredPrayers.length; i++) {
      const currentPrayer = this.filteredPrayers[i];
      const nextPrayer =
        this.filteredPrayers[(i + 1) % this.filteredPrayers.length];

      if (now >= currentPrayer.time && now < nextPrayer.time) {
        this.currentPrayerName = currentPrayer.name;
        this.generatePrayerTimeOptions(currentPrayer.time);
        return;
      }
    }

    // Special : after Isha or before Fajr
    this.currentPrayerName = 'Isha';
    this.generatePrayerTimeOptions(this.filteredPrayers[4].time);
  }

  generatePrayerTimeOptions(prayerTime: Date): void {
    const currentTime = new Date().getTime();
    console.log('Current time:', currentTime);
    const options = [];
    let newTime = new Date(prayerTime);

    while (newTime.getTime() <= currentTime) {
      options.push(
        newTime.toLocaleTimeString('en-US', {
          hour: '2-digit',
          minute: '2-digit',
          hour12: true,
        })
      );
      newTime.setMinutes(newTime.getMinutes() + 10);
    }
    this.prayerTimesForSelection = options;
  }
  // generatePrayerTimeOptions(prayerTime: Date): void {
  //   var currentTime = new Date().getTime();
  //   console.log('Current time:', currentTime);
  //   const options = [];
  //   for (let i = 0; i < 5; i++) {
  //     const newTime = new Date(prayerTime);
  //     newTime.setMinutes(newTime.getMinutes() + i * 10);
  //     options.push(
  //       newTime.toLocaleTimeString('en-US', {
  //         hour: '2-digit',
  //         minute: '2-digit',
  //         hour12: true,
  //       })
  //     );
  //   }
  //   options.push('Later');
  //   this.prayerTimesForSelection = options;
  // }

  setDuaAfterPrayer(): void {
    this.duaAfterPrayer = `اللهم أنت السلام ومنك السلام تباركت يا ذا الجلال والإكرام
    Translation: "O Allah, You are peace, and from You comes peace. Blessed are You, O Owner of Majesty and Honor."`;
  }

  onPrayerAnswered(): void {
    console.log(`Prayer confirmed: ${this.currentPrayerName}`);
    console.log(`Selected time: ${this.selectedTime}`);
  }

  refresh(): void {
    this.getLocationAndFetchTimes();
  }

  onSendPrayerPunctuality(): void {
    const prayerName = this.currentPrayerName;
    const selectedTime = this.selectedTime;
    console.log(
      `Prayer punctuality for ${prayerName} at ${selectedTime} has been sent.`
    );
  }
}
