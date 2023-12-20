import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { AppMaterialModule } from '../../shared/app-material/app-material.module';
import { Item } from '../model/item';
import { ItensService } from '../services/itens.service';
import { Observable, catchError, of } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../shared/components/error-dialog/error-dialog.component';



@Component({
  selector: 'app-itens',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './itens.component.html',
  styleUrl: './itens.component.css'
})
export class ItensComponent implements OnInit{

  itens$: Observable<Item[]>;

  ;

  //itensServise: ItensService;

  constructor(private itensServise: ItensService, public dialog: MatDialog) {
    //this.itensServise = new ItensService(httpClient);
    this.itens$ = this.itensServise.list()
    .pipe(
      catchError(error => {
        this.OnError('Error ao Carregar o itens.')
        return of([])
      })
    );
  }

  ngOnInit(): void {

  }

  OnError(errorMsg: string) {
    this.dialog.open(ErrorDialogComponent, {
      data: errorMsg
    });
  }

  displayedColumns = ['codigo', 'nome', 'quantidade'];
}
