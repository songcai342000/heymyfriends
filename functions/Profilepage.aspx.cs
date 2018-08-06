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

public partial class Profilepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Control profile;
        if (Request.QueryString["Uleste"] != null || Request.QueryString["innkurven"] != null)
        {
            profile = LoadControl("~/usercontrol/mail/fattmail.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["Sendt"] != null)
        {
            profile = LoadControl("~/usercontrol/mail/utboks.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["skriv"] != null || Request.QueryString["writetoanother"] != null)
        {
            profile = LoadControl("~/usercontrol/mail/nymeldning.ascx");
            Session["Mailreceiver"] = Session["Profile"];
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["editprofile"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/oppretterprofil.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["visitorprofile"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/moreprofile.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["girlprofile"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/moreprofile.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["boyprofile"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/moreprofile.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["searchprofile"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/moreprofile.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["searchsimiliarprofile"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/moreprofile.ascx");
            Panel1.Controls.Add(profile);
        }
        /*else if (Request.QueryString["showprofile"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/annenprofil.ascx");
            Panel1.Controls.Add(profile);
        }*/
        else if (Request.QueryString["createalbum"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/album/lagalbum.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["seealbum"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/album/lagalbum.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["myblogs"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/blog/lastblogg.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["editmember"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/oppretterprofil.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["deactivatemember"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/deaktivprofil.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["stopmember"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/profil/stopmember.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["writetoprofile"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/mail/nymeldning.ascx");
            Panel1.Controls.Add(profile);
        }
        else if (Request.QueryString["iamfavorite"] != null)
        {
            profile = LoadControl("/vennskap/usercontrol/minside/minepotensielle.ascx");
            Panel1.Controls.Add(profile);
        }
    }

    protected void inbox_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/mail/fattmail.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void sendt_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/mail/utboks.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void skriv_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/mail/nymeldning.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void profil_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/profil/minprofil.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void album_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/album/lagalbum.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void Bloger_Click(object sender, EventArgs e)
    {
        //Session["loadthecontrol"] = "/vennskap/usercontrol/blog/lastblogg.ascx";
        Response.Redirect("/vennskap/functions/Profilepage.aspx?myblogs={0}");
    }
    protected void redigeremeldem_Click(object sender, EventArgs e)
    {
        //Response.Redirect("/vennskap/functions/Profilepage.aspx?editprofile={0}");
    }
    protected void avsluttmeldem_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/profil/stopmember.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void minevenner_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine venner";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void favoritt_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine favorittprofiler";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void megsomfavoritt_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Meg som favoritt";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void besokere_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine besøkerer";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void favorittBloger_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine favorittblogger";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    /*protected void Blog_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/");
        Response.Redirect("/vennskap/functions/Default.aspx");
    }*/
    protected void statistic_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minsidecontent.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void deactivateMember_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/profil/stopmember.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void createprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Profilepage.aspx?editprofile={0}");
        //Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void mineblomster_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine blomster";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
    protected void minenøkler_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine nøkler";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
        Response.Redirect("/vennskap/functions/Default.aspx");
    }
}
