namespace HelpMyBook.Services.Data.Contracts
{
    using HelpMyBook.Data.Models;

    public interface IDonationsService
    {
        Donation Add(Donation donation);
    }
}
