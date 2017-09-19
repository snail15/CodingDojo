using System.ComponentModel.DataAnnotations;
namespace auction.Models
{
    public class UserModelView : BaseEntity {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage="You want to have a Username")]
        [MinLength(3, ErrorMessage="At least 3 chars!")]
        [MaxLength(20, ErrorMessage="It's too long!!")]
        public string Username {get; set;}

        [Required(ErrorMessage="You want Password?")]
        [MinLength(8, ErrorMessage="At least 8 chars!")]
        [DataType(DataType.Password)]
        public string Password {get; set;}

        [Required(ErrorMessage="Plase confirm password")]
        [Compare("Password", ErrorMessage="It doesn't match!! Typo?")]
        public string Confirm {get; set;}

        [Required(ErrorMessage="Faceless God?")]
        public string FirstName {get; set;}
        [Required(ErrorMessage="Faceless God?")]
        public string LastName {get; set;}


    }
}