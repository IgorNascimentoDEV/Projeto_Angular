import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Solicitacao } from '../model/solicitacao';
import { Observable, first } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SolicitacoesService {

  private readonly API = '/assets/solicitacoes.json'

  constructor(private httpclient: HttpClient) { }

  list(){
    return this.httpclient.get<Solicitacao[]>(this.API)
    .pipe(
      first()
    );
  }
}
