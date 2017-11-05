namespace FootballScores.Api
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public static class FootballScoresExtensions
    {
        public static void EnsureSeedData(this DatabaseContext context)
        {
            if (!context.Database.GetPendingMigrations().Any())
            {
                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(SeedData.Clubs);

                    context.SaveChanges();
                }
            }
        }
    }
}