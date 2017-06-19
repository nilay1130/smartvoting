using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace smartvoting
{
    public partial class AddUser : System.Web.UI.Page
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

        protected void BtnAddUser_Click(object sender, EventArgs e)
        {
            string city = Request.Form[DropDownListCity.UniqueID];
            string district = Request.Form[DropDownListDistrict.UniqueID];
            string neighborhood = Request.Form[DropDownListNeighborhood.UniqueID];
            string TC = TextBoxTc.Text;
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;
            string bp = TextBoxBirthPlace.Text;
            string s_bd = TextBoxBirthDate.Text;
            string file_number = TextBoxFileId.Text;
            string fingerprint = "";//Değişecek

            DateTime bd = DateTime.ParseExact(s_bd, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            if ((DateTime.Now.Year) - (bd.Year + 1) < 18)
            {
                LabelResult1.Text = "You cant add a person whose age is smaller than 18.";
            }
            else
            {
                 
                MySqlCommand cmd = MySQLDB.Connect();

                cmd.CommandText = "add_person_address";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LOC_PERSON_ID", TC);
                cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_PERSON_NAME", name);
                cmd.Parameters["@LOC_PERSON_NAME"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_PERSON_SURNAME", surname);
                cmd.Parameters["@LOC_PERSON_SURNAME"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_PERSON_BIRTHPLACE", bp);
                cmd.Parameters["@LOC_PERSON_BIRTHPLACE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_PERSON_BIRTHDATE", bd);
                cmd.Parameters["@LOC_PERSON_BIRTHDATE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_FINGER_PRINT", fingerprint);
                cmd.Parameters["@LOC_FINGER_PRINT"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_ADDRESS_CITY", city);
                cmd.Parameters["@LOC_ADDRESS_CITY"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_ADDRESS_DISTRICT", district);
                cmd.Parameters["@LOC_ADDRESS_DISTRICT"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_ADDRESS_NEIGBORHOOD", neighborhood);
                cmd.Parameters["@LOC_ADDRESS_NEIGBORHOOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_FILE_NUMBER", file_number);
                cmd.Parameters["@LOC_FILE_NUMBER"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@IS_PERSON", MySqlDbType.Bit);
                cmd.Parameters["@IS_PERSON"].Direction = ParameterDirection.Output;
                MySqlDataReader dr = cmd.ExecuteReader();

                String error = cmd.Parameters["@IS_PERSON"].Value.ToString();

                if (error.Equals("0"))
                {
                    LabelResult.Text = "Person added successfully.";
                }
                else
                {
                    LabelResult.Text = "The person already exist.";
                }

                MySQLDB.Disconnect();
            }
        }
    }
}