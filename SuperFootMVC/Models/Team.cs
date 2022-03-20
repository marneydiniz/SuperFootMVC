using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFootMVC.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(50)")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Column("Description", TypeName = "nvarchar(500)")]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [ForeignKey("Championship")]
        public int ChampionshipId { get; set; }
        public Championship Championship { get; set; }

        public List<Championship>? WinningChampionships { get; set; }

        public virtual List<Match> MatchHomeTeams { get; set; }
        public virtual List<Match> MatchVisitantTeams { get; set; }

        public List<Player> Players { get; set; }

        public int Victories { get; set; } = 0;
        public int Defeats { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int GoalsScored { get; set; } = 0;
        public int GoalsConceded { get; set; } = 0;
        public int DefenseScore { get; set; } = 0;
        public int AttackScore { get; set; } = 0;
    }
}
