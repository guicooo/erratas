import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/services/app.service';
import { NotificacoesService } from 'src/app/services/notificacoes.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-notificacoes',
  templateUrl: './notificacoes.component.html',
  styleUrls: ['./notificacoes.component.scss']
})
export class NotificacoesComponent implements OnInit {

  constructor(public appService: AppService, private _notificacoesService : NotificacoesService, private _toastr : ToastrService) { }

  ngOnInit() {
    this._notificacoesService.atualizarNotificacoes()
      .subscribe((dados : any) => {
      },(error) => {
        for(let item of error.error){   
          this._toastr.error(item.Mensagem);  
        }
      }) 
    
  }

 
 
}
