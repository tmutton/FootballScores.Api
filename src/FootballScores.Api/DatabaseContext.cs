using FootballScores.Api;
using FootballScores.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballScores.Api
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Club> Clubs { get; set; }
    }
}