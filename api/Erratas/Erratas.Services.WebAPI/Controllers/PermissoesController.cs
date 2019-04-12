using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Application.Models.Cargos;
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
    [RoutePrefix("Permissoes")]
    public class PermissoesController : ApiController
    {  
        private readonly ICargoPermissaoAppService _cargoPermissaoAppService;
        private readonly IPermissaoAppService _permissaoAppService;
        public PermissoesController(ICargoPermissaoAppService cargoPermissaoAppService, IPermissaoAppService permissaoAppService)
        {          
            _cargoPermissaoAppService = cargoPermissaoAppService;
            _permissaoAppService = permissaoAppService;
        }

        /// <summary>
        /// Listar permissoes
        /// </summary>        
        [HttpGet]
        [ClaimsAuthorize(Claim = "LP")]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _permissaoAppService.Listar());
        }
       
        /// <summary>
        /// Autorizar ou Desautorizar Permissoes pelo CargoId e PermissaoId
        /// </summary>
        [HttpPost]
        [ClaimsAuthorize(Claim = "AP")]
        [Route("Autorizacao")]
        public async Task<HttpResponseMessage> Autorizacao(CargoPermissaoModel cargoPermissaoModel)
        {
            var retorno = _cargoPermissaoAppService.Autorizacao(cargoPermissaoModel);
            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Alterações realizadas com sucesso" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        /// <summary>
        /// Autorizar ou Desautorizar Permissoes pelo Modulo
        /// </summary>
        [HttpPost]
        [ClaimsAuthorize(Claim = "APM")]
        [Route("AutorizacaoPorModulo")]
        public async Task<HttpResponseMessage> AutorizacaoPorModulo(CargoPermissaoModuloModel cargoPermissaoModuloModel)
        {
            var retorno = _cargoPermissaoAppService.AutorizacaoPorModulo(cargoPermissaoModuloModel);
            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Alterações realizadas com sucesso" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

    }
}
