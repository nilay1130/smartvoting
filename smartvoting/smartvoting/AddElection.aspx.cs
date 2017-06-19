using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class AddElection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("1")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }

        }

        protected void BtnAddElection_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = MySQLDB.Connect();
            string secimAdi = this.TextBoxSecimAdi.Text;
            string baslangicTarihi = this.BaslangicTarihi.Text;
            baslangicTarihi += " 08:00:00";
            DateTime baslangicTarihidt = DateTime.ParseExact(baslangicTarihi, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string bitisTarihi = this.BitisTarihi.Text;
            bitisTarihi += " 17:00:00";
            DateTime bitisTarihidt = DateTime.ParseExact(bitisTarihi, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            

            cmd.CommandText = "add_election";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_INFO", secimAdi);
            cmd.Parameters["@LOC_ELECTION_INFO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_STARTING_DATE", baslangicTarihidt);
            cmd.Parameters["@LOC_ELECTION_STARTING_DATE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ENDING_DATE", bitisTarihidt);
            cmd.Parameters["@LOC_ELECTION_ENDING_DATE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@LOC_ELECTION_ID", SqlDbType.Int);
            cmd.Parameters["@LOC_ELECTION_ID"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@LOC_CONTROL_ADDING", SqlDbType.Int);
            cmd.Parameters["@LOC_CONTROL_ADDING"].Direction = ParameterDirection.Output;

            MySqlDataReader dr = cmd.ExecuteReader();

            int error = (int)cmd.Parameters["@LOC_CONTROL_ADDING"].Value;

            if (error == 0)
            {
               
               

                LabelResult.Text = "Election is added.";
            }
            else if (error == 1)
            {
                LabelResult.Text = "Starting date already passed.";
            }
            else if (error == 2)
            {
                LabelResult.Text = "Starting date is after ending date.";
            }
            else if (error == 3)
            {
                LabelResult.Text = "Election already exists in database.";
            }

            MySQLDB.Disconnect();
        }
    }
}