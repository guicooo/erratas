using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Erratas.Api.Providers;
using System.Web.Http;
using Erratas.Infra.CrossCutting.IoC;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using Erratas.Infra.CrossCutting.Filters.ActionFilters;
using Swashbuckle.Application;
using Erratas.Application.AutoMapper;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;
using Erratas.Services.WebAPI.Providers;

[assembly: OwinStartup(typeof(Erratas.Services.WebAPI.Startup))]

namespace Erratas.Services.WebAPI
{
    public class Startup
    {        
        public void Configuration(IAppBuilder app)
        {              
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            BootStrapper.Register(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            HttpConfiguration config = new HttpConfiguration()
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };

            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Documentação da API de Erratas");

                    c.ApiKey("Authorization")
                        .Description("Filling bearer token here")
                        .Name("Bearer")
                        .In("header");

                    c.IncludeXmlComments(string.Format(@"{0}\bin\Erratas.Services.WebAPI.XML",
                           System.AppDomain.CurrentDomain.BaseDirectory));

                    c.RootUrl(req =>
                    {
                        var url = req.RequestUri.Scheme + "://" + req.RequestUri.Authority + System.Web.VirtualPathUtility.ToAbsolute("~");
                        return url;
                    });
                    
                })
                .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("Authorization", "header");                    
                });


            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new LogFilterAttribute());

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);

            ConfigureOAuth(app);
        

            AutoMapperConfig.RegisterMappings();

            var idProvider = new CustomUserIdProvider();
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);          

            app.MapSignalR();
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/usuario/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationProvider(),                
            };
            
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }        
    }
}
