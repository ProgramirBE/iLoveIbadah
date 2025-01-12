import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';

import { LoginComponent } from './presentation/shared/components/login/login.component';
import { RegisterComponent } from './presentation/shared/components/register/register.component';
import { DhikrTypesResolver } from './infrastructure/resolvers/proxies/internal/dhikr-types.resolver';
import { UserDhikrOverviewsResolver } from './infrastructure/resolvers/proxies/internal/user-dhikr-overviews.resolver';
import { UserSalahActivitiesResolver } from './infrastructure/resolvers/proxies/internal/user-salah-activities.resolver';
import { SalahTypesResolver } from './infrastructure/resolvers/proxies/internal/salah-types.resolver';

const routes: Routes = [
  // Standaard route die naar de login-pagina omleidt
  { path: '', redirectTo: 'home', pathMatch: 'full' },

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
      import(
        './presentation/shared/components/leaderboard/leaderboard.module'
      ).then((m) => m.LeaderboardPageModule),
  },

  // Lazy-loaded route voor de 'dhikr'-module
  {
    path: 'dhikr',
    loadChildren: () =>
      import('./presentation/shared/components/dhikr/dhikr.module').then(
        (m) => m.DhikrModule
      ),
    resolve: {
      userDhikrOverview: UserDhikrOverviewsResolver,
      dhikrTypes: DhikrTypesResolver,
    },
  },

  // Lazy-loaded route voor de 'salat'-module
  {
    path: 'salat',
    loadChildren: () =>
      import('./presentation/shared/components/salat/salat.module').then(
        (m) => m.SalatModule
      ),
    resolve: {
      userSalahActivities: UserSalahActivitiesResolver,
      salahTypes: SalahTypesResolver,
    },
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
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }), // Gebruik PreloadAllModules voor betere prestaties
  ],
  exports: [RouterModule],
  providers: [{ provide: LocationStrategy, useClass: HashLocationStrategy }],
})
export class AppRoutingModule {}
