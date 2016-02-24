namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using HelpMyBook.Web.ViewModels.Error;

    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View(new ErrorImageOutputModel { ImagePath = @"~\Content\Images\Errors\404-opt.png" });
        }

        public ActionResult Forbidden()
        {
            this.Response.StatusCode = 403;
            return this.View();
        }

        public ActionResult InternalServerError()
        {
            this.Response.StatusCode = 500;
            return this.View();
        }
    }
}
