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
    [RoutePrefix("Item")]
    public class ItemController : ApiController
    {
        private readonly IItemAppService _itemAppService;
        public ItemController(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _itemAppService.Listar());
        }
    }
}
