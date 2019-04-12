import { Component, OnInit, EventEmitter } from '@angular/core';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-visualizar-itens',
  templateUrl: './visualizar-itens.component.html',
  styleUrls: ['./visualizar-itens.component.scss']
})
export class VisualizarItensComponent implements OnInit {
  public editCurso = new EventEmitter();
  public curso : boolean = false;
  public editDisciplina = new EventEmitter();
  public disciplina : boolean = false;
  public listCursos : boolean = false;
  public listDisci : boolean = false;

  constructor(public appService : AppService) { }

  ngOnInit() {
  }

  editCursos(){ 
    this.curso = this.curso === false ? true :  false; 
    this.editCurso.emit(this.curso) 
  }

  editDisci(){ 
    this.disciplina = this.disciplina === false ? true :  false; 
    this.editDisciplina.emit(this.disciplina) 
  }  
  listarCursos() {
    this.listCursos = !this.listCursos;
  }
  listarDisci() {
    this.listDisci = !this.listDisci;
  }  
}
