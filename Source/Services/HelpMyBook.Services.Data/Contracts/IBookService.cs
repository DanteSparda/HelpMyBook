using HelpMyBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMyBook.Services.Data.Contracts
{
    public interface IBookService
    {
        Book Create(Book book);

        Book Update(Book book);

        IQueryable<Book> GetBookDetails(int id);

        IQueryable<Book> GetBooks();
    }
}
