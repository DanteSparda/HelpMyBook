namespace HelpMyBook.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Books;

    public class HomeController : BaseController
    {
        private readonly IUserService users;
        private readonly IBookService books;

        public HomeController(
            IBookService books,
            IUserService users)
        {
            this.books = books;
            this.users = users;
        }

        public ActionResult Index()
        {
            var viewModel = this.Cache.Get(
                    "categories",
                    () => this.books.GetHourlyBooks(3).To<BookViewModel>().ToList(),
                    60 * 60);

            return this.View(viewModel);
        }
    }
}
