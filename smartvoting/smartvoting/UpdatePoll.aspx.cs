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
    public partial class UpdatePoll : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                DropDownListCity.DataTextField = ds.Tables[0].Columns["CityName"].ToString();
                DropDownListCity.DataSource = ds.Tables[0];
                DropDownListCity.DataBind();
                DropDownListCity.SelectedItem.Text = "";
            }
            string querydistrict = "select * from district order by Name";
            MySqlCommand cmddistrict = new MySqlCommand(querydistrict, conn);
            MySqlDataAdapter dadistrict = new MySqlDataAdapter { SelectCommand = cmddistrict };
            DataSet dsdistrict = new DataSet();
            dadistrict.Fill(dsdistrict);
            if (!IsPostBack)
            {
                DropDownListDistrict.DataTextField = dsdistrict.Tables[0].Columns["Name"].ToString();
                DropDownListDistrict.DataSource = dsdistrict.Tables[0];
                DropDownListDistrict.DataBind();
                DropDownListDistrict.SelectedItem.Text = "";
            }
            string queryneighborhood = "select * from neighborhood order by Name";
            MySqlCommand cmdneighborhood = new MySqlCommand(queryneighborhood, conn);
            MySqlDataAdapter daneighborhood = new MySqlDataAdapter { SelectCommand = cmdneighborhood };
            DataSet dsneighborhood = new DataSet();
            daneighborhood.Fill(dsneighborhood);
            if (!IsPostBack)
            {
                DropDownListNeighborhood.DataTextField = dsneighborhood.Tables[0].Columns["Name"].ToString();
                DropDownListNeighborhood.DataSource = dsneighborhood.Tables[0];
                DropDownListNeighborhood.DataBind();
                DropDownListNeighborhood.SelectedItem.Text = "";
            }

            conn.Close();
        }

        protected void BtnShowPolls_Click(object sender, EventArgs e)
        {
            string city = Request.Form[DropDownListCity.UniqueID];
            string district = Request.Form[DropDownListDistrict.UniqueID];
            string neighborhood = Request.Form[DropDownListNeighborhood.UniqueID];
            String myConnectionString;
            myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("?sehir", city);
            cmd.Parameters.AddWithValue("?ilce", district);
            cmd.Parameters.AddWithValue("?mahalle", neighborhood);
            string query = "SELECT POLL_NAME FROM POLL WHERE (POLL_CITY = ?sehir AND POLL_DISTRICT = ?ilce AND POLL_NEIGHBORHOOD = ?mahalle AND POLL_AVAILABLE = 1 ) or POLL_NAME='#' ORDER BY POLL_NAME;";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter { SelectCommand = cmd };
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownListPolls.DataTextField = ds.Tables[0].Columns["POLL_NAME"].ToString();
            DropDownListPolls.DataSource = ds.Tables[0];
            DropDownListPolls.DataBind();
            DropDownListPolls.SelectedItem.Text = "";

            conn.Close();

        }

        protected void BtnUpdatePoll_Click(object sender, EventArgs e)
        {
            string city = Request.Form[DropDownListCity.UniqueID];
            string district = Request.Form[DropDownListDistrict.UniqueID];
            string neighborhood = Request.Form[DropDownListNeighborhood.UniqueID];
            string oldschoolname = Request.Form[DropDownListPolls.UniqueID];
            string poll= TextBoxNewSchool.Text;
            //poolun ıdsini dödüren queryi çalıştırılıp
            //UpdatePoll fonksiyonu çalıştırılcak 

            MySqlCommand cmd = MySQLDB.Connect();

            cmd.CommandText = "update_poll";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_OLD_POLL_NAME", oldschoolname);
            cmd.Parameters["@LOC_OLD_POLL_NAME"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_POLL_NAME", poll);
            cmd.Parameters["@LOC_POLL_NAME"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_POLL_CITY", city);
            cmd.Parameters["@LOC_POLL_CITY"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_POLL_DISTRICT", district);
            cmd.Parameters["@LOC_POLL_DISTRICT"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_POLL_NEIGHBORHOOD", neighborhood);
            cmd.Parameters["@LOC_POLL_NEIGHBORHOOD"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_CONTROL_UPDATE", MySqlDbType.Bit);
            cmd.Parameters["@LOC_CONTROL_UPDATE"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            String error = cmd.Parameters["@LOC_CONTROL_UPDATE"].Value.ToString();

            if (error.Equals("1"))
            {
                LabelResult.Text = "Poll updated successfully.";
            }
            else
            {
                LabelResult.Text = "No such poll.";
            }

            MySQLDB.Disconnect();
        }
    }
}