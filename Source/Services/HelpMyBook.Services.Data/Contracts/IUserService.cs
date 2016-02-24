namespace HelpMyBook.Services.Data.Contracts
{
    using HelpMyBook.Data.Models;

    public interface IUserService
    {
        ApplicationUser GetUser(string id);

        int BindBookAndUser(string userId, int bookId);

        void Update(ApplicationUser user);
    }
}
