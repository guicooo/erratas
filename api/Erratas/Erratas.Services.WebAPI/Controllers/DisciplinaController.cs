using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Application.Models.Disciplinas;
using Erratas.Infra.CrossCutting.Filters.AuthorizeFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Erratas.Services.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("Disciplina")]
    public class DisciplinaController : ApiController
    {
        private readonly IDisciplinaAppService _disciplinaAppService;
        public DisciplinaController(IDisciplinaAppService disciplinaAppService)
        {
            _disciplinaAppService = disciplinaAppService;
        }

        [HttpGet]
        [ClaimsAuthorize(Claim = "LD")]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _disciplinaAppService.Listar().Select(x => new { x.Id, x.Nome }));
        }

        [HttpGet]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "OD")]
        public async Task<HttpResponseMessage> Obter(string Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _disciplinaAppService.Obter(Id));
        }

        [HttpPost]
        [ClaimsAuthorize(Claim = "CD")]
        public async Task<HttpResponseMessage> Cadastrar(DisciplinaModel disciplinaModel)
        {
            var retorno = _disciplinaAppService.Cadastrar(disciplinaModel);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new { Id = retorno.Id, Mensagem = "Disciplina cadastrada com sucesso!" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        [HttpPut]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "AD")]
        public async Task<HttpResponseMessage> Atualizar(string Id, AtualizarDisciplinaModel atualizarDisciplinaModel)
        {
            var retorno = _disciplinaAppService.Atualizar(Id, atualizarDisciplinaModel);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new { Mensagem = "Disciplina atualizada com sucesso!" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        [HttpDelete]       
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "RD")]
        public async Task<HttpResponseMessage> Deletar(string Id)
        {
            if (!_disciplinaAppService.Deletar(Id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new MensagemModel() { Mensagem = "Id inválido" });

            return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Disciplina deletada com sucesso" });
        }
   
    }
}
