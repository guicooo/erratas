import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class PermissoesService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {

    }
    editarPermissoes(obj) {
        return this._http.post( 'Permissoes/Autorizacao', this.appService.tratarObjeto(obj))
                        .toPromise()
                        .then(data => data)
    }    

}

