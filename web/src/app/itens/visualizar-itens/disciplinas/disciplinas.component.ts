import { DisciplinaService } from 'src/app/services/disciplina.service';
import { Component, OnInit } from '@angular/core';
import { VisualizarItensComponent } from '../visualizar-itens.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { AppService } from 'src/app/services/app.service';
declare var $: any;

@Component({
  selector: 'app-disciplinas',
  templateUrl: './disciplinas.component.html',
  styleUrls: ['./disciplinas.component.scss'],
  providers: [ DisciplinaService ]
})
export class DisciplinasComponent implements OnInit {
  myControl = new FormControl();
  filtroCursos: Observable<string[]>;

  public listDisciplinas;

  public editDisciplina = new FormGroup({
    nome: new FormControl(null, Validators.required),
    modelo: new FormControl(null, Validators.required),
    curso: new FormControl(null, Validators.required),
  });

  constructor(
      private disciplinaService : DisciplinaService, 
      private visualizarItem : VisualizarItensComponent,
      public _appService : AppService
    ) {
    this.disciplinaService.listarDisciplinas()
    .subscribe(data=>{      
      this.listDisciplinas = data;
    })
   }

  ngOnInit() {
      
  }

}
