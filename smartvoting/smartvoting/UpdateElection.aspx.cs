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
    public partial class UpdateElection : System.Web.UI.Page
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
            string queryElection = "SELECT CONCAT(ELECTION_INFO, \", \", ELECTION_STARTING_DATE, \", \", ELECTION_ENDING_DATE) AS ELECTION FROM ELECTION WHERE ELECTION_STARTING_DATE > SYSDATE() OR ELECTION_INFO='#' ORDER BY ELECTION_INFO;";
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

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            string election = Request.Form[DropDownListElection.UniqueID];
            string[] parts = election.Split(',');
            string election_info = parts[0].Trim();
            string startdate = parts[1].Trim();
            string enddate = parts[2].Trim();
            TextBoxElectionName.Text = election_info;
        }

        protected void BtnUpdateElection_Click(object sender, EventArgs e)
        {
            string election = Request.Form[DropDownListElection.UniqueID];
            int election_id = returnelectionId(election);
            MySqlCommand cmd = MySQLDB.Connect();
            string election_info = TextBoxElectionName.Text;
            string startdate = BaslangicTarihi.Text;
            string enddate = BitisTarihi.Text;
            cmd.CommandText = "update_election";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ID", election_id);
            cmd.Parameters["@LOC_ELECTION_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_INFO", election_info);
            cmd.Parameters["@LOC_ELECTION_INFO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_STARTING_DATE", startdate);
            cmd.Parameters["@LOC_ELECTION_STARTING_DATE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ENDING_DATE", enddate);
            cmd.Parameters["@LOC_ELECTION_ENDING_DATE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_CONTROL_UPDATE", SqlDbType.Int);
            cmd.Parameters["@LOC_CONTROL_UPDATE"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            int error = (int)cmd.Parameters["@LOC_CONTROL_UPDATE"].Value;

            if (error == 0)
            {
                LabelResult.Text = "Election updated successfully.";
            }
            else if (error == 1)
            {
                LabelResult.Text = "Election starting date already passed.";
            }
            else if (error == 2)
            {
                LabelResult.Text = "Election ending date is before electıon starting date.";
            }

            MySQLDB.Disconnect();
        }
    }
}