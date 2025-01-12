import { Component, OnInit, Signal, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location, CommonModule } from '@angular/common';
import { UserDhikrActivity } from 'src/app/domain/models/user-dhikr-activity';
import { UserDhikrActivitiesService } from 'src/app/infrastructure/services/proxies/internal/user-dhikr-activities.service';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/user-accounts.service';
import { NetworkService } from 'src/app/infrastructure/services/proxies/external/network.service';
import { DhikrType } from 'src/app/domain/models/dhikr-type';
import { UserDhikrOverviewsService } from 'src/app/infrastructure/services/proxies/internal/user-dhikr-overviews.service';
import { UserDhikrOverview } from 'src/app/domain/models/user-dhikr-overview';
import { DhikrTypeService } from 'src/app/presentation/shared/components/dhikr/dhikr-type.service';
import { DhikrTypesService } from 'src/app/infrastructure/services/proxies/internal/dhikr-types.service';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr-home.component.html',
  styleUrls: ['./dhikr-home.component.scss'],
})
export class DhikrHomeComponent implements OnInit {
  section: string = ''; // Huidige sectie
  totalCounter = signal(0); // Lokale totale teller
  onlineTotalCounter = signal(0); // Online totale teller
  dhikrTypes: DhikrType[] = [];
  userDhikrOverview: UserDhikrOverview = new UserDhikrOverview({});
  createDhikrTypeForm: FormGroup;
  isLoggedIn = false;

  constructor(
    private formBuilder: FormBuilder,
    private dhikrTypeService: DhikrTypeService,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private userDhikrActivitiesService: UserDhikrActivitiesService,
    private userDhikrOverviewService: UserDhikrOverviewsService,
    private dhikrTypesService: DhikrTypesService,
    private networkService: NetworkService,
    private userAccountsService: UserAccountsService
  ) {
    this.createDhikrTypeForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      arabicFullName: [''],
    });
  }

  ngOnInit(): void {
    this.isLoggedIn = this.userAccountsService.isLoggedIn();

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

    const savedTotalCounter = localStorage.getItem('dhikrTotalCounter');

    if (savedTotalCounter) {
      this.totalCounter.set(parseInt(savedTotalCounter, 10));
    }
    if (this.isLoggedIn === true) {
      this.syncOnlineTotalCounter();
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

  onCreateDhikrType() {
    if (this.createDhikrTypeForm.valid) {
      const { fullName, arabicFullName } = this.createDhikrTypeForm.value;
      this.dhikrTypesService.create(fullName, arabicFullName).subscribe({
        next: (response) => {
          console.log('Dhikr type created successfully');
        },
        error: (error) => {
          console.error('Failed to create dhikr type', error);
        },
        complete: () => {
          console.log('Dhikr type creation process completed');
          window.location.reload();
        },
      });
    }
  }

  navigateToDhikr(dhikrTypeId: number): void {
    this.dhikrTypeService.setDhikrTypeId(dhikrTypeId);
    //this.router.navigate(['/dhikr/counter']);
    this.router.navigate(['/dhikr/counter']).then(() => {
      this.dhikrTypeService.triggerSetCurrentWordMethod();
    });
  }
}
