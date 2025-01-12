import { inject } from '@angular/core';
import { UserSalahActivitiesService } from 'src/app/infrastructure/services/proxies/internal/user-salah-activities.service';
import { UserSalahActivity } from 'src/app/domain/models/user-salah-activity';
import {
  ResolveFn,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/user-accounts.service';
import { of } from 'rxjs';

export const UserSalahActivitiesResolver: ResolveFn<UserSalahActivity[]> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const userSalahActivitiesService = inject(UserSalahActivitiesService);
  const userAccountsService = inject(UserAccountsService);
  if (userAccountsService.isLoggedIn() === false) {
    console.log('salahactivity resolver says isnotloggedin');
    return of([]);
  } else {
    const date = new Date();
    const formattedDate = date.toISOString().split('T')[0];
    console.log('formattedDate of resolver : ', formattedDate);
    return userSalahActivitiesService.getTrackedOn(formattedDate);
  }
};
