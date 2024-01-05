import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '../../../shared/app-material/app-material.module';
import { ListaSolicitacoesComponent } from '../../components/lista-solicitacoes/lista-solicitacoes.component';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SolicitacoesService } from '../../services/solicitacoes.service';
import { Observable, catchError, of } from 'rxjs';
import { Solicitacao } from '../../model/solicitacao';

@Component({
  selector: 'app-solicitacoes',
  standalone: true,
  templateUrl: './solicitacoes.component.html',
  styleUrl: './solicitacoes.component.css',
  imports: [CommonModule, AppMaterialModule, ListaSolicitacoesComponent],
})
export class SolicitacoesComponent implements OnInit {
  solicitacoes$: Observable<Solicitacao[]> | null = null;

  constructor(
    public dialog: MatDialog,
    public router: Router,
    private snackBar: MatSnackBar,
    private service: SolicitacoesService
  ) {
    this.refresh();
  }

  refresh(){
    this.solicitacoes$ = this.service.list().pipe(
      catchError((error => {
        this.onError("Error ao Carregar as solicitacoes");
        return of([]);
      }))
    )
  }
  public onAdd() {
    this.router.navigate(['/solicitacoes/nova-solicitacao']);
  }

  ngOnInit(): void {}

  public onError(ErrorMsg: string){
    console.log(ErrorMsg)
  }

  public onDelete(solicitacao: Solicitacao){
    this.service.delete(solicitacao.id).subscribe(
      () => {
        this.refresh();
        this.snackBar.open('Solicitacão removida com sucesso', '', { duration: 4000, verticalPosition: 'top', horizontalPosition: 'center'

      });
      },
      error => this.onError('Error ao tentar remover a solicitacão')
    )
  }
}
