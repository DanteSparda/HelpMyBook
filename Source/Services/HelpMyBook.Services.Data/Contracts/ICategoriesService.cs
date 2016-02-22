namespace HelpMyBook.Services.Data.Contracts
{
    using System.Linq;

    using HelpMyBook.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
