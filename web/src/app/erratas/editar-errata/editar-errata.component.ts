import {  DomSanitizer } from '@angular/platform-browser';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ErrataService } from 'src/app/services/errata.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemService } from 'src/app/services/item.service';
import { UnidadeService } from 'src/app/services/unidade.service';
import { MotivoService } from 'src/app/services/motivo.service';
import { InstitutoService } from 'src/app/services/instituto.service';
import { DisciplinaService } from 'src/app/services/disciplina.service';
import { UsuarioService } from 'src/app/services/usuarios.service';
import { AppService } from 'src/app/services/app.service';
import {map, startWith} from 'rxjs/operators'
import { Observable } from 'rxjs';
declare var $: any;

@Component({
  selector: 'app-editar-errata',
  templateUrl: './editar-errata.component.html',
  styleUrls: ['./editar-errata.component.scss'],
  providers: [ ErrataService ]
})
export class EditarErrataComponent implements OnInit {
  public id;
  public errata;
  public errataList;
  public errataId;

  // LISTA DOS CURSOS
  filtroCursos: Observable<string[]>;
  public idDoCurso;
  public cursoList : any = [];
  public inputCurso;
  public arrayCursos : any = [];
  public arrayDeleteImg : any = [];


  myControl = new FormControl();

  filtroDisciplinas: Observable<string[]>;
  filtroUsuarios: Observable<string[]>;

  // LISTA DE SERVICOS
  public itemList;
  public unidadeList;
  public motivoList;
  public institutoList;
  public usuarioList;
  
  public disciplinaList : any = [];
  public cursoName;

  public arrayImg : any = [];
  public arrayImgOld : any = [];
  public inputImageName = '';
  public sendImagem;


  //NGMODELS
  public selectUnidade;
  public unidade;
  public listaUnidade;

  public selectItem;
  public item;
  public listaItem;

  public selectMotivo;
  public motivo;
  public listaMotivo;

  public selectInstituto;
  public instituto;
  public listaInstituto;

  public inputAviso;

 
  public editErrata = new FormGroup({
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
    private errataService : ErrataService,
    private _route : ActivatedRoute,
    private itemService : ItemService,
    private unidadeService : UnidadeService,
    private motivoService : MotivoService,
    private institutoService : InstitutoService,
    private disciplinaService : DisciplinaService,
    private usuarioService : UsuarioService,
    private erratasService : ErrataService,
    public _appService : AppService,
    private _router : Router,
    private _sanitizer : DomSanitizer
    ) {
      this._route.params.subscribe( params => this.id = params.id);
     }

  ngOnInit() {
    this.errataService.getErrata(this.id)
    .subscribe(data=>{  
      this.errata = data;

      // this.item = this.errata.MotivoErrata.Id;
      this.arrayCursos = this.errata.ErrataCursos;
      this.arrayImgOld = this.errata.ImagensErrata;
 
      this.editErrata.controls.unidade.setValue(this.errata.Unidade.Id);
      this.editErrata.controls.motivo.setValue(this.errata.MotivoErrata.Id);
      this.editErrata.controls.instituto.setValue(this.errata.Instituto.Id);
      this.editErrata.controls.item.setValue(this.errata.Item.Id);
      this.editErrata.controls.aviso.setValue(this.errata.AvisoPostado);
      this.editErrata.controls.date.setValue(this.errata.DataDeSolicitacao);
      this.editErrata.controls.professor.setValue(this.errata.Professor);
      this.editErrata.controls.responsavelI.setValue(this.errata.ResponsavelInsercao.Id);
      this.editErrata.controls.responsavelR.setValue(this.errata.ResponsavelRevisao.Id);
      this.editErrata.controls.codModelo.setValue(this.errata.CodigoModelo);
      this.editErrata.controls.disciplina.setValue(this.errata.Disciplina.Id);
    

      this.filtroCursos = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => this._filterCursos(value))
      );       
      console.log(this.errata)
      this.actionSelectItem();
      this.actionSelectUnidade();
      this.actionSelectMotivo();
      this.actionSelectInstituto();
    })

    $( ".button-img" ).on( "click", function() {
      $( "#fileInput" ).trigger( "click" );
    });
  

    $(document).ready(function() {
      $('.js-example-basic-single').select2();
    });

    this.itemService.listarItem()
    .subscribe(data=>{      
      this.itemList = data;
      this.actionSelectItem();
    })
      this.unidadeService.listarUnidade()
      .subscribe(data=>{      
        this.unidadeList = data;
        this.actionSelectUnidade();
    })
    this.motivoService.listarMotivo()
    .subscribe(data=>{      
      this.motivoList = data;
      this.actionSelectMotivo();
    })
    this.institutoService.listarInstituto()
    .subscribe(data=>{      
      this.institutoList = data;
      this.actionSelectInstituto();
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

  deleteErrata(id){
    console.log(id);
    
    this.errataService.deletarErrata(id)
    .subscribe((data : any) => { 
      $('#modalDelete').modal('hide'); 
      this._toastr.success(data.Mensagem);  
      this._router.navigate(['erratas']);
    });  
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
    return this.errata.ErrataCursos.filter(option =>option.Nome.toLowerCase().indexOf(filterValue) === 0);
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


  removeImageOld(id) {
    this.inputImageName = '';
    this.arrayDeleteImg.push({Id: id})
    for( var i = 0; i < this.arrayImgOld.length; i++ ) {
      this.arrayImgOld[i].Id === id ? this.arrayImgOld.splice(i, 1) : false;
   }
    console.log(this.arrayDeleteImg);
  }
  removeImage() {
    this.editErrata.get('imagem').setValue('');
    this.inputImageName = '';
    this.arrayImg = [];
  }
 

  submitEditErrata() {
    let arrayId: any = [];
    if(this._appService.arrayCursos)
    {
      for(var item of this._appService.arrayCursos) {
        arrayId.push(item.Id);
      }
    }

    let arrayImgValue: any = [];
    for(var item of this.arrayImg){arrayImgValue.push(item.Value)}

    let deleteImg: any = [];
    for(var item of this.arrayDeleteImg){deleteImg.push(item.Id)}

    this.erratasService.editarErrata(this.id, {

      ImagensErrata: arrayImgValue,
      CodigoModelo: this.editErrata.controls.codModelo.value,
      Professor: this.editErrata.controls.professor.value,
      ResponsavelInsercaoId: this.editErrata.controls.responsavelI.value,
      ResponsavelRevisaoId: this.editErrata.controls.responsavelR.value,     
      DisciplinaId: this.editErrata.controls.disciplina.value,
      InstitutoId: this.editErrata.controls.instituto.value,
      MotivoErrataid: this.editErrata.controls.motivo.value,
      UnidadeId: this.editErrata.controls.unidade.value,
      Cursos: arrayId,
      CodigoOferta: this.editErrata.controls.codOferta.value,
      DataDeSolicitacao: this.editErrata.controls.date.value,
      Descricao: this.editErrata.controls.descricao.value,
      RemoverImagensErrata: deleteImg,
      ItemId: this.editErrata.controls.item.value

      })
      .subscribe((dados : any) => {
        this._toastr.success(dados.Mensagem);  
      },(error) => {
        for(let item of error.error){   
          this._toastr.error(item.Mensagem);  
        }
      })

  }
  actionSelectItem() {
      for(let i = 0; i < this.itemList.length; i++) {
      if(this.item && this.itemList[i].Id == this.item) {
        this.selectItem = this.itemList[i].Id;
        }
      }
  } 
  actionSelectUnidade() {
    for(let i = 0; i < this.unidadeList.length; i++) {
    if(this.unidade && this.unidadeList[i].Id == this.unidade) {
      this.selectUnidade = this.unidadeList[i].Id;
      }
    }
  } 
  actionSelectMotivo() {
    for(let i = 0; i < this.motivoList.length; i++) {
    if(this.motivo && this.motivoList[i].Id == this.motivo) {
      this.selectMotivo = this.motivoList[i].Id;
      }
    }
  } 
  actionSelectInstituto() {
    for(let i = 0; i < this.institutoList.length; i++) {
    if(this.instituto && this.institutoList[i].Id == this.instituto) {
      this.selectInstituto = this.institutoList[i].Id;
      }
    }
  }   

}
