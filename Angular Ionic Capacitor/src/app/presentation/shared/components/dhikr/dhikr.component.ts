import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { UserDhikrActivity } from 'src/app/domain/models/user-dhikr-activity';
import { UserDhikrActivitiesService } from 'src/app/infrastructure/services/proxies/internal/user-dhikr-activities.service';
import { NetworkService } from 'src/app/infrastructure/services/proxies/external/network.service';
import { DhikrType } from 'src/app/domain/models/dhikr-type';
import { UserDhikrOverviewsService } from 'src/app/infrastructure/services/proxies/internal/user-dhikr-overviews.service';
import { UserDhikrOverview } from 'src/app/domain/models/user-dhikr-overview';
import { DhikrTypeService } from 'src/app/presentation/shared/components/dhikr/dhikr-type.service';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/user-accounts.service';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent implements OnInit {
  dhikrTypeId = signal<number | null>(null); // Huidige dhikr type id
  dhikrFullName = signal(''); // Huidige dhikr type full name
  totalCounter = signal(0); // Lokale totale teller
  counter = signal(0); // Lokale teller
  //onlineCounter = signal<number | null>(null); // Online teller
  onlineCounter = signal(0);
  buttonDisabled: boolean = false;
  currentWord: string = '';
  //dhikrType: DhikrType = new DhikrType({});
  userDhikrActivity: UserDhikrActivity = new UserDhikrActivity({});
  dhikrTypes: DhikrType[] = [];
  userDhikrOverview: UserDhikrOverview = new UserDhikrOverview({});
  isLoggedIn = false;

  constructor(
    private dhikrTypeService: DhikrTypeService,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private userDhikrActivitiesService: UserDhikrActivitiesService,
    private userDhikrOverviewService: UserDhikrOverviewsService,
    private networkService: NetworkService,
    private userAccountsService: UserAccountsService
  ) {}

  ngOnInit(): void {
    this.isLoggedIn = this.userAccountsService.isLoggedIn();
    this.dhikrTypeId.set(this.dhikrTypeService.getDhikrTypeId());
    this.dhikrTypeService.triggerSetCurrentWord$.subscribe(() => {
      this.setCurrentWord();
    });
    this.setCurrentWord();
    if (this.isLoggedIn === true) {
      this.syncOnlineCounter();
    }

    this.dhikrTypes = this.route.snapshot.data['dhikrTypes'] || [];
    if (!this.dhikrTypes) {
      console.error('Failed to load dhikr types, retry to fetch from api');
    }

    this.userDhikrOverview = this.route.snapshot.data['userDhikrOverview'];
    if (!this.userDhikrOverview) {
      console.error(
        'Failed to load user dhikr overview, retry to fetch from api'
      );
    }

    // Ophalen van de lokale counters
    const savedCounter = localStorage.getItem('dhikrCounter');
    const savedTotalCounter = localStorage.getItem('dhikrTotalCounter');

    if (savedCounter) {
      this.counter.set(parseInt(savedCounter, 10));
    }
    if (savedTotalCounter) {
      this.totalCounter.set(parseInt(savedTotalCounter, 10));
    }

    // this.dhikrService.getCounters().subscribe({
    //   next: (data) => {
    //     this.onlineCounter = data.onlineCounter;
    //     this.onlineTotalCounter = data.onlineTotalCounter;
    //   },
    //   error: (err) => {
    //     console.error('Error fetching online counters:', err);
    //   },
    // });
  }
  syncOnlineCounter(): void {
    const id = this.dhikrTypeId();
    if (id !== null) {
      this.userDhikrActivitiesService
        .getbyperformedon(new Date(), id)
        .subscribe({
          next: (dhikrActivity: UserDhikrActivity) => {
            this.userDhikrActivity = dhikrActivity;
            this.onlineCounter.set(this.userDhikrActivity.totalPerformed); // Adjust as needed
          },
          error: (err) => {
            console.error('Error fetching online counters:', err);
          },
        });
    }
  }

  setCurrentWord(): void {
    console.log('this method is called');
    const id = this.dhikrTypeId();
    if (id !== null) {
      console.log('id is present');
      let currentDhikrType = this.dhikrTypes.find(
        (dhikrType) => dhikrType.id === id
      );
      const dhikrTypeFullName = currentDhikrType?.fullName ?? 'unknown';
      this.dhikrFullName.set(dhikrTypeFullName);
      console.log('kdjfkdjf:', this.dhikrFullName());
    }
  }

  async onButtonClick(): Promise<void> {
    this.networkService.isOnline.subscribe(async (status) => {
      if (status && this.isLoggedIn) {
        const id = this.dhikrTypeId();
        if (id !== null) {
          console.log('onlinecounter: ' + this.onlineCounter);
          try {
            // Await upsert operation
            const upsertResponse = await this.userDhikrActivitiesService
              .upsert(id)
              .toPromise();
            console.log('Dhikr activity upserted successfully', upsertResponse);
          } catch {
            Error;
          }
          console.error('Error upserting dhikr activity', Error);
          // this.userDhikrActivitiesService
          //   .upsert(parseInt(this.section))
          //   .subscribe({
          //     next: (upsertResponse) => {
          //       console.log(
          //         'Dhikr activity upserted successfully',
          //         upsertResponse
          //       );
          //     },
          //     error: (upsertError) => {
          //       console.error('Failed to upsert dhikr activity', upsertError);
          //     },
          //   });

          console.log('onlinecounter: ' + this.onlineCounter);

          this.syncOnlineCounter();

          console.log('onlinecounter: ' + this.onlineCounter);

          //--------------- de toi j'ai enlevé car c'est moi qui gère le backend coté api database
          // Online teller bijwerken
          // this.dhikrService.updateCounter(1).subscribe({
          //   next: () => {
          //     console.log('Online counter updated');
          //   },
          //   error: (err) => {
          //     console.error('Error updating online counter:', err);
          //   },
          // });
        }
      } else {
        this.counter.update((value) => value + 1);
        this.totalCounter.update((value) => value + 1);

        // Lokale opslag bijwerken
        localStorage.setItem('dhikrCounter', this.counter().toString());
        localStorage.setItem(
          'dhikrTotalCounter',
          this.totalCounter().toString()
        );
      }
    });

    // Specifieke secties
    // const currentDhikrType = this.dhikrTypes.find(
    //   (dhikrType) => dhikrType.id.toString() === this.section
    // );
    // if (currentDhikrType) {
    //   this.currentWord = currentDhikrType.fullName;
    // }

    // Deactiveer de knop elke 99 klikken
    if (this.counter() % 99 === 0) {
      this.buttonDisabled = true;
    }
  }

  onCheckboxToggle(): void {
    this.buttonDisabled = false;
  }

  // Methode om terug te navigeren en de pagina te refreshen
  goBack(event: Event): void {
    event.stopPropagation();
    this.location.replaceState('/dhikr/home');
    window.location.reload();
    // this.router.navigate(['/dhikr/home']).then(() => {
    //   window.location.reload();
    // });
  }
}
