import { Routes } from '@angular/router';

export const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'itens'},
  {path: 'se', redirectTo: 'solicitacoes'},
  {
    path: 'itens',
    loadChildren: () => import('./itens/itens.module').then(m => m.ItensModule)
  },
  {
    path: 'solicitacoes',
    loadChildren: () => import('./solicitacoes/solicitacoes.module').then(m => m.SolicitacoesModule)
  }
];
