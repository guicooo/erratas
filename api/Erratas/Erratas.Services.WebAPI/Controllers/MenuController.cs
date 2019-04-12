using Erratas.Application.Interfaces.Services;
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
    [RoutePrefix("Menu")]
    public class MenuController : ApiController
    {
        private readonly IMenuAppService _menuAppService;
        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }
        
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _menuAppService.Listar());
        }           
    }
}
