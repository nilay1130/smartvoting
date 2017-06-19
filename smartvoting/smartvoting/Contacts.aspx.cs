using System;
using System.Net;
using System.Net.Mail;


namespace smartvoting
{
    public partial class Contacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         protected void Button1_Click(object sender, EventArgs e)
         {
             MailMessage mailMessage = new MailMessage();

             mailMessage.From = new MailAddress(email.Value,name.Value);
             mailMessage.Subject = "İletişim Formu: " + this.name.Value;

             mailMessage.To.Add("info@smartvotingsystem.com");

             string body;
             body = "Ad Soyad: " + this.name.Value + "<br />";
             body += "Telefon: " + this.mobile.Value + "<br />";
             body += "E-posta: " + this.email.Value + "<br />";
             body += "Konu: " + this.subject.Value + "<br />";
             body += "Mesaj: " + this.message.Value + "<br />";
             body += "Tarih: " + DateTime.Now.ToString("dd MMMM yyyy") + "<br />";
             mailMessage.IsBodyHtml = true;
             mailMessage.Body = body;

             SmtpClient smtp = new SmtpClient("mail.smartvotingsystem.com", 587);
             NetworkCredential nc = new NetworkCredential("info@smartvotingsystem.com", "Ybu1234*");
             nc.Domain = "info@smartvotingsystem.com";
             smtp.Credentials = nc;
             smtp.EnableSsl = true;

             try
             {
                 smtp.Send(mailMessage);
                 lblFormResult.Text = "<p style=" + "color:#7ede95" + ">İlginiz için teşekkür ederiz!</p>";
                 email.Value = "";
                 message.Value = "";
                 name.Value = "";
                 subject.Value = "";
             }
             catch (Exception ex)
             {
                 lblFormResult.Text = ex.Message;
             }
         }
     }
    }
    
