import { AppService } from './../services/app.service';
import { Component, OnInit } from '@angular/core';
import { SignalRConnection, SignalR, BroadcastEventListener } from 'ng2-signalr';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NotificacoesService } from '../services/notificacoes.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  private _connection: any;
 
  constructor(private _route: ActivatedRoute, 
              public appService: AppService, 
              private _signalR: SignalR, 
              private _toastr: ToastrService,
              private _notificacoesService: NotificacoesService) { 

    this._connection = this._route.snapshot.data['connection'];    
  }

  ngOnInit() {

    // Se ja se conectou uma vez no signalR retorna.
    if(this.appService.conectado)
      return;

    this.appService.conectado = true;
    this._connection._configuration.qs.username = this.appService.idUsuario;
    let onMessageSent$ = new BroadcastEventListener<any>('SendMessageToClient');
    this._connection.listen(onMessageSent$);
    onMessageSent$.subscribe((chatMessage: any) => {
          this._toastr.success(chatMessage);

          // Toda vez que chegar uma nova msg, busca todas as outras de novo
          this._notificacoesService.listar().subscribe((data: any[]) => {
            this.appService.mensagens = data;
            this.appService.mensagensAtivas = data.filter(x => x.Visualizado == false);
            sessionStorage.setItem('mensagens', JSON.stringify(data))
          })
    });
    
    if(!this.appService.mensagens && !sessionStorage.getItem('mensagens')) {
      
      this._notificacoesService.listar().subscribe((data: any[]) => {
        this.appService.mensagens = data;
        this.appService.mensagensAtivas = data.filter(x => x.Visualizado == false);  
        sessionStorage.setItem('mensagens', JSON.stringify(data))
      });

    }
    
  }

}
