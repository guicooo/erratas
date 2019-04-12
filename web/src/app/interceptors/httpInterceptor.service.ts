import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, switchMap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AppService } from '../services/app.service';



@Injectable({
  providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor {
  public contentType;
  constructor(private _router : Router, private _appService : AppService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const apiReq = req.clone({      
      url: this.resolverUrl() + `${req.url}`,
      headers: this.retornarHeaders(req)
    });
   
    return next.handle(apiReq).pipe (
      catchError((error: Error) => {
        if(error instanceof HttpErrorResponse){
         // console.log('err', error);
          switch(error.status) {
            case 401:
              this._router.navigate(['login']);
            default:
            return throwError(error);
          }
        } else {
          return throwError(error);
        }
      })
    );
    
  }
  
  resolverUrl() : string {
    if(window.location.href.indexOf('/site/') != -1)
      return '/erratas/api/';
    else if(window.location.href.indexOf('localhost:3000') != -1)
      return 'http://localhost:18509/';
    else 
      return this._appService.url;   
  }

  retornarHeaders(req : HttpRequest<any>) : HttpHeaders {
      if(req.headers.has('contentType'))     
        return req.headers.set('Authorization', `Bearer ${localStorage.getItem('userKey')}`)                                                
      else      
        return req.headers.set('Authorization', `Bearer ${localStorage.getItem('userKey')}`)                    
                          .set('Content-Type', !req.headers.has('Content-Type') ? 'application/x-www-form-urlencoded' : req.headers.get('Content-Type'))        
  }

}
