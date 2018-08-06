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

public partial class functions_Nye : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if the senders name is not "", read his profile
        if (Request.QueryString["annenprofile"] != null)
        {
            Control profil = LoadControl("/vennskap/usercontrol/profil/annenprofil.ascx");
            Panel1.Controls.Add(profil);
            //set session profil as original value
            //Session["Profil"] = "";
        }
        if (Request.QueryString["seealbum"] != null)
        {
            Control profil = LoadControl("/vennskap/usercontrol/album/annenalbum.ascx");
            Panel1.Controls.Add(profil);
            //set session profil as original value
            //Session["Album"] = "";
        }
        if (Request.QueryString["seeblog"] != null)
        {
            Control profil = LoadControl("/vennskap/usercontrol/blog/readblog.ascx");
            Panel1.Controls.Add(profil);
            //set session profil as original value
            //Session["Blog"] = "";
        }
        if (Request.QueryString["blockuser"] != null)
        {
            Control profil = LoadControl("/vennskap/usercontrol/profil/blockprofile.ascx");
            Panel1.Controls.Add(profil);
            //set session profil as original value
            //Session["Blog"] = "";
        }
    }
}
