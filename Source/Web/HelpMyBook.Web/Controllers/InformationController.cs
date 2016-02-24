namespace HelpMyBook.Web.Controllers
{
    using System.Web.Mvc;

    public class InformationController : BaseController
    {
        [HttpGet]
        public ActionResult Contacts()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return this.View();
        }
    }
}
