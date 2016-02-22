namespace HelpMyBook.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using HelpMyBook.Common;
    using HelpMyBook.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
