

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class UnidadeService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {
       
    }


    listarUnidade() {
        return this._http.get('Unidade'); 
    }   
    
  
}

