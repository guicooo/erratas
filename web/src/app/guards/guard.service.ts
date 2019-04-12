import { CanActivate, Router } from "@angular/router";
import { Injectable } from "@angular/core";

@Injectable()
export class GuardService implements CanActivate {
   
    constructor(private _router: Router) { }

    canActivate() {     

      if(!localStorage.getItem('userKey'))
          this._router.navigate(['login']);

      return localStorage.getItem('userKey') ? true : false;
      
    }
}