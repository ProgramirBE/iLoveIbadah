import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { RouterModule, Routes } from '@angular/router';

import { DhikrComponent } from './dhikr.component';

const routes: Routes = [
  {
    path: '',
    component: DhikrComponent, // Assurez-vous que cette route correspond à la configuration
  },
];

@NgModule({
  declarations: [DhikrComponent], // Déclarez le composant ici
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes),
  ],
})
export class DhikrPageModule {}
