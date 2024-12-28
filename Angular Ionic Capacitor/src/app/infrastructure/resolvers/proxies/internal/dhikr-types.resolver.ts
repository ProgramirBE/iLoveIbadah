import { inject } from '@angular/core';
import { DhikrTypesService } from 'src/app/infrastructure/services/proxies/internal/dhikr-types.service';
import { DhikrType} from 'src/app/domain/models/dhikr-type';
import { ResolveFn, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

// @Injectable({
//   providedIn: 'root',
// })
export const DhikrTypesResolver: ResolveFn<DhikrType[]> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
  ) => {
    return inject(DhikrTypesService).getAll();
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
