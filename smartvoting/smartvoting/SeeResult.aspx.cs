using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class SeeResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("3")))
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
            string query = "SELECT CONCAT(ELECTION_INFO,  \", \", DATE_FORMAT(ELECTION_STARTING_DATE, '%d-%m-%Y %H:%i'), \", \", DATE_FORMAT(ELECTION_ENDING_DATE, '%d-%m-%Y %H:%i')) AS ELECTION,C.CANDIDATE_INFO AS CANDIDATE,R.VOTE_NUMBER FROM RESULT R INNER JOIN ELECTION E ON E.ELECTION_ID = R.ELECTION_ID INNER JOIN CANDIDATE C ON C.CANDIDATE_ID = R.CANDIDATE_ID WHERE E.ELECTION_STARTING_DATE > ?startdate  AND E.ELECTION_ENDING_DATE < ?enddate and ELECTION_INFO!='#' ; ";
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