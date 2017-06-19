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

namespace smartvoting
{
    public partial class UpdateUser : System.Web.UI.Page
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

        protected void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            string city= Request.Form[DropDownListDistrict.UniqueID]; 
            string district = Request.Form[DropDownListDistrict.UniqueID];
            string neighborhood = Request.Form[DropDownListNeighborhood.UniqueID];
            string tc = TextBoxTc.Text;
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;
            string birthplace = TextBoxBirthPlace.Text;
            string birthdate = TextBoxBirthDate.Text;
            DateTime birthdatedatetime = DateTime.ParseExact(birthdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //procedure çalıştırılcak//diğer hata mesejları için labelresultı kullan
            //yaşını 18 yaşından küçük olacak şekilde güncelleyemez
            if ((DateTime.Now.Year) - (birthdatedatetime.Year + 1) < 18)
            {
                LabelResult1.Text = "You cant add a person whose age is smaller than 18.";
            }
            else
            {
                MySqlCommand cmd = MySQLDB.Connect();

                cmd.CommandText = "update_person";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LOC_PERSON_ID", tc);
                cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_PERSON_NAME", name);
                cmd.Parameters["@LOC_PERSON_NAME"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_PERSON_SURNAME", surname);
                cmd.Parameters["@LOC_PERSON_SURNAME"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_PERSON_BIRTHPLACE", birthplace);
                cmd.Parameters["@LOC_PERSON_BIRTHPLACE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_PERSON_BIRTHDATE", birthdate);

                cmd.Parameters.AddWithValue("@IS_PERSON", MySqlDbType.Bit);
                cmd.Parameters["@IS_PERSON"].Direction = ParameterDirection.Output;
                MySqlDataReader dr = cmd.ExecuteReader();

                String error = cmd.Parameters["@IS_PERSON"].Value.ToString();
                cmd = MySQLDB.Connect();

                cmd.CommandText = "update_person_address";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LOC_PERSON_ID", tc);
                cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_ADDRESS_CITY", city);
                cmd.Parameters["@LOC_ADDRESS_CITY"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_ADDRESS_DISTRICT", district);
                cmd.Parameters["@LOC_ADDRESS_DISTRICT"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@LOC_ADDRESS_NEIGBORHOOD", neighborhood);
                cmd.Parameters["@LOC_ADDRESS_NEIGBORHOOD"].Direction = ParameterDirection.Input;

                dr = cmd.ExecuteReader();
                if (error.Equals("1"))
                {
                    LabelResult.Text = "Person updated successfully.";
                }
                else
                {
                    LabelResult.Text = "The person you tried to add is already registered.";
                }

                MySQLDB.Disconnect();
            }


        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            string tc = TextBoxTc.Text;
            MySqlCommand cmd = MySQLDB.Connect();

            cmd.CommandText = "select_person";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_PERSON_ID", tc);
            cmd.Parameters["@LOC_PERSON_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add("@LOC_PERSON_INFO", MySqlDbType.VarChar,500);
            cmd.Parameters["@LOC_PERSON_INFO"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@IS_PERSON", MySqlDbType.Bit);
            cmd.Parameters["@IS_PERSON"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            String error = cmd.Parameters["@IS_PERSON"].Value.ToString();

            if (error.Equals("0"))
            {
                LabelResult.Text = "There is no registered person with that TC identity number.";
            }
            else
            {
                string person_info = cmd.Parameters["@LOC_PERSON_INFO"].Value.ToString();
                string[] parts = person_info.Split('&');
                string person_name = parts[0].Trim();
                string person_surname = parts[1].Trim();
                string person_bp = parts[2].Trim();
                string person_bd = parts[3].Trim();
                string person_city = parts[4].Trim();
                string person_district = parts[5].Trim();
                string person_neigborhood = parts[6].Trim();

                string[] bd_parts = person_bd.Split('-');
                string bd_year = bd_parts[0];
                string bd_month = bd_parts[1];
                string bd_day = bd_parts[2];

                person_bd = bd_day + "." + bd_month + "." + bd_year;
                TextBoxName.Text = person_name;
                TextBoxSurname.Text = person_surname;
                TextBoxBirthPlace.Text = person_bp; 
            }

            MySQLDB.Disconnect();
        }
    }
    }

