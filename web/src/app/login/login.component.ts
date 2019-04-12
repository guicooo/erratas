import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './login.service';
import { Md5Service } from '../services/md5.service';
import { ToastrService } from 'ngx-toastr';
import { AppService } from '../services/app.service';
declare var $: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public listaMenu;

  public formLogin = new FormGroup({
    usuario: new FormControl(null, Validators.required),
    senha: new FormControl(null),
  });

  public formCadastrarSenha = new FormGroup({
    email: new FormControl(null, Validators.required),
    senha: new FormControl(null, Validators.required),
    confirmaSenha: new FormControl(null, Validators.required)
  });

  constructor(private _router: Router, 
    private _loginService: LoginService, 
    private _md5Service: Md5Service, 
    private _toastr: ToastrService,
    private appService: AppService) { }

  ngOnInit() {
    this.formLogin.controls['usuario'].setValue('anderson.souza@unip.br') 
    this.formLogin.controls['senha'].setValue('dev123456@@');
  }

  logar() {
  
    if(!this.formLogin.valid)
      return this._toastr.warning('Todos os campos são obrigatórios');    

    
    let dados: any = {
      usuario: this.formLogin.controls.usuario.value,
      senha: this._md5Service.tratarString(this.formLogin.controls.senha.value || ''),
      grant_type: 'password'
    }
    
    this._loginService.logar(dados)
              .subscribe(
                (resultado:any) => {                  
                  
                  if(resultado.cadastrarSenha) {
                    this.formCadastrarSenha.controls['email'].setValue(dados.usuario);
                    return $('#modalCadastrarSenha').modal('show');
                  }
                  this.appService.nomeUsuario = resultado.nome;
                  this.appService.emailUsuario = this.formLogin.controls.usuario.value;
                  this.appService.sobreNomeUsuario = resultado.sobreNome;
                  this.appService.idUsuario = resultado.Id;

                  localStorage.setItem('usuario', JSON.stringify(resultado));
                  localStorage.setItem('nomeUsuario', resultado.nome);
                  sessionStorage.setItem('idUsuario', resultado.Id);
                  localStorage.setItem('emailUsuario', this.formLogin.controls.usuario.value);
                  localStorage.setItem('userKey', resultado.access_token);
                  this.appService.permissoesGet()
                  this._router.navigate(['/home']);
                },
                (data: any) => {                                   
                  this._toastr.warning(data.error.error);
                }                               
              )
      
  }

  cadastrarSenha() {
    if(!this.formCadastrarSenha.valid)
        return this._toastr.warning('Todos os campos são obrigatórios');    

  
    let dados: any = {
      email: this.formCadastrarSenha.controls.email.value,
      senha: this._md5Service.tratarString(this.formCadastrarSenha.controls.senha.value || ''),
      confirmaSenha: this._md5Service.tratarString(this.formCadastrarSenha.controls.confirmaSenha.value || ''),
    }

    this._loginService.cadastrarSenha(dados)
              .subscribe(
                (resultado:any) => {     
                  this._toastr.success(resultado.Mensagem);                               
                  $('#modalCadastrarSenha').modal('hide');               
                },
                (data: any) => {                                                 
                  this._toastr.warning(data.error[0].Mensagem);
                }                               
              )
  }

  abrirModal() {  
    $('#modalCadastrarSenha').modal('show');
  }
}
