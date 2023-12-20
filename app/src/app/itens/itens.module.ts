import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ItensRoutingModule } from './itens-routing.module';
import { HttpClientModule } from '@angular/common/http';
import {ItensService} from './services/itens.service';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ItensRoutingModule,
    HttpClientModule,
    SharedModule
  ],
  providers: [ItensService]
})
export class ItensModule { }
