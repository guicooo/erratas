import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuarios.service';
import { ToastrService } from 'ngx-toastr';

import { DepartamentoService } from 'src/app/services/departamento.service';
import { AppService } from 'src/app/services/app.service';
declare var $: any;

@Component({
  selector: 'app-adicionar-usuario',
  templateUrl: './adicionar-usuario.component.html',
  styleUrls: ['./adicionar-usuario.component.scss'],
  providers: [ UsuarioService ]
})
export class AdicionarUsuarioComponent implements OnInit {

  public cargoID;
  optionsModel: string[];
  public listaCursos;
  public arrayBlank = [];

  public listaDepartamentos;

  public newUser = new FormGroup({
    nome: new FormControl(null, Validators.required),
    sobrenome: new FormControl(null, Validators.required),
    email: new FormControl(null, Validators.required),
    cargo: new FormControl(null, Validators.required),
    curso: new FormControl(null, Validators.required),
    departamento: new FormControl(null, Validators.required)
  });

  constructor(
    private usuarioService : UsuarioService,
    private _toastr: ToastrService,
    private _departamentoService : DepartamentoService,
    private _appService : AppService
    ) {
      this.usuarioService.listarCargos()
      .subscribe(data=>{      
        this.cargoID = data;
      })

      this._departamentoService.listarDepartamentos()
      .subscribe(data=>{      
        this.listaDepartamentos = data;
      })
     }

     ngOnInit() {
    }


  submitNewUser() {
    let arrayId: any = [];
    for(var item of this._appService.arrayCursos)
    {
      arrayId.push(item.Id)
    }
    
    this.usuarioService.novoUsuario({
      Nome: this.newUser.controls.nome.value,
      Sobrenome: this.newUser.controls.sobrenome.value,
      Email: this.newUser.controls.email.value,
      Ativo: 'true',
      CargoId:  this.newUser.controls.cargo.value,
      DepartamentoId:  this.newUser.controls.departamento.value,
      Cursos: arrayId
      })
      .then((dados : any) => {
        //console.log(dados)
        this._toastr.success(dados.Mensagem);  
      })
      .catch(xhr => {        
        for(let item of xhr.error){   
          this._toastr.error(item.Mensagem);  
        }
        })  
  }  

}
