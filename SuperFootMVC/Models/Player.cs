using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFootMVC.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(50)")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
