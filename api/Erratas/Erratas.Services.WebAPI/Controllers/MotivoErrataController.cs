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
    [RoutePrefix("MotivoErrata")]
    public class MotivoErrataController : ApiController
    {
        private readonly IMotivoErrataAppService _motivoErrataAppService;
        public MotivoErrataController(IMotivoErrataAppService motivoErrataAppService)
        {
            _motivoErrataAppService = motivoErrataAppService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _motivoErrataAppService.Listar());
        }
    }
}
