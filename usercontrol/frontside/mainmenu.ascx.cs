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
        /*if (Session["Username"] != "")
        {
            start.PostBackUrl = "/vennskap/functions/Default.aspx";
        }*/
    }
    protected void seek_Click(object sender, EventArgs e)
    {
        if (Session["Username"].ToString() != "")
        {
            Session["loadthecontrol"] = "/vennskap/usercontrol/minside/søkkontent.ascx";
            seek.PostBackUrl = "/vennskap/functions/Søk.aspx";
        }
        else
        {
            seek.PostBackUrl = "/vennskap/general/Hjelp.aspx?Membershiprequired={0}";
        }
    }
    protected void minside_Click(object sender, EventArgs e)
    {
        if (Session["Username"].ToString() != "" && Roles.IsUserInRole(Session["Username"].ToString(), "user"))
        {
            Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minsidecontent.ascx";
            minside.PostBackUrl = "/vennskap/functions/Default.aspx";
        }
        else if (Session["Username"].ToString() != "" && Roles.IsUserInRole(Session["Username"].ToString(), "admin"))
        {
            Session["loadthecontrol"] = "/vennskap/usercontrol/minside/administration.ascx";
            minside.PostBackUrl = "/vennskap/administrator/Default.aspx";
        }
        else
        {
            minside.PostBackUrl = "/vennskap/general/Hjelp.aspx?Membershiprequired={0}";
        }
    }
  
    protected void venner_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/aboutwebside.ascx";
        venner.PostBackUrl = "/vennskap/general/Hjelp.aspx?Aboutsite={0}";        

    }
    protected void abonnement_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/abonnement.ascx";
        abonnement.PostBackUrl = "/vennskap/general/Hjelp.aspx?Order={0}";
    }
}
