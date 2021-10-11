using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingWeb.DAL
{
    public class MSSQLProvider
    {
        public DataTable SQLSelect(string sqlCommand)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["localDB"];
            string connectionString = settings.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter(sqlCommand, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0];
            }

        }
    }
}