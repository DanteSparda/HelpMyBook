namespace HelpMyBook.Services.Data.Contracts
{
    using System.Linq;
    using HelpMyBook.Data.Models;

    public interface IBookService
    {
        Book Create(Book book);

        Book Update(Book book);

        IQueryable<Book> GetBookDetails(int id);

        IQueryable<Book> GetBooks();

        IQueryable<Book> GetHourlyBooks(int id);

        IQueryable<Book> GetDownloadableBooks();
    }
}
