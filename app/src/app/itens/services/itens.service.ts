import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Item } from '../model/item';
import { delay, first, tap } from 'rxjs';

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

  public loadById(id: string) {
    return this.httpClient.get<Item>(`${this.API}/${id}`);
  }

  public update(item: Item){
    return this.httpClient.put<Item>(`${this.API}/${item.id}`, item)
      .pipe(
        tap(
          () => console.log('Atualização bem-sucedida'),
          (error) => console.error('Erro ao atualizar item:', error)
        )
      );
  }

  public delete(id: string){
    return this.httpClient.delete(`${this.API}/${id}`)
      .pipe(
        tap(
          () => console.log('Exclusão realizada'),
          (error) => console.error('Erro ao excluir item:', error)
        )
      );
  }

}
