import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuarios.service';
import { AppService } from 'src/app/services/app.service';
import { ToastrService } from 'ngx-toastr';
declare var $: any;

@Component({
  selector: 'app-visualizar-usuario',
  templateUrl: './visualizar-usuario.component.html',
  styleUrls: ['./visualizar-usuario.component.scss'],
  providers: [ UsuarioService ]
})
export class VisualizarUsuarioComponent implements OnInit {
  public userName;
  public userList;
  public userId;
  btnClose;


  constructor(
    public usuarioService : UsuarioService,
    public appService : AppService,
    private _toastr: ToastrService
    ) { 
    this.usuarioService.listarUsuarios()
    .subscribe(data=>{      
      this.userList = data;
      console.log(this.userList)
    })
  }

  ngOnInit() {
  }
  deleteUser(id){
    this.usuarioService.deletarUsuario(id)
    .subscribe((data : any) => { 
      $('#modalDelete').modal('hide'); 
      this._toastr.success(data.Mensagem);  
      this.usuarioService.listarUsuarios()
      .subscribe(data=>{      
        this.userList = data;
      })
    });  
  }
  deleteModal(nome, sobrenome, id) {
    this.userName = nome + ' ' +  sobrenome;
    this.userId = id;
  }
    

}
