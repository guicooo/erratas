import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class NotificacoesService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {

    }

    listar() {
        return this._http.get( 'Notificacao/')                       
    }    

    atualizarNotificacoes(){ 
        return this._http.put( 'Notificacao/AtualizarTodas', '')
    }             
}
