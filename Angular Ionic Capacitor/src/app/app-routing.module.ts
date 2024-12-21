import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './presentation/shared/components/login/login.component';
import { RegisterComponent } from './presentation/shared/components/register/register.component'; // Importeer de RegisterComponent

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent }, // Voeg de route voor de RegisterComponent toe
  {
    path: 'home',
    loadChildren: () =>
      import('./presentation/shared/components/home/home.module').then((m) => m.HomePageModule), // Laad 'home' module
  },
  {
    path: 'leaderboard',
    loadChildren: () =>
      import('./presentation/shared/components/leaderboard/leaderboard.module').then(
        (m) => m.LeaderboardPageModule
      ), // Laad 'leaderboard' module
  },
  {
    path: 'dhikr',
    loadChildren: () =>
      import('./presentation/shared/components/dhikr/dhikr.module').then((m) => m.DhikrModule),
  },
  {
    path: 'salat',
    loadChildren: () =>
      import('./presentation/shared/components/salat/salat.module').then((m) => m.SalatModule),
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }), // Configureer routes met preload strategie
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
