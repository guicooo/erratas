using Erratas.Application.Interfaces.Services;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class MensagemAppService : IMensagemAppService
    {
        private readonly IMensagemService _mensagemService;
        private readonly IMensagemRepository _mensagemRepository;
        private readonly IUnitOfWork _uow;
        public MensagemAppService(IMensagemService mensagemService, IUnitOfWork uow, IMensagemRepository mensagemRepository)
        {
            _mensagemService = mensagemService;
            _mensagemRepository = mensagemRepository;
            _uow = uow;
        }
        public bool GravarMensagem(IEnumerable<string> Ids, string Descricao, string Disciplina, string Link)
        {
            foreach(var item in Ids)
            {
                var mensagem = new Mensagem() 
                {
                    Id = Guid.NewGuid(),
                    Descricao = Descricao,
                    Disciplina = Disciplina,
                    DataDeGeracao = DateTime.Now,
                    Visualizado = false,
                    UsuarioId = Guid.Parse(item),
                    Link = Link
                };

               _mensagemService.GravarMensagem(mensagem);
            }

            _uow.Commit();
            return true;
        }
        public IEnumerable<Mensagem> Listar()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var UsuarioId = Guid.Parse(identity.Claims.Where(x => x.Type.ToLower() == "userid").SingleOrDefault().Value);
            return _mensagemRepository.ObterPorUsuario(UsuarioId).OrderBy(x => x.Visualizado);
        }


        public bool Atualizar(Guid Id)
        {
            var mensagem = _mensagemRepository.ObterPorId(Id);

            _uow.BeginTransaction();

            mensagem.Visualizado = !mensagem.Visualizado;

            _mensagemService.Atualizar(mensagem);
            _uow.Commit();
            return true;
        }


        public bool AtualizarTodas()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var UsuarioId = Guid.Parse(identity.Claims.Where(x => x.Type.ToLower() == "userid").SingleOrDefault().Value);
            var mensagens = _mensagemRepository.ObterPorUsuario(UsuarioId);

            _uow.BeginTransaction();

            foreach(var item in mensagens)
            {
                item.Visualizado = true;
                _mensagemService.Atualizar(item);
            }

            _uow.Commit();
            return true;
        }
    }
}
