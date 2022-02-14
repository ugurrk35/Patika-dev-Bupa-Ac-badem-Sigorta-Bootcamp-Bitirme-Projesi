using Bupa.Data.Abstract;
using Bupa.Data.Concrete.Oracle;

using Bupa.Entity.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Data.Concrete
{
    public class CustomerRepository :ICustomerRepository
    {





      private readonly string conStr = DataConnection.GetConnectionString();


        /// <summary>
        ///customer create metodu procudure kullanıldı
        /// </summary>
        public string Create(Customer customer)
        {

            using (OracleConnection con = new OracleConnection(conStr))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("CreateCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@c_customerFirstName", customer.Firstname);
                    cmd.Parameters.Add("@c_customerSurname", customer.Surname);
                    cmd.Parameters.Add("@c_customerJob", customer.Job);
                    cmd.Parameters.Add("@c_customerAdress", customer.Adress);
                    cmd.Parameters.Add("@c_customerCity", customer.City);
                    cmd.Parameters.Add("@c_customerPostalCode", customer.Postal_Code);
                    cmd.Parameters.Add("@c_customerPhone", customer.Phone);
                    cmd.Parameters.Add("@c_customerCardName", customer.Card_name);
                    cmd.Parameters.Add("@c_customerCardNumber", customer.Card_number);
                    cmd.Parameters.Add("@c_customerExpiration", customer.Expiration);
                    cmd.Parameters.Add("@c_customerCvv", customer.Cvv);
                    cmd.Parameters.Add("@c_customerTaksit", customer.Taksit);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return ("Data save Successfully");
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    return (ex.Message.ToString());
                }
            }
        }


        /// <summary>
        ///Müşteri silme procudure kulldıldı
        /// </summary>
        public bool Delete(string id)
        {
            OracleCommand cmd = new OracleCommand("BP_CUSTOMER_DELETE_ID", Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("BP_CUSTOMER_ID", id);

            return Tools.ExecuteQuery(cmd);
        }
        /// <summary>
        ///Bütün Müşterileri Listeleme
        /// </summary>
        public List<Customer> GetAllCustomer()
        {

            List<Customer> customers = new List<Customer>();

            OracleParameter oracleParameter = new OracleParameter();
            oracleParameter.ParameterName = "orde";
            oracleParameter.Direction = ParameterDirection.Output;
            oracleParameter.OracleDbType = OracleDbType.RefCursor;

            using OracleConnection con = new OracleConnection(conStr);
            using OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "C_GET_ALL_CUSTOMER";

            cmd.Parameters.Add(oracleParameter);
            con.Open();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    customers.Add(new Customer
                    {
                        Customer_Id = Convert.ToInt32(sdr["CUSTOMER_ID"]),
                        Firstname = Convert.ToString(sdr["FIRSTNAME"]),
                        Surname = Convert.ToString(sdr["SURNAME"]),
                        Adress = Convert.ToString(sdr["ADRESS"]),
                        City = Convert.ToString(sdr["CITY"]),
                        Postal_Code = Convert.ToString(sdr["POSTAL_CODE"]),
                        Phone = Convert.ToString(sdr["PHONE"]),
                        Job = Convert.ToString(sdr["JOB"]),
                        Card_name = Convert.ToString(sdr["CARD_NAME"]),
                        Card_number = Convert.ToString(sdr["CARD_NUMBER"]),
                        Expiration = Convert.ToString(sdr["EXPIRATION"]),
                        Cvv = Convert.ToString(sdr["CVV"]),
                        Taksit = Convert.ToString(sdr["TAKSIT"])
                    });
                }
            }
            con.Close();

            return customers;
        }

        public List<Customer> GetCustomer(int customer_id)
        {
            
                using OracleConnection con = new OracleConnection(conStr);
                using OracleCommand cmd = new OracleCommand();

                List<Customer> customer = new List<Customer>();

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
                cmd.CommandText = "SP_GET_Customer_Id";


                con.Open();

                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customer.Add(new Customer
                        {
                            Customer_Id = Convert.ToInt32(sdr["CUSTOMER_ID"]),
                            Firstname = Convert.ToString(sdr["FIRSTNAME"]),
                            Surname = Convert.ToString(sdr["SURNAME"]),
                            Adress = Convert.ToString(sdr["ADRESS"]),
                            City = Convert.ToString(sdr["CITY"]),
                            Postal_Code = Convert.ToString(sdr["POSTAL_CODE"]),
                            Phone = Convert.ToString(sdr["PHONE"]),
                            Job = Convert.ToString(sdr["JOB"]),
                            Card_name = Convert.ToString(sdr["CARD_NAME"]),
                            Card_number = Convert.ToString(sdr["CARD_NUMBER"]),
                            Expiration = Convert.ToString(sdr["EXPIRATION"]),
                            Cvv = Convert.ToString(sdr["CVV"]),
                            Taksit = Convert.ToString(sdr["TAKSIT"])
                        });
                    }
                }
                con.Close();

                return customer;
           
        }
    }

}
