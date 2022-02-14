using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bupa.Admin.Models
{
    public class ProductAdd
    {
        public int product_Id { get; set; }
        public string product_Name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public List<object> orderDetails { get; set; }
    }
}
