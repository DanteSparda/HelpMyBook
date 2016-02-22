namespace HelpMyBook.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly IUserService users;
        private readonly ICategoriesService jokeCategories;
        private readonly IBookService books;

        public HomeController(
            IJokesService jokes,
            ICategoriesService jokeCategories,
            IBookService books,
            IUserService users)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
            this.books = books;
            this.users = users;
        }

        public ActionResult Index()
        {
            var jokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
                    30 * 60);
            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
                Categories = categories
            };

            return this.View(viewModel);
        }
    }
}
