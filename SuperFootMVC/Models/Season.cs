using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFootMVC.Models
{
    [Table("Seasons")]
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }

        public List<Championship>? Championships { get; set; }
    }
}
