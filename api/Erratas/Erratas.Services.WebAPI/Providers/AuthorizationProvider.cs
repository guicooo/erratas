using Erratas.Infra.Data.Context;
using Erratas.Infra.Data.Repository;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Api.Providers
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {           
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            // context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            EntityContext entityContext = new EntityContext();
            var usuarioRepository = new UsuarioRepository(entityContext);          
            var usuario = usuarioRepository.ValidarUsuario(context.UserName, context.Password);

            if (usuario == null || (usuario.Senha != null && usuario.Senha != context.Password))
            {
                context.SetError("Usuário ou senha inválidos");
                return;
            }
           
            if(usuario.Ativo == false)
            {
                context.SetError("Usuário foi deletado");
                return;
            }
            
            var claims = usuarioRepository.ObterPermissoes(usuario.Cargo.Id);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            if (usuario.Senha == null)
            {
                context.OwinContext.Set<bool>("cadastrarSenha", true);
                claims = new string[] { };
            }

            identity.AddClaim(new Claim("userId", usuario.Id.ToString()));
            identity.AddClaim(new Claim("cargoId", usuario.CargoId.ToString()));
          
            foreach (var item in claims)
            {
                identity.AddClaim(new Claim("claims", item));
            }

            context.OwinContext.Set<string>("nome", usuario.Nome.Trim());
            context.OwinContext.Set<string>("sobreNome", usuario.SobreNome.Trim());
            context.OwinContext.Set<string>("Id", usuario.Id.ToString());
          
            identity.AddClaim(new Claim(ClaimTypes.Role, usuario.Cargo.Nome));
                                      
            GenericPrincipal principal = new GenericPrincipal(identity, new string[] { });
            Thread.CurrentPrincipal = principal;
            
            context.Validated(identity);
                  
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            string thisIsTheToken = context.AccessToken;
            context.AdditionalResponseParameters.Add("Id", context.OwinContext.Get<string>("Id"));
            context.AdditionalResponseParameters.Add("nome", context.OwinContext.Get<string>("nome"));       
            context.AdditionalResponseParameters.Add("sobreNome", context.OwinContext.Get<string>("sobreNome"));
            context.AdditionalResponseParameters.Add("cadastrarSenha", context.OwinContext.Get<bool>("cadastrarSenha"));
          
            return base.TokenEndpointResponse(context);
        }
                    
    }
}