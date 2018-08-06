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

public partial class usercontrol_location_møreogromsdal : System.Web.UI.UserControl
{
    /*public string City
    {
        get
        {
            Session["city"] = møreList.SelectedValue;
            return Session["city"].ToString();
        }
        set
        {
            møreList.SelectedValue = Session["city"].ToString();
            Session["city"] = value;
        }
    }*/
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["city"] = møreList.SelectedValue;
        if (Session["city"].ToString() != "")
        {
            møreList.SelectedValue = Session["city"].ToString();
        }
        else
        {
            møreList.SelectedValue = "";
        }
    }
    protected void møreList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["city"] = møreList.SelectedValue;
    }
}
