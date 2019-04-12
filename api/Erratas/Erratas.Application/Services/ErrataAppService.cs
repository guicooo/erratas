using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models.Erratas;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Application.Services
{
    public class ErrataAppService : IErrataAppService
    {
        private readonly IErrataService _errataService;
        private readonly IErrataRepository _errataRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMensagemAppService _mensagemAppService;
        private readonly IUsuarioRepository _usuarioRepository;
        public ErrataAppService(IErrataRepository errataRepository, 
            IErrataService errataService, 
            IUnitOfWork uow, 
            IMensagemAppService mensagemAppService,
            IUsuarioRepository usuarioRepository)
        {
            _errataService = errataService;
            _errataRepository = errataRepository;
            _mensagemAppService = mensagemAppService;
            _usuarioRepository = usuarioRepository;
            _uow = uow;
        }

        public Errata Cadastrar()
        {
            var errata = new ErrataAdapter().FormDataParaErrata(Guid.NewGuid());
            _uow.BeginTransaction();

            errata = _errataService.Cadastrar(errata);

            if (errata.ValidationResult.IsValid)            
                _uow.Commit();

            if (!errata.ValidationResult.IsValid)
                return errata;


            return errata;
        }
        public IEnumerable<string> RetornarUsuarios(Errata errata)
        {
            var lstUsuarios = new List<string>();
            foreach (var item in errata.ErrataCursos)
            {
                var usuarios = _usuarioRepository.ObterUsuariosPorCurso(item.CursoId);

                foreach (var item2 in usuarios)
                {
                    lstUsuarios.Add(item2.ToString());
                }
            }

            _mensagemAppService.GravarMensagem(lstUsuarios.Distinct().ToList(), errata.Descricao, errata.Disciplina.Nome, "/erratas/editar/" + errata.Id);
            return lstUsuarios.Distinct();
        }

        public IEnumerable<ObterErrataModel> Listar()
        {
            var retorno = _errataRepository.Listar();
            return new ErrataAdapter().ErrataParaListaErrataModel(retorno);
        }
        public Errata Atualizar(Guid Id)
        {
            var errata = new ErrataAdapter().FormDataParaErrata(Id);
            _uow.BeginTransaction();

            errata = _errataService.Atualizar(errata);

            if (errata.ValidationResult.IsValid)
                _uow.Commit();

            return errata;
        }
        public ObterErrataModel Obter(Guid Id)
        {
            var retorno = _errataRepository.ObterPorId(Id);
            return new ErrataAdapter().ErrataParaObterErrataModel(retorno);
        }
    }
}
