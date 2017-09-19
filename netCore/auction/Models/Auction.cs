using System;
using System.Collections.Generic;

namespace auction.Models
{
    public class Auction : BaseEntity {
        public int Id {get; set;}
        
        public string CreatedUser {get; set;}
        public string ProductName {get; set;}
        public string Description {get; set;}
        public DateTime EndDate {get; set;}
        public int Bid {get; set;}

        public string HighestBidder {get; set;}
        public DateTime CreatedAt {get; set;}

        
        // public List<Bidding> Bidders {get; set;}

        // public Auction() {
        //     Bidders = new List<Bidding>();
        // }

    }
}