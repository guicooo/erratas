import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CursoService } from 'src/app/services/curso.service';
import { ToastrService } from 'ngx-toastr';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.scss'],
  providers: [ CursoService ]
})
export class CursoComponent implements OnInit {


  public newCurso = new FormGroup({
    nome: new FormControl(null, Validators.required),
    id: new FormControl(null, Validators.required)
  });

  constructor(private cursoService : CursoService, private _toastr : ToastrService, private appService : AppService) { }

  ngOnInit() {
  }
  submitnewCurso() {
    this.cursoService.novoCurso({
      Id: this.newCurso.controls.id.value,
      Nome: this.newCurso.controls.nome.value,
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
