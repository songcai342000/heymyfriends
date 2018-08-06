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

public partial class usercontrol_frontside_miniloggin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
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
