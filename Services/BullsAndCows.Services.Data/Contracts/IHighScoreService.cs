namespace Teleimot.Services.Data.Contracts
{
    using System.Linq;
    using Teleimot.Data.Models;

    public interface IHighScoreService
    {
        void UpdateRank(string userId, bool won);

        IQueryable<User> GetLatest();
    }
}
