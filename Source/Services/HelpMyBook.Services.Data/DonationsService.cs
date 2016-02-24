namespace HelpMyBook.Services.Data
{
    using HelpMyBook.Data.Common;
    using HelpMyBook.Data.Models;
    using HelpMyBook.Services.Data.Contracts;

    public class DonationsService : IDonationsService
    {
        private readonly IDbRepository<Donation> donations;

        public DonationsService(IDbRepository<Donation> donations)
        {
            this.donations = donations;
        }

        public Donation Add(Donation donation)
        {
            this.donations.Add(donation);
            this.donations.Save();
            return donation;
        }
    }
}
