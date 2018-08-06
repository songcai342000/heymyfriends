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
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

public partial class usercontrol_lagalbum : System.Web.UI.UserControl
{
    Picturecollection mypictures;
    int Id;
    string Username;
    Mutex mtx1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        Id = int.Parse(Session["PictureId"].ToString());
        mypictures = new Picturecollection();
        lock (mypictures)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getbyid), mypictures);
                Dictionary<string, DataTable> thepic = mypictures.getdictionarypic();
                DataTable pictureTable = thepic[Username];
                Debug.Assert(pictureTable != null, "get picture by id not successfully");
                string path = pictureTable.Rows[0]["Picturepath"].ToString();
                System.Drawing.Image theimage = Bitmap.FromFile("c:\\users\\documents\\visual studio 2008\\vennskaper\\images\\" + path);
                int wid = theimage.Width;
                int hei = theimage.Height;
                Image1.Width = wid + 50;
                Image1.Height = theimage.Height + (int)(50 * (wid / hei));
                Image1.ImageUrl = "/vennskap/images/" + path;
                string des = pictureTable.Rows[0]["Picturepath"].ToString();
                desLi.Text = des;
            }
            catch(Exception ex)
            {
                //logic
                Exceptncollection myex = new Exceptncollection();
                myex.exceptiondata(Username, ex.Message, myex);
            }
            finally
            {
                mypictures.removedictionarypic(Username);
            }
        }
    }

    /// <summary>
    /// callback object
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="TimeOut"></param>
    protected void getbyid(Object obj)
    {
        DataTable table;
        table = ((Picturecollection)obj).GetPictureById(Id);
        ((Picturecollection)obj).filldictionarypic(Username, table);
    }
}
