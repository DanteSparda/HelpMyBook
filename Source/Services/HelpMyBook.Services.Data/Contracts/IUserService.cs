using HelpMyBook.Data.Common.Models;
using HelpMyBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMyBook.Services.Data.Contracts
{
    public interface IUserService
    {
        ApplicationUser GetUser(string id);
        int BindBookAndUser(string userId, int bookId);
        void Update(ApplicationUser user);
    }
}
