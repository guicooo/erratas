import { Md5 } from 'ts-md5';
import { Injectable } from '@angular/core';

@Injectable()
export class Md5Service {

    constructor() { }

    tratarString(valor: string) : string {            
        return Md5.hashStr(valor).toString();        
    }

}