using System;

namespace FootballScores.Api.DTO
{
    public class CreateMatch
    {
        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }
        
        public DateTimeOffset KickOff { get; set; }
    }
}
