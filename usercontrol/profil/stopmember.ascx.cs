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

public partial class usercontrol_profil_stopmember : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void deactivateBtn_Click(object sender, EventArgs e)
    {
        //profile will not be shown as a search result
        Profile.Profileapproved = "";
    }
    protected void stopmemberBtn_Click(object sender, EventArgs e)
    {
        //profile is hiden, can't log in, user data is canceled after 3 monthes, should have a function to know the user if he / she register later again
        Profile.Profileapproved = "Canceled";
    }
}
