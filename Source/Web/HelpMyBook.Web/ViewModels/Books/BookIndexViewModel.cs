namespace HelpMyBook.Web.ViewModels.Books
{
    using HelpMyBook.Data.Models;
    using HelpMyBook.Web.Infrastructure.Mapping;

    public class BookIndexViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual BookFile BookFile { get; set; }
    }
}
