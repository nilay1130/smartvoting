using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class ChangeAdminPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("2")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = MySQLDB.Connect();
            string userName = Session["userName"].ToString();
            string passwordold = this.TextBoxPasswordOld.Text;
            string passwordnew = this.TextBoxPasswordNew.Text;
            string passwordnew2 = this.TextBoxPasswordNew2.Text;

            cmd.CommandText = "update_city_official_password";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_PERSON_ID", userName);
            cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_OLD_PASS", passwordold);
            cmd.Parameters["@LOC_OLD_PASS"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_NEW_PASS", passwordnew);
            cmd.Parameters["@LOC_NEW_PASS"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_NEW_PASS_AGAIN", passwordnew2);
            cmd.Parameters["@LOC_NEW_PASS_AGAIN"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@OLD_PASS_CORRECT", MySqlDbType.Bit);
            cmd.Parameters["@OLD_PASS_CORRECT"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@PASSES_CORRECT", MySqlDbType.Bit);
            cmd.Parameters["@PASSES_CORRECT"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            String old_pass_correct = cmd.Parameters["@OLD_PASS_CORRECT"].Value.ToString();
            String passes_correct = cmd.Parameters["@PASSES_CORRECT"].Value.ToString();

            if (old_pass_correct.Equals("0"))
            {
                LabelResult.Text = "Wrong password.";
            }
            else if (old_pass_correct.Equals("1") && passes_correct.Equals("0"))
            {
                LabelResult.Text = "The values ​​you entered do not match.";
            }
            else
            {
                LabelResult.Text = "Your password was updated successfully.";
            }

            MySQLDB.Disconnect();
        }
    }
}
      
        
      
        