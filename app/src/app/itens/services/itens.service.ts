import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Item } from '../model/item';
import { first, tap } from 'rxjs';



@Injectable({
  providedIn: 'root',
})
export class ItensService {

  private readonly API = '/assets/itens.json';

  constructor(private httpClient: HttpClient) {}

  list() {
    return this.httpClient.get<Item[]>(this.API)
    .pipe(
      first(),
      //tap(itens => console.log(itens))
    );
  }
}
