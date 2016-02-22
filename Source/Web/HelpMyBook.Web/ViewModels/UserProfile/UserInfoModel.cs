namespace HelpMyBook.Web.ViewModels.UserProfile
{
    using HelpMyBook.Data.Models;
    using HelpMyBook.Web.Infrastructure.Mapping;

    public class UserInfoModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string AvatarUrl { get; set; }

        public string Name { get; set; }

        public int? BookId { get; set; }

        public string Username { get; set; }

        public decimal Money { get; set; }

        public string PersonalInfo { get; set; }
    }
}
