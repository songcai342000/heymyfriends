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

public partial class usercontrol_venstercategory2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //show minsidecontent by default 
        if (Session["loadthecontrol"].ToString() == "")
        {
            Session["loadthecontrol"] = "/vennskap/usercontrol/minside/minsidecontent.ascx";
        }
        /*Epostcollection epostcollection = new Epostcollection();
        DataTable newposttable = epostcollection.GetEpostByReceiverStatus(Session["Profil"].ToString());
        newmailLi.Text = "(" + newposttable.Rows.Count.ToString() + ")";*/
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
