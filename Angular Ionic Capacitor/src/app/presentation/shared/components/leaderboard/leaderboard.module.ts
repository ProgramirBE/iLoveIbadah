import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { RouterModule, Routes } from '@angular/router';

import { LeaderboardComponent } from './leaderboard.component';

const routes: Routes = [
  {
    path: '',
    component: LeaderboardComponent, // Le composant principal de cette page
  },
];

@NgModule({
  declarations: [LeaderboardComponent],
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes),
  ],
})
export class LeaderboardPageModule {}
