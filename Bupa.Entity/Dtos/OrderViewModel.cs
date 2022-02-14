using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Entity.Dtos
{
    public class OrderViewModel
    {
        /// <summary>
        /// order,product,customer tablosu birleştirildi gerekli yerler alındı
        /// tüm siparişleri listeleme procudurinde kullanıldı
        /// </summary>
        public int order_id { get; set; }
        public string customer_name { get; set; }   
        public string order_Date { get; set; }
        public string product_name { get; set; }
        public string Price { get; set; }
    }
}
