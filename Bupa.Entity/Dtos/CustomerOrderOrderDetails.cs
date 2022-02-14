using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Entity.Dtos
{
    public class CustomerOrderOrderDetails
    {
     /// <summary>
     /// order,order_detail,customer tablosu birleştirildi 
     /// procudure ve triggerda kullanılmak üzere
     /// gerekli yerler alındı
     /// müşeteri siparişi için
     /// </summary>
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Job { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Postal_Code { get; set; }
        
        public string Card_name { get; set; }
        public string Card_number { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
        public string Taksit { get; set; }
        public string Order_Date { get; set; }
        public string Price { get; set; }
        public int product_id { get; set; }
    }
}
