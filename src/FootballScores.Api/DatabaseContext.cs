using FootballScores.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballScores.Api
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
        { }

        public DbSet<Clubs> Events { get; set; }
    }
}