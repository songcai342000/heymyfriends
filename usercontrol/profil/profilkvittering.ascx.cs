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

public partial class usercontrol_profil_profilkvittering : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["profilereceip"] != null)
        {
            receip.Text = "Profilen din er nå sendt til godkjenning.";
        }
        else if (Request.QueryString["novalidprofile"] != null)
        {
            receip.Text = "Din profil venter nå på godkjenelse. Du får svar innen 36 timer.";
        }
        else if (Request.QueryString["noprofilefound"] != null)
        {
            receip.Text = "Det finnes 0 profile.";
        }
        else if (Request.QueryString["noblogfound"] != null)
        {
            receip.Text = "Det finnes 0 blog.";
        }
        else if (Request.QueryString["newmailreceip"] != null)
        {
            receip.Text = "Din melding har blitt sendt til " + Session["Profil"].ToString();
        }
        else if (Request.QueryString["newfriendreceip"] != null)
        {
            receip.Text = Session["Profil"].ToString() + "er nå lagt til dine venner";
        }
        else if (Request.QueryString["newblogreceip"] != null)
        {
            receip.Text = "Bloggen har blitt last opp.";
        }
        else if (Request.QueryString["newkeyreceip"] != null)
        {
            receip.Text = "Din førspørelse har blitt sendt til " + Session["Profil"].ToString();
        }
        else if (Request.QueryString["favoriteblog"] != null)
        {
            receip.Text = "Bloggen har blitt lagt til i dine favoritt.";
        }
        else if (Request.QueryString["key"] != null)
        {
            receip.Text = "Key har blitt lagt til i din lag.";
        }
        else if (Request.QueryString["favoriteprofile"] != null)
        {
            receip.Text = "Profilen har blitt lagt til i dine favoritt.";
        }
        else if (Request.QueryString["blockprofile"] != null)
        {
            receip.Text = "Profilen har blitt blokkert.";
        }
        else if (Request.QueryString["blockprofilefeil"] != null)
        {
            receip.Text = "Server feil. Venligst prøve igjen senere.";
        }
        else if (Request.QueryString["newmailfeil"] != null)
        {
            receip.Text = "Server feil. Venligst prøve igjen senere.";
        }
        else if (Request.QueryString["newbloglfeil"] != null)
        {
            receip.Text = "Server feil. Venligst prøve igjen senere.";
        }
        else if (Request.QueryString["nokey"] != null)
        {
            receip.Text = "Brukeren har ikke album ennå.";
        }
        else if (Request.QueryString["newfriendfeil"] != null)
        {
            receip.Text = "Server feil. Venligst prøve igjen senere.";
        }
        else if (Request.QueryString["newprofilefeil"] != null)
        {
            receip.Text = "Server feil. Venligst prøve igjen senere.";
        }
        else if (Request.QueryString["paymentreceip"] != null)
        {
            receip.Text = "Takk for bestillingen. Din betalingsstatus har blitt oppdattet.";
        }
        else if (Request.QueryString["registerrequired"] != null)
        {
            receip.Text = "Vennligst opprett et brukerskonto først.";
            registermemberlink.Visible = true;
            registermemberlink.Enabled = true;
        }
    }
}
