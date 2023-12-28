import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ItensComponent } from './container/itens/itens.component';
import { ItensFormComponent } from './container/itens-form/itens-form.component';

const routes: Routes = [
  {path: '', component: ItensComponent},
  {path: 'novo', component: ItensFormComponent},
  {path: 'editar/:id', component: ItensFormComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItensRoutingModule { }
