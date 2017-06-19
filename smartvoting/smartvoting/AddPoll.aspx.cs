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
    public partial class AddPollaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("2")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            string querycity = "select * from city order by CityName";
            MySqlCommand cmd = new MySqlCommand(querycity, conn);
            MySqlDataAdapter da = new MySqlDataAdapter { SelectCommand = cmd };
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownListCity.DataTextField = ds.Tables[0].Columns["CityName"].ToString();
            DropDownListCity.DataSource = ds.Tables[0];
            DropDownListCity.DataBind();
            DropDownListCity.SelectedItem.Text = "";
            string querydistrict = "select * from district order by Name";
            MySqlCommand cmddistrict = new MySqlCommand(querydistrict, conn);
            MySqlDataAdapter dadistrict = new MySqlDataAdapter { SelectCommand = cmddistrict };
            DataSet dsdistrict = new DataSet();
            dadistrict.Fill(dsdistrict);
            DropDownListDistrict.DataTextField = dsdistrict.Tables[0].Columns["Name"].ToString();
            DropDownListDistrict.DataSource = dsdistrict.Tables[0];
            DropDownListDistrict.DataBind();
            DropDownListDistrict.SelectedItem.Text = "";
            string queryneighborhood = "select * from neighborhood order by Name";
            MySqlCommand cmdneighborhood = new MySqlCommand(queryneighborhood, conn);
            MySqlDataAdapter daneighborhood = new MySqlDataAdapter { SelectCommand = cmdneighborhood };
            DataSet dsneighborhood = new DataSet();
            daneighborhood.Fill(dsneighborhood);
            DropDownListNeighborhood.DataTextField = dsneighborhood.Tables[0].Columns["Name"].ToString();
            DropDownListNeighborhood.DataSource = dsneighborhood.Tables[0];
            DropDownListNeighborhood.DataBind();
            DropDownListNeighborhood.SelectedItem.Text = "";
            conn.Close();

        }

        protected void BtnAddPoll_Click(object sender, EventArgs e)
        {
            string schoolName = TextBoxSchoolName.Text;
            string city= Request.Form[DropDownListCity.UniqueID];
            string district= Request.Form[DropDownListDistrict.UniqueID];
            string neighborhood= Request.Form[DropDownListNeighborhood.UniqueID];
            MySqlCommand cmd = MySQLDB.Connect();

            cmd.CommandText = "add_poll";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_POLL_NAME", schoolName);
            cmd.Parameters["@LOC_POLL_NAME"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_POLL_CITY", city);
            cmd.Parameters["@LOC_POLL_CITY"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_POLL_DISTRICT", district);
            cmd.Parameters["@LOC_POLL_DISTRICT"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_POLL_NEIGHBORHOOD", neighborhood);
            cmd.Parameters["@LOC_POLL_NEIGHBORHOOD"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_IS_POLL", MySqlDbType.Bit);
            cmd.Parameters["@LOC_IS_POLL"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            String error = cmd.Parameters["@LOC_IS_POLL"].Value.ToString();

            if (error.Equals("1"))
            {
                LabelResult.Text = "School added successfully.";
            }
            else
            {
                LabelResult.Text = "The school is already exist.";
            }

            MySQLDB.Disconnect();
        }
    }
}