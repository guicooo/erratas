using Erratas.Application.Interfaces.Services;
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
    [RoutePrefix("instituto")]
    public class InstitutoController : ApiController
    {
        private readonly IInstitutoAppService _institutoAppService;
        public InstitutoController(IInstitutoAppService institutoAppService)
        {
            _institutoAppService = institutoAppService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _institutoAppService.Listar());
        }
    }
}
