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
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

public partial class usercontrol_annenalbum : System.Web.UI.UserControl
{
    //Picturecollection mypictures;
    //Picturecollection pictures;
    //DataTable pictureTable;
    int Id;
    string Username;
    string Profilename;
    /*Exceptncollection myex1;
    Exceptncollection myex2;
    Mutex mymtx1;
    Mutex mymtx2;*/
    //Mutex mtx1;
    protected void Page_Load(object sender, EventArgs e)
    {
        //get username and profilename
        Username = Session["Username"].ToString();
        Profilename = Session["Profil"].ToString();
        //mypictures = new Picturecollection();
        //get pictures by profile name
        Picturecollection mypictures = new Picturecollection();
        lock (mypictures)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getbyuser), mypictures);
                Dictionary<string, DataTable> picbyuser = mypictures.getdictionarybyuser();
                DataTable pictureTable = mypictures.GetPictureByUser(Profilename);
                Debug.Assert(pictureTable != null, "getpicture by user table is null");
                getpictures(pictureTable);
            }
            catch(Exception ex)
            {
                Exceptncollection myex1 = new Exceptncollection();
                myex1.exceptiondata(Username, ex.Message, myex1);
            }
            finally
            {
                /*if (myex1 != null)
                {
                    myex1.removedicid(Username);
                }
                if (mymtx1 != null)
                {
                    mymtx1.ReleaseMutex();
                }*/
                mypictures.removedictionarybyuser(Username);
            }
        }
    }

    //int PictureId;
    protected void theimagebutton_Click(object sender, ImageClickEventArgs e)
    {
        //get pictureid from the imagebutton clicked
        Session["PictureId"] = int.Parse(((ImageButton)sender).ID);
        //launch data on another page
        Response.Redirect("/vennskap/functions/Readmailprofil.aspx?fullsizepicture={0}");
    }

    //cancel selected picture
    protected void cancelpicBtn_Click(object sender, EventArgs e)
    {
        //Picturecollection pictures2 = new Picturecollection();
        //get picture id from button id
        Mutex mtx1 = null;
        Picturecollection mypictures = new Picturecollection();
        try
        {
            Id = int.Parse(((Button)sender).ID.Substring(3));
            ManualResetEvent evt1 = new ManualResetEvent(false);
            mtx1 = new Mutex(true);
            ThreadPool.RegisterWaitForSingleObject(evt1,
          new WaitOrTimerCallback(getbyid),
          null, Timeout.Infinite, true);
            Dictionary<string, DataTable> thedictionarybyid = mypictures.getdictionarypic();
            //int CommentId = thedictionaryid[Username];
            DataTable thetable = thedictionarybyid["Username"];
            //mypictures.removedictionarypic(Username);
            ThreadPool.RegisterWaitForSingleObject(mtx1,
               new WaitOrTimerCallback(savechange),
               null, Timeout.Infinite, true);

            //DataTable thetable = pictures2.GetPictureById(pictureid);
            //Picture thepicture = new Picture(Id, Username, thetable.Rows[0]["Picturepath"].ToString(), DateTime.Parse(thetable.Rows[0]["Time"].ToString()), thetable.Rows[0]["Description"].ToString());
            //delete the picture from table and update database
            if (thetable.Rows.Count == 1)
            {
                thetable.Rows.Remove(thetable.Rows[0]);
            }
            //mypictures.Save();
            evt1.Set();
            Debug.Assert(thetable != null, "get picture by id feil");
        }
        catch (Exception ex)
        {
            Exceptncollection myex2 = new Exceptncollection();
            lock (myex2)
            {
                myex2.exceptiondata(Username, ex.Message, myex2);
            }
        }
        finally
        {
            /*if (myex2 != null)
            {
                myex2.removedicid(Username);
            }
            if (mymtx2 != null)
            {
                mymtx2.ReleaseMutex();
            }*/
            if (mtx1 != null)
            {
                mtx1.ReleaseMutex();
            }
        }
    }

    protected void getpictures(DataTable pictureTable)
    {
        if (pictureTable.Rows.Count > 0)
        {
            clickPicLi.Visible = true;
        }
        else
        {
            clickPicLi.Visible = false;
        }
        photoPanel.Controls.Add(new LiteralControl("<table><tr>"));
        int i;
        for (i = 0; i < pictureTable.Rows.Count; i++)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            ImageButton imgBtn = new ImageButton();
            imgBtn.Width = 120;
            imgBtn.Height = 100;
            imgBtn.ImageUrl = "/vennskap/images/" + (pictureTable.Rows[i]["Picturepath"].ToString()).Substring(74);
            imgBtn.ID = pictureTable.Rows[i]["Id"].ToString();
            imgBtn.Click += new ImageClickEventHandler(theimagebutton_Click);
            photoPanel.Controls.Add(imgBtn);
            photoPanel.Controls.Add(new LiteralControl("<br />"));
            Button cancelpicBtn = new Button();
            cancelpicBtn.Text = "Slette";
            cancelpicBtn.ID = "Btn" + pictureTable.Rows[i]["Id"].ToString();
            cancelpicBtn.Click += new EventHandler(cancelpicBtn_Click);
            cancelpicBtn.OnClientClick = "alert('Er du sikkert du skal slette dette bildet?')";
            photoPanel.Controls.Add(cancelpicBtn);
            photoPanel.Controls.Add(new LiteralControl("</td>"));
            if (i == 4 || i == 9 || i == 14 || i == 19 || i == 24)
            {
                photoPanel.Controls.Add(new LiteralControl("</tr><tr>"));
            }
        }
        if (i < 5)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 10 && i > 5)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 15 && i > 10)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 20 && i > 15)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 25 && i > 20)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 30 && i > 25)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (!(i == 4 || i == 9 || i == 14 || i == 19 || i == 24))
        {
            photoPanel.Controls.Add(new LiteralControl("</tr><tr>"));
        }
        photoPanel.Controls.Add(new LiteralControl("</table>"));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    //method for callingback
    protected void getbyid(Object obj, bool TimeOut)
    {
        DataTable table;
        table = ((Picturecollection)obj).GetPictureById(Id);
        ((Picturecollection)obj).filldictionarypic(Username, table);
    }

    protected void getbyuser(Object obj)
    {
        DataTable table;
        table = ((Picturecollection)obj).GetPictureByUser(Profilename);
        ((Picturecollection)obj).filldictionarybyuser(Username, table);
    }

    protected void constru(Object obj, bool TimeOut)
    { 
       obj = new Picturecollection(1);
    }

    protected void savechange(Object obj, bool TimeOut)
    {
        ((Picturecollection)obj).Save();
    }
}
