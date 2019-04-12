using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Application.Models.Cursos;
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
    [RoutePrefix("Curso")]   
    public class CursoController : ApiController
    {
        private readonly ICursoAppService _cursoAppService;
        public CursoController(ICursoAppService cursoAppService)
        {
            _cursoAppService = cursoAppService;
        }

        [HttpGet]
        [ClaimsAuthorize(Claim = "LCU")]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cursoAppService.Listar().Select(x => new { x.Id, x.Nome }));
        }

        [HttpGet]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "OCU")]
        public async Task<HttpResponseMessage> Obter(string Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cursoAppService.Obter(Id));
        }

        [HttpPost]
        [ClaimsAuthorize(Claim = "CCU")]
        public async Task<HttpResponseMessage> Cadastrar(CursoModel cursoModel)
        {
            var retorno = _cursoAppService.Cadastrar(cursoModel);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new { Id = retorno.Id, Mensagem = "Curso cadastrado com sucesso!" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        [HttpPut]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "ACU")]
        public async Task<HttpResponseMessage> Atualizar(string Id, AtualizarCursoModel atualizarCursoModel)
        {
            var retorno = _cursoAppService.Atualizar(Id, atualizarCursoModel);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new { Mensagem = "Curso atualizado com sucesso!" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        [HttpDelete]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "RCU")]
        public async Task<HttpResponseMessage> Deletar(string Id)
        {
            if (!_cursoAppService.Deletar(Id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new MensagemModel() { Mensagem = "Id inválido" });

            return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Curso deletado com sucesso" });
        }
    }
}
