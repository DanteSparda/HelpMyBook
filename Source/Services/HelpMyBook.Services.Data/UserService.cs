using HelpMyBook.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMyBook.Data.Models;
using HelpMyBook.Data.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace HelpMyBook.Services.Data
{
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
    }
}
