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

public partial class usercontrol_location_oppland : System.Web.UI.UserControl
{
    /*public string City
    {
        get
        {
            Session["city"] = opplandList.SelectedValue;
            return Session["city"].ToString();
        }
        set
        {
            opplandList.SelectedValue = Session["city"].ToString();
            Session["city"] = value;
        }
    }*/
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["city"] = opplandList.SelectedValue;
        if (Session["city"].ToString() != "")
        {
            opplandList.SelectedValue = Session["city"].ToString();
        }
        else
        {
            opplandList.SelectedValue = "";
        }
    }
    protected void opplandList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["city"] = opplandList.SelectedValue;
    }
}

