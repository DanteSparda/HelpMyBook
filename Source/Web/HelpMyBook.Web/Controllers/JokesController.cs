namespace HelpMyBook.Web.Controllers
{
    using System.Web.Mvc;

    using HelpMyBook.Services.Data;
    using HelpMyBook.Web.Infrastructure.Mapping;
    using HelpMyBook.Web.ViewModels.Home;
    using Services.Data.Contracts;

    public class JokesController : BaseController
    {
        private readonly IJokesService jokes;

        public JokesController(
            IJokesService jokes)
        {
            this.jokes = jokes;
        }

        public ActionResult ById(string id)
        {
            var joke = this.jokes.GetById(id);
            var viewModel = this.Mapper.Map<JokeViewModel>(joke);
            return this.View(viewModel);
        }
    }
}
