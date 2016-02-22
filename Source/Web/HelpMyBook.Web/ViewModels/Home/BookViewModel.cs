using HelpMyBook.Data.Models;
using HelpMyBook.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMyBook.Web.ViewModels.Home
{
    public class BookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public virtual BookFileViewModel BookFile { get; set; }
    }
}
