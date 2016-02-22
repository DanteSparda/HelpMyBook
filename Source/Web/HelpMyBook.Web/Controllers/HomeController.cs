namespace HelpMyBook.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Home;
    using System.Text.RegularExpressions;
    using Common;
    using System.Web.UI.WebControls;
    public class HomeController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly ICategoriesService jokeCategories;
        private readonly IBookService books;
        private readonly IFilesService files;

        public HomeController(
            IJokesService jokes,
            IFilesService files,
            ICategoriesService jokeCategories,
            IBookService books)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
            this.books = books;
            this.files = files;
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

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Downloads()
        {
            var books = this.books.GetBooks().To<BookViewModel>().ToList();

            return this.View(books);
        }

        [HttpGet]
        public FileContentResult DownloadBook(int id)
        {
            var bookToDownload = this.files.GetBookFile(id);

            var name = $"{bookToDownload.Name}.{bookToDownload.FileExtension}";

            return this.File(bookToDownload.Content, "application/octet-stream", name);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var userId = this.User.Identity.GetUserId();

            var book = new Book
            {
                CreatorId = userId
            };

            if (file != null)
            {
                int idx = file.FileName.LastIndexOf('.');
                if (idx == -1)
                {
                    this.ModelState.AddModelError(string.Empty, "File must have an extention!");
                    return this.View();
                }

                var fileName = file.FileName.Substring(0, idx);
                var fileExtention = file.FileName.Substring(idx + 1);

                if (!Regex.IsMatch(fileExtention, ValidationConstants.FileExtentionRegex))
                {
                    this.ModelState.AddModelError(string.Empty, "File extention not supported!");
                    return this.View();
                }

                using (var memory = new MemoryStream())
                {
                    file.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    book.BookFile = new BookFile
                    {
                        Content = content,
                        Name = fileName,
                        FileExtension = fileExtention
                    };
                }
            }

            var creationResult = this.books.Create(book);

            return this.RedirectToAction("Index");
        }
    }
}
