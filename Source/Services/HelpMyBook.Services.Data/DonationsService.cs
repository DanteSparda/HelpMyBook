using HelpMyBook.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMyBook.Data.Models;
using HelpMyBook.Data.Common;

namespace HelpMyBook.Services.Data
{
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
