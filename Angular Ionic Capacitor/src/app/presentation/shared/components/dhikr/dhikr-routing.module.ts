import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DhikrComponent } from './dhikr.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' }, // Standaard naar 'home' binnen Dhikr
  { path: 'home', component: DhikrComponent, data: { section: 'home' } },
  { path: '1', component: DhikrComponent, data: { section: '1' } },
  { path: '2', component: DhikrComponent, data: { section: '2' } },
  { path: '3', component: DhikrComponent, data: { section: '3' } },
  { path: 'dhikr', component: DhikrComponent, data: { section: 'dhikr' } },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DhikrRoutingModule {}
