using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindCreated.Entities
{
    public class CustomerDemo
    {
        public CustomerDemo()
        {
            OrdersDemo = new List<OrdersDemo>(); //Null Ref Hatası almamak için new işlemi yaptık
        }

        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public int OrderCount { get; set; }
        public List<OrdersDemo> OrdersDemo { get; set; }
    }

    public class OrdersDemo
    {
        
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductDemo> ProductDemos { get; set; }
    }

    public class ProductDemo
    {
        public string ProductName { get; set; }
    }
}
