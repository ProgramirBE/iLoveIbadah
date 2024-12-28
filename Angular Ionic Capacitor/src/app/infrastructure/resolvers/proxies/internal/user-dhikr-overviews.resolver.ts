import { inject } from '@angular/core';
import {
  ResolveFn,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { UserDhikrOverviewsService } from 'src/app/infrastructure/services/proxies/internal/user-dhikr-overviews.service';
import { UserDhikrOverview } from 'src/app/domain/models/user-dhikr-overview';

export const UserDhikrOverviewsResolver: ResolveFn<UserDhikrOverview> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  return inject(UserDhikrOverviewsService).getByUserAccount();
};
