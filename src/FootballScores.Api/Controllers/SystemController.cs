using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FootballScores.Api.Controllers
{
    [Route("api/[controller]")]
    public class SystemController
    {
        // GET: api/system
        [HttpGet]
        public Dictionary<string, string> Get()
        {
            return new Dictionary<string, string>()
            {
                {
                    "Name", "FootballScores.Api"
                },
                {
                    "Version", "1.0.0"
                }
            };
        }
    }
}