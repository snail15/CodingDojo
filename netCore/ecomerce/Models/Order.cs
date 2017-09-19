using System;

namespace ecomerce.Models
{
    public class Order : BaseEntity {

        public int Id {get; set;}
        public int Quantity {get; set;}

        public int CustomerId {get; set;}
        public Customer Customer {get; set;}

        public int ProductId {get; set;}
        public Product Product {get; set;}

        public DateTime CreatedAt {get; set;}


    }
}