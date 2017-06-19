using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class SuperAdminPage : System.Web.UI.Page
    {
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("1")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
        }

        protected void BtnAddGeneralOfficial_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddGeneralOfficial.aspx");
        }

        protected void BtnDeleteCityOfficial_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteCityOfficial.aspx");
        }

        protected void BtnDeleteGeneralOfficial_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteGeneralOfficial.aspx");
        }

        protected void BtnChangeSuperAdminPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeSuperAdminPassword.aspx");
        }

        protected void BtnAddCityOfficial_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCityOfficial.aspx");
        }

        protected void BtnAddElection_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddElection.aspx");
        }

        protected void BtnDeleteCandidate_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteCandidate.aspx");
        }

        protected void BtnUpdateElection_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateElection.aspx");
        }

        protected void BtnAddCandidateToElection_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCandidateToElection.aspx");
        }

        protected void BtnAddCandidate_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCandidate.aspx");
        }

        protected void BtnUpdateCandidate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateCandidate.aspx");
        }
    }
}