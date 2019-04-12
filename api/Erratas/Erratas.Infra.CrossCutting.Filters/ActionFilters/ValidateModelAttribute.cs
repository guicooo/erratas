using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http.Formatting;
using Erratas.Application.Models;
using Erratas.Application.Adapters;

namespace Erratas.Infra.CrossCutting.Filters.ActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {            
            if (actionContext.ActionArguments.Any(kv => kv.Value == null))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new MensagemModel() { Mensagem = "Parâmetro não pode ser nulo" });
            }

            if (actionContext.ModelState.IsValid == false)
            {
                var retorno = MensagemAdapter.RetornarMensagensModelState(actionContext.ModelState.Values);

                actionContext.Response =
                    actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, retorno, actionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
            }
        }
    }
}
