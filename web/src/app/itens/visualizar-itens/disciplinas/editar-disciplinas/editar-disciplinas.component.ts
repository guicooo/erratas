import { DisciplinaService } from './../../../../services/disciplina.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppService } from 'src/app/services/app.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-editar-disciplinas',
  templateUrl: './editar-disciplinas.component.html',
  styleUrls: ['./editar-disciplinas.component.scss']
})
export class EditarDisciplinasComponent implements OnInit {
  public id;
  public DisciName;
  public DisciId;
  public DisciCursos;
  public thisDisciplina;

  public editDisciplina = new FormGroup({
    nome: new FormControl(null, Validators.required),
    modelo: new FormControl(null, Validators.required),
  });

  constructor(
                private _route : ActivatedRoute,
                private disciplinaService : DisciplinaService,
                public _appService : AppService,
                private _toastr: ToastrService
  ) {
    this._route.params.subscribe( params => this.id = params.id);
   }

  ngOnInit() {
    this.disciplinaService.getDisciplina(this.id)
    .subscribe(data=>{  
      this.thisDisciplina = data;

      this.editDisciplina.controls.nome.setValue(this.thisDisciplina.Nome);
      this.editDisciplina.controls.modelo.setValue(this.thisDisciplina.CodigoModelo);

      this._appService.arrayCursos = [];
      this._appService.arrayCursos = this.thisDisciplina.Cursos;
      
    })
  }

 
  submitEditUser() {
    let arrayId: any = [];
      for(var item of this._appService.arrayCursos)
    {
      arrayId.push(item.Id)
    }
    this.disciplinaService.editarDisciplina(this.id, {
      Nome: this.editDisciplina.controls.nome.value,
      CodigoModelo: this.editDisciplina.controls.modelo.value,
      Cursos: arrayId
      })
      .subscribe((dados : any) => {
        this._toastr.success(dados.Mensagem);  
      },(error) => {
        for(let item of error.error){   
          this._toastr.error(item.Mensagem);  
        }
      })  
      console.log(this._appService.arrayCursos);
      
  }
}
