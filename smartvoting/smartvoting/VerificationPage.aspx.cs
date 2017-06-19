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
    public partial class VerificationPage : System.Web.UI.Page
    {

        private SimpleAES256 AES256 = new SimpleAES256();

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
          
        protected void Button1_Click(object sender, EventArgs e)
        {  
            if (DropDownListElection.SelectedIndex != 0 && TextBox1.Text != "")
            {
                string election = Request.Form[DropDownListElection.UniqueID];
                int election_id = returnelectionId(election);
                string serial = TextBox1.Text;
                string username = Session["userName"].ToString();
                  
                string cipherText = getCipherText(serial, username, election_id);
                
                string cipher = username + serial;

                if (cipherText != "")
                {
                     
                    try
                    {
                        string plainText = AES256.DecryptText(cipherText, cipher);
                        Label1.Text = "Your vote was counted in final results as: ";

                        Label2.Text = plainText;
                    }

                    catch (Exception)
                    {
                        LabelResult.Text = "You entered wrong!"; 
                    }
                    
                }
                
                else
                {
                    LabelResult.Text = "Database error";
                }
                   
            }
                
            else if (DropDownListElection.SelectedIndex != 0 && TextBox1.Text == "")
            {
                Label3.Visible = false;
                Label4.Visible = true;
            }

            else if (DropDownListElection.SelectedIndex == 0 && TextBox1.Text != "")
            {

                Label3.Visible = true;
                Label4.Visible = false;
            }

            else
            {
                Label3.Visible = true;
                Label4.Visible = true;
            }
            }


        private string getCipherText(string serial, string username, int electionid)
        {
            string cipherText = "";

            MySqlCommand cmd = MySQLDB.Connect();

            cmd.CommandText = "show_vote";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ID", electionid);
            cmd.Parameters["@LOC_ELECTION_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_PERSON_ID", username);
            cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_SERIALNUMBER", serial);
            cmd.Parameters["@LOC_SERIALNUMBER"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add("@LOC_CIPHERTEXT", MySqlDbType.VarChar);
            cmd.Parameters["@LOC_CIPHERTEXT"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@CONTROL", SqlDbType.Int);
            cmd.Parameters["@CONTROL"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            int error = (int)cmd.Parameters["@CONTROL"].Value;

            if (error == 0)
            {
                cipherText = cmd.Parameters["@LOC_CIPHERTEXT"].Value.ToString();
                //Diğer işlemler 
                //LabelResult.Text = cipherText;
            }
            else if (error == 1)
            {
                LabelResult.Text = "You did not vote for selected election.";
            }
            else if (error == 2)
            {
                LabelResult.Text = "No matching serial number.";
            }

            MySQLDB.Disconnect();
            return cipherText;
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

            DropDownListElection.Items.Insert(0, new ListItem("Please select an election to verify your vote", ""));
            DropDownListElection.SelectedIndex = 0;

            conn.Close();
        }

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

    }
}