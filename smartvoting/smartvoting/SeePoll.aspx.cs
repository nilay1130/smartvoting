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
    public partial class SeePoll : System.Web.UI.Page
    {
        public int returnelectionId(string election)
        {
            string[] parts = election.Split(',');
            string election_info = parts[0].Trim();
            string startdate = parts[1].Trim();
            string enddate = parts[2].Trim();
            MySqlCommand cmd = MySQLDB.Connect();
            cmd.CommandText = "select_election_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_INFO", election_info);
            cmd.Parameters["@LOC_ELECTION_INFO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_STARTING_DATE", startdate);
            cmd.Parameters["@LOC_ELECTION_STARTING_DATE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ENDING_DATE", enddate);
            cmd.Parameters["@LOC_ELECTION_ENDING_DATE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ID", SqlDbType.Int);
            cmd.Parameters["@LOC_ELECTION_ID"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            int election_id = (int)cmd.Parameters["@LOC_ELECTION_ID"].Value;
            MySQLDB.Disconnect();
            return election_id;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("3")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            string queryElection = "SELECT CONCAT(ELECTION_INFO, \", \",  DATE_FORMAT(ELECTION_STARTING_DATE, '%Y-%m-%d %H:%i'), \", \",  DATE_FORMAT(ELECTION_ENDING_DATE, '%Y-%m-%d %H:%i')) AS ELECTION FROM ELECTION WHERE ELECTION_STARTING_DATE > SYSDATE() OR ELECTION_INFO='#' ORDER BY ELECTION_INFO;";
            MySqlCommand cmd = new MySqlCommand(queryElection, conn);
            MySqlDataAdapter da = new MySqlDataAdapter { SelectCommand = cmd };
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (!IsPostBack)
            {
                DropDownListElection.DataTextField = ds.Tables[0].Columns["ELECTION"].ToString();
                DropDownListElection.DataSource = ds.Tables[0];
                DropDownListElection.DataBind();
                DropDownListElection.SelectedItem.Text = "";
            }
            conn.Close();
        }

        protected void BtnShowPoll_Click(object sender, EventArgs e)
        {
            string userName = Session["userName"].ToString();
            string election = Request.Form[DropDownListElection.UniqueID];
            int electionId = returnelectionId(election);
            var pollName = "";
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("?electionId", electionId);
            cmd.Parameters.AddWithValue("?userName", userName);
            string query = "SELECT PO.POLL_NAME FROM POLL_BY_ADDRESS PBA INNER JOIN RES_ADDRESS RA ON RA.ADDRESS_ID = PBA.ADDRESS_ID INNER JOIN POLL PO ON PBA.POLL1_ID = PO.POLL_ID WHERE RA.ADDRESS_ID =(SELECT P.ADDRESS_ID FROM PERSON P WHERE PERSON_ID = ?userName) AND PBA.ELECTION_ID = ?electionId; ";
            cmd.CommandText = query;
            conn.Open();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pollName = reader["POLL_NAME"].ToString();


            }
            TextBoxPoll.Text = pollName;
            conn.Close();
        }
    }   
}