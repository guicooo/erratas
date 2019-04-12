using Erratas.Application.Interfaces.Services;
using Erratas.Application.Services;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Domain.Services;
using Erratas.Domain.Validations;
using Erratas.Infra.Data.Context;
using Erratas.Infra.Data.Interfaces;
using Erratas.Infra.Data.Repository;
using Erratas.Infra.Data.UoW;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            // App
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<ICargoAppService, CargoAppService>(Lifestyle.Scoped);
            container.Register<ICargoPermissaoAppService, CargoPermissaoAppService>(Lifestyle.Scoped);
            container.Register<IMenuAppService, MenuAppService>(Lifestyle.Scoped);
            container.Register<IExtrapolacaoAppService, ExtrapolacaoAppService>(Lifestyle.Scoped);
            container.Register<ICursoAppService, CursoAppService>(Lifestyle.Scoped);
            container.Register<IDisciplinaAppService, DisciplinaAppService>(Lifestyle.Scoped);
            container.Register<IModeloAppService, ModeloAppService>(Lifestyle.Scoped);
            container.Register<IPermissaoAppService, PermissaoAppService>(Lifestyle.Scoped);
            container.Register<IInstitutoAppService, InstitutoAppService>(Lifestyle.Scoped);
            container.Register<IMotivoErrataAppService, MotivoErrataAppService>(Lifestyle.Scoped);
            container.Register<IItemAppService, ItemAppService>(Lifestyle.Scoped);
            container.Register<IErrataAppService, ErrataAppService>(Lifestyle.Scoped);
            container.Register<IUnidadeAppService, UnidadeAppService>(Lifestyle.Scoped);
            container.Register<IDepartamentoAppService, DepartamentoAppService>(Lifestyle.Scoped);
            container.Register<IRelatorioAppService, RelatorioAppService>(Lifestyle.Scoped);
            container.Register<IMensagemAppService, MensagemAppService>(Lifestyle.Scoped); 


            // Domain
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<ICargoService, CargoService>(Lifestyle.Scoped);
            container.Register<IPermissaoService, PermissaoService>(Lifestyle.Scoped);
            container.Register<ICargoPermissaoService, CargoPermissaoService>(Lifestyle.Scoped);
            container.Register<IExtrapolacaoService, ExtrapolacaoService>(Lifestyle.Scoped);
            container.Register<ILogAppService, LogAppService>(Lifestyle.Scoped);
            container.Register<IErrataService, ErrataService>(Lifestyle.Scoped);
            container.Register<IDisciplinaService, DisciplinaService>(Lifestyle.Scoped);
            container.Register<ICursoService, CursoService>(Lifestyle.Scoped);
            container.Register<IMensagemService, MensagemService>(Lifestyle.Scoped);

            // Infra Data
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IModuloRepository, ModuloRepository>(Lifestyle.Scoped);
            container.Register<ICargoRepository, CargoRepository>(Lifestyle.Scoped);
            container.Register<ICargoPermissaoRepository, CargoPermissaoRepository>(Lifestyle.Scoped);
            container.Register<IPermissaoRepository, PermissaoRepository>(Lifestyle.Scoped);
            container.Register<ILogRepository, LogRepository>(Lifestyle.Scoped);
            container.Register<IDisciplinaRepository, DisciplinaRepository>(Lifestyle.Scoped);
            container.Register<ICursoRepository, CursoRepository>(Lifestyle.Scoped);
            container.Register<ICursoDisciplinaRepository, CursoDisciplinaRepository>(Lifestyle.Scoped);
            container.Register<IInstitutoRepository, InstitutoRepository>(Lifestyle.Scoped);
            container.Register<IMotivoErrataRepository, MotivoErrataRepository>(Lifestyle.Scoped);
            container.Register<IItemRepository, ItemRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioCursoRepository, UsuarioCursoRepository>(Lifestyle.Scoped);
            container.Register<IErrataRepository, ErrataRepository>(Lifestyle.Scoped);
            container.Register<IUnidadeRepository, UnidadeRepository>(Lifestyle.Scoped);
            container.Register<IErrataImagemRepository, ErrataImagemRepository>(Lifestyle.Scoped);
            container.Register<IErrataCursoRepository, ErrataCursoRepository>(Lifestyle.Scoped);
            container.Register<IDepartamentoRepository, DepartamentoRepository>(Lifestyle.Scoped);
            container.Register<IRelatorioRepository, RelatorioRepository>(Lifestyle.Scoped);
            container.Register<IMensagemRepository, MensagemRepository>(Lifestyle.Scoped);
            
            container.Register<EntityContext>(Lifestyle.Scoped);                     
        }
    }
}
