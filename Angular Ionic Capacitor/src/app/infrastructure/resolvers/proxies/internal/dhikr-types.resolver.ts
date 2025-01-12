import { inject } from '@angular/core';
import { DhikrTypesService } from 'src/app/infrastructure/services/proxies/internal/dhikr-types.service';
import { DhikrType} from 'src/app/domain/models/dhikr-type';
import { ResolveFn, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { forkJoin, map } from 'rxjs';
import { UserAccountsService } from 'src/app/infrastructure/services/proxies/internal/user-accounts.service';

// @Injectable({
//   providedIn: 'root',
// })
export const DhikrTypesResolver: ResolveFn<DhikrType[]> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot,
  ) => {
    const dhikrTypesService = inject(DhikrTypesService);
    const userAccountsService = inject(UserAccountsService);
    if (userAccountsService.isLoggedIn() === false) {
      console.log('resolver says isnotloggedin');
      return dhikrTypesService.getAll();
    }
    else {
      console.log('resolver says isloggedin');
      return forkJoin([
        dhikrTypesService.getAll(),
        dhikrTypesService.getAllByUserAccount(),
      ]).pipe(
        map(([allDhikrTypes, userDhikrTypes]) => {
          return [...allDhikrTypes, ...userDhikrTypes];
        })
      );
    }
    // return inject(DhikrTypesService).getAll();
    // return inject(DhikrTypesService).getAllByUserAccount();
};
  // private dhikrTypes: DhikrType[] = [];

  // constructor(private dhikrTypesService: DhikrTypesService) {}

  // loadDhikrTypes(): Promise<void> {
  //   return new Promise((resolve, reject) => {
  //     this.dhikrTypesService.getAll().subscribe(
  //       (dhikrTypes: DhikrType[]) => {
  //         this.dhikrTypes = dhikrTypes;
  //         resolve();
  //       },
  //       (error) => {
  //         console.error('Error fetching DhikrTypes:', error);
  //         reject(error);
  //       }
  //     );
  //   });
  // }

  // getDhikrTypes(): DhikrType[] {
  //   return this.dhikrTypes;
  // }
