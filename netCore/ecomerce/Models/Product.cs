using System;
using System.Collections.Generic;

namespace ecomerce.Models
{
    public class Product : BaseEntity {
        public int Id {get; set;}

        public string Name {get; set;}
        public int Stock {get; set;}

        public List<Order> Customers {get; set;}

        public DateTime CreatedAt {get; set;}

        public string Image {get; set;}

        public string Description {get; set;}

        public Product() {
            Customers = new List<Order>();
        }


    }
}