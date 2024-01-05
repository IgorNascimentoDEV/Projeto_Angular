import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Item } from '../../model/item';
import { Router } from '@angular/router';
import { AppMaterialModule } from '../../../shared/app-material/app-material.module';

@Component({
  selector: 'app-lista-itens',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './lista-itens.component.html',
  styleUrl: './lista-itens.component.css'
})
export class ListaItensComponent {

  @Input() itens : Item[] = []
  @Output() add = new EventEmitter(false);
  @Output() delete = new EventEmitter(false);

  displayedColumns = ['codigo', 'nome', 'quantidade', 'acoes'];

  constructor(private route: Router) {}

  public onAdd() {
    this.add.emit(true)
  }

  public onEdit(id: string){
    this.route.navigate(['itens/editar/',id])
  }

  public onDelete(item: Item){
    this.delete.emit(item);
  }
}
