namespace HelpMyBook.Services.Data
{
    using System.Linq;
    using HelpMyBook.Data.Common;
    using HelpMyBook.Data.Models;
    using HelpMyBook.Services.Data.Contracts;

    public class FilesService : IFilesService
    {
        private readonly IDbRepository<BookFile> bookfiles;

        public FilesService(IDbRepository<BookFile> bookfiles)
        {
            this.bookfiles = bookfiles;
        }

        public BookFile GetBookFile(int id)
        {
            var book = this.bookfiles.All().Where(x => x.Id == id).FirstOrDefault();
            return book;
        }
    }
}
