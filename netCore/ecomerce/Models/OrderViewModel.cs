using System;
using System.ComponentModel.DataAnnotations;
namespace ecomerce.Models
{
    public class OrderViewModel : BaseEntity {
        [Key]
        public int Id { get; set;}

        [Required(ErrorMessage="How Many??")]
        [Range(1, Int32.MaxValue, ErrorMessage="Need to order at least one!!")]
        public int Quantity {get; set;}


        public int CustomerId {get; set;}
       

        public int ProductId {get; set;}
    

    }
}