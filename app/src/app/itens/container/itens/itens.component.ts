import { CommonModule } from '@angular/common';
import { Component, OnInit, Output } from '@angular/core';

import { AppMaterialModule } from '../../../shared/app-material/app-material.module';
import { Item } from '../../model/item';
import { ItensService } from '../../services/itens.service';
import { Observable, catchError, of } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';

import { Router } from '@angular/router';
import { EventEmitter } from 'stream';
import { ListaItensComponent } from '../../components/lista-itens/lista-itens.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-itens',
  standalone: true,
  templateUrl: './itens.component.html',
  styleUrl: './itens.component.css',
  imports: [CommonModule, AppMaterialModule, ListaItensComponent],
})
export class ItensComponent implements OnInit {
  itens$: Observable<Item[]> | null = null;

  //itensServise: ItensService;

  constructor(
    private itensServise: ItensService,
    public dialog: MatDialog,
    public router: Router,
    private snackBar: MatSnackBar,
  ) {

    this.refresh();
  }
  private refresh(){
    this.itens$ = this.itensServise.list().pipe(
      catchError((error) => {
        this.OnError('Error ao Carregar o itens.');
        return of([]);
      })
    );
  }

  public onAdd() {
    this.router.navigate(['itens/novo']);
  }
  ngOnInit(): void {}

  OnError(errorMsg: string) {
    //this.dialog.open(ErrorDialogComponent, {
    // data: errorMsg
    // });
    console.log(errorMsg);
  }

  onDelete(item: Item) {
    this.itensServise.delete(item.id).subscribe(
      () => {
        this.refresh();
        this.snackBar.open('Item removido com Suceso!', '', { duration: 4000, verticalPosition: 'top', horizontalPosition: 'center'

      });
      },
      error => this.OnError('Error ao tentar remover Item')
    )
  }
}
