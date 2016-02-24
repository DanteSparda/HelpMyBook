namespace HelpMyBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HelpMyBook.Common;
    using HelpMyBook.Data.Common.Models;

    public class Book : BaseModel<int>
    {
        public Book()
        {
            this.Donations = new HashSet<Donation>();
        }

        public override int Id { get; set; }

        [MaxLength(ValidationConstants.BookTitleMaximum)]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.BookDescriptionMaximum)]
        public string Description { get; set; }

        public decimal RequredMoney { get; set; }

        public int? BookFileId { get; set; }

        public virtual BookFile BookFile { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
