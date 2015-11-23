namespace Teleimot.Services.Data.Contracts
{
    using System.Linq;
    using Teleimot.Data.Models;

    public interface IGuessService
    {
        Guess MakeGuess(int gameId, string number, string userId);

        IQueryable<Guess> GetGuessDetails(int id);
    }
}
