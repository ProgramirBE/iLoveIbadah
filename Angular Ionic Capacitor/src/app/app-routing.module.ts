import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './presentation/shared/components/login/login.component';
import { RegisterComponent } from './presentation/shared/components/register/register.component';

const routes: Routes = [
  // Standaard route die naar de login-pagina omleidt
  { path: '', redirectTo: 'login', pathMatch: 'full' },

  // Route voor login-component
  { path: 'login', component: LoginComponent },

  // Route voor register-component
  { path: 'register', component: RegisterComponent },

  // Lazy-loaded route voor de 'home'-module
  {
    path: 'home',
    loadChildren: () =>
      import('./presentation/shared/components/home/home.module').then(
        (m) => m.HomePageModule
      ),
  },

  // Lazy-loaded route voor de 'leaderboard'-module
  {
    path: 'leaderboard',
    loadChildren: () =>
      import('./presentation/shared/components/leaderboard/leaderboard.module').then(
        (m) => m.LeaderboardPageModule
      ),
  },

  // Lazy-loaded route voor de 'dhikr'-module
  {
    path: 'dhikr',
    loadChildren: () =>
      import('./presentation/shared/components/dhikr/dhikr.module').then(
        (m) => m.DhikrModule
      ),
  },

  // Lazy-loaded route voor de 'salat'-module
  {
    path: 'salat',
    loadChildren: () =>
      import('./presentation/shared/components/salat/salat.module').then(
        (m) => m.SalatModule
      ),
  },

  // Lazy-loaded route voor de 'profile'-module
  {
    path: 'profile',
    loadChildren: () =>
      import('./presentation/shared/components/profile/profile.module').then(
        (m) => m.ProfileModule
      ),
  },
  

  // Fallback voor niet-bestaande routes
  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }), // Gebruik PreloadAllModules voor betere prestaties
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
