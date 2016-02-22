using HelpMyBook.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMyBook.Data.Models
{
    public class Donation: BaseModel<int>
    {
        public string DonatorId { get; set; }

        public ApplicationUser Donator { get; set; }

        public decimal Amount { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
