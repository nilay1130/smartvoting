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
    public partial class AddCandidateToElection : System.Web.UI.Page
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
           
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("1")))
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

        protected void BtnShowCandidates_Click(object sender, EventArgs e)
        {
            string election = Request.Form[DropDownListElection.UniqueID];
            int election_id = returnelectionId(election);

            String query = "SELECT C.CANDIDATE_INFO FROM CANDIDATE C " +
                  ";";

            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            MySqlCommand cmd1 = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter { SelectCommand = cmd1 };
            DataSet ds = new DataSet();
            da.Fill(ds);

            DropDownListCandidate.DataTextField = ds.Tables[0].Columns["CANDIDATE_INFO"].ToString();
            DropDownListCandidate.DataSource = ds.Tables[0];
            DropDownListCandidate.DataBind();
            DropDownListCandidate.SelectedItem.Text = "";

            conn.Close();

        }



        protected void BtnAddCandidate_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = MySQLDB.Connect();
            string election = Request.Form[DropDownListElection.UniqueID];
            string candidate_info = Request.Form[DropDownListCandidate.UniqueID];
            int election_id = returnelectionId(election);
            cmd.CommandText = "add_candidate_election";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ID", election_id);
            cmd.Parameters["@LOC_ELECTION_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_CANDIDATE_INFO",candidate_info );
            cmd.Parameters["@LOC_CANDIDATE_INFO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_CONTROL", SqlDbType.Int);
            cmd.Parameters["@LOC_CONTROL"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            int error = (int)cmd.Parameters["@LOC_CONTROL"].Value;

            if (error == 0)
            {
                LabelResult.Text = "No such candidate.";
            }
            else if (error == 1)
            {
                LabelResult.Text = "Candidate added election successfully.";
            }
            else if (error == 2)
            {
                LabelResult.Text = "This candidate already in that election  candidate.";
            }

            MySQLDB.Disconnect();
        }
    }
}