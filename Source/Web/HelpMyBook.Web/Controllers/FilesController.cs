using HelpMyBook.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpMyBook.Web.Controllers
{
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
