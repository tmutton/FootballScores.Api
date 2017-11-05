using System;
using System.ComponentModel.DataAnnotations;

namespace FootballScores.Api.Models
{
    public class Match
    {
        public Guid Id { get; set; }

        public Club HomeTeam { get; set; }

        public Club AwayTeam { get; set; }

        [Required]
        public DateTimeOffset KickOff { get; set; }
    }
}
