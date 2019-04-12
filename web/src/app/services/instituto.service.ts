

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";
@Injectable()
export class InstitutoService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {       
    }
    
    listarInstituto() {
        return this._http.get('Instituto') 
    }   
    
  
}

