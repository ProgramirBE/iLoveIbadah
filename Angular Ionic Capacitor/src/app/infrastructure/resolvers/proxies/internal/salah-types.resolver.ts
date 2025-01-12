import { inject } from '@angular/core';
import { SalahTypesService } from 'src/app/infrastructure/services/proxies/internal/salah-types.service';
import { SalahType } from 'src/app/domain/models/salah-type';
import {
  ResolveFn,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';

// @Injectable({
//   providedIn: 'root',
// })
export const SalahTypesResolver: ResolveFn<SalahType[]> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const salahTypesService = inject(SalahTypesService);
  return salahTypesService.getAll();
};