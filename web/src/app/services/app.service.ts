import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
declare var $: any;


@Injectable()
export class AppService {
    public url = "http://200.174.103.116/erratas/api/";
    public token: string = localStorage.getItem('userKey') || '';
    public nomeUsuario: string = localStorage.getItem('nomeUsuario') || '';
    public emailUsuario: string = localStorage.getItem('emailUsuario') || '';
    public idUsuario: string = sessionStorage.getItem('idUsuario') || '';
    public sobreNomeUsuario: string = '';
    public openSide : boolean;
    public arrayCursos;

    public conectado: boolean = false;
    public mensagens: any = sessionStorage.getItem('mensagens') ? JSON.parse(sessionStorage.getItem('mensagens')) : '';
    public mensagensAtivas: any = sessionStorage.getItem('mensagens') ? JSON.parse(sessionStorage.getItem('mensagens')).filter(x => x.Visualizado == false) : '';
        
    ////// VARIAVEIS DE PERMISSOES
    public errata;
    public errataAtualizar;
    public errataListar;
    public errataCadastrar;
    public errataObter;

    public itens;


    public usuarios;
    public usuariosAtualizar;
    public usuariosListar;
    public usuariosCadastrar;
    public usuariosObter;
    public usuariosRemover;
    public usuariosZerarSenha;

    public permissoes;
    public permissoesAtualizar;

    public disciplinas;
    public disciplinasCadastrar;
    public disciplinasListar;
    public disciplinasAtualizar;

    public cursos;
    public cursosCadastrar;
    public cursosListar;
    public cursosAtualizar;

    public relatorios;
    //////////////////////////////////  
    

    constructor(private _http: HttpClient) { }    
    
    getRandomNumber(min: number, max: number) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    tratarObjeto(obj) {
        var newObj = '';
        let array = Object.getOwnPropertyNames(obj);
        $.each(array, (index, value) => {            
            if(obj[value])
            {               
                var aux =  obj[value].toString().split(',');                
                if(aux.length > 0) {               
                    for(var i = 0; i < aux.length; i++)
                    {                       
                        newObj += value + '=' + aux[i] + "&"
                    }                
                } else {
                    newObj += value + '=' + obj[value].value + "&"
                }
            }
               
        })
        return newObj;
    }

    tratarObjetoErratas(obj) {
        var formData = new FormData();
        let array = Object.getOwnPropertyNames(obj);
        $.each(array, (index, value) => { 
            if(obj[value])
            {               
                var aux =  obj[value].toString().split(',');                
                if(aux.length > 0) {               
                    for(var i = 0; i < aux.length; i++)
                    {                              
                        formData.append(value , aux[i]);
                    }                
                } else {                   
                    formData.append(value , obj[value]);
                }
            }
        })
        return formData;
    }

    listarMenu() {
        return this._http.get('Menu') 
    }   

    permissoesGet(){
        this.listarMenu()
        .subscribe((data:any)=>{ 
          data = data.Modulos;
          console.log(data);
   
         this.errata = data.find(x => x.Nome == "Erratas").Autorizado;;
         this.errataCadastrar = data.find(x => x.Nome =='Erratas').Permissoes.find(x => x.Nome == "Cadastrar Erratas").Autorizado;
         this.errataListar = data.find(x => x.Nome =='Erratas').Permissoes.find(x => x.Nome == "Listar Erratas").Autorizado;
         this.errataAtualizar = data.find(x => x.Nome =='Erratas').Permissoes.find(x => x.Nome == "Atualizar Erratas").Autorizado;
         this.errataObter = data.find(x => x.Nome =='Erratas').Permissoes.find(x => x.Nome == "Obter Erratas").Autorizado;
   
         this.usuarios = data.find(x => x.Nome == "Usuários").Autorizado;
         this.usuariosAtualizar = data.find(x => x.Nome == "Usuários").Permissoes.find(x => x.Nome == "Atualizar Usuarios").Autorizado;
         this.usuariosListar = data.find(x => x.Nome == "Usuários").Permissoes.find(x => x.Nome == "Listar Usuarios").Autorizado;
         this.usuariosCadastrar = data.find(x => x.Nome == "Usuários").Permissoes.find(x => x.Nome == "Cadastrar Usuarios").Autorizado;
         this.usuariosObter = data.find(x => x.Nome == "Usuários").Permissoes.find(x => x.Nome == "Obter Usuarios").Autorizado;
         this.usuariosRemover = data.find(x => x.Nome == "Usuários").Permissoes.find(x => x.Nome == "Remover Usuarios").Autorizado;
         this.usuariosZerarSenha = data.find(x => x.Nome == "Usuários").Permissoes.find(x => x.Nome == "Zerar Senha").Autorizado;

         this.permissoes = data.find(x => x.Nome == "Permissões").Autorizado;;
         this.permissoesAtualizar = data.find(x => x.Nome =='Permissões').Permissoes.find(x => x.Nome == "Atualizar Permissoes").Autorizado;

         this.disciplinas = data.find(x => x.Nome == "Disciplinas").Autorizado;
         this.disciplinasCadastrar = data.find(x => x.Nome == "Disciplinas").Permissoes.find(x => x.Nome == "Cadastrar Disciplinas").Autorizado;
         this.disciplinasListar = data.find(x => x.Nome == "Disciplinas").Permissoes.find(x => x.Nome == "Listar Disciplinas").Autorizado;
         this.disciplinasAtualizar = data.find(x => x.Nome == "Disciplinas").Permissoes.find(x => x.Nome == "Atualizar Disciplinas").Autorizado;

         this.cursos = data.find(x => x.Nome == "Cursos").Autorizado;
         this.cursosCadastrar = data.find(x => x.Nome == "Cursos").Permissoes.find(x => x.Nome == "Cadastrar Cursos").Autorizado;
         this.cursosListar = data.find(x => x.Nome == "Cursos").Permissoes.find(x => x.Nome == "Listar Cursos").Autorizado;
         this.cursosAtualizar = data.find(x => x.Nome == "Cursos").Permissoes.find(x => x.Nome == "Atualizar Cursos").Autorizado;         
   
         this.relatorios = data.find(x => x.Nome == "Relatórios").Autorizado;
        });  
    }
    
 
}