import { Component, OnInit } from '@angular/core';
import { ItemService } from 'src/app/services/item.service';
import { UnidadeService } from 'src/app/services/unidade.service';
import { MotivoService } from 'src/app/services/motivo.service';
import { InstitutoService } from 'src/app/services/instituto.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import {map, startWith} from 'rxjs/operators'
import { DisciplinaService } from 'src/app/services/disciplina.service';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from 'src/app/services/usuarios.service';
import { ErrataService } from 'src/app/services/errata.service';
import { AppService } from 'src/app/services/app.service';
import { DomSanitizer } from '@angular/platform-browser';
declare var $: any;

@Component({
  selector: 'app-adicionar-errata',
  templateUrl: './adicionar-errata.component.html',
  styleUrls: ['./adicionar-errata.component.scss']
})
export class AdicionarErrataComponent implements OnInit {

  // LISTA DOS CURSOS
  filtroCursos: Observable<string[]>;
  public idDoCurso;
  public cursoList : any = [];
  public inputCurso;
  public arrayCursos : any = [];


  myControl = new FormControl();

  filtroDisciplinas: Observable<string[]>;
  filtroUsuarios: Observable<string[]>;

  public itemList;
  public unidadeList;
  public motivoList;
  public institutoList;
  public usuarioList;
  public arrayBlank = [];
  
  public disciplinaList : any = [];
  public cursoName;

  public idDaInsercao;
  public idDaRevisao;

  public arrayImg : any = [];
  public inputImageName = '';
  public sendImagem;

  public modelo;


  //NGMODELS
  public selectUnidade = 0;
  public selectItem = 0;
  public selectMotivo = 0;
  public selectAviso = 'true';
  public selectInstituto = 0;
  
  
  public disabled : boolean = true;

  //montando modelo
  public disciplinaInput;

    public newErrata = new FormGroup({
    codModelo: new FormControl(null, Validators.required),
    disciplina: new FormControl(null, Validators.required),
    codOferta: new FormControl(null, Validators.required),
    curso: new FormControl(null, Validators.required),
    date: new FormControl(null, Validators.required),
    professor: new FormControl(null, Validators.required),
    motivo: new FormControl(null, Validators.required),
    item: new FormControl(null, Validators.required),
    unidade: new FormControl(null, Validators.required),
    responsavelI: new FormControl(null, Validators.required),
    responsavelR: new FormControl(null, Validators.required),
    aviso: new FormControl(null, Validators.required),
    instituto: new FormControl(null, Validators.required),
    descricao: new FormControl(null, Validators.required),
    imagem: new FormControl(null, Validators.required),
  });


  constructor(
    private _toastr: ToastrService,
    private itemService : ItemService,
    private unidadeService : UnidadeService,
    private motivoService : MotivoService,
    private institutoService : InstitutoService,
    private disciplinaService : DisciplinaService,
    private usuarioService : UsuarioService,
    private erratasService : ErrataService,
    private _appService : AppService,
    private _sanitizer : DomSanitizer

  ) { }

  ngOnInit() {


    $( ".button-img" ).on( "click", function() {
      $( "#fileInput" ).trigger( "click" );
    });
  

    $(document).ready(function() {
      $('.js-example-basic-single').select2();
    });

    this.itemService.listarItem()
    .subscribe(data=>{      
      this.itemList = data;
    })
      this.unidadeService.listarUnidade()
      .subscribe(data=>{      
        this.unidadeList = data;
    })
    this.motivoService.listarMotivo()
    .subscribe(data=>{      
      this.motivoList = data;
    })
    this.institutoService.listarInstituto()
    .subscribe(data=>{      
      this.institutoList = data;
    })

    this.disciplinaService.listarDisciplinas()
    .subscribe(data=>{      
      this.disciplinaList = data;
      this.filtroDisciplinas = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => this._filterDisciplinas(value))
      ); 
    })
    this.usuarioService.listarUsuarios()
    .subscribe(data=>{      
      this.usuarioList = data;
      this.filtroUsuarios = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => this._filterUsuarios(value))
      ); 
    })          
   
  }
 

  _filterDisciplinas(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.disciplinaList.filter(option =>option.Nome.toLowerCase().indexOf(filterValue) === 0);
  }   
  _filterUsuarios(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.usuarioList.filter(option =>option.Nome.toLowerCase().indexOf(filterValue) === 0);
  } 
  _filterCursos(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.modelo.Cursos.filter(option =>option.Nome.toLowerCase().indexOf(filterValue) === 0);
  } 
  
  getRevisao(id){
    this.idDaRevisao = id;
  }  
  getInsercao(id){
    this.idDaInsercao = id;
  }
   

  getModelo(event) {
    this.erratasService.getModelo(event.target.value)
     .subscribe((data : any) => {
        this.modelo = data;
        this.disabled = false;

        this.filtroCursos = this.myControl.valueChanges.pipe(
          startWith(''),
          map(value => this._filterCursos(value))
        ); 
        
        this.disciplinaInput = this.modelo.Disciplinas[0].Nome

      },(error) => {
        for(let item of error.error){   
          this._toastr.error(item.Mensagem);  
        }
      })
    
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

  onFileChange(event) {
    let found : boolean = false;
    let reader : any = new FileReader();

    this.inputImageName = event.target.files[0].name;

    if(event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {


      for( var i = 0; i < this.arrayImg.length; i++ ) {
        if(this.arrayImg[i].Name == file.name){
          this._toastr.warning("O curso já foi adicionado");  
          found = true;
          break;
        }
      }
      if(!found){
        this.arrayImg.push(
          {
            Name: file.name,
            Type: file.type,
            Link: this._sanitizer.bypassSecurityTrustUrl("data:image/png;base64," + reader.result.split(',')[1]),
            Value: reader.result.split(',')[1]
          }
        )
      }
      console.log(this.arrayImg)
      }
    }

  }


  removeImage() {
    this.newErrata.get('imagem').setValue('');
    this.inputImageName = '';
    this.arrayImg = [];
  }
 

  submitNewErrata() {
    let arrayId: any = [];
    if(this._appService.arrayCursos)
    {
      for(var item of this._appService.arrayCursos) {
        arrayId.push(item.Id);
      }
    }
    

    let arrayImg: any = [];
    for(var item of this.arrayImg){arrayImg.push(item.Value)}

      
    this.erratasService.novaErrata({
      ImagensErrata: arrayImg,
      CodigoModelo: this.newErrata.controls.codModelo.value,
      Professor: this.newErrata.controls.professor.value,
      ResponsavelInsercaoId: this.idDaInsercao,
      ResponsavelRevisaoId: this.idDaRevisao,
      InstitutoId: this.newErrata.controls.instituto.value,
      MotivoErrataid: this.newErrata.controls.motivo.value,
      DisciplinaId: this.modelo.Disciplinas[0].Id,
      UnidadeId: this.newErrata.controls.unidade.value,
      ErrataCursos: arrayId,
      CodigoOferta: this.newErrata.controls.codOferta.value,
      DataDeSolicitacao: this.newErrata.controls.date.value,
      Descricao: this.newErrata.controls.descricao.value,
      ItemId: this.newErrata.controls.item.value
    })
    .then((dados : any) => {  
      this._toastr.success(dados.Mensagem);  
    })
    .catch(xhr => {        
      for(let item of xhr.error){   
        this._toastr.error(item.Mensagem);  
      }
    })  
      
  }
  
}
