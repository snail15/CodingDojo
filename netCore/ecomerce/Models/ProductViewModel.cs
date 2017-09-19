using System;
using System.ComponentModel.DataAnnotations;
namespace ecomerce.Models
{
    public class ProductViewModel : BaseEntity {
        [Key]
        public int Id { get; set;}
        [Required(ErrorMessage="Customer needs to know the name of product")]
        [MinLength(2, ErrorMessage="Too Short")]
        public string Name {get; set;}

        [Required(ErrorMessage="Customer likes pirctures")]
        [Url(ErrorMessage="Need Url format")]
        public string Image {get; set;}

        [Required(ErrorMessage="Customer needs some info on this product??")]
        public string Description {get; set;}

        [Required(ErrorMessage="Well, how many of them??")]
        [Range(1, Int32.MaxValue, ErrorMessage="Give us at least 1 of them")]
        public int Stock {get; set;}
    }
}