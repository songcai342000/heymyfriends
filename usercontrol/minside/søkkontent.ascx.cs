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
using System.Collections.Generic;
using vennobjects;

public partial class usercontrol_søkkontent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["Min"] = min.SelectedValue;
        Session["Max"] = maks.SelectedValue;
        Session["selectedprovince"] = fylke.SelectedValue;
        Session["selectedgender"] = gender.SelectedValue;
        Session["selectedmembershipstart"] = nymeldem.SelectedValue;
        if (CheckBox2.Checked)
        {
            Session["allprofile"] = "Yes";
        }
        if (CheckBox3.Checked)
        {
            Session["profilepicture"] = "Yes";
        }
        if (CheckBox4.Checked)
        {
            Session["profilealbum"] = "Yes";
        }
        if (CheckBox5.Checked)
        {
            Session["profileblog"] = "Yes";
        }
        Response.Redirect("/vennskap/functions/Profilepage.aspx?searchprofile={0}");
    }
    //member search
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (CheckBox6.Checked)
        {
            Session["Profil"] = memberTxt.Text;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofile={0}");
        }
        else
        {
            Session["profilesearch"] = memberTxt.Text;
            Response.Redirect("/vennskap/functions/Profilepage.aspx?searchsimiliarprofile={0}");
        }
    }
}
