namespace HelpMyBook.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using HelpMyBook.Services.Data.Contracts;
    using Microsoft.AspNet.Identity;
    using ViewModels.UserProfile;
    using Common;
    [Authorize]
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

        [HttpGet]
        public ActionResult ChangeInfo()
        {
            var id = this.User.Identity.GetUserId();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserChangeInfoModel>());
            var mapper = config.CreateMapper();

            var user = this.users.GetUser(id);
            var viewmodel = mapper.Map<UserChangeInfoModel>(user);
            return this.View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeInfo(UserChangeInfoModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = this.User.Identity.GetUserId();
            var user = this.users.GetUser(id);
            if (model.AvatarUrl != null)
            {
                user.AvatarUrl = model.AvatarUrl;
            }

            if (model.PersonalInfo != null)
            {
                user.PersonalInfo = model.PersonalInfo;
            }

            if (model.Name != null)
            {
                user.Name = model.Name;
            }
            
            this.users.Update(user);

            this.TempData[GlobalConstants.MessageNameSuccess] = "You've successfuly updated your profile!";

            return this.RedirectToAction("Info");
        }
    }
}
