using System.Collections.Generic;

namespace Bupa.WebUI.Models
{
    public class CustomerRootObject
    {
        public int customer_Id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string job { get; set; }
        public string adress { get; set; }
        public string city { get; set; }
        public string postal_Code { get; set; }
        public string phone { get; set; }
        public List<object> orders { get; set; }
    }
}
