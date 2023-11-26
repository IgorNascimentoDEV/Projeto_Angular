import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Solicitacao } from '../model/solicitacao';
import { AppMaterialModule } from '../../shared/app-material/app-material.module';

@Component({
  selector: 'app-solicitacoes',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './solicitacoes.component.html',
  styleUrl: './solicitacoes.component.css'
})
export class SolicitacoesComponent {

  solicitacoes: Solicitacao[] = [
    {
      solicitante: 'Igor Vinicius',
      setor: 'Tecnologia',
      quantidade: 1,
      centroCusto: 10402,
      dataSolicitacao: '26/11/2023',
      codigoItem: [100230],
    }
  ]
  displayedColumns = ['solicitante', 'setor', 'dataSolicitacao'];
}
