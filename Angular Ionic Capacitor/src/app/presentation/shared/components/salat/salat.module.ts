import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { HttpClientModule } from '@angular/common/http';
import { SalatRoutingModule } from './salat-routing.module';
import { SalatComponent } from './salat.component';
import { UserSalahActivitiesService } from 'src/app/infrastructure/services/proxies/internal/user-salah-activities.service';
import { SalahTypesService } from 'src/app/infrastructure/services/proxies/internal/salah-types.service';
import { NetworkService } from 'src/app/infrastructure/services/proxies/external/network.service';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/user-accounts.service';
import { IslamicFinderService } from 'src/app/infrastructure/services/proxies/external/islamic-finder.service';
//import { Geolocation} from '@ionic-native/geolocation/ngx';
//import { Geolocation} from '@capacitor/geolocation';

@NgModule({
  declarations: [SalatComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    HttpClientModule,
    SalatRoutingModule,
  ],
  providers: [
    UserSalahActivitiesService,
    SalahTypesService,
    NetworkService,
    IslamicFinderService,
    UserAccountsService,
  ]
})
export class SalatModule {}
