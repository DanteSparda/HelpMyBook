namespace HelpMyBook.Web.ViewModels.Books
{
    using System.Web;

    public class BookFileUpdateModel
    {
        public HttpPostedFileBase File { get; set; }

        public int BookId { get; set; }

        public int? BookFileId { get; set; }

        public bool Downloadable { get; set; }
    }
}
