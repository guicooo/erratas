import { AppService } from './../../services/app.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UsuarioService } from 'src/app/services/usuarios.service';
import { DepartamentoService } from 'src/app/services/departamento.service';
import { CursoService } from 'src/app/services/curso.service';
import { ToastrService } from 'ngx-toastr';
import { ListCursosComponent } from 'src/app/shared/list-cursos/list-cursos.component';
declare var $: any;

@Component({
  selector: 'app-editar-usuarios',
  templateUrl: './editar-usuarios.component.html',
  styleUrls: ['./editar-usuarios.component.scss'],
  providers: [ListCursosComponent]
})
export class EditarUsuariosComponent implements OnInit {

  public id;
  public userId;
  public cargo;
  public departamento;
  public listaDepartamentos;
  

  public listCargos;
  public listDepartamento;
  public cursoId;
  public cursoName;

  public selectCargo;
  public selectDepartamento;


  public editUser = new FormGroup({
    nome: new FormControl(null, Validators.required),
    sobrenome: new FormControl(null, Validators.required),
    email: new FormControl(null, Validators.required),
    cargo: new FormControl(null, Validators.required),
    curso: new FormControl(null, Validators.required),
    departamento: new FormControl(null, Validators.required)
  });

  constructor(
    private _route : ActivatedRoute,
    public usuarioService : UsuarioService,
    public _departamentoService : DepartamentoService,
    public cursoService : CursoService,
    private _toastr: ToastrService,
    public _appService : AppService,
    ) {



    this._route.params.subscribe( params => this.id = params.id);


    this.usuarioService.getUsuario(this.id)
    .subscribe(data=>{  
      this.userId = data;
      this.editUser.controls.nome.setValue(this.userId.Nome);
      this.editUser.controls.sobrenome.setValue(this.userId.SobreNome);
      this.editUser.controls.email.setValue(this.userId.Email);
      this.editUser.controls.cargo.setValue(this.userId.Cargo.Id);

      this._appService.arrayCursos = [];
      this._appService.arrayCursos = this.userId.Cursos;

      this.departamento = this.userId.Departamento.Id;
      this.actionSelectCargo();
      this.actionSelectDepartamento();
      
    })

    this._departamentoService.listarDepartamentos()
    .subscribe(data=>{      
      this.listaDepartamentos = data;
      this.actionSelectDepartamento();
    })

    this.usuarioService.listarCargos()
    .subscribe(data=>{      
      this.listCargos = data;      
      this.actionSelectCargo();
    })
   }

  ngOnInit() {
  }
  

  submitEditUser() {
    let arrayId: any = [];
      for(var item of this._appService.arrayCursos)
    {
      arrayId.push(item.Id)
    }
    this.usuarioService.editarUsuario(this.id, {
      Nome: this.editUser.controls.nome.value,
      Sobrenome: this.editUser.controls.sobrenome.value,
      Email: this.editUser.controls.email.value,
      Ativo: 'true',
      CargoId:  this.editUser.controls.cargo.value,
      DepartamentoId:  this.editUser.controls.departamento.value,
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

  actionSelectCargo() {
    for(let i = 0; i < this.listCargos.length; i++) {
      if(this.cargo && this.listCargos[i].Id == this.cargo) {
        this.selectCargo = this.listCargos[i].Id;
      }
    }
  }
  actionSelectDepartamento() {
    for(let i = 0; i < this.listaDepartamentos.length; i++) {
      if(this.departamento && this.listaDepartamentos[i].Id == this.departamento) {
        this.selectDepartamento = this.listaDepartamentos[i].Id;
      }
    }
  }  
  zerarSenha(){
    this.usuarioService.zerarSenha(this.id)
    .subscribe((dados : any) => {
      this._toastr.success(dados.Mensagem);  
      $('#modalDelete').modal('hide'); 
    },(error) => {
      for(let item of error.error){   
        this._toastr.error(item.Mensagem);  
      }
    })    
    
  }
 
}
