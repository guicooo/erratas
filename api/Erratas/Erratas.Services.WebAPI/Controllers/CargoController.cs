using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Domain.Entities;
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
    [RoutePrefix("Cargo")]
    public class CargoController : ApiController
    {
        private readonly ICargoAppService _cargoAppService;
        public CargoController(ICargoAppService cargoAppService)
        {         
            _cargoAppService = cargoAppService;
        }

        /// <summary>
        /// Listar Cargos
        /// </summary>      
        [HttpGet]
        [ClaimsAuthorize(Claim = "LC")]
        public async Task<HttpResponseMessage> Listar()
        {            
            return Request.CreateResponse(HttpStatusCode.OK, _cargoAppService.Listar().Select(x => new { x.Id, x.Nome }));
        }

        /// <summary>
        /// Obter Cargo pelo Id
        /// </summary>      
        [HttpGet]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "OC")]
        public async Task<HttpResponseMessage> Obter(Guid Id)
        {
            var cargo = _cargoAppService.Obter(Id);
            return Request.CreateResponse(HttpStatusCode.OK, cargo);
        }

        /// <summary>
        /// Cadastrar Cargo
        /// </summary>      
        [HttpPost]
        [ClaimsAuthorize(Claim = "CC")]
        public async Task<HttpResponseMessage> Cadastrar(CargoModel cargoModel)
        {
            var retorno = _cargoAppService.Cadastrar(cargoModel);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new { Id = retorno.Id, Mensagem = "Cargo cadastrado com sucesso" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        /// <summary>
        /// Atualizar Cargo
        /// </summary>      
        [HttpPut]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "AC")]
        public async Task<HttpResponseMessage> Atualizar(Guid Id, [FromBody]CargoAtualizarModel cargoModel)
        {
            var retorno = _cargoAppService.Atualizar(Id, cargoModel);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Cargo atualizado com sucesso" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        /// <summary>
        /// Deletar Cargo
        /// </summary>   
        [HttpDelete]
        [Route("{id}")]
        [ClaimsAuthorize(Claim = "RC")]
        public async Task<HttpResponseMessage> Deletar(Guid Id)
        {
            var retorno = _cargoAppService.Deletar(Id);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Cargo deletado com sucesso" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
       
        } 
       
    }
}

