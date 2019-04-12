import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgProgressModule } from '@ngx-progressbar/core';
import { NgProgressHttpModule } from '@ngx-progressbar/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpInterceptorService } from './interceptors/httpInterceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppService } from './services/app.service';
import { GuardService } from './guards/guard.service';

import { Md5Service } from './services/md5.service';
import { Md5 } from 'ts-md5';
import { ToastrModule } from 'ngx-toastr';
import {MatInputModule} from '@angular/material';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatFormFieldModule} from '@angular/material/form-field';
import { ChartsModule } from 'ng2-charts';
import {NgxPaginationModule} from 'ngx-pagination';
 
import { AdicionarUsuarioComponent } from './usuarios/adicionar-usuario/adicionar-usuario.component';
import { VisualizarUsuarioComponent } from './usuarios/visualizar-usuario/visualizar-usuario.component';
import { RouterModule } from '@angular/router';
import { VisualizarItensComponent } from './itens/visualizar-itens/visualizar-itens.component';
import { AdicionarItensComponent } from './itens/adicionar-itens/adicionar-itens.component';
import { DisciplinaComponent } from './itens/adicionar-itens/disciplina/disciplina.component';
import { CursoComponent } from './itens/adicionar-itens/curso/curso.component';
import { UsuariosComponent } from './itens/adicionar-itens/usuarios/usuarios.component';
import { VisualizarErrataComponent } from './erratas/visualizar-errata/visualizar-errata.component';
import { AdicionarErrataComponent } from './erratas/adicionar-errata/adicionar-errata.component';
import { RelatoriosComponent } from './relatorios/relatorios.component';
import { CursosComponent } from './itens/visualizar-itens/cursos/cursos.component';
import { DisciplinasComponent } from './itens/visualizar-itens/disciplinas/disciplinas.component';
import { ItemService } from './services/item.service';
import { UnidadeService } from './services/unidade.service';
import { MotivoService } from './services/motivo.service';
import { InstitutoService } from './services/instituto.service';
import { CursoService } from './services/curso.service';
import { UsuarioService } from './services/usuarios.service';
import { ErrataService } from './services/errata.service';
import { DisciplinaService } from './services/disciplina.service';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { EditarErrataComponent } from './erratas/editar-errata/editar-errata.component';
import { EditarUsuariosComponent } from './usuarios/editar-usuarios/editar-usuarios.component';
import { DepartamentoService } from './services/departamento.service';
import { ListCursosComponent } from './shared/list-cursos/list-cursos.component';
import { EditarDisciplinasComponent } from './itens/visualizar-itens/disciplinas/editar-disciplinas/editar-disciplinas.component';
import { RelatorioService } from './services/relatorio.service';

// Notificações
import { SignalRModule } from 'ng2-signalr';
import { SignalRConfiguration } from 'ng2-signalr';
import { ConnectionResolver } from './resolvers/connectionResolver';
import { NotificacoesComponent } from './navbar/notificacoes/notificacoes.component';
import { PermissoesComponent } from './permissoes/permissoes.component';
import { CargoService } from './services/cargo.service';
import { PermissoesService } from './services/permissoes.service';
import { NotificacoesService } from './services/notificacoes.service';


export function createConfig(): SignalRConfiguration {
  const c = new SignalRConfiguration();
  c.hubName = 'ErratasHub'; 
  c.url = window.location.port == "3000" ? 'http://localhost:18509' : 'http://200.174.103.116/erratas/api';
  c.qs = { 'username' : sessionStorage.getItem('idUsuario') };
  c.logging = false;  
  c.executeEventsInZone = false; 
  c.executeErrorsInZone = false; 
  c.executeStatusChangeInZone = false;
  c.withCredentials = false;
  return c;
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    AdicionarErrataComponent,
    AdicionarUsuarioComponent,
    VisualizarUsuarioComponent,
    VisualizarItensComponent,
    AdicionarItensComponent,
    DisciplinaComponent,
    CursoComponent,
    UsuariosComponent,
    VisualizarErrataComponent,
    RelatoriosComponent,
    CursosComponent,
    DisciplinasComponent,
    NavbarComponent,
    SidebarComponent,
    EditarErrataComponent,
    EditarUsuariosComponent,
    ListCursosComponent,
    EditarDisciplinasComponent,
    NotificacoesComponent,
    PermissoesComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgProgressModule.forRoot(),
    NgProgressHttpModule.forRoot(),
    ToastrModule.forRoot(),
    RouterModule,
    FormsModule,
    MatInputModule,
    MatAutocompleteModule,
    MatFormFieldModule,
    ChartsModule,
    NgxPaginationModule,
    // NgxMaskModule.forRoot(),
    SignalRModule.forRoot(createConfig)
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptorService, multi: true},
    Md5Service, 
    Md5,
    AppService,
    GuardService,
    AppRoutingModule,    
    ItemService,
    UnidadeService,
    MotivoService,
    InstitutoService,
    CursoService,
    DisciplinaService,
    UsuarioService,
    ErrataService,
    DepartamentoService,
    RelatorioService,
    CargoService,
    PermissoesService,
    ConnectionResolver,
    NotificacoesService
  ],
  bootstrap: [
    AppComponent
  ],
  exports:[
    MatAutocompleteModule,
    MatFormFieldModule,
    MatInputModule,
  ]
})
export class AppModule { }
