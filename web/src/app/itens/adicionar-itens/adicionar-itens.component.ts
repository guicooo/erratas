import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-adicionar-itens',
  templateUrl: './adicionar-itens.component.html',
  styleUrls: ['./adicionar-itens.component.scss']
})
export class AdicionarItensComponent implements OnInit {

  constructor(public _appService : AppService) { }

  ngOnInit() {
  }

}
