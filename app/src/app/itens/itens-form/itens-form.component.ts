import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '../../shared/app-material/app-material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ItensService } from '../services/itens.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-itens-form',
  standalone: true,
  imports: [CommonModule, AppMaterialModule],
  templateUrl: './itens-form.component.html',
  styleUrl: './itens-form.component.css',
})
export class ItensFormComponent {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private service: ItensService, private snackBar: MatSnackBar) {
    this.form = this.formBuilder.group({
      codigo: [null],
      nome: [null],
      preco: [null],
      quantidade: [null],
    });
  }

  public onSubmit() {
    this.service.save(this.form.value)
    .subscribe(data => console.log(data), error => this.onError())
  }

  public onCancel() {}

  onError(){
    this.snackBar.open('Error ao salvar!', '', {duration: 4000});
  }
}
