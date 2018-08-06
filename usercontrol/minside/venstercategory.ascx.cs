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

public partial class usercontrol_venstercategory : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //show minsidecontent by default 
        if (Session["loadthecontrol"].ToString() == "")
        {
            Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minsidecontent.ascx";
        }
        //show number of new mail
        Epostcollection epostcollection = new Epostcollection();
        DataTable newposttable = epostcollection.GetEpostByReceiverStatus(Session["Profil"].ToString());
        newmailLi.Text = "(" + newposttable.Rows.Count.ToString() + ")";
    }

    protected void inbox_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/mail/fattmail.ascx";
    }
    protected void sendt_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/mail/utboks.ascx";
    }
    protected void skriv_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/mail/nymeldning.ascx";
    }
    //load up my profile
    protected void profil_Click(object sender, EventArgs e)
    {
         //check if the user is valid, get profile data
        //MembershipUser theuser = Membership.GetUser(Session["Username"].ToString());
        //ProfileCommon theprofile = Profile.GetProfile(Session["Profil"].ToString());
        /*if (t)
        {
            Session["loadthecontrol"] = "/vennskap/usercontrol/profil/minprofil.ascx";
        }
        else
        {
            Response.Redirect("/vennskap/functions/Profilopprettet.aspx?novalidprofile={0}");     
        }*/
        Session["loadthecontrol"] = "/vennskap/usercontrol/profil/minprofil.ascx";
    }
    protected void album_Click(object sender, EventArgs e)
    {
        //Session["loadthecontrol"] = "/vennskap/usercontrol/album/lagalbum.ascx";
        Response.Redirect("/vennskap/functions/Profilepage.aspx?createalbum={0}");
    }
    /*protected void Bloger_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/blog/lastblogg.ascx";
    }*/
    protected void redigeremeldem_Click(object sender, EventArgs e)
    {
        //Response.Redirect("/vennskap/functions/Profilepage.aspx?editprofile={0}");
    }
 
    protected void avsluttmeldem_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/profil/stopmember.ascx";
    }
    protected void minevenner_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine venner";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
    }
    protected void favoritt_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine favorittprofiler";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
    }
    protected void megsomfavoritt_Click(object sender, EventArgs e)
    {
        //use different session from session["favoritetype"], easier when need to use different function later
        Session["iamfavorite"] = "Meg som favoritt";
        Response.Redirect("/vennskap/functions/Profilepage.aspx?iamfavorite={0}");
        /*Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
        Session["favoritetype"] = "myfavoriteprofile";*/
    }
    protected void besokere_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine besøkerer";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
    }
    protected void favorittBloger_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine favorittblogger";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
    }
    protected void statistic_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minsidecontent.ascx";
    }
    protected void deactivateMember_Click(object sender, EventArgs e)
    {
        Session["loadthecontrol"] = "/vennskap/usercontrol/profil/stopmember.ascx";
    }
    protected void createprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Profilepage.aspx?editprofile={0}");
    }
    protected void Bloger_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Profilepage.aspx?myblogs={0}");
    }
    protected void mineblomster_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine blomster/kupper";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
    }
    protected void minenøkler_Click(object sender, EventArgs e)
    {
        Session["favoritetype"] = "Mine nøkler";
        Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minepotensielle.ascx";
    }
}
