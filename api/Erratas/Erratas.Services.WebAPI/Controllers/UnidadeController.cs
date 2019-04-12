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
    [RoutePrefix("Unidade")]
    public class UnidadeController : ApiController
    {
        private readonly IUnidadeAppService _unidadeAppService;
        public UnidadeController(IUnidadeAppService unidadeAppService)
        {
            _unidadeAppService = unidadeAppService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _unidadeAppService.Listar().OrderBy(x => x.Nome));
        }
    }
}
