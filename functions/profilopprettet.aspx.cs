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

public partial class Profilopprettet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //load different usercontrol by different condition and get different information
        if (Request.QueryString["profilereceip"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["novalidprofile"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["noprofilefound"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["newmailreceip"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["newblogreceip"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["favoriteblog"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["key"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["newfriendreceip"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["favoriteprofile"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
        }
        else if (Request.QueryString["blockprofile"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["blockprofilefeil"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["newmailfeil"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["newblogfeil"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["favoriteblogfeil"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["newprofilefeil"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
        }
        else if (Request.QueryString["newfriendfeil"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["paymentreceip"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
        else if (Request.QueryString["registerrequired"] != null)
        {
            Control uc = LoadControl("/vennskap/usercontrol/profil/profilkvittering.ascx");
            Panel1.Controls.Add(uc);

        }
  
    }
}
