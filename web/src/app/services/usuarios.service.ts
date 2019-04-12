

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";
import { Md5Service } from "./md5.service";


@Injectable()
export class UsuarioService {
    
    constructor(private _http: HttpClient, private appService: AppService, private _md5Service: Md5Service)  {
      
    }

    listarUsuarios() {
        return this._http.get('Usuario') 
    }

    deletarUsuario(id){ 
        return this._http.delete('Usuario/' + id)
    }     

    novoUsuario(obj) {
        return this._http.post( 'Usuario', this.appService.tratarObjeto(obj))
                        .toPromise()
                        .then(data => data)
    }
    
    listarCargos() {
        return this._http.get('Cargo') 
    }   
 
    trocaSenha(obj) {
        obj.Senha = this._md5Service.tratarString(obj.Senha);
        obj.ConfirmaSenha = this._md5Service.tratarString(obj.ConfirmaSenha);
        
        return this._http.put('Usuario/trocarSenha', this.appService.tratarObjeto(obj))
                        .toPromise()
                        .then(data => data)
    } 

    getUsuario(id){ 
        return this._http.get( 'Usuario/' + id)
    }     

    editarUsuario(id, obj){ 
        return this._http.put( 'Usuario/' + id, this.appService.tratarObjeto(obj))
    }

    zerarSenha(id){
        return this._http.put( 'Usuario/zerarSenha/' + id, '')
    }   
         
}
