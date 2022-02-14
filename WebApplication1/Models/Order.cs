using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Order
    {
        public int order_id { get; set; }
        public string customer_name { get; set; }
        public string order_Date { get; set; }
        public string product_name { get; set; }
        public string Price { get; set; }
    }
}