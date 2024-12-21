import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SalatComponent } from './salat.component';

const routes: Routes = [
  {
    path: '',
    component: SalatComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SalatRoutingModule {}

