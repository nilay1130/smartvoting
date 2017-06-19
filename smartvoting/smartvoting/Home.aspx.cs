using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace smartvoting
{
    public partial class Home : System.Web.UI.Page
    {
        public static MySqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLogin"] == null)
            {
                
            }
            else
            {
                string role = Session["roleNumber"].ToString();
                switch (role)
                {
                    case "1":
                        Response.Redirect("SuperAdminPage.aspx");
                        break;
                    case "2":
                        Response.Redirect("AdminPage.aspx");
                        break;
                    case "3":
                        Response.Redirect("UserPage.aspx");
                        break;
                    default: 
                        break;
                } 
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn;
            cmd = new MySqlCommand();
            string myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
           
            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
            cmd.Connection = conn; 

            String tc = username.Value;
            String pass = password.Value;
            String tempTC;
            String pss_con;
            switch (tc.ToCharArray()[0])
            {
                case 'g':
                    tempTC = tc.Substring(1, tc.Length - 1);

                    cmd.CommandText = "control_generalofficial";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LOC_PERSON_ID", tempTC);
                    cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@LOC_PASS", pass);
                    cmd.Parameters["@LOC_PASS"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@LOC_IS_GENERALOFFICIAL", MySqlDbType.Bit);
                    cmd.Parameters["@LOC_IS_GENERALOFFICIAL"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@LOC_PASS_CONTROL", MySqlDbType.Bit);
                    cmd.Parameters["@LOC_PASS_CONTROL"].Direction = ParameterDirection.Output;

                    MySqlDataReader dr = cmd.ExecuteReader();

                    String is_go = cmd.Parameters["@LOC_IS_GENERALOFFICIAL"].Value.ToString();
                    pss_con = cmd.Parameters["@LOC_PASS_CONTROL"].Value.ToString();

                    if (is_go.Equals("0") )
                    {
                        //HATA MESAJI!!!
                        lblFormResult.Text = "You havent general official authorization.";
                    }
                    else if (pss_con.Equals("0"))
                    {
                        //HATA MESAJI!!!
                        lblFormResult.Text = "You entered  wrong password .";
                    }
                    else
                    {
                        //GENERAL OFFICIAL SAYFASINA YÖNLENDİR.

                        Session.Add("userName", tempTC);
                        Session.Add("roleNumber", 1);
                        Session.Add("isLogin",1);
                            Response.Redirect("SuperAdminPage.aspx"); 
                        
                    }
                    conn.Close();
                    break;

                case 'c':
                    tempTC = tc.Substring(1, tc.Length - 1);

                    cmd.CommandText = "control_cityofficial";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LOC_PERSON_ID", tempTC);
                    cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@LOC_PASS", pass);
                    cmd.Parameters["@LOC_PASS"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@LOC_IS_CITYOFFICIAL", MySqlDbType.Bit);
                    cmd.Parameters["@LOC_IS_CITYOFFICIAL"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@LOC_PASS_CONTROL", MySqlDbType.Bit);
                    cmd.Parameters["@LOC_PASS_CONTROL"].Direction = ParameterDirection.Output;

                    dr = cmd.ExecuteReader();

                    String is_co = cmd.Parameters["@LOC_IS_CITYOFFICIAL"].Value.ToString();
                    pss_con = cmd.Parameters["@LOC_PASS_CONTROL"].Value.ToString();

                    if (is_co.Equals("0"))
                    {
                        //HATA MESAJI!!!
                        lblFormResult.Text = "You havent city official authorization.";
                    }
                    else if (pss_con.Equals("0"))
                    {
                        //HATA MESAJI!!!
                        lblFormResult.Text = "You entered wrong password .";
                    }
                    else
                    {
                        //CITY OFFICIAL SAYFASINA YÖNLENDİR.
                        Session.Add("userName", tempTC);
                        Session.Add("roleNumber", 2);
                        Session.Add("isLogin", 1);
                        Response.Redirect("AdminPage.aspx"); 
                    }
                    conn.Close();
                    break;

                default:
                    tempTC = tc.Substring(1, tc.Length - 1);
                    cmd.CommandText = "control_person";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LOC_PERSON_ID", tc);
                    cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@LOC_PASS", pass);
                    cmd.Parameters["@LOC_PASS"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@LOC_IS_PERSON", MySqlDbType.Bit);
                    cmd.Parameters["@LOC_IS_PERSON"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@LOC_PASS_CONTROL", MySqlDbType.Bit);
                    cmd.Parameters["@LOC_PASS_CONTROL"].Direction = ParameterDirection.Output;

                    dr = cmd.ExecuteReader();

                    String is_pe = cmd.Parameters["@LOC_IS_PERSON"].Value.ToString();
                    pss_con = cmd.Parameters["@LOC_PASS_CONTROL"].Value.ToString();

                    if (is_pe.Equals("0"))
                    {
                        //HATA MESAJI!!!
                        lblFormResult.Text = "There isnt such a user.";
                    }
                    else if (pss_con.Equals("0"))
                    {
                        //HATA MESAJI!!!
                        lblFormResult.Text = "You entered wrong password .";
                    }
                    else
                    {
                        //USER SAYFASINA YÖNLENDİR.
                        Session.Add("userName", tc);
                        Session.Add("roleNumber", 3);
                        Session.Add("isLogin", 1);
                        Response.Redirect("UserPage.aspx"); 
                    }
                    conn.Close();
                    break;
                    
            }
        }
         
    }
}


