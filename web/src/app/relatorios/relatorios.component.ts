import { Component, OnInit } from '@angular/core';
import { RelatorioService } from '../services/relatorio.service';

@Component({
  selector: 'app-relatorios',
  templateUrl: './relatorios.component.html',
  styleUrls: ['./relatorios.component.scss']
})
export class RelatoriosComponent implements OnInit {
  public arrayUsuarios;
  public arrayDepartamentos;
  public listaUsuariosNome:string[] = [];
  public listaUsuariosDados:number[] = [];
  public listaDepartamentoNome:string[] = [];
  public listaDepartamentoDados:number[] = [];

  constructor(private _relatorioService : RelatorioService) { }

  ngOnInit() {
    this._relatorioService.listarRelatorio()
    .subscribe((data:any)=>{ 
      this.arrayUsuarios = data[1].Usuario;
      this.arrayDepartamentos = data[0].Departamento;
      

      for(var item of data[0].Departamento){
        this.listaDepartamentoNome.push(item.Nome)
        this.listaDepartamentoDados.push(item.Quantidade)
      }
      for(var item of data[1].Usuario){
        this.listaUsuariosNome.push(item.Nome)
        this.listaUsuariosDados.push(item.Quantidade)
      }   
    })
   
  }


  public doughnutChartType:string = 'doughnut';
  public coresRelatorios: Array<any> = [{backgroundColor: ['#008DAF', '#36ADA7', '#117090', '#0081AD', '#008DAF', '#00A1AD', '#36ADA7', '#74B493', '#00528F', '#005F8D', '#117090', '#0081AD', '#008DAF', '#00A1AD', '#36ADA7', '#74B493']}]
  public options: any = {
    legend: { position: 'bottom' },
    responsive : true,
    maintainAspectRatio: false
  }
 
  printUser(): void {
    let printContents, popupWin, printHead;
    printHead = document.getElementById('printHead').innerHTML;
    printContents = document.getElementById('printUser').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <title>Relatorio de erratas - Usuários</title>
        </head>
    <body onload="window.print();window.close()">
      ${printHead}
      <h2>Relatório de Usuários</h2>
      ${printContents}
    </body>
      </html>`
    );
    popupWin.document.close();
  }

  printDepartamento(): void {
    let printContents, popupWin, printHead;
    printHead = document.getElementById('printHead').innerHTML;
    printContents = document.getElementById('printDepartamento').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <title>Relatorio de erratas - Departamentos</title>
        </head>
    <body onload="window.print();window.close()">
      ${printHead}
      <h2>Relatório dos Departamentos</h2>
      ${printContents}
    </body>
      </html>`
    );
    popupWin.document.close();
  }  
}
