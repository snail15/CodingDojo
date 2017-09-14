using System.ComponentModel.DataAnnotations;
using restaurant.Validators;
using System;
namespace restaurant.Models
{
    public class Review : BaseEntity {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="You Need Restaurant Name")]
        public string RestaurantName { get; set;}

        [Required(ErrorMessage="You Need Your Name??")]
        public string ReviewerName { get; set; }

        [Required(ErrorMessage="Aren't you here to leave a review??")]
        public string Description {get; set;}

        [FutureDate(ErrorMessage="You can't be from the future")]
        [Required(ErrorMessage="You need a date")]
        public DateTime Date { get; set; }

        public string Star { get; set; }
    }
}