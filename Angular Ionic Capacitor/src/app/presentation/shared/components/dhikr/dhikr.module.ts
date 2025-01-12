import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { HttpClientModule } from '@angular/common/http';

import { DhikrRoutingModule } from './dhikr-routing.module';
import { DhikrComponent } from './dhikr.component';
import { DhikrHomeComponent } from './dhikrhome/dhikr-home.component';
import { NetworkService } from 'src/app/infrastructure/services/proxies/external/network.service';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/user-accounts.service';

@NgModule({
  declarations: [DhikrComponent, DhikrHomeComponent],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ReactiveFormsModule,
    HttpClientModule,
    DhikrRoutingModule,
  ],
  providers: [NetworkService, UserAccountsService],
})
export class DhikrModule {}
