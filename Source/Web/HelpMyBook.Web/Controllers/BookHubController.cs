namespace HelpMyBook.Web.Controllers
{
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using Hubs;
    using Services.Data.Contracts;

    public class BookHubController : BaseController
    {
        private readonly IBookService books;
        private BookHubService hubService = new BookHubService();

        public BookHubController(IBookService books)
        {
            this.books = books;
        }

        [HttpGet]
        public JsonResult Result(int id)
        {
            var result = this.hubService.GetData(id).ToList();
            decimal totalMoney = 0;

            for (int i = 0; i < result.Count; i++)
            {
                totalMoney += result[i].Amount;
            }

            return this.Json(totalMoney.ToString("N", new CultureInfo("en-US")), JsonRequestBehavior.AllowGet);
        }
    }
}
