using System;
using System.ComponentModel.DataAnnotations;
namespace auction.Models
{
    public class AuctionViewModel : BaseEntity {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage="You want to have a Product Name")]
        [MinLength(3, ErrorMessage="At least 3 chars!")]
        public string ProductName {get; set;}


        [Required(ErrorMessage="Want Description?")]
        [MinLength(10, ErrorMessage="At least 10 chars!")]
        public string Description {get; set;}

        [Required(ErrorMessage="You need a price?")]
        [Range(1, Int32.MaxValue, ErrorMessage="Has to be at least a dollar!")]
        public int Bid {get; set;}

        [Required(ErrorMessage="When does it end?")]
        public string EndDate{get; set;}



    }
}