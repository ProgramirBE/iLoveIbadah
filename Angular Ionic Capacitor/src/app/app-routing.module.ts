import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full', // Redirection par défaut vers 'home'
  },
  {
    path: 'home',
    loadChildren: () =>
      import('./home/home.module').then((m) => m.HomePageModule), // Chargement paresseux pour 'home'
  },
  {
    path: 'dhikr',
    loadChildren: () =>
      import('./dhikr/dhikr.module').then((m) => m.DhikrPageModule),// Chargement paresseux pour 'dhikr'
  },
  {
    path: 'leaderboard',
    loadChildren: () =>
      import('./leaderboard/leaderboard.module').then(
        (m) => m.LeaderboardPageModule
      ), // Chargement paresseux pour 'leaderboard'
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }), // Configuration des routes avec préchargement
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
