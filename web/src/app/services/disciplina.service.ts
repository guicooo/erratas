

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class DisciplinaService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {
      
    }

    novaDisciplina(obj) {
        return this._http.post( 'Disciplina', this.appService.tratarObjeto(obj))
                        .toPromise()
                        .then(data => data)
    }
    listarCursos() {
        return this._http.get('Curso') 
    }
    listarDisciplinas() {
        return this._http.get('Disciplina') 
    }
    deletarDisciplina(id){ 
        return this._http.delete('Disciplina/' + id)
    }     
    editarDisciplina(id, obj){ 
        return this._http.put( 'Disciplina/' + id, this.appService.tratarObjeto(obj))
    }  
    getDisciplina(id){ 
        return this._http.get( 'Disciplina/' + id)
    }  
}

