using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bupa.Entity.Models;

namespace Bupa.Entity.Models
{
    public class Order
    {
        public Order()
        {
           // OrderDetails = new HashSet<OrderDetail>();
        }
        public int Order_Id { get; set; }
        public int Customer_Id { get; set; }
        public string Order_Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
