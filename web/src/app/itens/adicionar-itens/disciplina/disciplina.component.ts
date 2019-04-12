import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DisciplinaService } from 'src/app/services/disciplina.service';
import { ToastrService } from 'ngx-toastr';
import { AppService } from 'src/app/services/app.service';


@Component({
  selector: 'app-disciplina',
  templateUrl: './disciplina.component.html',
  styleUrls: ['./disciplina.component.scss'],
  providers: [ DisciplinaService ]
})
export class DisciplinaComponent implements OnInit {

  public listaCursos;
  public value: string[];
  public current: string;
  public arrayCurrentCursos: any[];
  public arrayBlank = [];


  public newDisciplina = new FormGroup({
    nome: new FormControl(null, Validators.required),
    modelo: new FormControl(null, Validators.required),
    curso: new FormControl(null, Validators.required),
  });


  constructor(
                private disciplinaService : DisciplinaService, 
                private _toastr : ToastrService, 
                private _appService : AppService,
    ) {

   }

   ngOnInit() {

  }
  
  changed(data: {value: string[]}) {
    this.current = data.value.join();
    this.arrayCurrentCursos = data.value
    console.log(this.arrayCurrentCursos)
  }

  submitnewDisciplina() {
    let arrayId: any = [];
    for(var item of this._appService.arrayCursos)
    {
      arrayId.push(item.Id)
    }
    
    this.disciplinaService.novaDisciplina({
      Id: this.newDisciplina.controls.modelo.value,
      Nome: this.newDisciplina.controls.nome.value,
      CodigoModelo: this.newDisciplina.controls.modelo.value,
      Cursos: arrayId

      })
      .then((dados : any) => {
        console.log(dados)
        this._toastr.success(dados.Mensagem);  
      })
      .catch(xhr => {        
        for(let item of xhr.error){   
          this._toastr.error(item.Mensagem);  
        }


        })
  }  
}
