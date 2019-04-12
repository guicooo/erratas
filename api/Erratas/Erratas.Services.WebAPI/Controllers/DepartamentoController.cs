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
    [RoutePrefix("Departamento")]
    public class DepartamentoController : ApiController
    {
        private readonly IDepartamentoAppService _departamentoAppService;
        public DepartamentoController(IDepartamentoAppService departamentoAppService)
        {
            _departamentoAppService = departamentoAppService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _departamentoAppService.Listar());
        }
    }
}
