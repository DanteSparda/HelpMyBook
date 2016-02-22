namespace HelpMyBook.Web.Controllers
{
    using System.Web.Mvc;
    using HelpMyBook.Services.Data.Contracts;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using Data.Models;
    using ViewModels.UserProfile;
    public class UserProfileController : BaseController
    {
        private IUserService users;

        public UserProfileController(IUserService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult Info()
        {
            var id = this.User.Identity.GetUserId();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserInfoModel>());
            var mapper = config.CreateMapper();

            var user = this.users.GetUser(id);
            var viewmodel = mapper.Map<UserInfoModel>(user);
            return this.View(viewmodel);
        }
    }
}
