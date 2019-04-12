using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models.Erratas;
using Erratas.Infra.CrossCutting.Filters.AuthorizeFilters;
using Erratas.Services.WebAPI.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Erratas.Services.WebAPI.Controllers
{
    [System.Web.Http.Authorize]
    [RoutePrefix("Errata")]
    public class ErrataController : ApiController
    {
        private readonly IErrataAppService _errataAppService;
        public ErrataController(IErrataAppService errataAppService)
        {
            _errataAppService = errataAppService;
        }

        [HttpGet]
        [ClaimsAuthorize(Claim = "LE")]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _errataAppService.Listar());
        }

        [HttpGet]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "OE")]
        public async Task<HttpResponseMessage> Obter(Guid Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _errataAppService.Obter(Id));
        }            
      
        [HttpPost]
        [ClaimsAuthorize(Claim = "CE")]
        public async Task<HttpResponseMessage> Cadastrar()
        {
            var retorno = _errataAppService.Cadastrar();
           
            if (!retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));

            // Dispara as notificãções para os usuarios
            var lstIds = _errataAppService.RetornarUsuarios(retorno);
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ErratasHub>();
            hubContext.Clients.Users(lstIds.ToList()).SendMessageToClient("Você possui uma nova notificação");

            return Request.CreateResponse(HttpStatusCode.OK, new { Id = retorno.Id, Mensagem = "Errata cadastrada com sucesso" });                        
        }

        [HttpPut]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "AE")]
        public async Task<HttpResponseMessage> Atualizar(Guid Id)
        {
            var retorno = _errataAppService.Atualizar(Id);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new { Mensagem = "Errata atualizada com sucesso!" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }
     
    }
}
