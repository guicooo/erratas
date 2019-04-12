

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class DepartamentoService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {
    }

    listarDepartamentos() {
        return this._http.get('Departamento') 
    }
}

