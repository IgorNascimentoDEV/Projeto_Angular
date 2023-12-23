import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Item } from '../model/item';
import { delay, first, tap } from 'rxjs';
import { ItensModule } from '../itens.module';



@Injectable({
  providedIn: 'root',
})
export class ItensService {

  private readonly API = 'https://localhost:7269/api/itens';

  constructor(private httpClient: HttpClient) {}

  list() {
    return this.httpClient.get<Item[]>(this.API)
    .pipe(
      first(),
      tap(itens => console.log(itens))
    );
  }


  save(record: Item) {
    return this.httpClient.post<Item>(this.API, record).pipe(first());
  }
}
