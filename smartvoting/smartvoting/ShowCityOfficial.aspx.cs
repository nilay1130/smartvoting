using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Data;

namespace smartvoting
{
    public partial class ShowCityOfficial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("2")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
        }
         
        protected void BtnShow_Click(object sender, EventArgs e)
        {
            string startdate = TextBoxStartDate.Text;
            DateTime datestartdt = DateTime.ParseExact(startdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string enddate = TextBoxEndDate.Text;
            DateTime dateenddt = DateTime.ParseExact(enddate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("?startdate", datestartdt);
            cmd.Parameters.AddWithValue("?enddate", dateenddt);
            string query = "SELECT P.PERSON_ID, P.PERSON_NAME, P.PERSON_SURNAME, CODC.DUTY_NUMBER, CODC.DUTY_STARTING_DATE, CODC.DUTY_ENDING_DATE, CASE P.PERSON_IS_DEAD WHEN '1' THEN 'DEAD' ELSE 'ALIVE' END AS PERSON_IS_DEATH FROM CITYOFFICIAL_DUTY_CONTROL CODC INNER JOIN PERSON P ON P.PERSON_ID = CODC.PERSON_ID WHERE CODC.DUTY_STARTING_DATE > ?startdate AND CODC.DUTY_ENDING_DATE < ?enddate;";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter { SelectCommand = cmd };
            DataTable dt = new DataTable();
            da.Fill(dt);
            myGridView.DataSource = dt;
            myGridView.DataBind();
            conn.Close();
        }
    }
                       
}