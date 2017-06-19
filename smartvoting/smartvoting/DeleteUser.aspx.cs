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
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["userName"] == null ||!(Session["roleNumber"].ToString().Equals("2")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
        }

        protected void BtnDeleteGeneralOfficial_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = MySQLDB.Connect();
            string TC = this.TextBoxTc.Text;

            cmd.CommandText = "delete_person";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_PERSON_ID", TC);
            cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_IS_PERSON", SqlDbType.Bit);
            cmd.Parameters["@LOC_IS_PERSON"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            String error = cmd.Parameters["@LOC_IS_PERSON"].Value.ToString();

            if (error.Equals("1"))
            {
                LabelResult.Text = "Death information was updated succesfully.";
            }
            else if (error.Equals("0"))
            {
                LabelResult.Text = "No such person.";
            }

            MySQLDB.Disconnect();
        }
    }
}
      