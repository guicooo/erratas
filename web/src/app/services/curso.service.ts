

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";

@Injectable()
export class CursoService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {       
    }

    novoCurso(obj) {
        return this._http.post('Curso', this.appService.tratarObjeto(obj))
                        .toPromise()
                        .then(data => data)
    }

    listarCursos() {
        return this._http.get('Curso', ) 
    }   
    
    deletarCurso(id){ 
        return this._http.delete('Curso/' + id, )
    } 

    editarCurso(id, obj){ 
        return this._http.put( 'Curso/' + id, this.appService.tratarObjeto(obj))
    }   
         
}

