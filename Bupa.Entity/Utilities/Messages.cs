using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Entity.Utilities
{
    public static class Messages
    {
        // Messages.Customer.NotFound()
        public static class Customer
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir müşteri bulunamadı.";
                return "Böyle bir müşteri bulunamadı.";
            }

            public static string Add(string customerName)
            {
                return $"{customerName} adlı müşteri başarıyla eklenmiştir.";
            }

        }
    }

}