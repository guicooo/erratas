import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UsuarioService } from '../services/usuarios.service';
import { AppService } from '../services/app.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
  providers: [ UsuarioService ]
})
export class NavbarComponent implements OnInit {
  public sidebar : boolean = false;

  public newKey = new FormGroup({
    senha: new FormControl(null, Validators.required),
    confirmsenha: new FormControl(null, Validators.required),
  });

  constructor(
                private _router: Router, 
                private _toastr : ToastrService, 
                private usuarioService : UsuarioService,
                public appService : AppService
              ) { }

  ngOnInit() {
  }
  
  logout() {
    this._router.navigate([''])
    localStorage.setItem('userKey', '')
    sessionStorage.setItem('mensagens', '')
  }

  submitnewKey() {
    this.usuarioService.trocaSenha({
      Email: this.appService.emailUsuario,
      Senha: this.newKey.controls.senha.value,
      ConfirmaSenha: this.newKey.controls.confirmsenha.value,
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

  openSide(){ 
    this.appService.openSide = !this.appService.openSide;
  }  
}
