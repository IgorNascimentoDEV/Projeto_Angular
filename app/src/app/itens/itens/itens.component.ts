import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';


import { Item } from '../model/item';
import { AppMaterialModule } from '../../shared/app-material/app-material.module';


@Component({
  selector: 'app-itens',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './itens.component.html',
  styleUrl: './itens.component.css'
})
export class ItensComponent {

  itens: Item[] = [
    {
      _id:"1",
      codigo: 100230,
      nome: 'Fita',
      preco: 10.50,
      quantidade: 10,
      solicitacoes: []
    }
  ];

  displayedColumns = ['codigo', 'nome', 'quantidade'];
}
