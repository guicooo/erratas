using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Services.WebAPI.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Erratas.Services.WebAPI.Controllers
{
    // [Authorize]
    [RoutePrefix("Notificacao")]
    public class NotificacaoController : ApiController
    {
        private readonly IMensagemAppService _mensagemAppService;
        public NotificacaoController(IMensagemAppService mensagemAppService)
        {
             _mensagemAppService = mensagemAppService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            var x = _mensagemAppService.Listar();
            return Request.CreateResponse(HttpStatusCode.OK, x);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Atualizar(Guid Id)
        {
            _mensagemAppService.Atualizar(Id);
            return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Notificação atualizada com sucesso" });
        }

        [HttpPut]        
        [Route("AtualizarTodas")]
        public async Task<HttpResponseMessage> AtualizarTodas()
        {
            _mensagemAppService.AtualizarTodas();
            return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Notificações atualizadas com sucesso" });
        }

        [HttpGet]
        [Route("Teste")]
        public void Teste()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ErratasHub>();
            hubContext.Clients.User("f5d18391-f010-471b-be12-dbebb66cab04").SendMessageToClient("Você possui uma nova notificação");
        }
    }
}
