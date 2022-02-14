using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bupa.Admin.Models
{
    public class OrderModel
    {
        public int order_Id { get; set; }
        public int customer_Id { get; set; }
        public DateTime order_Date { get; set; }
        public object customer { get; set; }
        public List<object> orderDetails { get; set; }
    }
}
