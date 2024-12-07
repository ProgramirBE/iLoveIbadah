import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component'; // Importeer de RegisterComponent
import { Dhikr1Component } from './dhikr1/dhikr1.component';
import { Dhikr2Component } from './dhikr2/dhikr2.component';
import { Dhikr3Component } from './dhikr3/dhikr3.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },  
  { path: 'register', component: RegisterComponent }, // Voeg de route voor de RegisterComponent toe
  { path: 'dhikr1', component: Dhikr1Component }, // Route voor Dhikr1
  { path: 'dhikr2', component: Dhikr2Component }, // Route voor Dhikr2
  { path: 'dhikr3', component: Dhikr3Component }, // Route voor Dhikr3
  {
    path: 'home',
    loadChildren: () =>
      import('./home/home.module').then((m) => m.HomePageModule), // Laad 'home' module
  },
  {
    path: 'dhikr',
    loadChildren: () =>
      import('./dhikr/dhikr.module').then((m) => m.DhikrPageModule), // Laad 'dhikr' module
  },
  {
    path: 'leaderboard',
    loadChildren: () =>
      import('./leaderboard/leaderboard.module').then(
        (m) => m.LeaderboardPageModule
      ), // Laad 'leaderboard' module
  },
  {
    path: 'dhikrhome',
    loadChildren: () =>
      import('./dhikrhome/dhikrhome.module').then((m) => m.DhikrhomePageModule),
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }), // Configureer routes met preload strategie
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
