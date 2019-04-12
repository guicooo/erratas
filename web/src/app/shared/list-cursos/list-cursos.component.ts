import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { CursoService } from 'src/app/services/curso.service';
import {map, startWith} from 'rxjs/operators'
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-list-cursos',
  templateUrl: './list-cursos.component.html',
  styleUrls: ['./list-cursos.component.scss']
})
export class ListCursosComponent implements OnInit {

  myControl = new FormControl();
  filtroCursos: Observable<string[]>;

  public idDoCurso;

  public cursoList : any = [];


  public inputCurso;
  @Input() arrayCursos : any = [];

  @Input() Titulo : string;


  constructor(
              private _toastr: ToastrService,
              private _cursoService : CursoService,
              private _appService : AppService
    ) { }

  ngOnInit() {
    this._cursoService.listarCursos()
    .subscribe(data=>{      
      this.cursoList = data;
      this.filtroCursos = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => this._filterCursos(value))
      ); 
    }) 


  }

  _filterCursos(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.cursoList.filter(option =>option.Nome.toLowerCase().indexOf(filterValue) === 0);
  }  

  
  getCursos(id) {
    this.inputCurso = '';
    let cursoId;
    let cursoName;
    let found : boolean = false;
    cursoId = id.split(' - ')[0]
    cursoName = id.split(' - ')[1]   
    // console.log(this.idDoCurso)
    for( var i = 0; i < this.arrayCursos.length; i++ ) {
      if(this.arrayCursos[i].Id == cursoId){
        this._toastr.warning("O curso já foi adicionado");  
        found = true;
        break;
      }
   }
   if(!found){
    this.arrayCursos.push(
      {
        Id: cursoId,
        Nome: cursoName,
      }
    )
   }
   this.idDoCurso = cursoId;
   this._appService.arrayCursos = this.arrayCursos
   console.log(this._appService.arrayCursos)
  }
  removeCurso(id : number){
    for( var i = 0; i < this.arrayCursos.length; i++ ) {
      this.arrayCursos[i].Id === id ? this.arrayCursos.splice(i, 1) : false;
   }
     //console.log(this.arrayCursos)
  }

}
