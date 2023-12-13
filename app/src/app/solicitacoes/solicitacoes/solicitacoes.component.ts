import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Solicitacao } from '../model/solicitacao';
import { AppMaterialModule } from '../../shared/app-material/app-material.module';
import { SolicitacoesService } from '../services/solicitacoes.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-solicitacoes',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './solicitacoes.component.html',
  styleUrl: './solicitacoes.component.css'
})
export class SolicitacoesComponent implements OnInit{

  solicitacoes: Observable<Solicitacao[]>;


  displayedColumns = ['solicitante', 'setor', 'dataSolicitacao', 'status'];

  constructor(private solicitacoesService: SolicitacoesService) {
    this.solicitacoes = this.solicitacoesService.list();
  }

  ngOnInit(): void {
  }
}
