using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Application.Models.Usuarios;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Infra.CrossCutting.Filters.ActionFilters;
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
    [RoutePrefix("Usuario")]
    [Authorize]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// Listar usuários
        /// </summary>        
        [HttpGet]       
        [ClaimsAuthorize(Claim = "LU")]
        public async Task<HttpResponseMessage> Listar()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _usuarioAppService.Listar().Select(x => new { x.Id, x.Nome, x.SobreNome, x.Email, Cargo = new { x.Cargo.Id, x.Cargo.Nome } }));
        }

        /// <summary>
        /// Obter usuário pelo Id
        /// </summary>       
        [HttpGet]
        [ClaimsAuthorize(Claim = "OU")]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Obter(Guid Id)
        {
            var retorno = _usuarioAppService.Obter(Id);
            return Request.CreateResponse(HttpStatusCode.OK, retorno);
        }

        /// <summary>
        /// Cadastrar usuário
        /// </summary>        
        [HttpPost]      
        [ClaimsAuthorize(Claim = "CU")]
        
        public async Task<HttpResponseMessage> Cadastrar([FromBody]UsuarioModel usuario)
        {            
            var retorno = _usuarioAppService.Cadastrar(usuario);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new { Id = retorno.Id, Mensagem = "Usuário cadastrado com sucesso" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        /// <summary>
        /// Atualizar usuário passando id na url e dados no body
        /// </summary>        
        [HttpPut]       
        [ClaimsAuthorize(Claim = "AU")]      
        [Route("{id}")]
        public async Task<HttpResponseMessage> Atualizar(Guid Id, [FromBody]UsuarioAtualizarModel usuario)
        {           
            var retorno = _usuarioAppService.Atualizar(Id, usuario);

            if (retorno.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Usuário atualizado com sucesso" });

            return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(retorno.ValidationResult));
        }

        /// <summary>
        /// Deletar usuário pelo Id
        /// </summary>      
        [HttpDelete]
        [ClaimsAuthorize(Claim = "RU")]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Deletar(Guid Id)
        {
            if (!this._usuarioAppService.Deletar(Id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new MensagemModel() { Mensagem = "Id inválido" });

            return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Usuário deletado com sucesso" });
        }

        /// <summary>
        /// Zerar a senha do usuário pelo Id
        /// </summary>       
        [HttpPut]
        [Route("zerarSenha/{id}")]       
        [ClaimsAuthorize(Claim = "ZS")]
        public async Task<HttpResponseMessage> ZerarSenha(Guid Id)
        {                        
            if(!this._usuarioAppService.ZerarSenha(Id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new MensagemModel() { Mensagem = "Id inválido" });

            return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Senha zerada com sucesso" });
        }

        /// <summary>
        /// Cadastrar nova senha
        /// </summary>      
        [HttpPost]
        [Route("cadastrarSenha")]        
        [AllowAnonymous]
        public async Task<HttpResponseMessage> CadastrarSenha(CadastrarSenhaModel cadastrarSenha)
        {
            var usuario = _usuarioAppService.CadastrarSenha(cadastrarSenha);
                
            if(!usuario.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(usuario.ValidationResult));

            return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Nova Senha cadastrada com sucesso" });                  
        }

        /// <summary>
        /// Trocar senha
        /// </summary>      
        [HttpPut]
        [Route("trocarSenha")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> TrocarSenha(TrocarSenha trocarSenha)
        {
            var usuario = _usuarioAppService.TrocarSenha(trocarSenha);

            if (!usuario.ValidationResult.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, MensagemAdapter.RetornarMensagensFluent(usuario.ValidationResult));

            return Request.CreateResponse(HttpStatusCode.OK, new MensagemModel() { Mensagem = "Senha atualizada com sucesso" });
        }
       
    }
}
