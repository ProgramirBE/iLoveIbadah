import { Component, OnInit } from '@angular/core';
import { SalatService } from './salat.service';

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
  nextPrayerName: string = '';
  currentPrayerName: string = '';
  timer: { hours: number; minutes: number; seconds: number } | null = null;
  filteredPrayers: { name: string; time: string }[] = [];
  prayerTimesForSelection: string[] = [];
  selectedTime: string = '';
  duaAfterPrayer: string = ''; // Toegevoegd om de fout te corrigeren
  private timerInterval: any;

  constructor(private salatService: SalatService) {}

  ngOnInit(): void {
    this.updateCurrentDate();
    this.getLocationAndFetchTimes();
    this.setDuaAfterPrayer();
    setInterval(() => this.updateCurrentDate(), 1000);
  }

  updateCurrentDate(): void {
    const now = new Date();
    this.currentDate = now.toLocaleDateString('en-US', {
      weekday: 'long',
      year: 'numeric',
      month: 'long',
      day: 'numeric',
    });
  }

  getLocationAndFetchTimes(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.latitude = position.coords.latitude;
          this.longitude = position.coords.longitude;
          this.location = `${this.latitude.toFixed(2)}, ${this.longitude.toFixed(2)}`;
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

  fetchSalatTimes(): void {
    if (this.latitude !== null && this.longitude !== null) {
      this.salatService.getSalatTimes(this.latitude, this.longitude).subscribe({
        next: (data) => {
          if (data.results) {
            this.salatTimes = data.results;

            this.filteredPrayers = [
              { name: 'Fajr', time: this.salatTimes['Fajr'].replace(/[^0-9:]/g, '') },
              { name: 'Dhuhr', time: this.salatTimes['Dhuhr'].replace(/[^0-9:]/g, '') },
              { name: 'Asr', time: this.salatTimes['Asr'].replace(/[^0-9:]/g, '') },
              { name: 'Maghrib', time: this.salatTimes['Maghrib'].replace(/[^0-9:]/g, '') },
              { name: 'Isha', time: this.salatTimes['Isha'].replace(/[^0-9:]/g, '') },
            ];

            this.setCurrentPrayer();
          } else {
            console.error('No prayer times received.');
            this.salatTimes = null;
          }
        },
        error: (error) => {
          console.error('Error fetching prayer times:', error);
          this.salatTimes = null;
        },
      });
    }
  }

  setCurrentPrayer(): void {
    const now = new Date();

    const prayerTimes = this.filteredPrayers.map((prayer) => {
      const [hours, minutes] = prayer.time.split(':').map(Number);
      const prayerDate = new Date();
      prayerDate.setHours(hours, minutes, 0, 0);
      return { name: prayer.name, time: prayerDate };
    });

    const currentPrayer =
      prayerTimes.find((prayer, index) => {
        const nextPrayer = prayerTimes[index + 1];
        return nextPrayer
          ? now >= prayer.time && now < nextPrayer.time
          : now >= prayer.time;
      }) || prayerTimes[0];

    this.currentPrayerName = currentPrayer.name;

    // Genereer tijdopties voor het huidige gebed
    this.generatePrayerTimeOptions(currentPrayer.time);
  }

  generatePrayerTimeOptions(prayerTime: Date): void {
    const options = [];
    for (let i = 0; i < 5; i++) {
      const newTime = new Date(prayerTime.getTime());
      newTime.setMinutes(newTime.getMinutes() + i * 10);
      options.push(newTime.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }));
    }
    options.push('Later');
    this.prayerTimesForSelection = options;
  }

  onPrayerAnswered(): void {
    console.log(`Gebed beantwoord: Ja`);
    console.log(`Geselecteerde tijd: ${this.selectedTime}`);
  }

  refresh(): void {
    console.log('Refreshing...');
    this.getLocationAndFetchTimes();
  }

  setDuaAfterPrayer(): void {
    this.duaAfterPrayer = `اللهم أنت السلام ومنك السلام تباركت يا ذا الجلال والإكرام 
    Translation: "O Allah, You are peace and from You comes peace. Blessed are You, O Owner of Majesty and Honor."`;
  }
}
