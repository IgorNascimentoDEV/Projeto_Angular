import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SolicitacoesRoutingModule } from './solicitacoes-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { SolicitacoesService } from './services/solicitacoes.service';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SolicitacoesRoutingModule,
    HttpClientModule
  ],
  providers: [SolicitacoesService]
})
export class SolicitacoesModule { }
