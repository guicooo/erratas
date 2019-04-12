

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class CargoService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {

    }

    listarCargo() {
        return this._http.get('Cargo') 
    }   
    getCargo(id){ 
        return this._http.get( 'Cargo/' + id)
    }   
  
}

