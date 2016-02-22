namespace HelpMyBook.Services.Data.Contracts
{
    using System.Linq;

    using HelpMyBook.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
