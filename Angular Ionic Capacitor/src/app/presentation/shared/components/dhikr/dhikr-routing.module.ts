import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DhikrComponent } from './dhikr.component';
import { DhikrHomeComponent } from './dhikrhome/dhikr-home.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' }, // Standaard naar 'home' binnen Dhikr
  { path: 'home', component: DhikrHomeComponent },
  { path: 'counter', component: DhikrComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DhikrRoutingModule {}

// import { NgModule } from '@angular/core';
// import { RouterModule, Routes, Router, Route } from '@angular/router';
// import { DhikrComponent } from './dhikr.component';
// import { DhikrTypesService } from 'src/app/infrastructure/services/proxies/internal/dhikr-types.service';
// import { DhikrType } from 'src/app/domain/models/dhikr-type';

// const initialRoutes: Routes = [
//   { path: '', redirectTo: 'home', pathMatch: 'full' }, // Default to 'home' within Dhikr
//   { path: 'home', component: DhikrComponent, data: { section: 'home' } },
// ];

// @NgModule({
//   imports: [RouterModule.forChild(initialRoutes)],
//   exports: [RouterModule],
// })
// export class DhikrRoutingModule {
//   constructor(
//     private dhikrTypesService: DhikrTypesService,
//     private router: Router
//   ) {
//     this.addDynamicRoutes();
//   }

//   private addDynamicRoutes(): void {
//     this.dhikrTypesService.getAll().subscribe((dhikrTypes: DhikrType[]) => {
//       const dynamicRoutes: Route[] = dhikrTypes.map((dhikrType) => ({
//         path: `${dhikrType.id}`,
//         component: DhikrComponent,
//         data: { section: `${dhikrType.id}` },
//       }));

//       // Combine initial routes and dynamic routes
//       const allRoutes: Route[] = [...this.router.config, ...dynamicRoutes];

//       // Reset the router configuration with the updated routes
//       this.router.resetConfig(allRoutes);

//       console.log('Dynamic routes added:', dynamicRoutes);
//     });
//   }
// }

// import { NgModule } from '@angular/core';
// import { ActivatedRoute, RouterModule, Routes, Router } from '@angular/router';
// import { DhikrComponent } from './dhikr.component';
// import { DhikrTypesService } from 'src/app/infrastructure/services/proxies/internal/dhikr-types.service';
// import { DhikrType } from 'src/app/domain/models/dhikr-type';
// import { OnInit } from '@angular/core';

// const initialRoutes: Routes = [
//   { path: '', redirectTo: 'home', pathMatch: 'full' }, // Default to 'home' within Dhikr
//   { path: 'home', component: DhikrComponent, data: { section: 'home' } },
// ];

// @NgModule({
//   imports: [RouterModule.forChild(initialRoutes)],
//   exports: [RouterModule],
// })
// export class DhikrRoutingModule {
//   constructor(
//     private dhikrTypesService: DhikrTypesService,
//     private route: ActivatedRoute,
//     private router: Router
//   ) {
//     this.dhikrTypesService.getAll().subscribe((dhikrTypes: DhikrType[]) => {

//       //const dynamicRoutes: Routes = [];
//       dhikrTypes.forEach((dhikrType) => {
//         initialRoutes.push({
//           path: `${dhikrType.id}`,
//           component: DhikrComponent,
//           data: { section: `${dhikrType.id}` },
//         })
//         console.log(initialRoutes);
//       });

//       // Add the dynamic routes to the initial routes
//       //const allRoutes = [...initialRoutes, ...dynamicRoutes];
//       //initialRoutes = allRoutes;
//     })}
//   }
// import { NgModule } from '@angular/core';
// import { RouterModule, Routes } from '@angular/router';
// import { DhikrComponent } from './dhikr.component';
// import { DhikrTypesService } from 'src/app/infrastructure/services/proxies/internal/dhikr-types.service';
// import { DhikrType } from 'src/app/domain/models/dhikr-type';

// const routes: Routes = [
//   { path: '', redirectTo: 'home', pathMatch: 'full' }, // Default to 'home' within Dhikr
//   { path: 'home', component: DhikrComponent, data: { section: 'home' } },
// ];

// @NgModule({
//   imports: [RouterModule.forChild(routes)],
//   exports: [RouterModule],
// })
// export class DhikrRoutingModule {
//   private dhikrTypes: DhikrType[] = [];

//   constructor(private dhikrTypesService: DhikrTypesService) {
//     this.dhikrTypesService.getAll().subscribe((dhikrTypes: DhikrType[]) => {
//       dhikrTypes.forEach((dhikrType) => {
//         routes.push({
//           path: `${dhikrType.id}`,
//           component: DhikrComponent,
//           data: { section: `${dhikrType.id}` },
//         });
//       });
//       // Reconfigure the router with the new routes
//       RouterModule.forChild(routes);
//     });
//   }

// }
