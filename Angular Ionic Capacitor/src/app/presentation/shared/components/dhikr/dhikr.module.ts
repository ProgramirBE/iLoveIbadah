import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { HttpClientModule } from '@angular/common/http'; 

import { DhikrRoutingModule } from './dhikr-routing.module';
import { DhikrComponent } from './dhikr.component';

@NgModule({
  declarations: [DhikrComponent],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HttpClientModule, // Voeg deze regel toe
    DhikrRoutingModule,
  ],
})
export class DhikrModule {}
