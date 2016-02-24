namespace HelpMyBook.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class BookHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BookHub>();
            context.Clients.All.displayStatus();
        }
    }
}
