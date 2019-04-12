

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";

@Injectable()
export class MotivoService{
    
    constructor(private _http: HttpClient, private appService: AppService)  {

    }

    listarMotivo() {
        return this._http.get('MotivoErrata') 
    }   
    
  
}

