

import { Injectable } from "@angular/core";
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class ErrataService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {
       
    }

    listarErratas() {
        return this._http.get('Errata'); 
    }   

    novaErrata(obj) {
        let options = {
            headers: new HttpHeaders({
                'contentType': 'false',                
            })
        };
        
        return this._http.post('Errata', this.appService.tratarObjetoErratas(obj), options)
                        .toPromise()
                        .then(data => data)
    }

    deletarErrata(id){ 
        return this._http.delete('Errata/' + id);
    }     

    getModelo(modelo) {
        return this._http.get('Modelo/' + modelo); 
    }        
    getErrata(id) {
        return this._http.get('Errata/' + id); 
    }  
    editarErrata(id, obj){ 
        let options = {
            headers: new HttpHeaders({
                'contentType': 'false',                
            })
        };
        return this._http.put( 'Errata/' + id, this.appService.tratarObjetoErratas(obj), options)
    }         
         
}

