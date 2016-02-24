namespace HelpMyBook.Services.Data.Contracts
{
    using HelpMyBook.Data.Models;

    public interface IFilesService
    {
        BookFile GetBookFile(int id);
    }
}
