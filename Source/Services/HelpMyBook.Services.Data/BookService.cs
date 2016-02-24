namespace HelpMyBook.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HelpMyBook.Data.Common;
    using HelpMyBook.Data.Models;
    using HelpMyBook.Services.Data.Contracts;

    public class BookService : IBookService
    {
        private readonly IDbRepository<Book> books;
        private readonly IDbRepository<BookFile> bookfiles;

        public BookService(IDbRepository<Book> books, IDbRepository<BookFile> bookfiles)
        {
            this.books = books;
            this.bookfiles = bookfiles;
        }

        public Book Create(Book book)
        {
            this.books.Add(book);
            this.books.Save();
            return book;
        }

        public IQueryable<Book> GetBooks()
        {
            return this.books.All();
        }

        public IQueryable<Book> GetBookDetails(int id)
        {
            return this.books.All().Where(x => x.Id == id);
        }

        public Book Update(Book book)
        {
            this.books.Update(book);
            this.books.Save();
            return book;
        }

        public IQueryable<Book> GetHourlyBooks(int id)
        {
            return this.books.All().OrderBy(x => Guid.NewGuid()).Take(3);
        }

        public IQueryable<Book> GetDownloadableBooks()
        {
            return this.books.All().Where(x => x.BookFile.Downloadable == true);
        }
    }
}
