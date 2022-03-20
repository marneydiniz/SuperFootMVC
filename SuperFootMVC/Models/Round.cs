using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFootMVC.Models
{
    [Table("Rounds")]
    public class Round
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }

        [ForeignKey("Championship")]
        public int ChampionshipId { get; set; }
        public Championship Championship { get; set; }

        public List<Match> Matches { get; set; }
    }
}
