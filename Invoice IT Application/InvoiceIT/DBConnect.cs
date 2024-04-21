using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace InvoiceIT
{
    public class DBConnect
    {
        public static SqlConnection MakeConn() // to make a new sql connection
        {
            string str = ConfigurationManager.ConnectionStrings["invitdbcon"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            con.Open();
            return con;
        }


        public static void DropConn(SqlConnection con) // to drop the sql connection created
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Dispose();
        }

    }
}