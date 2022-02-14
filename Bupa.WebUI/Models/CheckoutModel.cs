namespace Bupa.WebUI.Models
{
    public class CheckoutModel
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Job { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Postal_Code { get; set; }
        public string Phone { get; set; }
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
