namespace HelpMyBook.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using HelpMyBook.Common;
    using HelpMyBook.Data.Models;
    using HelpMyBook.Services.Data.Contracts;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using ViewModels.Books;
    using ViewModels.UserProfile;
    public class BooksController : BaseController
    {
        private readonly IUserService users;
        private readonly IBookService books;
        private readonly IFilesService files;
        private readonly IDonationsService donations;

        public BooksController(IUserService users, IBookService books, IFilesService files, IDonationsService donations)
        {
            this.users = users;
            this.books = books;
            this.files = files;
            this.donations = donations;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            //    var user = this.users.GetUser(this.User.Identity.GetUserId());
            //    if (user.BookId != null)
            //    {
            //        this.TempData.Clear();
            //        this.TempData[GlobalConstants.MessageNameError] = "You've already created a book!";

            //        return this.Redirect("/");
            //    }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreateModel model, bool downloadable)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.Identity.GetUserId();

            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                RequredMoney = model.RequredMoney
            };

            if (model.File != null)
            {
                int idx = model.File.FileName.LastIndexOf('.');
                if (idx == -1)
                {
                    this.ModelState.AddModelError(string.Empty, "File must have an extention!");
                    return this.View();
                }

                var fileName = model.File.FileName.Substring(0, idx);
                var fileExtention = model.File.FileName.Substring(idx + 1);

                if (!Regex.IsMatch(fileExtention, ValidationConstants.FileExtentionRegex))
                {
                    this.ModelState.AddModelError(string.Empty, "File extention not supported!");
                    return this.View();
                }

                using (var memory = new MemoryStream())
                {
                    model.File.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    book.BookFile = new BookFile
                    {
                        Downloadable = downloadable,
                        Content = content,
                        Name = fileName,
                        FileExtension = fileExtention
                    };
                }
            }

            var user = this.users.GetUser(this.User.Identity.GetUserId());

            var creationResult = this.books.Create(book);

            this.users.BindBookAndUser(user.Id, creationResult.Id);

            this.TempData.Clear();

            this.TempData[GlobalConstants.MessageNameSuccess] = "You've successfuly created a book!";

            return this.RedirectToAction("Details", new { id = creationResult.Id });
        }

        [HttpGet]
        public ActionResult Downloads()
        {
            var books = this.books.GetBooks().To<BookViewModel>().ToList();

            return this.View(books);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var viewmodel = this.books.GetBookDetails(id).To<BookDetailsViewModel>().FirstOrDefault();

            if (this.User.Identity.IsAuthenticated)
            {
                var user = this.users.GetUser(this.User.Identity.GetUserId());
                if (user.BookId == viewmodel.Id)
                {
                    viewmodel.OwnerLooking = true;
                }

                viewmodel.MoneyPartialModel = new UserMoneyModel()
                {
                    UserId = user.Id,
                    BookId = viewmodel.Id,
                    Money = user.Money
                };
            }

            return this.View(viewmodel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var viewmodel = this.books.GetBookDetails(id).To<BookDetailsViewModel>().FirstOrDefault();

            var user = this.users.GetUser(this.User.Identity.GetUserId());
            if (user.BookId != id)
            {
                this.TempData[GlobalConstants.MessageNameError] = "You are not allowed to edit this book!";
                return this.View("Details", new { id = id });
            }

            return this.View(viewmodel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBookInfo(BookDetailsViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Edit", model);
            }

            var book = this.books.GetBookDetails(model.Id).FirstOrDefault();

            book.Title = model.Title;
            book.Description = model.Description;

            var creationResult = this.books.Update(book);

            this.TempData.Clear();
            this.TempData[GlobalConstants.MessageNameSuccess] = "You've successfuly created a book!";

            return this.RedirectToAction("Details", new { id = creationResult.Id });

        }

        [HttpGet]
        [Authorize]
        public ActionResult FileUpdate(int bookId)
        {
            var fileId = this.books.GetBookDetails(bookId).FirstOrDefault().BookFileId;
            var model = new BookFileUpdateModel
            {
                BookFileId = fileId,
                BookId = bookId
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult FileUpdate(BookFileUpdateModel model)
        {
            if (model.File != null)
            {
                int idx = model.File.FileName.LastIndexOf('.');
                if (idx == -1)
                {
                    this.ModelState.AddModelError(string.Empty, "File must have an extention!");
                    return this.View("FileUpdate", model);
                }

                var fileName = model.File.FileName.Substring(0, idx);
                var fileExtention = model.File.FileName.Substring(idx + 1);

                if (!Regex.IsMatch(fileExtention, ValidationConstants.FileExtentionRegex))
                {
                    this.ModelState.AddModelError(string.Empty, "File extention not supported!");
                    return this.View("FileUpdate", model);
                }

                using (var memory = new MemoryStream())
                {
                    model.File.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    /*
                    take book
                    see if has file id
                    if not book.bookfile = new bookfile
                    save
                    if has 
                    book.bookfile.props = blabla
                    */
                    var book = this.books.GetBookDetails(model.BookId).FirstOrDefault();
                    if (book.BookFileId == null)
                    {
                        book.BookFile = new BookFile
                        {
                            Downloadable = model.Downloadable,
                            Content = content,
                            Name = fileName,
                            FileExtension = fileExtention
                        };
                    }
                    else
                    {
                        book.BookFile.Downloadable = model.Downloadable;
                        book.BookFile.Content = content;
                        book.BookFile.Name = fileName;
                        book.BookFile.FileExtension = fileExtention;
                    }

                    var result = books.Update(book);

                }
            }

            return this.RedirectToAction("Details", new { id = model.BookId });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Contribute(UserMoneyModel model)
        {
            if (model.Money < model.Contribution)
            {
                this.TempData[GlobalConstants.MessageNameError] = "You can't contribute more than you have!";
                return this.RedirectToAction("Details", new { id = model.BookId });
            }

            if (model.Contribution == 0)
            {
                this.TempData[GlobalConstants.MessageNameError] = "You can't contribute 0$!";
                return this.RedirectToAction("Details", new { id = model.BookId });
            }

            var user = this.users.GetUser(model.UserId);

            var donation = new Donation()
            {
                DonatorId = user.Id,
                Amount = model.Contribution,
                BookId = model.BookId
            };

            this.donations.Add(donation);
            user.Money -= model.Contribution;
            this.users.Update(user);
            this.TempData[GlobalConstants.MessageNameSuccess] = $"Thank you for your donation ({model.Contribution})";
            return this.RedirectToAction("Details", new { id = model.BookId });
        }
    }
}
