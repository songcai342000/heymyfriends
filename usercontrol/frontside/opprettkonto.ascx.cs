using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using vennobjects;
using System.Net.Mail;

public partial class usercontrol_opprettkonto : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

   protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
   {
       if (agree.Checked)
       {
           Session["Profil"] = CreateUserWizard1.UserName;
           Roles.AddUserToRole(CreateUserWizard1.UserName, "user");
           MembershipUser theuser = Membership.GetUser(CreateUserWizard1.UserName);
           theuser.IsApproved = true;
           Membership.DeleteUser("jing");
           //myMail();
           Server.Transfer("/vennskap/functions/Profilepage.aspx?editprofile={0}");
       }
       else
       {
           CreateUserWizard1.DisableCreatedUser = true;
           Membership.DeleteUser(CreateUserWizard1.UserName);
           CreateUserWizard1.Enabled = false;
           agreementrequired.Text = "Du må være enig om brukeravtalen og vilkår for å bli medlem.";
       }
   }
   protected void agree_CheckedChanged(object sender, EventArgs e)
   {
       if (agree.Checked)
       {
           CreateUserWizard1.Enabled = true;
           //if the user has been created, redirect the page to edit profile
           /*if (Roles.IsUserInRole(CreateUserWizard1.UserName, "user"))
           {
                Server.Transfer("/vennskap/functions/Profilepage.aspx?editprofile={0}");
           }*/
          // CreateUserWizard1.UserName = null;
           Server.Transfer("/vennskap/functions/Profilepage.aspx?editprofile={0}");
       }
   }

   protected void myMail(string mailaddr)
   {
       string mailcont = "";
       //oppretterer en mail obsjekt
       MailMessage message = new MailMessage(
        "Kundeservice@Minevenner.no",
        mailaddr,
        "Velkomme å bli medlem til Minevenner.no", mailcont);
       //Sender eposten via min isp server
       SmtpClient client = new SmtpClient("smtp.bluecom.no");
       client.Send(message);
   }
}
