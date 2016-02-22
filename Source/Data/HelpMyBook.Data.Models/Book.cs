using HelpMyBook.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMyBook.Data.Models
{
    public class Book : BaseModel<int>
    {
        public override int Id { get; set; }

        public int? BookFileId { get; set; }

        public virtual BookFile BookFile { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
