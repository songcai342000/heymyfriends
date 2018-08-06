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

public partial class usercontrol_frontside_membershiprequired : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Membershiprequired"] != null)
        {
            Literal1.Text = "Du må ha et abonnement for å ha tilgang til denne funksjonen. Vil du kjøpe abonnement? Klikke ";
            
        }
        else if (Request.QueryString["Duplicateusername"] != null)
        {
            Literal1.Text = "Brukernavnet er opptatt. Venligst velg et annet.";
        }
   
    }
  

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {

        Session["Username"] = Login1.UserName;
        if (Roles.IsUserInRole(Login1.UserName, "admin"))
        {
            Response.Redirect("/vennskap/administrator/Default.aspx");
        }
        if (Roles.IsUserInRole(Login1.UserName, "user"))
        {
            Response.Redirect("/vennskap/functions/Default.aspx");
        }

    }
}
