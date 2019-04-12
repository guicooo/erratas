

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AppService } from "./app.service";


@Injectable()
export class ItemService {
    
    constructor(private _http: HttpClient, private appService: AppService)  {

    }

    listarItem() {
        return this._http.get('Item') 
    }   
    
  
}

