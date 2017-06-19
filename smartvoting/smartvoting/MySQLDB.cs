


using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public class MySQLDB
    {
        public static MySqlCommand cmd;
        public static MySqlConnection conn;
        public static MySqlCommand Connect()
        {
            
            cmd = new MySqlCommand();
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                cmd.Connection = conn;

                return cmd;
            }
            catch (MySqlException ex)
            {
                return cmd;
            }
        }

        public static void Disconnect()
        {
            conn.Close();
        }

    }
}