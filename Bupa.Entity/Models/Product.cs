using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Entity.Models
{
   public class Product
    {
        public Product()
        {
            //OrderDetails = new HashSet<OrderDetail>();
        }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
