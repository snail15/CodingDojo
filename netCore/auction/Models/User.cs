using System;
using System.Collections.Generic;

namespace auction.Models
{
    public class User : BaseEntity {

        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Username {get; set;}

        public string Password {get; set;}

        // public List<Bidding> Biddings {get; set;}

        public DateTime CreatedAt {get; set;}

        public int Wallet {get; set;}

       
        // public User(){
        //     Biddings = new List<Bidding>();
        // }
        
    }
}