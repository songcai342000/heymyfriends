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

public partial class functions_DisplayPicture : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Picturecollection mypictures = new Picturecollection();
        DataTable pictureTable = mypictures.GetPictureById(int.Parse(Session["PictureId"].ToString()));
    }
}
