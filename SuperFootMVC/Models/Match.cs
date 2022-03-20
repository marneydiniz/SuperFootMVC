using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFootMVC.Models
{
    [Table("Matches")]
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Round")]
        public int RoundId { get; set; }
        public Round Round { get; set; }

        [Required]
        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        [Required]
        [ForeignKey("VisitantTeam")]
        public int VisitantTeamId { get; set; }
        public Team VisitantTeam { get; set; }

        [Required]
        public int ScoreHomeTeam { get; set; } = 0;

        [Required]
        public int ScoreVisitantTeam { get; set; } = 0;
    }
}
