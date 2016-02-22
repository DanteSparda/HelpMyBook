using HelpMyBook.Common;
using HelpMyBook.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMyBook.Data.Models
{
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
