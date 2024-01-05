import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Solicitacao } from '../../model/solicitacao';
import { AppMaterialModule } from '../../../shared/app-material/app-material.module';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-solicitacoes',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './lista-solicitacoes.component.html',
  styleUrl: './lista-solicitacoes.component.css'
})
export class ListaSolicitacoesComponent {
  @Input() solicitacoes: Solicitacao[] = [];
  @Output() add = new EventEmitter(false);
  @Output() delete = new EventEmitter(false);

  displayedColumns = ['solicitante', 'setor', 'dataSolicitacao', 'status', 'acoes'];

  constructor(private route: Router) {}

  onAdd(){
    this.add.emit(true)
  }
  onEdit(id: string){
    this.route.navigate(['solicitacoes/editar-solicitacao/', id])
  }

  onDelete(solicitacao: Solicitacao){
    this.delete.emit(solicitacao);
  }
}
