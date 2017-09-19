using System;

namespace auction.Models
{
    public class Bidding : BaseEntity {
        public int Id {get; set;}

        public int UserId {get; set;}
        public User User {get; set;}

        public int AuctionId {get; set;}
        public Auction Auction {get; set;}

        public DateTime CreatedAt {get; set;}
        
    }
}