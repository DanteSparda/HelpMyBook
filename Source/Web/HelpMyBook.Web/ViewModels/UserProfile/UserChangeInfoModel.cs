using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMyBook.Web.ViewModels.UserProfile
{
    public class UserChangeInfoModel
    {
        public string Id { get; set; }

        [Url]
        public string AvatarUrl { get; set; }

        [MaxLength(120)]
        public string Name { get; set; }

        //[MinLength(3)]
        //public string Username { get; set; }

        [MaxLength(500)]
        [Display(Name="Personal Info")]
        public string PersonalInfo { get; set; }
    }
}
