namespace HelpMyBook.Web.ViewModels.Books
{
    using System.Collections.Generic;

    public class BookIndexDataModel
    {
        public IEnumerable<BookIndexViewModel> Books { get; set; }

        public bool HasBook { get; set; }
    }
}
