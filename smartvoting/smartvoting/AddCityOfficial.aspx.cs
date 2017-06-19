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
    public partial class AddCityOfficial : System.Web.UI.Page
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
            MySqlCommand cmd = MySQLDB.Connect();
            string tc = this.TextBoxTc.Text;
            //STORED PROCEDURE ÇALIŞTIRILCAK

            cmd.CommandText = "add_cityofficial";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_PERSON_ID", tc);
            cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@IS_PERSON", SqlDbType.Int);
            cmd.Parameters["@IS_PERSON"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            int error = (int)cmd.Parameters["@IS_PERSON"].Value;

            if (error == 0)
            {
                LabelResult.Text = "City Official was added succesfully.";
            }
            else if (error == 1)
            {
                LabelResult.Text = "Person you tried to add is dead.";
            }
            else if (error == 2)
            {
                LabelResult.Text = "Person you tried to add do not exist.";
            }

            MySQLDB.Disconnect();
        }
    }
}


