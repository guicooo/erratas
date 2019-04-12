using Erratas.Application.Interfaces.Services;
using Erratas.Domain.Interfaces.Repositories;
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
    [RoutePrefix("Log")]
    public class LogController : ApiController
    {
        private readonly ILogAppService _logAppService;
        public LogController(ILogAppService logAppService)
        {
            _logAppService = logAppService; 
        }

        /// <summary>
        /// Listar logs
        /// </summary>       
        [HttpGet]
        [ClaimsAuthorize(Claim = "LL")]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _logAppService.Listar());
        }

        /// <summary>
        /// Obter log pelo Id
        /// </summary>       
        [HttpGet]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "OL")]
        public async Task<HttpResponseMessage> Obter(Guid Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _logAppService.Obter(Id));
        }
              
    }
}
