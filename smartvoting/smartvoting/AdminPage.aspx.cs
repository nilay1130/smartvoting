using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("2")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
        }

        protected void BtnChangeAdminPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeAdminPassword.aspx");
        }

        protected void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteUser.aspx");
        }

        protected void BtnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }

        protected void BtnAddPoll_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPoll.aspx");
        }

        protected void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUser.aspx");
        }

        protected void BtnDeletePoll_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeletePoll.aspx");
        }

        protected void BtnUpdatePoll_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePoll.aspx");
        }

        protected void BtnShowCityOfficial_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowCityOfficial.aspx");
        }

        protected void BtnShowGeneralOfficial_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowGeneralOfficial.aspx");
        }
    }
}