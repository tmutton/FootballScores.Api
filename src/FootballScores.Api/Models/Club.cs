using System.ComponentModel.DataAnnotations;

namespace FootballScores.Api.Models
{
    public class Club
    {
        [Key]
        [Required]
        [MaxLength(3)]
        public string ShortCode { get; set; }

        [Required]
        public string Name { get; set; }
    }
}