using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Infra.Data.Context;
using Erratas.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace Erratas.Infra.CrossCutting.Filters.ActionFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogRepository _logRepository;
        public LogFilterAttribute()
        {
            _logRepository = new LogRepository(new EntityContext());
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Method != HttpMethod.Get)
            {
                ClaimsIdentity claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
                if (claimsIdentity.FindFirst("userId") == null)
                    return;

                var log = new Log()
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = Guid.Parse(claimsIdentity.FindFirst("userId").Value),
                    DataDeGravacao = DateTime.Now,
                    Verbo = actionExecutedContext.Request.Method.Method,
                    Status = actionExecutedContext.Response != null ? actionExecutedContext.Response.StatusCode.ToString() : null,
                    Retorno = actionExecutedContext.Response != null && actionExecutedContext.Response.Content != null ? actionExecutedContext.Response.Content.ReadAsStringAsync().Result : null,
                    Url = actionExecutedContext.Request.RequestUri.ToString(),
                    Acao = actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                    Controller = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName
                };

                _logRepository.Cadastrar(log);
                _logRepository.Salvar();
            }
        }
    }
}
