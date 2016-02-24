namespace HelpMyBook.Web.Controllers
{
    using System.Web.Mvc;
    using HelpMyBook.Services.Data.Contracts;

    public class FilesController : BaseController
    {
        private IFilesService files;

        public FilesController(IFilesService files)
        {
            this.files = files;
        }

        [HttpGet]
        public FileContentResult DownloadBook(int id)
        {
            var bookToDownload = this.files.GetBookFile(id);
            var name = $"{bookToDownload.Name}.{bookToDownload.FileExtension}";
            return this.File(bookToDownload.Content, "application/octet-stream", name);
        }
    }
}
