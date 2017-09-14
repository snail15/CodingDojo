using System.ComponentModel.DataAnnotations;
namespace weddingplanner2.Models
{
    public class UserViewModel : BaseEntity {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage="Nobody has no name")]
        [MinLength(2, ErrorMessage="Too Short")]
        public string Name {get; set;}

        [Required(ErrorMessage="Give us your email")]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [MinLength(4, ErrorMessage="At least 4 chars")]
        [DataType(DataType.Password)]
        public string Password { get; set;}

        [Compare("Password", ErrorMessage="They don't match!")]
        public string Confirm {get; set;}

    }
}