using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FootballScores.Api.Controllers
{
    [Route("api/clubs")]
    public class ClubsController
    {
        private DatabaseContext _dbContext;

        public ClubsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/clubs
        [HttpGet]
        public IEnumerable<Models.Club> Get()
        {
            return _dbContext.Clubs;
        }

        // GET api/clubs/{id}
        [HttpGet("{id}")]
        public Models.Club Get(string shortCode)
        {
            return _dbContext.Clubs.Where(x => x.ShortCode == shortCode).FirstOrDefault();
        }
    }
}
