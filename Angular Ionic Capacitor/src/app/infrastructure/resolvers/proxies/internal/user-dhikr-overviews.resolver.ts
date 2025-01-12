import { inject } from '@angular/core';
import {
  ResolveFn,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { UserDhikrOverviewsService } from 'src/app/infrastructure/services/proxies/internal/user-dhikr-overviews.service';
import { UserDhikrOverview } from 'src/app/domain/models/user-dhikr-overview';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/user-accounts.service';

export const UserDhikrOverviewsResolver: ResolveFn<UserDhikrOverview> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const userDhikrOverviewsService = inject(UserDhikrOverviewsService);
  const userAccountsService = inject(UserAccountsService);

  if (userAccountsService.isLoggedIn() === true) {
    return userDhikrOverviewsService.getByUserAccount();
  }
  return new UserDhikrOverview({});
};
