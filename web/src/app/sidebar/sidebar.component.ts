import { Component, OnInit } from '@angular/core';
import { AppService } from '../services/app.service';
import { NavbarComponent } from '../navbar/navbar.component';
declare var $: any;

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
 
  constructor(public appService: AppService) { }

  ngOnInit() {
    
    if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) {
      $('.multi-collapse').find( "a" ).click(() => $('.sidenav').removeClass( "side-closed" ));
      $('#relatorios').click(() => $('.sidenav').removeClass( "side-closed" ));      
     }
  }

  clickClosed(){
      this.appService.openSide = false;
  }

}
