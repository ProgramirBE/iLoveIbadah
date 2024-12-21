import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { SalatRoutingModule } from './salat-routing.module';
import { SalatComponent } from './salat.component';

@NgModule({
  declarations: [SalatComponent],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SalatRoutingModule,
  ],
})
export class SalatModule {}
