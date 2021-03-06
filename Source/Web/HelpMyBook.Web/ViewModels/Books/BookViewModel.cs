﻿namespace HelpMyBook.Web.ViewModels.Books
{
    using HelpMyBook.Data.Models;
    using HelpMyBook.Web.Infrastructure.Mapping;

    public class BookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual BookFileViewModel BookFile { get; set; }
    }
}
