using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Erratas.Services.WebAPI.Providers
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {   
            return HttpContext.Current.Request.QueryString["username"].ToString();
        }
    }
}