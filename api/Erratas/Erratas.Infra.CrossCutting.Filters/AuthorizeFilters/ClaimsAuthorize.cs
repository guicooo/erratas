using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Erratas.Infra.CrossCutting.Filters.AuthorizeFilters
{
    public class ClaimsAuthorize : AuthorizeAttribute
    {
        public string Claim { get; set; }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            ClaimsIdentity claimsIdentity;
            var httpContext = HttpContext.Current;
            if (!(httpContext.User.Identity is ClaimsIdentity))
                return false;

            claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindAll("claims");
            if (!claim.Any())
                return false;

            if (!claim.Where(c => c.Value == Claim).Any())
                return false;

            return base.IsAuthorized(actionContext);
        }
    }
}
