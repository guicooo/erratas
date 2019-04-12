

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class RelatorioService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {
       
    }

    listarRelatorio() {
        return this._http.get('Relatorio'); 
    }   
  
  
}

