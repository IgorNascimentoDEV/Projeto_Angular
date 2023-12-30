import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Solicitacao } from '../../model/solicitacao';
import { Observable } from 'rxjs';
import { SolicitacoesService } from '../../services/solicitacoes.service';
import { AppMaterialModule } from '../../../shared/app-material/app-material.module';

@Component({
  selector: 'app-lista-solicitacoes',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './lista-solicitacoes.component.html',
  styleUrl: './lista-solicitacoes.component.css'
})
export class ListaSolicitacoesComponent {

  solicitacoes: Observable<Solicitacao[]>;
  @Output() add = new EventEmitter(false);


  displayedColumns = ['solicitante', 'setor', 'dataSolicitacao', 'status', 'acoes'];

  constructor(private solicitacoesService: SolicitacoesService) {
    this.solicitacoes = this.solicitacoesService.list();
  }

  onAdd(){
    this.add.emit(true)
  }
  onEdit(id: string){

  }

  onDelete(solicitacao: Solicitacao){

  }
}
