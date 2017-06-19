using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class AddCandidate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("1")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string candidateInfo = TextBoxCandidateInfo.Text;
            string picturePath="";
           
            
                
                
                MySqlCommand cmd = MySQLDB.Connect();

                cmd.CommandText = "add_candidate";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LOC_CANDIDATE_INFO", candidateInfo);
                cmd.Parameters["@LOC_CANDIDATE_INFO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_CANDIDATE_IMAGE", picturePath);
                cmd.Parameters["@LOC_CANDIDATE_IMAGE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_IS_CANDIDATE", MySqlDbType.Bit);
                cmd.Parameters["@LOC_IS_CANDIDATE"].Direction = ParameterDirection.Output;

                MySqlDataReader dr = cmd.ExecuteReader();

                String error = cmd.Parameters["@LOC_IS_CANDIDATE"].Value.ToString();

                if (error.Equals("0"))
                {
                    LabelResult.Text = "That candidate is already in database.";
                }
                else
                {
                    LabelResult.Text = "Candidate added successfully.";
                }

                MySQLDB.Disconnect();

            }
        }
    }
