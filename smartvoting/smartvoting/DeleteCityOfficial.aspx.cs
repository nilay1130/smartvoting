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
    public partial class DeleteCityOfficial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("1")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
        }

        protected void BtnDeleteCityOfficial_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = MySQLDB.Connect();
            string tc = this.TextBoxTc.Text;
            //STORED PROCEDURE ÇALIŞTIRILCAK

            cmd.CommandText = "delete_cityofficial";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_PERSON_ID", tc);
            cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@IS_CO", SqlDbType.Bit);
            cmd.Parameters["@IS_CO"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            String error = cmd.Parameters["@IS_CO"].Value.ToString();

            if (error.Equals("0"))
            {
                LabelResult.Text = "City Official was deleted succesfully.";
            }
            else if (error.Equals("1"))
            {
                LabelResult.Text = "Person you tried to add doesnt exist.";
            }

            MySQLDB.Disconnect();
        }
    }
}
        