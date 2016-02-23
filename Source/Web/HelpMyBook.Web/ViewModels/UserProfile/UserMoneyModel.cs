using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMyBook.Web.ViewModels.UserProfile
{
    public class UserMoneyModel
    {
        public string UserId { get; set; }

        public int BookId { get; set; }

        public decimal Money { get; set; }

        public decimal Contribution { get; set; }
    }
}
