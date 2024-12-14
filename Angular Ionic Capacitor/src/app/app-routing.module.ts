import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component'; // Importeer de RegisterComponent

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },  
  { path: 'register', component: RegisterComponent }, // Voeg de route voor de RegisterComponent toe
  {
    path: 'home',
    loadChildren: () =>
      import('./home/home.module').then((m) => m.HomePageModule), // Laad 'home' module
  },
  {
    path: 'leaderboard',
    loadChildren: () =>
      import('./leaderboard/leaderboard.module').then(
        (m) => m.LeaderboardPageModule
      ), // Laad 'leaderboard' module
  },
  {
    path: 'dhikr',
    loadChildren: () =>
      import('./dhikr/dhikr.module').then((m) => m.DhikrModule),
  },  
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }), // Configureer routes met preload strategie
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
