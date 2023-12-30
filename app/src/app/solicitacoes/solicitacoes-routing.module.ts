import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SolicitacoesComponent } from './container/solicitacoes/solicitacoes.component';
import { SolicitacaoFormComponent } from './container/solicitacoes-form/solicitacoes-form.component';

const routes: Routes = [
  { path: '', component: SolicitacoesComponent },
  {path: 'nova-solicitacao', component: SolicitacaoFormComponent},
  {path: 'editar-solicitacao/:id', component: SolicitacoesComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SolicitacoesRoutingModule { }
