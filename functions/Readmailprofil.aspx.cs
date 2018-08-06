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
using vennobjects;

public partial class functions_Readmailprofil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if the senders name is not "", read his profile
        if (Request.QueryString["readprofile"] != null)
        {
            Control profil = LoadControl("/vennskap/usercontrol/profil/minprofil.ascx");
            Panel1.Controls.Add(profil);
            //set session profil as original value
            //Session["Profil"] = "";
        }
        if (Request.QueryString["annenprofile"] != null)
        {
            Control profil = LoadControl("/vennskap/usercontrol/profil/annenprofil.ascx");
            Panel1.Controls.Add(profil);
            //set session profil as original value
            //Session["Profil"] = "";
        }
        if (Request.QueryString["fullsizepicture"] != null)
        {
            Control profil = LoadControl("/vennskap/usercontrol/album/fullsizepic.ascx");
            Panel1.Controls.Add(profil);
            //set session profil as original value
        }
        if (Request.QueryString["readmail"] != null)
        {
            Control mail = LoadControl("/vennskap/usercontrol/mail/lesemail.ascx");
            Panel1.Controls.Add(mail);
            //Session["Epost"] = "";
            //Session["Time"] = "";
            //Epostcollection postlist = new Epostcollection();
            //Epost mypost = postlist.Getmailbytitletime(Session["Epost"].ToString(), Session["Time"].ToString());
        }
        if (Request.QueryString["grantkey"] != null)
        {
            Control mail = LoadControl("/vennskap/usercontrol/mail/grantkey.ascx");
            Panel1.Controls.Add(mail);
            //Session["Epost"] = "";
            //Session["Time"] = "";
            //Epostcollection postlist = new Epostcollection();
            //Epost mypost = postlist.Getmailbytitletime(Session["Epost"].ToString(), Session["Time"].ToString());
        }
    }
}
