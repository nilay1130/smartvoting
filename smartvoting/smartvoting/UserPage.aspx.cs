using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smartvoting
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["userName"] == null || !(Session["roleNumber"].ToString().Equals("3")))
            {
                Response.Redirect("NotAuthorizatedPage.aspx");
            }
        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void BtnVote_Click(object sender, EventArgs e)
        {
            //TODO: Fingerprint Control NESİBE
            Response.Redirect("VotePage.aspx");
        }

        protected void BtnSeePoll_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeePoll.aspx");
        }

        protected void BtnResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeeResult.aspx");
        }

        protected void BtnVerification_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerificationPage.aspx");
        }
    }
}