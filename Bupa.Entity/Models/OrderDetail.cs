
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Entity.Models
{
    public class OrderDetail
    {
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }      
        public string Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
