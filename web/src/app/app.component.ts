import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { AppService } from './services/app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public mostrarSidebar: boolean = true;

  constructor(public router: Router, public appService : AppService) {
    this.router.events.subscribe((evento) => {
      
      if(evento instanceof NavigationEnd) {
        //console.log(this.router.url)
        if(this.router.url == '/' || this.router.url.indexOf('/login') != -1) 
          this.mostrarSidebar = false      
        else
          this.mostrarSidebar = true;
      }
    });
  }
  ngOnInit() {
    if(this.appService.token != '' && this.appService.token != null)
      this.appService.permissoesGet()
  }

}

