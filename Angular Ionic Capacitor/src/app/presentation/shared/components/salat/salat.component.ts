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
  timer: { hours: number; minutes: number; seconds: number } | null = null;
  filteredPrayers: { name: string; time: string }[] = [];
  duaAfterPrayer: string = ''; 
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
          if (data.success && data.results) {
            this.salatTimes = Object.fromEntries(
              Object.entries(data.results).map(([key, value]) => [
                key,
                (value as string).replace(/%/g, ''), 
              ])
            );

            this.filteredPrayers = [
              { name: 'Fajr', time: this.salatTimes['Fajr'] },
              { name: 'Dhuhr', time: this.salatTimes['Dhuhr'] },
              { name: 'Asr', time: this.salatTimes['Asr'] },
              { name: 'Maghrib', time: this.salatTimes['Maghrib'] },
              { name: 'Isha', time: this.salatTimes['Isha'] },
            ];

            this.setNextPrayerTimer(); // Set the timer
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

  setNextPrayerTimer(): void {
    if (this.timerInterval) {
      clearInterval(this.timerInterval);
    }

    if (!this.filteredPrayers || this.filteredPrayers.length === 0) {
      console.error('No prayer times available to set the timer.');
      this.nextPrayerName = 'Unavailable';
      this.timer = { hours: 0, minutes: 0, seconds: 0 };
      return;
    }

    const now = new Date();

    const prayerTimes = this.filteredPrayers.map((prayer) => {
      const [hours, minutes] = prayer.time.split(':').map(Number);
      const prayerDate = new Date();
      prayerDate.setHours(hours, minutes, 0, 0);
      return { name: prayer.name, time: prayerDate };
    });

    const nextPrayer =
      prayerTimes.find((prayer) => prayer.time > now) || prayerTimes[0];

    this.nextPrayerName = nextPrayer.name;

    this.timerInterval = setInterval(() => {
      const currentTime = new Date();
      let diff = (nextPrayer.time.getTime() - currentTime.getTime()) / 1000;

      if (diff < 0) {
        diff += 24 * 60 * 60;
      }

      if (diff <= 0) {
        clearInterval(this.timerInterval);
        this.setNextPrayerTimer();
      } else {
        this.timer = {
          hours: Math.floor(diff / 3600),
          minutes: Math.floor((diff % 3600) / 60),
          seconds: Math.floor(diff % 60),
        };
      }
    }, 1000);
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
