using Erratas.Application.Interfaces.Services;
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
    [RoutePrefix("Relatorio")]
    public class RelatorioController : ApiController
    {
        private readonly IRelatorioAppService _relatorioAppService;
        public RelatorioController(IRelatorioAppService relatorioAppService)
        {
            _relatorioAppService = relatorioAppService;
        }

        [HttpGet]     
        [ClaimsAuthorize(Claim = "VR")]
        public async Task<HttpResponseMessage> ListarTodos()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _relatorioAppService.ListarTodos());
        }

        [HttpGet]
        [Route("Usuario")]
        [ClaimsAuthorize(Claim = "VR")]
        public async Task<HttpResponseMessage> ListarPorUsuarios()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _relatorioAppService.ListarPorUsuario());
        }

        [HttpGet]
        [Route("Usuario/{id}")]
        [ClaimsAuthorize(Claim = "VR")]
        public async Task<HttpResponseMessage> ObterPorUsuario(Guid Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _relatorioAppService.ListarPorUsuario().Where(x => x.Id == Id));
        }

        [HttpGet]
        [Route("Departamento")]
        [ClaimsAuthorize(Claim = "VR")]
        public async Task<HttpResponseMessage> ListarPorDepartamentos()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _relatorioAppService.ListarPorDepartamento());
        }

        [HttpGet]
        [Route("Departamento/{id}")]
        [ClaimsAuthorize(Claim = "VR")]
        public async Task<HttpResponseMessage> ListarPorDepartamento(Guid Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _relatorioAppService.ListarPorDepartamento().Where(x => x.Id == Id));
        }
    }
}
