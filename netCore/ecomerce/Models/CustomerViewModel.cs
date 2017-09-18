using System.ComponentModel.DataAnnotations;
namespace ecomerce.Models
{
    public class CustomerViewModel : BaseEntity {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage="Nobody has no name")]
        [MinLength(2, ErrorMessage="Too Short")]
        public string Name {get; set;}

    }
}