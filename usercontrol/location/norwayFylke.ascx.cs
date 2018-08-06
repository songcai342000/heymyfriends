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

public partial class usercontrol_location_norwayFylke : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/non.ascx";
            if (Province == "" || Province == null)
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/non.ascx";
            }
            if (Province == "Akershus")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/akershus.ascx";
            }
            if (Province == "Aust-Agder")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/austagder.ascx";
            }
            if (Province == "Buskerud")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/buskerud.ascx";
            }
            if (Province == "Finnmark")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/finnmark.ascx";
            }
            if (Province == "Hedmark")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/hedmark.ascx";
            }
            if (Province == "Hordaland")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/hordaland.ascx";
            }
            if (Province == "Møre og Romsdal")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/møreogromsdal.ascx";
            }
            if (Province == "Nordland")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/nordtrøndelag.ascx";
            }
            if (Province == "Nord-Trøndelag")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/nordland.ascx";
            }
            if (Province == "Oppland")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/oppland.ascx";
            }
            if (Province == "Oslo")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/oslo.ascx";
            }
            if (Province == "Rogaland")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/rogaland.ascx";
            }
            if (Province == "Sogn og Fjordane")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/sognogfjord.ascx";
            }
            if (Province == "Sør-Trøndelag")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/sørtrøndelag.ascx";
            }
            if (Province == "Telemark")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/telemark.ascx";
            }
            if (Province == "Troms")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/troms.ascx";
            }
            if (Province == "Vest-Agder")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/vestagder.ascx";
            }
            if (Province == "Vestfold")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/vestfold.ascx";
            }
            if (Province == "Østfold")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/østfold.ascx";
            }
            if (Province == "Annet")
            {
                Session["provinceList"] = "/vennskap/usercontrol/location/annet.ascx";
            }
        }
        /*if (!IsPostBack)
        {
            Control uc = LoadControl(Session["provinceList"].ToString());
            PlaceHolder2.Controls.Clear();
            PlaceHolder2.Controls.Add(uc);
        }*/
    }

    public string Province
    {
        get { return fylke.SelectedValue; }
        set { fylke.SelectedValue = value; }
    }

  

    protected void fylke_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fylke.SelectedIndex == 0)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/non.ascx";
        }
        if (fylke.SelectedIndex == 1)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/akershus.ascx";
        }
        if (fylke.SelectedIndex == 2)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/austagder.ascx";
        }
        if (fylke.SelectedIndex == 3)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/buskerud.ascx";
        }
        if (fylke.SelectedIndex == 4)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/finnmark.ascx";
        }
        if (fylke.SelectedIndex == 5)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/hedmark.ascx";
        }
        if (fylke.SelectedIndex == 6)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/hordaland.ascx";
        }
        if (fylke.SelectedIndex == 7)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/møreogromsdal.ascx";
        }
        if (fylke.SelectedIndex == 8)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/nordtrøndelag.ascx";
        }
        if (fylke.SelectedIndex == 9)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/nordland.ascx";
        }
        if (fylke.SelectedIndex == 10)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/oppland.ascx";
        }
        if (fylke.SelectedIndex == 11)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/oslo.ascx";
        }
        if (fylke.SelectedIndex == 12)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/rogaland.ascx";
        }
        if (fylke.SelectedIndex == 13)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/sognogfjord.ascx";
        }
        if (fylke.SelectedIndex == 14)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/sørtrøndelag.ascx";
        }
        if (fylke.SelectedIndex == 15)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/telemark.ascx";
        }
        if (fylke.SelectedIndex == 16)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/troms.ascx";
        }
        if (fylke.SelectedIndex == 17)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/vestagder.ascx";
        }
        if (fylke.SelectedIndex == 18)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/vestfold.ascx";
        }
        if (fylke.SelectedIndex == 19)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/østfold.ascx";
        }
        if (fylke.SelectedIndex == 20)
        {
            Session["provinceList"] = "/vennskap/usercontrol/location/annet.ascx";
        }
    }
}
