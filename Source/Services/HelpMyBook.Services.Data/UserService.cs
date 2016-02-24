namespace HelpMyBook.Services.Data
{
    using HelpMyBook.Data.Models;
    using HelpMyBook.Services.Data.Contracts;
    using Microsoft.AspNet.Identity;

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> users;

        public UserService(UserManager<ApplicationUser> users)
        {
            this.users = users;
        }

        public int BindBookAndUser(string userId, int bookId)
        {
            var user = this.users.FindById(userId);
            user.BookId = bookId;
            this.users.Update(user);
            return bookId;
        }

        public ApplicationUser GetUser(string id)
        {
            var user = this.users.FindById(id);
            return user;
        }

        public void Update(ApplicationUser user)
        {
            this.users.Update(user);
        }
    }
}
