import { VisualizarErrataComponent } from './erratas/visualizar-errata/visualizar-errata.component';
import { AdicionarItensComponent } from './itens/adicionar-itens/adicionar-itens.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { GuardService } from './guards/guard.service';
import { VisualizarUsuarioComponent } from './usuarios/visualizar-usuario/visualizar-usuario.component';
import { AdicionarUsuarioComponent } from './usuarios/adicionar-usuario/adicionar-usuario.component';
import { VisualizarItensComponent } from './itens/visualizar-itens/visualizar-itens.component';
import { CursoComponent } from './itens/adicionar-itens/curso/curso.component';
import { DisciplinaComponent } from './itens/adicionar-itens/disciplina/disciplina.component';
import { UsuariosComponent } from './itens/adicionar-itens/usuarios/usuarios.component';
import { AdicionarErrataComponent } from './erratas/adicionar-errata/adicionar-errata.component';
import { RelatoriosComponent } from './relatorios/relatorios.component';
import { EditarUsuariosComponent } from './usuarios/editar-usuarios/editar-usuarios.component';
import { EditarDisciplinasComponent } from './itens/visualizar-itens/disciplinas/editar-disciplinas/editar-disciplinas.component';
import { EditarErrataComponent } from './erratas/editar-errata/editar-errata.component';
import { ConnectionResolver } from './resolvers/connectionResolver';
import { NotificacoesComponent } from './navbar/notificacoes/notificacoes.component';
import { PermissoesComponent } from './permissoes/permissoes.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home', canActivate: [ GuardService ], component: HomeComponent, resolve: { connection: ConnectionResolver } },
  { path: 'erratas', canActivate: [ GuardService ], component: VisualizarErrataComponent, resolve: { connection: ConnectionResolver }},
    { path: 'erratas/adicionar', canActivate: [ GuardService ], component: AdicionarErrataComponent, resolve: { connection: ConnectionResolver }},  
    { path: 'erratas/editar/:id', canActivate: [ GuardService ], component: EditarErrataComponent, resolve: { connection: ConnectionResolver }},

  { path: 'usuarios', canActivate: [ GuardService ], component: VisualizarUsuarioComponent, resolve: { connection: ConnectionResolver }},
    { path: 'usuarios/adicionar', canActivate: [ GuardService ], component: AdicionarUsuarioComponent, resolve: { connection: ConnectionResolver }},
    { path: 'usuarios/editar/:id', canActivate: [ GuardService ], component: EditarUsuariosComponent, resolve: { connection: ConnectionResolver }},

  { path: 'itens', canActivate: [ GuardService ], component: VisualizarItensComponent, resolve: { connection: ConnectionResolver }},
    { path: 'itens/adicionar', canActivate: [ GuardService ], component: AdicionarItensComponent, children: [
      {path: 'curso', canActivate: [ GuardService ], component: CursoComponent, resolve: { connection: ConnectionResolver }},
      {path: 'disciplina', canActivate: [ GuardService ], component: DisciplinaComponent, resolve: { connection: ConnectionResolver }},
      {path: 'usuarios', canActivate: [ GuardService ], component: UsuariosComponent, resolve: { connection: ConnectionResolver }},
    ]},  
    { path: 'itens/editar/:id', canActivate: [ GuardService ], component: EditarDisciplinasComponent, resolve: { connection: ConnectionResolver }},

  { path: 'relatorios', canActivate: [ GuardService ], component: RelatoriosComponent, resolve: { connection: ConnectionResolver }},
  
  { path: 'notificacoes', canActivate: [ GuardService ], component: NotificacoesComponent, resolve: { connection: ConnectionResolver }},

  { path: 'permissoes', canActivate: [ GuardService ], component: PermissoesComponent, resolve: { connection: ConnectionResolver }},

  { path: '', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


