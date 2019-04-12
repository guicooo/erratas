import { VisualizarItensComponent } from './../visualizar-itens.component';
import { Component, OnInit, Input } from '@angular/core';
import { CursoService } from 'src/app/services/curso.service';
import { ToastrService } from 'ngx-toastr';
import { AppService } from 'src/app/services/app.service';
declare var $: any;

@Component({
  selector: 'app-cursos',
  templateUrl: './cursos.component.html',
  styleUrls: ['./cursos.component.scss'],
  providers: [ CursoService ]
})
export class CursosComponent implements OnInit {
  public listCursos;
  public cursoName;
  public cursorId;
  public edit;
  public inputNomeCurso;

  constructor(private cursoService : CursoService, 
              private _toastr: ToastrService, 
              private visualizarItem : VisualizarItensComponent,
              private appService : AppService) {
    this.cursoService.listarCursos()
    .subscribe(data=>{      
      this.listCursos = data;
    })
   }

  ngOnInit() {
    this.visualizarItem.editCurso.subscribe(val => {
      this.edit = val
    });
  }


  editCurso(event){
    $('.li-list-itens').removeClass('editar');
    $(event.target).parent().addClass('editar');   
  }

  getCurso(event){this.inputNomeCurso = event;}

    putCurso(id){
    console.log(this.inputNomeCurso);
    this.cursoService.editarCurso(id, {
      Nome: this.inputNomeCurso
      })
      .subscribe((dados : any) => {
        //console.log(dados)
        this._toastr.success(dados.Mensagem);  
        this.cursoService.listarCursos()
        .subscribe(data=>{      
          this.listCursos = data;
        })
      },(error) => {
        for(let item of error.error){   
          this._toastr.error(item.Mensagem);  
        }
        
      })  
      
  
  }
  
}
