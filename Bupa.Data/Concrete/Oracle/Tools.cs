using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Data.Concrete.Oracle
{
    public class Tools
    {

        static string constr = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVICE_NAME = orcl))); User Id = C##Bupa; Password=14557Fb+;";
        private static OracleConnection con = new OracleConnection(constr);

        /// <summary>
        /// Tools.Baglanti diyere connection stringe erişiyoruz repositorylerden
        /// </summary>
        public static OracleConnection Baglanti
        {
            get { return con; }
        }
        /// <summary>
        ///Tools.ExecuteQuery(cmd); repositorilerde kullanılmak için 
        ///create,delete,update metodları içerinde kod saysını azaltmak
        /// </summary>
        public static bool ExecuteQuery(OracleCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                int ddd = cmd.ExecuteNonQuery();
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
                if (ddd > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
    }
}
