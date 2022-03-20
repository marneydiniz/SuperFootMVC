using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFootMVC.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(50)")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User")]
        public int UserId { get; set; }
        public User User { get; set; }
        
        //public List<Championship> Championships { get; set; }
        
        public List<Season>? Seasons { get; set; }
    }
}
