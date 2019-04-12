import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AppService } from "../services/app.service";

@Injectable({providedIn: 'root'})
export class LoginService {
    constructor(private _http: HttpClient, private appService: AppService) {}

    logar(dados: any) : Observable<any> {       
        let headers = new HttpHeaders({
            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
        });
        let options = { headers: headers };

        return this._http.post('usuario/login', `grant_type=password&username=${dados.usuario}&password=${dados.senha}`, options);           
    }

    cadastrarSenha(dados: any) : Observable<any> {             
        return this._http.post('usuario/cadastrarSenha', this.appService.tratarObjeto(dados));           
    }
}
