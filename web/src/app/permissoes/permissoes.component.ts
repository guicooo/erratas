import { Component, OnInit } from '@angular/core';
import { CargoService } from '../services/cargo.service';
import { PermissoesService } from '../services/permissoes.service';
import { ToastrService } from 'ngx-toastr';
import { AppService } from '../services/app.service';

@Component({
  selector: 'app-permissoes',
  templateUrl: './permissoes.component.html',
  styleUrls: ['./permissoes.component.scss']
})
export class PermissoesComponent implements OnInit {
  public listarCargos;
  public getModulos: any[];
  public permissoes: any[] = [];
  private cargo;


  constructor(private _cargosService : CargoService, 
              private _permissoesService : PermissoesService,
              private _toastr : ToastrService,
              public _appService : AppService
              ) { }

  ngOnInit() {
    this._cargosService.listarCargo()
    .subscribe((data:any)=>{ 
      this.listarCargos = data;
    });
    this._cargosService.getCargo('bd3c8cdc-844e-401d-a593-5e4ad033b2c5')
    .subscribe((data:any)=>{ 
      this.getModulos = data.Modulos;
      this.cargo = data.Id;
    });
        
  }
  selectCargo(event){
    this._cargosService.getCargo(event)
    .subscribe((data:any)=>{ 
      this.getModulos = data.Modulos;
      this.cargo = data.Id;
    });    
  }
  checkboxChanged(id, idModulo){
    let checked = this.getModulos.find(x => x.Id == idModulo).Permissoes.find(x => x.Id == id).Autorizado
                                   = !this.getModulos.find(x => x.Id == idModulo).Permissoes.find(x => x.Id == id).Autorizado
 
    this._permissoesService.editarPermissoes({
      CargoId: this.cargo,
      PermissaoId: id,
      Autorizado: checked
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
