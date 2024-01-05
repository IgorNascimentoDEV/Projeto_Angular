import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Solicitacao } from '../model/solicitacao';
import { Observable, first, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SolicitacoesService {

  private readonly API = 'https://localhost:7269/api/solicitacao'

  constructor(private httpclient: HttpClient) { }

  list(){
    return this.httpclient.get<Solicitacao[]>(this.API)
    .pipe(
      first()
    );
  }

  public loadById(id: string) {
    return this.httpclient.get<Solicitacao>(`${this.API}/${id}`);
  }

  public update(solicitacao: Solicitacao){
    return this.httpclient.put<Solicitacao>(`${this.API}/${solicitacao.id}`, solicitacao)
      .pipe(
        tap(
          () => console.log('Atualização bem-sucedida'),
          (error) => console.error('Erro ao atualizar Solicitacao:', error)
        )
      );
  }

  save(solicitacao: Solicitacao) {
    return this.httpclient.post<Solicitacao>(this.API, solicitacao).pipe(first());
  }

  public delete(id: string){
    return this.httpclient.delete(`${this.API}/${id}`)
    .pipe(
      tap(
        () => console.log('Exclusão realizada'),
        (error) => console.error('Error ao excluir a solicitação', error)
      )
    );
  }
}
