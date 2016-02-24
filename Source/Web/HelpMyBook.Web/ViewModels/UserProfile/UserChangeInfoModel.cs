namespace HelpMyBook.Web.ViewModels.UserProfile
{
    using System.ComponentModel.DataAnnotations;

    public class UserChangeInfoModel
    {
        public string Id { get; set; }

        [Url]
        public string AvatarUrl { get; set; }

        [MaxLength(120)]
        public string Name { get; set; }

        [MaxLength(500)]
        [Display(Name="Personal Info")]
        public string PersonalInfo { get; set; }
    }
}
