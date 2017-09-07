using System.ComponentModel.DataAnnotations;

namespace formsubmission.Models
{
    public class User : BaseEnitity {
        [Required]
        [MinLength(4)]
        public string FirstName;
        [Required]
        [MinLength(4)]
        public string LastName;
        [Required]
        [Range(1, 200)]
        public int Age;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress;
        [Required]
        [MinLength(8)]
        public string Password;


    }
}