using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Services.WebAPI.Hubs
{
    [HubName("ErratasHub")]
    public class ErratasHub : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }               
    }
}