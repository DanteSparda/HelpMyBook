namespace HelpMyBook.Web.Controllers
{
    using System.Web.Mvc;

    public class PartialsDistributorController : BaseController
    {
        [HttpGet]
        public ActionResult FileUpload()
        {
            return this.PartialView("_FileUpload");
        }
    }
}
