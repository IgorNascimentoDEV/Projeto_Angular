import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '../../../shared/app-material/app-material.module';
import { ListaSolicitacoesComponent } from "../../components/lista-solicitacoes/lista-solicitacoes.component";
import { Router } from '@angular/router';

@Component({
    selector: 'app-solicitacoes',
    standalone: true,
    templateUrl: './solicitacoes.component.html',
    styleUrl: './solicitacoes.component.css',
    imports: [CommonModule, AppMaterialModule, ListaSolicitacoesComponent]
})
export class SolicitacoesComponent implements OnInit{

  constructor( public router: Router,){}

  public onAdd() {
    this.router.navigate(['/solicitacoes/nova-solicitacao'])
  }

  ngOnInit(): void {
  }
}
