using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperFootMVC.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("FirstName", TypeName = "nvarchar(50)")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName", TypeName = "nvarchar(50)")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Column("Email", TypeName = "nvarchar(50)")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",
         ErrorMessage = "Password must include: " +
            "Alphabetic character -- " +
            "Numeric character -- " +
            "Special character -- " +
            "Uppercase character -- " +
            "Lowercase character -- " +
            "Minimum of 6 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        public List<Game>? Games { get; set; }
    }
}
