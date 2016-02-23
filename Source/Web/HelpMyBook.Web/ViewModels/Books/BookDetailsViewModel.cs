namespace HelpMyBook.Web.ViewModels.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using HelpMyBook.Data.Models;
    using HelpMyBook.Web.Infrastructure.Mapping;
    using UserProfile;

    public class BookDetailsViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public bool OwnerLooking { get; set; }

        [Required]
        [MaxLength(ValidationConstants.BookTitleMaximum)]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.BookDescriptionMaximum)]
        public string Description { get; set; }

        public decimal RequredMoney { get; set; }

        public UserMoneyModel MoneyPartialModel { get; set; }

        public virtual BookFile BookFile { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
