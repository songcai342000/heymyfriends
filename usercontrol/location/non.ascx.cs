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

public partial class usercontrol_location_non : System.Web.UI.UserControl
{
    /*public string City
    {
        get
        {
            return askerList.SelectedValue;
        }
        set
        {
            askerList.SelectedValue = value;
        }
    }*/
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["city"].ToString() != "")
        {
            askerList.SelectedValue = Session["city"].ToString();
        }
        else
        {
            askerList.SelectedValue = "";
        }
    }
    protected void askerList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["city"] = askerList.SelectedValue;
    }
}
