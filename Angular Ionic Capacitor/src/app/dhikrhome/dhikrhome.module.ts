import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DhikrhomePageRoutingModule } from './dhikrhome-routing.module';

import { DhikrhomePage } from './dhikrhome.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DhikrhomePageRoutingModule
  ],
  declarations: [DhikrhomePage]
})
export class DhikrhomePageModule {}
