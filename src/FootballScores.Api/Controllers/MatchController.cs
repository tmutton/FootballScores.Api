using FootballScores.Api.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FootballScores.Api.Controllers
{
    [Route("api/match")]
    public class MatchController
    {
        private DatabaseContext _dbContext;

        public MatchController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public void Post([FromBody]CreateMatch SaveMatch)
        {
            var home = _dbContext.Clubs.Where(x => x.ShortCode == SaveMatch.HomeTeam).FirstOrDefault();
            var away = _dbContext.Clubs.Where(x => x.ShortCode == SaveMatch.AwayTeam).FirstOrDefault();
            
            var match = new Models.Match()
            {
                Id = Guid.NewGuid(),
                HomeTeam = home,
                AwayTeam = away,
                KickOff = SaveMatch.KickOff
            };

            _dbContext.Add(match);

            _dbContext.SaveChanges();
        }

        [HttpGet]
        public Models.Match Get(Guid id)
        {
            return _dbContext.Matches.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
