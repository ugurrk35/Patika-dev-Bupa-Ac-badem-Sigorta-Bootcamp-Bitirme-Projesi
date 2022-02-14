using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Data.Concrete.Oracle
{
    internal class DataConnection
    {
        public static string GetConnectionString()
        {

            return "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id = C##Bupa; Password=14557Fb+;";

        }
       
    }
}
