using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
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
    [Authorize]
    [RoutePrefix("Extrapolacao")]
    public class ExtrapolacaoController : ApiController
    {
        private readonly IExtrapolacaoAppService _extrapolacaoAppService;
        public ExtrapolacaoController(IExtrapolacaoAppService extrapolacaoAppService)
        {
            _extrapolacaoAppService = extrapolacaoAppService;
        }

        [HttpPost]
        [Route("Modelos")]
        public async Task<HttpResponseMessage> ExtrairModelos()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
      
        [HttpPost]
        [Route("Grade")]
        public async Task<HttpResponseMessage> ExtrairGrade()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any()
               && HttpContext.Current.Request.Files["arquivo"] != null)
            {
                var arquivo = HttpContext.Current.Request.Files["arquivo"];
                if (_extrapolacaoAppService.ExtrapolarGrade(arquivo))
                    Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Extrapolação efetuada com sucesso!" });
                else
                    Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new MensagemModel() { Mensagem = "Arquivo é obrigatório" });
        }       
    }
}
