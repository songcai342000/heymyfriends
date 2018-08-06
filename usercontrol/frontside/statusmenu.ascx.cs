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

public partial class usercontrol_mainmenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(Session["Username"].ToString(), "user") || Roles.IsUserInRole(Session["Username"].ToString(), "admin"))
        {
            LoginStatus1.Visible = true;
            nameHype.Text = "Velkomme, " + Session["Username"].ToString();
        }
        else
        {
            LoginStatus1.Visible = false;
            nameHype.Visible = false;
        }
    }

    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        //Session["Username"] = "";
        LoginStatus1.Visible = false;
        nameHype.Visible = false;
    }
}
