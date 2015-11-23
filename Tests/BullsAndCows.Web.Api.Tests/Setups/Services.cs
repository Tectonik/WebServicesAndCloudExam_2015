namespace Teleimot.Web.Api.Tests.Setups
{
    using Teleimot.Services.Data;
    using Teleimot.Services.Data.Contracts;

    public static class Services
    {
        public static IHighScoreService GetHighScoreService()
        {
            return new HighScoreService(Repositories.GetUsersRepository());
        }

        public static IGamesService GetGamesService()
        {
            return new GamesService(null, Repositories.GetGamesRepository(), null);
        }

        public static IGuessService GetGuessService()
        {
            return new GuessService(null, null);
        }
    }
}
