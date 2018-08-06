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

public partial class functions_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostingFromMenu() && !IsPostBack)
        {
            if (Session["loadthecontrol"].ToString() != "")
            {
                try
                {
                    Control uc = LoadControl(Session["loadthecontrol"].ToString());
                    PlaceHolder1.Controls.Add(uc);
                }
                catch
                {
                }
            }
            else
            {
                Control uc = LoadControl("/vennskap/usercontrol/minside/minsidecontent.ascx");
                PlaceHolder1.Controls.Add(uc);
            }
        }
        
    }

    bool IsPostingFromMenu()
    {
        string ctlID = ScriptManager1.AsyncPostBackSourceElementID;
        Control c = this.FindControl(ctlID);
        if (c == null)
            return false;
        return (c.ID == "venstercategory1");
    }

}
