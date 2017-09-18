using System;
using System.Collections.Generic;

namespace ecomerce.Models
{
    public class Customer : BaseEntity {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Order> Orders {get; set;}

        public Customer() {
            Orders = new List<Order>();
        }
    }
}