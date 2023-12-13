import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ItensRoutingModule } from './itens-routing.module';
import { HttpClientModule } from '@angular/common/http';
import {ItensService} from './services/itens.service';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ItensRoutingModule,
    HttpClientModule
  ],
  providers: [ItensService]
})
export class ItensModule { }
