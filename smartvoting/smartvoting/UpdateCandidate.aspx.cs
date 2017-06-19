using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class UpdateCandidate : System.Web.UI.Page
    {
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
            string query = "SELECT C.CANDIDATE_INFO FROM CANDIDATE C " +
                  ";";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter { SelectCommand = cmd };
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (!IsPostBack)
            {
                DropDownListCandidate.DataTextField = ds.Tables[0].Columns["CANDIDATE_INFO"].ToString();
                DropDownListCandidate.DataSource = ds.Tables[0];
                DropDownListCandidate.DataBind();
                DropDownListCandidate.SelectedItem.Text = "";
            }
            conn.Close();
        }

        protected void BtnUpdateCandidate_Click(object sender, EventArgs e)
        {
            var candidate_id = "";
            string candidateinfo = Request.Form[DropDownListCandidate.UniqueID];
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
            string picturePath="";
            
                string newCandidateInfo = TextBoxCandidateInfo.Text;
                cmd = MySQLDB.Connect();

                cmd.CommandText = "update_candidate";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LOC_CANDIDATE_ID", candidate_id);
                cmd.Parameters["@LOC_CANDIDATE_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_CANDIDATE_INFO", newCandidateInfo);
                cmd.Parameters["@LOC_CANDIDATE_INFO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_CANDIDATE_IMAGE", picturePath);
                cmd.Parameters["@LOC_CANDIDATE_IMAGE"].Direction = ParameterDirection.Input;

                MySqlDataReader dr = cmd.ExecuteReader();
                MySQLDB.Disconnect();
            }
        }
    }


