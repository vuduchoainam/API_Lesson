﻿namespace Lessonapi.Data
{
    public class OrderDetail
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }
        
        //relationship
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
