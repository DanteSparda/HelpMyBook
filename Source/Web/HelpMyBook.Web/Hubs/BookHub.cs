using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HelpMyBook.Web.Hubs
{
    public class BookHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BookHub>();
            context.Clients.All.displayStatus();
        }
    }
}