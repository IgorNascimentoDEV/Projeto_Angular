import { Component, OnInit } from '@angular/core';
import { CommonModule, Location } from '@angular/common';
import { AppMaterialModule } from '../../../shared/app-material/app-material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ItensService } from '../../services/itens.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { Item } from '../../model/item';
import { map, switchMap } from 'rxjs';

@Component({
  selector: 'app-itens-form',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './itens-form.component.html',
  styleUrl: './itens-form.component.css',
})
export class ItensFormComponent implements OnInit{
  form: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private service: ItensService,
    private snackBar: MatSnackBar,
    private location: Location,
    private route: ActivatedRoute
  ) {
    this.form = this.formBuilder.group({
      id: '',
      codigo: [null],
      nome: [null],
      preco: [null],
      quantidade: [null],
    });
  }
  ngOnInit(): void {
    this.route.params
      .pipe(
        map((params: any) => params['id']),
        switchMap(id => this.service.loadById(id))
      )
      .subscribe(
        (item) => {
          if (item) {
            this.updateForm(item);
          }
        });
  }

  public updateForm(item: Item){
    this.form.patchValue({
      id: item.id,
      codigo: item.codigo,
      nome: item.nome,
      preco: item.preco,
      quantidade: item.quantidade,
    })
  }

  public onSubmit() {
    if (this.form.value.id) {
      this.service.update(this.form.value).subscribe(
        (data) => this.onSuccess(),
        (error) => this.onError()
      );
    } else {
      this.service.save(this.form.value).subscribe(
        (data) => this.onSuccess(),
        (error) => this.onError()
      );
    }
  }


  public onCancel() {
    this.location.back();
  }

  private onError() {
    this.snackBar.open('Error ao salvar!', '', { duration: 4000 });
  }

  private onSuccess() {
    this.snackBar.open('Item salvo com Suceso!', '', { duration: 4000 });
    this.onCancel();
  }
}
