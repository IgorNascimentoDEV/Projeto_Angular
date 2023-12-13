import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { AppMaterialModule } from '../../shared/app-material/app-material.module';
import { Item } from '../model/item';
import { ItensService } from '../services/itens.service';
import { Observable } from 'rxjs';



@Component({
  selector: 'app-itens',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './itens.component.html',
  styleUrl: './itens.component.css'
})
export class ItensComponent implements OnInit{

  itens: Observable<Item[]>;

  ;

  //itensServise: ItensService;

  constructor(private itensServise: ItensService) {
    //this.itensServise = new ItensService(httpClient);
    this.itens = this.itensServise.list();
  }

  ngOnInit(): void {

  }

  displayedColumns = ['codigo', 'nome', 'quantidade'];
}
