using Bupa.Data.Abstract;
using Bupa.Data.Concrete.Oracle;
using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Data.Concrete
{
    public class ProductRepository : IProductRepository
    {

        //private readonly string _connectionString;
        //public DbConnection(IConfiguration _configuratio)
        //{
        //  _connectionString = _configuratio.GetConnectionString("Baglanti");
        //}

        private readonly string conStr = DataConnection.GetConnectionString();

        /// <summary>
        ///Yeni Poliçe oluşturma oluşturma metodu
        ///procudure kullanıldı
        ///genel müdürlük ekranında kullanılmak için
        ///</summary>
        public bool Create(Product product)
        {         
                    OracleCommand cmd = new OracleCommand("AddProduct",Tools.Baglanti); 
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_productname", product.Product_Name);
                    cmd.Parameters.Add("p_description", product.Price);
                    cmd.Parameters.Add("p_price", product.Description);

                    return Tools.ExecuteQuery(cmd);

            /// <summary>
            /// database connection stringde aynı yerde
            ///açma kapa işlemleri oracle klasörünün Tools sınıfında
            ///try catch finally blogunun içinde tek bir yerden yönetiliyor  
            /// </summary>

        }
        /// <summary>
        /// Poliçe silme genel müdürlük ekranında kullanılmak için
        /// procudure ile yapıldı
        /// </summary>
        public bool Delete(string id)
        {

            //OracleCommand cmd = new OracleCommand("BP_PRODUCT_DELETE_ID", Tools.Baglanti);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("BP_PRODUCT_ID", obj.Product_Id);

            //return Tools.ExecuteQuery(cmd);
     

            OracleCommand cmd = new OracleCommand("BP_PRODUCT_DELETE_ID", Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("BP_PRODUCT_ID", id);

            return Tools.ExecuteQuery(cmd); 

        }
        /// <summary>
        ///ürünleri listeleme genel müdürlük ve ön yüzde ürünleri listelemek için
        ///procudure yazıldı fakat kullanılmadı
        ///birde bu şekilde kullanıldığı görmek için
        ///diğer iki sınıfta(customer ve order) aynı sorgunun procuduru kullanıldı
        /// </summary>
        public List<Product> GetAllProductsEnd()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM PRODUCTS";
            using (OracleConnection con = new OracleConnection(conStr))
            {
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (OracleDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            products.Add(new Product
                            {
                                Product_Id = Convert.ToInt32(sdr["PRODUCT_ID"]),
                                Product_Name = Convert.ToString(sdr["PRODUCT_NAME"]),
                                Price = Convert.ToInt32(sdr["PRICE"]),
                                Description = Convert.ToString(sdr["DESCRIPTION"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return products;
       
         }

        /// <summary>
        ///Ürünleri güncellemek için genel müdürlük projesi için yazıldı
        ///procudure kullanıldı
        /// </summary>
        public bool Update(Product product)
        {
            OracleCommand cmd = new OracleCommand("SP_PRODUCT_UPDATE", Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_productname", product.Product_Name);
            cmd.Parameters.Add("p_description", product.Price);
            cmd.Parameters.Add("p_price", product.Description);

            return Tools.ExecuteQuery(cmd); //açma kapa işlemleri
        }
    }

  
  
}

