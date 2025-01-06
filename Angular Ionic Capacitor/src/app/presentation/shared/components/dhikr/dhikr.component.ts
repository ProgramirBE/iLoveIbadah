import { Component, OnInit, Signal, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDhikrActivity } from 'src/app/domain/models/user-dhikr-activity';
import { UserDhikrActivitiesService } from 'src/app/infrastructure/services/proxies/internal/user-dhikr-activities.service';
import { NetworkService } from 'src/app/infrastructure/services/proxies/external/network.service';
import { DhikrType } from 'src/app/domain/models/dhikr-type';
import { UserDhikrOverviewsService } from 'src/app/infrastructure/services/proxies/internal/user-dhikr-overviews.service';
import { UserDhikrOverview } from 'src/app/domain/models/user-dhikr-overview';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent implements OnInit {
  section: string = ''; // Huidige sectie
  dhikrTypeId: number = 0; // Huidige dhikr type id
  counter: number = 0; // Lokale teller
  totalCounter: number = 0; // Lokale totale teller
  onlineCounter = signal(0); // Online teller
  onlineTotalCounter = signal(0); // Online totale teller
  buttonDisabled: boolean = false;
  currentWord: string = '';
  //dhikrType: DhikrType = new DhikrType({});
  userDhikrActivity: UserDhikrActivity = new UserDhikrActivity({});
  dhikrTypes: DhikrType[] = [];
  currentDhikrTypeId: number = 0;
  userDhikrOverview: UserDhikrOverview = new UserDhikrOverview({});

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userDhikrActivitiesService: UserDhikrActivitiesService,
    private userDhikrOverviewService: UserDhikrOverviewsService,
    private networkService: NetworkService
  ) {}

  ngOnInit(): void {
    // Ophalen van de sectie uit de route
    this.route.data.subscribe((data) => {
      this.section = data['section'] || 'home';
      // this.dhikrTypes = data['dhikrTypes'] || [];
      // console.log('Dhikr types:', this.dhikrTypes);
      this.setCurrentWord();
    });

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
      this.counter = parseInt(savedCounter, 10);
    }

    if (savedTotalCounter) {
      this.totalCounter = parseInt(savedTotalCounter, 10);
    }
    this.syncOnlineTotalCounter();
    this.syncOnlineCounter();

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
    this.userDhikrActivitiesService
      .getbyperformedon(new Date(), parseInt(this.section))
      .subscribe({
        next: (dhikrActivity: UserDhikrActivity) => {
          this.userDhikrActivity = dhikrActivity;
          //const activity = UserDhikrActivity.fromApiResponse(response);
          this.onlineCounter.set(this.userDhikrActivity.totalPerformed); // Adjust as needed
        },
        error: (err) => {
          console.error('Error fetching online counters:', err);
        },
      });
  }

  syncOnlineTotalCounter(): void {
    this.userDhikrOverviewService.getByUserAccount().subscribe({
      next: (dhikrOverview: UserDhikrOverview) => {
        this.userDhikrOverview = dhikrOverview;
        //const activity = UserDhikrActivity.fromApiResponse(response);
        this.onlineTotalCounter.set(this.userDhikrOverview.totalPerformed); // Adjust as needed
      },
      error: (err) => {
        console.error('Error fetching online counters:', err);
      },
    });
  }

  setCurrentWord(): void {
    const currentDhikrType = this.dhikrTypes.find(
      (dhikrType) => dhikrType.id.toString() === this.section
    );
    if (currentDhikrType) {
      this.currentWord = currentDhikrType.fullName;
    }
  }

  async onButtonClick(): Promise<void> {
    this.networkService.isOnline.subscribe(async (status) => {
      if (status) {
        console.log('onlinecounter: ' + this.onlineCounter);
        try {
          // Await upsert operation
          const upsertResponse = await this.userDhikrActivitiesService
            .upsert(parseInt(this.section))
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
      } else {
        this.counter++;
        this.totalCounter++;

        // Lokale opslag bijwerken
        localStorage.setItem('dhikrCounter', this.counter.toString());
        localStorage.setItem('dhikrTotalCounter', this.totalCounter.toString());
      }
    });

    this.setCurrentWord();

    // Specifieke secties
    // const currentDhikrType = this.dhikrTypes.find(
    //   (dhikrType) => dhikrType.id.toString() === this.section
    // );
    // if (currentDhikrType) {
    //   this.currentWord = currentDhikrType.fullName;
    // }

    // Deactiveer de knop elke 99 klikken
    if (this.counter % 99 === 0) {
      this.buttonDisabled = true;
    }
  }

  onCheckboxToggle(): void {
    this.buttonDisabled = false;
  }

  // Methode om terug te navigeren en de pagina te refreshen
  goBack(): void {
    this.syncOnlineTotalCounter();
    console.log('onlineTotalCounter: ' + this.onlineTotalCounter);
    this.router.navigate(['/dhikr/home'])
      .then(() => {
      this.syncOnlineTotalCounter();
    });
  }
}
