import { Component, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NetworkService } from 'src/app/infrastructure/services/proxies/external/network.service';
import { IslamicFinderService } from 'src/app/infrastructure/services/proxies/external/islamic-finder.service';
import { UserSalahActivity } from 'src/app/domain/models/user-salah-activity';
import { SalahType } from 'src/app/domain/models/salah-type';
import { UserSalahActivitiesService } from 'src/app/infrastructure/services/proxies/internal/user-salah-activities.service';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/user-accounts.service';
import { SalahTypesService } from 'src/app/infrastructure/services/proxies/internal/salah-types.service';

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
    Dohr: 0,
    Asr: 0,
    Maghrib: 0,
    Isha: 0,
  };
  //userSalahActivity: UserSalahActivity = new UserSalahActivity();
  userSalahActivities: UserSalahActivity[] = [];
  salahTypes: SalahType[] = [];
  mappedSalahData: { salahTypeId: number; punctualityPercentage: number }[] =
    [];
  salahTypeId = signal(0);
  isLoggedIn = false;
  trackPrayerPunctualityForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private salahTypeService: SalahTypesService,
    private islamicFinderService: IslamicFinderService,
    private userSalahActivitiesService: UserSalahActivitiesService,
    private networkService: NetworkService,
    private userAccountsService: UserAccountsService
  ) {
    this.trackPrayerPunctualityForm = this.formBuilder.group({
      prayerTimeOption: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.isLoggedIn = this.userAccountsService.isLoggedIn();
    this.salahTypes = this.route.snapshot.data['salahTypes'] || [];
    if (!this.salahTypes) {
      console.error('Failed to load dhikr types, retry to fetch from api');
    }
    if (this.salahTypes) {
      console.log(this.salahTypes.map((s) => s.fullName));
    }

    this.userSalahActivities = this.route.snapshot.data['userSalahActivities'];
    if (!this.userSalahActivities) {
      console.error(
        'Failed to load user salah activities, retry to fetch from api'
      );
    }
    
    this.mapSalahData();
    // this.mappedSalahData = this.salahTypes.map((id) => {
    //   const activity = this.userSalahActivities.find(
    //     (activity) => activity.salahTypeId === id
    //   );
    //   return {
    //     salahTypeId: id,
    //     punctualityPercentage: activity
    //       ? `${activity.punctualityPercentage}%`
    //       : '??',
    //   };
    // });

    this.updateCurrentDateTime();
    this.getLocationAndFetchTimes();
    this.setDuaAfterPrayer();

    setInterval(() => {
      this.updateCurrentDateTime();
      this.determineNextPrayer();
      this.determineCurrentPrayer();
    }, 60000); // Update toutes les 60 secondes
  }

  mapSalahData(): void {
    this.mappedSalahData = this.salahTypes.map((salahType) => {
      const activity = this.userSalahActivities.find(
        (activity) => activity.salahTypeId === salahType.id
      );
      return {
        salahTypeId: salahType.id,
        punctualityPercentage: activity ? activity.punctualityPercentage : -1, // Use -1 for missing data
      };
    });
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
                  name: 'Dohr',
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
          hour12: false,
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
    console.log(this.userSalahActivities);
  }

  async onTrackPrayerPunctuality(): Promise<void> {
    if (this.trackPrayerPunctualityForm.valid) {
      const { prayerTimeOption } = this.trackPrayerPunctualityForm.value;
      const now = this.currentTime;
      let currentPrayerBeginTime: Date | undefined;
      let nextPrayerBeginTime: Date | undefined;
      let punctualityPercentage: number | undefined;

      for (let i = 0; i < this.filteredPrayers.length; i++) {
        const currentPrayer = this.filteredPrayers[i];
        const nextPrayer =
          this.filteredPrayers[(i + 1) % this.filteredPrayers.length];

        if (
          (now >= currentPrayer.time && now < nextPrayer.time) ||
          (currentPrayer.name === 'Isha' &&
            nextPrayer.name === 'Sobh' &&
            now >= currentPrayer.time)
        ) {
          this.currentPrayerName = currentPrayer.name;
          currentPrayerBeginTime = currentPrayer.time;
          nextPrayerBeginTime = nextPrayer.time;

          // Adjust nextPrayerBeginTime for the transition across midnight
          if (currentPrayer.name === 'Isha' && nextPrayer.name === 'Sobh') {
            nextPrayerBeginTime.setDate(nextPrayerBeginTime.getDate() + 1);
          }
        }
      }
      if (currentPrayerBeginTime && nextPrayerBeginTime) {
        console.log('currentprayername', this.currentPrayerName);
        punctualityPercentage = this.calculatePunctualityPercentage(
          prayerTimeOption,
          currentPrayerBeginTime,
          nextPrayerBeginTime
        );
        console.log('Punctuality percentage:', punctualityPercentage);

        // Continue with the rest of your logic
      } else {
        console.error('Failed to determine prayer times');
      }

      //this.salahTypes.map((s) => s.fullName);
      let salahType = this.salahTypes.find(
        (s) => s.fullName === this.currentPrayerName
      );
      const salahTypeId = salahType?.id ?? 'Unknown';
      console.log('SalahTypeId:', salahTypeId);
      try {
        // Wait for the upsert and other async operations to complete
        await this.upsertSalahActivity(salahTypeId, punctualityPercentage);
        await this.refreshUserSalahActivities();
        this.mapSalahData();
        window.location.reload(); // Reload after everything has finished
      } catch (error) {
        console.error('Error during salah activity update', error);
      }
    }
  }

  refreshUserSalahActivities(): void {
    const date = new Date();
    const formattedDate = date.toISOString().split('T')[0];
    
    this.userSalahActivitiesService.getTrackedOn(formattedDate).subscribe({
      next: (data) => {
        this.userSalahActivities = data; // Assign the received data to the array
        console.log(
          'User Salah Activities refreshed:',
          this.userSalahActivities
        );
      },
      error: (error) => {
        console.error('Error fetching User Salah Activities:', error);
      },
    });
  }

  calculatePunctualityPercentage(
    prayerTimeOption: string,
    currentPrayerBeginTime: Date,
    nextPrayerBeginTime: Date
  ): number {
    // Extract hours and minutes from prayerTimeOption
    const [optionHours, optionMinutes] = prayerTimeOption
      .split(':')
      .map(Number);

    // Convert currentPrayerBeginTime and nextPrayerBeginTime to total minutes
    const currentPrayerMinutes =
      currentPrayerBeginTime.getHours() * 60 +
      currentPrayerBeginTime.getMinutes();
    const nextPrayerMinutes =
      nextPrayerBeginTime.getHours() * 60 + nextPrayerBeginTime.getMinutes();

    // Handle the transition across midnight for Isha to Sobh
    const adjustedNextPrayerMinutes =
      nextPrayerMinutes < currentPrayerMinutes
        ? nextPrayerMinutes + 24 * 60
        : nextPrayerMinutes;

    // Convert prayerTimeOption to total minutes
    const prayerOptionMinutes = optionHours * 60 + optionMinutes;

    // Handle the transition across midnight for prayerTimeOption
    const adjustedPrayerOptionMinutes =
      prayerOptionMinutes < currentPrayerMinutes
        ? prayerOptionMinutes + 24 * 60
        : prayerOptionMinutes;

    // Calculate the percentage
    const percentage =
      ((adjustedPrayerOptionMinutes - currentPrayerMinutes) /
        (adjustedNextPrayerMinutes - currentPrayerMinutes)) *
      100;

    // Invert the percentage
    const invertedPercentage = 100 - percentage;

    // Ensure the percentage is between 0 and 100
    return Math.max(
      0,
      Math.min(100, parseFloat(invertedPercentage.toFixed(2)))
    );
  }

  upsertSalahActivity(salahTypeId: any, punctualityPercentage: any): Promise<any> {
    return new Promise((resolve, reject) => {
    this.userSalahActivitiesService
      .upsert(salahTypeId, punctualityPercentage)
      .subscribe({
        next: (response) => {
          console.log('Salah activity upserted successfully', response);
          resolve(response);
        },
        error: (error) => {
          console.error('Error upserting salah activity', error);
          reject(error);
        },
      });
  });
}
}
