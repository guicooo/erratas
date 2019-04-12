using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
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
    [RoutePrefix("Modelo")]
    public class ModeloController : ApiController
    {
        private readonly IModeloAppService _modeloAppService;
        public ModeloController(IModeloAppService modeloAppService)
        {
            _modeloAppService = modeloAppService; 
        }

        [HttpGet]
        [Route("{modelo}")]
        public async Task<HttpResponseMessage> Obter(string modelo)
        {
            var retorno = _modeloAppService.Obter(modelo);
            if (retorno.Disciplinas.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, retorno);

            return Request.CreateResponse(HttpStatusCode.BadRequest, new MensagemModel() { Mensagem = "Nenhum modelo encontrado" }); 
        }        
    }
}
