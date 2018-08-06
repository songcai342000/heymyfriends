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

public partial class usercontrol_abonnement : System.Web.UI.UserControl
{
    List<string> priceList;
    protected void Page_Load(object sender, EventArgs e)
    {
        priceList = new List<string>();
        string pricevalue;
        pricevalue = "Kjøp 12 måneder for 1199 kr";
        priceList.Add(pricevalue);
        pricevalue = "Kjøp 6 måneder for 699 kr";
        priceList.Add(pricevalue);
        pricevalue = "Kjøp 3 måneder for 399 kr";
        priceList.Add(pricevalue);
        pricevalue = "Kjøp 1 måneder for 149 kr";
        priceList.Add(pricevalue);
        priceRad.DataSource = priceList;
        priceRad.DataBind();
        ProfileCommon myProfile = Profile.GetProfile(Session["Username"].ToString());
        if (myProfile.General.Validorder.ToString() != "01.01.0001 00:00:00")
        {
            if (myProfile.General.Validorder.CompareTo(DateTime.Now) <= 0)
            {
                validdaysinforLi.Text = string.Format("Din abonnement utløpet på {0}", myProfile.General.Validorder.ToString());
            }
            else
            {
                validdaysinforLi.Text = string.Format("Din abonnement er til {0}", myProfile.General.Validorder.ToString());
            }
        }
        else
        {
            validdaysinforLi.Text = "Du har ingen abonnement.";        
        }
        
    }
    protected void payBtn_Click(object sender, EventArgs e)
    {
        //need web payment solution
        /*ProfileCommon myProfile = Profile.GetProfile(Session["Username"].ToString());
        if (myProfile != null)
        {
            if (priceRad.SelectedValue == priceList[0].ToString())
            {
                myProfile.General.Validorder = myProfile.General.Validorder.AddMonths(12);
            }
            else if (priceRad.SelectedValue == priceList[1].ToString())
            {
                myProfile.General.Validorder = myProfile.General.Validorder.AddMonths(6);
            }
            else if (priceRad.SelectedValue == priceList[2].ToString())
            {
                myProfile.General.Validorder = myProfile.General.Validorder.AddMonths(3);
            }
            else if (priceRad.SelectedValue == priceList[3].ToString())
            {
                myProfile.General.Validorder = myProfile.General.Validorder.AddMonths(1);
            }
            myProfile.General.Status = "Active";
            Response.Redirect("/vennskap/functions/Profilopprettet.aspx?paymentreceip={0}");
        }
        //active this later
        else
        {
            //show message
            string alertmessage = "alert('Vennlig register deg som bruker')";
            Response.Write(alertmessage);
        }
    }*/
    }
           
}
