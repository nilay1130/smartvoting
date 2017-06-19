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
    public partial class VotePage : System.Web.UI.Page
    {

        String currElection = " ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("3")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
            if (!IsPostBack)
            {
                checkElections();
            }
              
        }

        private void checkElections()
        { 
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            string queryElection = "SELECT CONCAT(ELECTION_INFO, \", \", ELECTION_STARTING_DATE, \", \", ELECTION_ENDING_DATE) AS ELECTION FROM ELECTION WHERE ELECTION_STARTING_DATE > SYSDATE() AND ELECTION_INFO!='#' ORDER BY ELECTION_INFO;";
            MySqlCommand cmd = new MySqlCommand(queryElection, conn);
            MySqlDataAdapter da = new MySqlDataAdapter { SelectCommand = cmd };
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownListElection.DataTextField = ds.Tables[0].Columns["ELECTION"].ToString();
            DropDownListElection.DataSource = ds.Tables[0];
            DropDownListElection.DataBind(); 

            DropDownListElection.Items.Insert(0, new ListItem("Please select the election you want to vote", ""));
            DropDownListElection.SelectedIndex = 0;
            conn.Close();
               
        } 

        protected void Button1_Click(object sender, EventArgs e)
        { 
            if (Request.Form[DropDownListElection.UniqueID] != null  && DropDownListElection.SelectedIndex != 0)
            {
                currElection = Request.Form[DropDownListElection.UniqueID]; // TODO: election ID'yi veritabanından al. ElectionPage e gönder.

                string electioninfo = currElection;

                Response.Redirect("ElectionPage.aspx?election=" + electioninfo);
            }

            else
            {
                 
            }

        }
    }
}