namespace HelpMyBook.Web.ViewModels.Home
{
    using HelpMyBook.Data.Models;
    using HelpMyBook.Web.Infrastructure.Mapping;

    public class BookFileViewModel : IMapFrom<BookFile>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
