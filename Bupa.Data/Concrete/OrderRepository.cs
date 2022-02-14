using Bupa.Data.Abstract;
using Bupa.Data.Concrete.Oracle;
using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Data.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        ///OOP mantığı ile constructor içinde bağlanmak istedim.
        ///ama yapmadım.Oracle.ManagedDataAccess birçok yol denedim ama null geldi.
        /// </summary>

        //private readonly string _connectionString;
        //public DbConnection(IConfiguration _configuratio)
        //{
        //  _connectionString = _configuratio.GetConnectionString("Baglanti");
        //}

        /// <summary>
        ///Oracle database bağlantısı
        /// </summary>
        private readonly string conStr = DataConnection.GetConnectionString();

        /// <summary>
        ///wep apide id gönderek silinme metodu
        ///procudure kullanıldı
        /// </summary>
        public bool Delete(string id)
        {
            OracleCommand cmd = new OracleCommand("BP_ORDER_DELETE_ID", Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("BP_ORDER_ID", id);

            return Tools.ExecuteQuery(cmd);

            /// <summary>
            /// databse connection stringde aynı yerde
            ///açma kapa işlemleri oracle klasörünün Tools sınıfında
            ///try catch finally blogunun içinde tek bir yerden yönetiliyor  
            ///
            /// </summary>

        }


        /// <summary>
        ///Order id customer id ve sipariş tarihi bütün kayıtların listelendiği metod
        ///Aynı şekilde sys_refcursor ile birlikte procudure yazıldı.
        /// </summary>
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            OracleParameter oracleParameter = new OracleParameter();
            oracleParameter.ParameterName = "orde";
            oracleParameter.Direction = ParameterDirection.Output;
            oracleParameter.OracleDbType = OracleDbType.RefCursor;

            using OracleConnection con = new OracleConnection(conStr);
            using OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ORDERS_LIST";

            cmd.Parameters.Add(oracleParameter);
            con.Open();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    orders.Add(new Order
                    {
                        Order_Id = Convert.ToInt32(sdr["ORDER_ID"]),
                        Customer_Id = Convert.ToInt32(sdr["CUSTOMER_ID"]),                   
                        Order_Date = Convert.ToString(sdr["ORDER_DATE"])
                    });
                }
            }
            con.Close();

            return orders;
        }
        /// <summary>
        ///Sipariş sırasında oluşturulan tüm kullanıcıların ve tüm bilgileri listelendi
        ///Listeleme işlemi için procudure kullanıldı.
        ///</summary>
        public List<OrderViewModel> GetAllOrderswithCustomer()
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();
           
            OracleParameter oracleParameter = new OracleParameter();
            oracleParameter.ParameterName = "ss";
            oracleParameter.Direction = ParameterDirection.Output;
            oracleParameter.OracleDbType = OracleDbType.RefCursor;

            using OracleConnection con = new OracleConnection(conStr);
            using OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_All_Order";

            cmd.Parameters.Add(oracleParameter);
            con.Open();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    orders.Add(new OrderViewModel
                    {
                        order_id = Convert.ToInt32(sdr["ORDER_ID"]),
                        customer_name = Convert.ToString(sdr["CUSTOMER_NAME"]),
                        order_Date = Convert.ToString(sdr["ORDER_DATE"]),
                        product_name = Convert.ToString(sdr["PRODUCT_NAME"]),
                        Price = Convert.ToString(sdr["PRICE"])
                       
                    });
                }
            }
            con.Close();

            return orders;
        
    }
        /// <summary>
        ///id ye göre müşteriyi getiriyor.
        ///order id si, customer sınıfından isim ve soy isim birleştirildi,order date,price ve product name bilgileri
        ///procudure yazıldı
        ///</summary>
        public List<OrderViewModel> GetOrders(int customer_id)
        {
            using OracleConnection con = new OracleConnection(conStr);
            using OracleCommand cmd = new OracleCommand();

            List<OrderViewModel> orders = new List<OrderViewModel>();

            OracleParameter oracleParameter = new OracleParameter();
            oracleParameter.ParameterName = "results";
            oracleParameter.Direction = ParameterDirection.Output;
            oracleParameter.OracleDbType = OracleDbType.RefCursor;

            OracleParameter oracleParameterId = new OracleParameter();
            oracleParameterId.ParameterName = "P_ID";
            oracleParameterId.Value = customer_id;
            oracleParameterId.Direction = ParameterDirection.Input;
            oracleParameterId.OracleDbType = OracleDbType.Int32;

            cmd.Parameters.Add(oracleParameterId);
            cmd.Parameters.Add(oracleParameter);

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_ORDERS";


            con.Open();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    orders.Add(new OrderViewModel
                    {
                        order_id = Convert.ToInt32(sdr["ORDER_ID"]),
                        customer_name = Convert.ToString(sdr["CUSTOMER_NAME"]),
                        order_Date = Convert.ToString(sdr["ORDER_DATE"]),
                        Price = Convert.ToString(sdr["PRICE"]),
                        product_name = Convert.ToString(sdr["PRODUCT_NAME"])
                    });
                }
            }
            con.Close();

            return orders;
        }
 

        /// <summary>
        ///CreateOrderCustomer Procudure yazıldı.3 tablonun birleşiminden oluşan tabloya veri kaydetmeye yarıyor.
        ///Ayrıca bir adet triger eklendi.
        ///Bu tabloya veri girişi oluşunca çalışmaya başlayıp tabloda
        ///olan verileri diğer 3 tabloya gönderiyor idleri ile eşleştirip gönderiyor.
        /// </summary>

        public bool CreateOrder(CustomerOrderOrderDetails order)
        {
            OracleCommand cmd = new OracleCommand("CreateOrderCustomer", Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("c_customerOrderFirstName", order.Firstname);
            cmd.Parameters.Add("c_customerOrderSurname", order.Surname);
            cmd.Parameters.Add("c_customerOrderJob", order.Job);
            cmd.Parameters.Add("c_customerOrderAdress", order.Adress);
            cmd.Parameters.Add("c_customerOrderCity", order.City);
            cmd.Parameters.Add("c_customerOrderPostalCode", order.Postal_Code);
            cmd.Parameters.Add("c_customerOrderPhone", order.Phone);
            cmd.Parameters.Add("c_customerOrderCardName", order.Card_name);
            cmd.Parameters.Add("c_customerOrderCardNumber", order.Card_number);
            cmd.Parameters.Add("c_customerOrderExpiration", order.Expiration);
            cmd.Parameters.Add("c_customerOrderCvv", order.Cvv);
            cmd.Parameters.Add("c_customerOrderTaksit", order.Taksit);
            cmd.Parameters.Add("c_customerOrderOrderDate", order.Order_Date);
            cmd.Parameters.Add("c_customerOrderPrice", order.Price);
            cmd.Parameters.Add("c_customerOrderProductId", order.product_id);
     

            return Tools.ExecuteQuery(cmd); //açma kapa işlemleri
        }
    }
}
