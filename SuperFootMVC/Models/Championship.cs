using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFootMVC.Models
{
    [Table("Championships")]
    public class Championship
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


        [ForeignKey("ChampionTeam")]
        public int? ChampionTeamId { get; set; }
        public Team ChampionTeam { get; set; }


        public List<Season> Seasons { get; set; }

        public List<Round>? Rounds { get; set; }

        public List<Team>? Teams { get; set; }

    }
}
