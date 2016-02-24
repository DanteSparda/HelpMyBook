namespace HelpMyBook.Data.Models
{
    using HelpMyBook.Data.Common.Models;

    public class Donation : BaseModel<int>
    {
        public string DonatorId { get; set; }

        public ApplicationUser Donator { get; set; }

        public decimal Amount { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
