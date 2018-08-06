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

public partial class Hjelp : System.Web.UI.Page
{
    //load different content on hjelp.aspx
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Membershiprequired"] != null)
        {
            Control profile = LoadControl("~/usercontrol/frontside/membershiprequired.ascx");
            PlaceHolder1.Controls.Add(profile);
        }
        else if (Request.QueryString["Duplicateusername"] != null)
        {
            Control profile = LoadControl("~/usercontrol/frontside/membershiprequired.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["Noblogfound"] != null)
        {
            Control profile = LoadControl("~/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(new LiteralControl("<div style='padding-left: 110px'>"));
            Panel1.Controls.Add(profile);
            Panel1.Controls.Add(new LiteralControl("</div>"));
        }
        else if (Request.QueryString["Aboutsite"] != null)
        {
            Control profile = LoadControl("~/usercontrol/frontside/aboutwebside.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["Privacy"] != null)
        {
            Control profile = LoadControl("~/usercontrol/frontside/privacy.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["Help"] != null)
        {
            Control profile = LoadControl("~/usercontrol/frontside/help.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["Order"] != null)
        {
            Control profile = LoadControl("~/usercontrol/frontside/abonnement.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["Contact"] != null)
        {
            Control profile = LoadControl("~/usercontrol/frontside/contact.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["Agreement"] != null)
        {
            Control profile = LoadControl("~/usercontrol/frontside/agreement.ascx");
            Panel1.Controls.Add(profile);
        }
    }
}
