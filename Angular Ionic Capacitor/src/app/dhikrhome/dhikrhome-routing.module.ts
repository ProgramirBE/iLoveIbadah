import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DhikrhomePage } from './dhikrhome.page';

const routes: Routes = [
  {
    path: '',
    component: DhikrhomePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DhikrhomePageRoutingModule {}
