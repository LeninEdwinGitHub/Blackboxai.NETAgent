using System;
using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
    }
}
