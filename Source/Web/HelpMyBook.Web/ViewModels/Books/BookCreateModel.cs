namespace HelpMyBook.Web.ViewModels.Books
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Common;

    public class BookCreateModel
    {
        public HttpPostedFileBase File { get; set; }

        [Required]
        [MaxLength(ValidationConstants.BookTitleMaximum)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ValidationConstants.BookDescriptionMaximum)]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Required money")]
        public decimal RequredMoney { get; set; }
    }
}
