import { Component, OnInit } from '@angular/core';
import { ErrataService } from 'src/app/services/errata.service';
import { AppService } from 'src/app/services/app.service';


@Component({
  selector: 'app-visualizar-errata',
  templateUrl: './visualizar-errata.component.html',
  styleUrls: ['./visualizar-errata.component.scss'],
  providers: [ ErrataService ]
})
export class VisualizarErrataComponent implements OnInit {
  p: number = 1;
  collection = [];
  public errataList;
  public errataCod;
  public errata;
  btnClose;
  public errataCursos;
  public errataImagens;

  constructor(
    private errataService : ErrataService,
    public _appService : AppService
    ) { 
 
    }

  ngOnInit() {
    this.errataService.listarErratas()
    .subscribe(data=>{      
      this.errataList = data;
      console.log(this.errataList)
    })
  }


  visualizaModal(id, cod) {
    this.errataCod = cod;
    this.errataService.getErrata(id)
    .subscribe(data=>{      
      this.errata = data;
      this.errataCursos = this.errata.ErrataCursos
      this.errataImagens = this.errata.ImagensErrata
      console.log(this.errataImagens);
    })
  }  

  
}
