using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class ElectionPage : System.Web.UI.Page
    {
        string election = " ";
        string electionIDStr = " "; 

        SimpleAES256 AES256 = new SimpleAES256();

        protected void Page_Load(object sender, EventArgs e)

        {
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("3")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
            election = Request.QueryString["election"].ToString();

            if (!IsPostBack)
            {
                string serialNumber = produceSerialNumber();
                Label2.Text = serialNumber;
            }   
            string checkCandidate = " ";

            /*  try
              {
                 // File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "checkCandidate.txt", "true");

                 // string content = File.ReadAllText("checkCandidate.txt"); 

                  throw new FileNotFoundException();
              }
              catch (FileNotFoundException ex )
              {
                  // your message here.
              }*/
            if (!IsPostBack)
            {
                checkCandidates();
            } 
        }

        private string produceSerialNumber()
        {
            // here is one approach
            Random rand = new Random((int)DateTime.Now.Ticks);
            int RandomNumber;
            RandomNumber = rand.Next(100000, 999999);

            string s1 = RandomNumber.ToString();

            int CharCode = rand.Next(Convert.ToInt32('a'), Convert.ToInt32('z'));
            char RandomChar = Convert.ToChar(CharCode);

            string s2 = RandomChar.ToString(); 

            return s2+s1;
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

        private void checkCandidates()
        {
            // TODO: election id yi yollayıp candidate ların isimlerini ve resimlerini al.
            // TODO: aldığın resimleri img'ye kaydet
              
            List<string> list = getCandidateNames();

           // saveCandidateImages(list);
              
           /* for (int i = 0; i<list.Count; i++)
            {
                string item = list[i];
                list[i] = "<img src='" + "img/" + list[i] + ".png" + "'/>" + item;
            }*/

            for (int i = 0; i<list.Count; i++) //TODO: image not found error  
            {
                RadioButtonList1.Items.Add(new ListItem(list[i], ""+i+""));
            } 
        } 
 
        private void saveCandidateImages(List<string> nameList)
        {
            int election_id = returnelectionId(election);
            string sql = "SELECT C.CANDIDATE_IMAGE FROM CANDIDATE C " +
                  "INNER JOIN ELECTION_CANDIDATE EC ON C.CANDIDATE_ID = EC.CANDIDATE_ID " +
                  "WHERE EC.ELECTION_ID = " + election_id + " AND CANDIDATE_INFO != '#';";
           /* String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            var command = new MySqlCommand(sql, conn);
            var Reader = command.ExecuteReader();
            while (Reader.Read())
            { 
                Response.ContentType = "image/jpeg"; // if your image is a jpeg of course
                Response.BinaryWrite((byte[])Reader.GetValue(0));
            }
            
            conn.Close();

             */

        }

        private List<string> getCandidateNames()
        {
            int election_id = returnelectionId(election); 

            string sql = "SELECT C.CANDIDATE_INFO FROM CANDIDATE C " +
                  "INNER JOIN ELECTION_CANDIDATE EC ON C.CANDIDATE_ID = EC.CANDIDATE_ID " +
                  "WHERE EC.ELECTION_ID = " + election_id + " AND CANDIDATE_INFO != '#';";
             
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            var list = new List<string>();

            using (var command = new MySqlCommand(sql, conn))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(reader.GetString(0));
                }
            }
            /* foreach (string item in list)
             {
                 item =
                 RadioButtonList1.Items.Add(item);
             }*/
            conn.Close();
            return list;
        }

        private string getCandidateID(string candidateinfo)
        { 
            var candidate_id = ""; 
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("?candidateinfo", candidateinfo);
            string query = "SELECT CANDIDATE_ID FROM CANDIDATE WHERE CANDIDATE_INFO = ?candidateinfo; ";
            cmd.CommandText = query;
            conn.Open();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                candidate_id = reader["CANDIDATE_ID"].ToString(); 
            }

            conn.Close();

            return candidate_id;
        }
          
        private void addVote(string election_id, string username, string candidate_id, string ciphertext, string serialtext)
        {
            MySqlCommand cmd = MySQLDB.Connect();

            cmd.CommandText = "add_vote";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ID", election_id);
            cmd.Parameters["@LOC_ELECTION_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_PERSON_ID", username);
            cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_CANDIDATE_ID", candidate_id);
            cmd.Parameters["@LOC_CANDIDATE_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@CIPHERTEXT", ciphertext);
            cmd.Parameters["@CIPHERTEXT"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@SERIALNUMBER", serialtext);
            cmd.Parameters["@SERIALNUMBER"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_CONTROL_ADDING", MySqlDbType.Bit);
            cmd.Parameters["@LOC_CONTROL_ADDING"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            String error = cmd.Parameters["@LOC_CONTROL_ADDING"].Value.ToString();

            if (error.Equals("1"))
            {
                LabelResult.Text = "You voted successfully. Please keep your serial number. Thank you for voting :)";
            }
            else
            {
                LabelResult.ForeColor = System.Drawing.Color.Red;
                LabelResult.Text = "You've already voted this election! ";
            }

            MySQLDB.Disconnect();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem!= null)
            {
                string s = RadioButtonList1.SelectedItem.ToString();

                // TODO: Buraya bi query yaz. Nesibe balabanı gönder result a kaydeder. 

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                // Response.Redirect("VotePage.aspx");
                // Response.Write("Clicked Yes!");

                // oy verilen kişiyi şifrele. 
                // string userName = Session["userName"].ToString();

                string plainText = RadioButtonList1.SelectedItem.ToString();
                string cipher = Session["userName"].ToString() + Label2.Text;

                string cipherText = AES256.EncryptText(plainText, cipher);
                 

                string candidate_id = getCandidateID(RadioButtonList1.SelectedItem.ToString());

               // int candidate_id = 2;
                 
                int electionid = returnelectionId(election);
                  
               addVote(electionid.ToString(), Session["userName"].ToString(), candidate_id, cipherText, Label2.Text);

                // veritabanına vote tablosuna ciphertexti ve kaydet. 

                // veritabanına result tablosuna user id candidate id yi yolla
                   
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                //Response.Redirect("VotePage.aspx"); 
            }

            else
            {
                Label3.Visible=true;
            }
        } 
    }
}