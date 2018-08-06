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
using System.IO.Compression;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;

public partial class usercontrol_lastblogg : System.Web.UI.UserControl
{
    #region globle
    Blog theblog;
    Blogcollection blogs;
    Blogcollection myblogs;
    DataTable blogtable;
    Mutex mtx1;
    //DataTable blogsorted;//my blogs in different categories
    string Username;
    string theblogtitle;
    string selectedcategory;
    string Profilename;
    /*Exceptncollection myex1;
    Exceptncollection myex2;
    Exceptncollection myex3;
    Exceptncollection myex4;
    Exceptncollection myex5;
    Exceptncollection myex6;
    Exceptncollection myex7;
    Mutex mymtx1;
    Mutex mymtx2;
    Mutex mymtx3;
    Mutex mymtx4;
    Mutex mymtx5;
    Mutex mymtx6;
    Mutex mymtx7;*/

    List<string> picdata = new List<string>();//picturepathes of blog pictures
    List<string> textcontent = new List<string>();//blog content in different textareas
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //get username
        Username = Session["Username"].ToString();//assign Username

        Profilename = Session["Profil"].ToString();//assign Profilename
        blogcount.Text = Session["myblogcount"].ToString();
        //get blogcount.Text from session
        topicbloglist.Visible = false;
        relationbloglist.Visible = false;
        activitybloglist.Visible = false;
        otherbloglist.Visible = false;
        //no need to use session
        //Session["sortlink"] = RadioButtonList1.SelectedValue;
        selectedcategory = RadioButtonList1.SelectedValue; ;
        if (RadioButtonList1.SelectedValue == "topic")
        {
            meaningLi.Text = "Hva mener du om dette?";
            meaningRad.Visible = true;
            meaningRad.Enabled = true;
            blogtitle.Text = Session["tematitle"].ToString();
        }
    }

    //clean requirement pf getallblogs of the user from dictionary when the user leave the page
    /*protected void Page_UnLoad(object sender, EventArgs e)
    {
        Blogcollection blogs = new Blogcollection();
        lock (blogs)
        {
            blogs.removedictionarybyuser(Username);
        }
    }*/
      

    //get all blogs of the user
    protected void getallblogs()
    {
        blogs = new Blogcollection();
        lock (blogs)
        {
            try
            {
                //no cache dependency because it doesn't change often
                ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusername), blogs);
                //Thread.Sleep(250);
                Dictionary<string, DataTable> thedictionarybyuser = blogs.getdictionarybyuser();
                blogtable = thedictionarybyuser[Username];
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
                //remove key from dictionary
                blogs.removedictionarybyuser(Username);
            }
        }
    }

    protected void topiclink_Click(object sender, EventArgs e)
    {
        //get blogs if it has not benn got
        if (blogtable == null)
        {
            getallblogs();
        }
        //get topic table
        DataTable blogsorted = blogtable.Clone();
        foreach (DataRow dr in blogtable.Rows)
        {
            if (dr["Blogcategory"].ToString() == "topic")
            {
                blogsorted.ImportRow(dr);
            }
        }
        //DataTable blogsorted = getbytopic;
        if (blogsorted.Rows.Count >= 1)
        {
            topicbloglist.DataSource = blogsorted;
            topicbloglist.DataBind();
        }
        topicbloglist.Visible = true;
    }
    protected void relationlink_Click(object sender, EventArgs e)
    {
        //get blogs if it has not benn got
        if (blogtable == null)
        {
            getallblogs();
        }
        DataTable blogsorted = blogtable.Clone();
        foreach (DataRow dr in blogtable.Rows)
        {
            if (dr["Blogcategory"].ToString() == "relation")
            {
                blogsorted.ImportRow(dr);
            }
        }
        if (blogsorted.Rows.Count >= 1)
        {
            relationbloglist.DataSource = blogsorted;
            relationbloglist.DataBind();
        }
        relationbloglist.Visible = true;
    }

    protected void activitylink_Click(object sender, EventArgs e)
    {
        //get blogs if it has not benn got
        if (blogtable == null)
        {
            getallblogs();
        }
        //get activity table
        DataTable blogsorted = blogtable.Clone();
        foreach (DataRow dr in blogtable.Rows)
        {
            if (dr["Blogcategory"].ToString() == "activity")
            {
                blogsorted.ImportRow(dr);
            }
        }
        if (blogsorted.Rows.Count >= 1)
        {
            activitybloglist.DataSource = blogsorted;
            activitybloglist.DataBind();
        }
        activitybloglist.Visible = true;
    }

    protected void otherlink_Click(object sender, EventArgs e)
    {
        //get blogs if it has not benn got
        if (blogtable == null)
        {
            getallblogs();
        }
        //get other table
        DataTable blogsorted = blogtable.Clone();
        foreach (DataRow dr in blogtable.Rows)
        {
            if (dr["Blogcategory"].ToString() == "other")
            {
                blogsorted.ImportRow(dr);
            }
        }
        if (blogsorted.Rows.Count >= 1)
        {
            otherbloglist.DataSource = blogsorted;
            otherbloglist.DataBind();
        }
        otherbloglist.Visible = true;
    }

    //send the blog
    //int BlogId = 0;
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //check if the user has valid abonnement or the user is administrator
            if (Username == "song" || (Profile.GetProfile(Username)).General.Validorder.CompareTo(DateTime.Now) > 0)
            {
                saveblog();
            }
            else if (Username == "" || (Profile.GetProfile(Username)).General.Validorder.CompareTo(DateTime.Now) < 0)
            {
                Response.Redirect("/vennskap/general/Hjelp.aspx?Membershiprequired={0}");
            }
        }
        catch (Exception ex)
        {
            Exceptncollection myex2 = new Exceptncollection();
            myex2.exceptiondata(Username, ex.Message, myex2);
            //legge til logikk eller feil meldning
        }
        /*finally
        
        {
           if (myex2 != null)
            {
                myex2.removedicid(Username);
            }
            if (mymtx2 != null)
            {
                mymtx2.ReleaseMutex();
            }
        }*/
        Response.Redirect("/vennskap/functions/Profilopprettet.aspx?newblogreceip={0}");
    }

  
   
    //if it is a topic discussion, the user will see the radiobutton to chose a point
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["sortlink"] = RadioButtonList1.SelectedValue;
        selectedcategory = RadioButtonList1.SelectedValue;
        if (RadioButtonList1.SelectedValue == "topic")
        {
            meaningLi.Text = "Hva mener du om dette?";
            meaningRad.Visible = true;
            meaningRad.Enabled = true;
            blogtitle.Text = Session["tematitle"].ToString();
        }
    }

    protected void topicbloglist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //get state management value when click linkbutton respectively
        ((LinkButton)e.CommandSource).Font.Bold = false;
        DataTable theblogvalue = new DataTable();
        if (e.CommandName == "blogTitle")
        {
            string blogtitle = (((LinkButton)e.Item.FindControl("titleBtn"))).Text;
            theblogtitle = blogtitle;
             //theblogvalue = null;
            //DataTable blogtable = myblogs.GetBlogByUserTitle(Username, blogtitle);
             blogs = new Blogcollection();
             lock (blogs)
             {
                 try
                 {
                     ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusertitle), blogs);
                     Dictionary<string, DataTable> thedictionarybyusertitle = blogs.getdictionarybyusertitle();
                     theblogvalue = thedictionarybyusertitle[Username];
                 }
                 catch(Exception ex)
                 {
                     Exceptncollection myex3 = new Exceptncollection();
                     myex3.exceptiondata(Username, ex.Message, myex3);
                 }
                 finally
                 {
                     /*if (myex3 != null)
                     {
                         myex3.removedicid(Username);
                     }
                     if (mymtx3 != null)
                     {
                         mymtx3.ReleaseMutex();
                     }*/
                     blogs.removedictionarybyusertitle(Username);
                 }
             }
            if (theblogvalue.Rows.Count > 0)
            {
                Session["chosensortedblog"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            //delete from dictionary, ready to read another blog
            Response.Redirect("/vennskap/general/Blogtarget.aspx");
        }
    }
    protected void relationbloglist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //get state management value when click linkbutton respectively
        ((LinkButton)e.CommandSource).Font.Bold = false;
        DataTable theblogvalue = new DataTable();
        if (e.CommandName == "blogTitle")
        {
            //Session["Time"] = (((LinkButton)e.Item.FindControl("timeBtn"))).Text;
            string blogtitle = (((LinkButton)e.Item.FindControl("titleBtn"))).Text;
            theblogtitle = blogtitle;
            //Blogcollection myblogs = null;
            blogs = new Blogcollection();
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusertitle), blogs);
                    Dictionary<string, DataTable> thedictionarybyusertitle = blogs.getdictionarybyusertitle();
                    theblogvalue = thedictionarybyusertitle[Username];
                }
                catch(Exception ex)
                {
                    Exceptncollection myex4 = new Exceptncollection();
                    myex4.exceptiondata(Username, ex.Message, myex4);
                }
                finally
                {
                    /*if (myex4 != null)
                    {
                        myex4.removedicid(Username);
                    }
                    if (mymtx4 != null)
                    {
                        mymtx4.ReleaseMutex();
                    }*/
                    blogs.removedictionarybyusertitle(Username);
                }
            }
            if (theblogvalue.Rows.Count > 0)
            {
                Session["chosensortedblog"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            //delete from dictionary, ready to read another blog
            Response.Redirect("/vennskap/general/Blogtarget.aspx");
        }
    }
    protected void activitybloglist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //get state management value when click linkbutton respectively
        ((LinkButton)e.CommandSource).Font.Bold = false;
        DataTable theblogvalue = new DataTable();
        if (e.CommandName == "blogTitle")
        {
            string blogtitle = (((LinkButton)e.Item.FindControl("titleBtn"))).Text;
            theblogtitle = blogtitle;
            //Blogcollection myblogs = null;
            blogs = new Blogcollection();
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusertitle), blogs);
                    Dictionary<string, DataTable> thedictionarybyusertitle = blogs.getdictionarybyusertitle();
                    theblogvalue = thedictionarybyusertitle[Username];
                }
                catch(Exception ex)
                {
                    Exceptncollection myex5 = new Exceptncollection();
                    myex5.exceptiondata(Username, ex.Message, myex5);
                }
                finally
                {
                   /* if (myex5 != null)
                    {
                        myex5.removedicid(Username);
                    }
                    if (mymtx5 != null)
                    {
                        mymtx5.ReleaseMutex();
                    }*/
                    blogs.removedictionarybyusertitle(Username);
                }
            }
            if (theblogvalue.Rows.Count > 0)
            {
                Session["chosensortedblog"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            //delete from dictionary, ready to read another blog
            Response.Redirect("/vennskap/general/Blogtarget.aspx");
        }
    }
    protected void otherbloglist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //get state management value when click linkbutton respectively
        ((LinkButton)e.CommandSource).Font.Bold = false;
        DataTable theblogvalue = new DataTable();
        if (e.CommandName == "blogTitle")
        {
            string blogtitle = (((LinkButton)e.Item.FindControl("titleBtn"))).Text;
            theblogtitle = blogtitle;
            //Blogcollection myblogs = null;
            blogs = new Blogcollection();
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusertitle), blogs);
                    Dictionary<string, DataTable> thedictionarybyusertitle = blogs.getdictionarybyusertitle();
                    theblogvalue = thedictionarybyusertitle[Username];
                }
                catch(Exception ex)
                {
                    Exceptncollection myex6 = new Exceptncollection();
                    myex6.exceptiondata(Username, ex.Message, myex6);
                }
                finally
                {
                   /* if (myex6 != null)
                    {
                        myex6.removedicid(Username);
                    }
                    if (mymtx6 != null)
                    {
                        mymtx6.ReleaseMutex();
                    }*/
                    blogs.removedictionarybyusertitle(Username);
                }
            }

            if (theblogvalue.Rows.Count > 0)
            {
                Session["chosensortedblog"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            //delete from dictionary, ready to read another blog
            Response.Redirect("/vennskap/general/Blogtarget.aspx");
        }
    }
    //load up picture for the blog
    int BlogId;
    protected void loadBtn_Click(object sender, EventArgs e)
    {
        if (loadPic.HasFile)
        {
            try
            {
                // Get the name of the file to upload.
                String fileName = loadPic.FileName;
                System.Drawing.Image theimage = Bitmap.FromFile(fileName);
                Bitmap bmp = new Bitmap(theimage, 117, 90);

                // Append the name of the file to upload to the path.
                string picturepath = "C:\\Users\\mhelenem\\Documents\\Visual Studio 2008\\Websites\\vennskaper\\images\\" + BlogId.ToString() + ".jpg";
                picdata.Add(picturepath);
                //Save the picture to web server
                bmp.Save(picturepath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                //logic
                Exceptncollection myex7 = new Exceptncollection();
                lock (myex7)
                {
                    myex7.exceptiondata(Username, ex.Message, myex7);
                }
            }
            /*finally
            {
                if (myex7 != null)
                {
                    myex7.removedicid(Username);
                }
                if (mymtx7 != null)
                {
                    mymtx7.ReleaseMutex();
                }
            }*/
            //insert pictures to blog
            insertpic(picdata);
        }
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "Du har ikke spesiferert en fil til å laste opp.";
        }
    }

    private string meaning;
    public string Meaning
    {
        get
        {
            if (meaningRad.SelectedValue == "Jeg er enig")
            {
                meaning = "Positive";
            }
            else
            {
                meaning = "Negative";
            }
            return meaning;
        }
        set
        {
            meaning = value;
        }
    }
    protected void meaningRad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (meaningRad.SelectedValue == "Jeg er enig")
        {
            meaning = "Positive";
        }
        else
        {
            meaning = "Negative";
        }
    }

    //thread management

    //producer
    /// <summary>
    /// id must be created before save
    /// </summary>
    /// <param name="obj"></param>
    protected void SaveBlog(Object obj, bool TimeOut)
    {
        ((Blogcollection)obj).Save();
    }

  
   //thread management
    protected void getbyusername(Object obj)
    {
        DataTable table;
        table = ((Blogcollection)obj).GetByUsername(Username);
        ((Blogcollection)obj).filldictionarybyuser(Username, table);
    }

   

    protected void createid(Object obj)
    {
        int BlogId;
        BlogId = ((Blogcollection)obj).CreateBlogId();
        ((Blogcollection)obj).filldictionaryid(Username, BlogId);
    }

    //create object by new Blogcollection(1);
    protected void constru(Object obj, bool TimeOut)
    {
        obj = new Blogcollection(1);
    }

    protected void getbyusertitle(Object obj)
    {
        DataTable table;
        //obj = new Blogcollection();
        table = ((Blogcollection)obj).GetBlogByUserTitle(Profilename, theblogtitle);
        ((Blogcollection)obj).filldictionarybyusertitle(Username, table);
    }

    protected void compressfile(string savePath)
    {
        //get contents
        string x = "";
        foreach (string str in textcontent)
        {
            x += "<picurl>" + str + "\n";
        }
        //compress file
        using (FileStream fs = new FileStream(savePath, FileMode.CreateNew))
        {
            using (GZipStream mygz = new GZipStream(fs, CompressionMode.Compress))
            {
                using (StreamWriter sw = new StreamWriter(mygz))
                {
                    lock (sw)
                    {
                        //write blog content to a text file
                        sw.Write(x);
                    }
                }
            }
        }
    }

    protected void saveblog()
    {
        //Blogcollection blogs = null;
        int BlogId;
        blogs = new Blogcollection();
        try
        {
            lock (blogs)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createid), blogs);
                Dictionary<string, int> thedictionaryid = blogs.getdictionaryid();
                BlogId = thedictionaryid[Username];
            }
            if (BlogId != -1)
            {
                ManualResetEvent evt1 = new ManualResetEvent(false);
                mtx1 = new Mutex(true);

                string savePath = @"C:\Users\mhelenem\documents\Visual Studio 2008\WebSites\vennskaper\blogarticles\" + BlogId.ToString() + ".txt" + ".gz";
                compressfile(savePath);
                string picturepath = "C:\\Users\\mhelenem\\Documents\\Visual Studio 2008\\Websites\\vennskaper\\images\\" + BlogId.ToString() + ".jpg";
                //Blog theblog = null;
                if (meaningRad.Enabled == true)
                {
                    //theblog = new Blog(BlogId, Username, Session["tematitle"].ToString(), savePath, DateTime.Now, Session["sort"].ToString(), Meaning, picturepath.Substring(74));
                    theblog = new Blog(BlogId, Username, Session["tematitle"].ToString(), savePath, DateTime.Now, selectedcategory, "", theblog.Picturepath);
                }
                else
                {
                    Meaning = "";
                    //theblog = new Blog(BlogId, Username, Session["tematitle"].ToString(), savePath, DateTime.Now, Session["sort"].ToString(), "", picturepath.Substring(74));
                    theblog = new Blog(BlogId, Username, Session["tematitle"].ToString(), savePath, DateTime.Now, selectedcategory, "", theblog.Picturepath);
                }
                //delete from dictionary, ready to send another blog
                //add blog to database
                //Blogcollection myblogs = new Blogcollection(1);//get schema

                ThreadPool.RegisterWaitForSingleObject(evt1,
                  new WaitOrTimerCallback(constru),
                  null, Timeout.Infinite, true);

                //ThreadPool.QueueUserWorkItem(new WaitCallback(constru), blogs);
                myblogs.Add(theblog);
                ThreadPool.RegisterWaitForSingleObject(mtx1,
                   new WaitOrTimerCallback(SaveBlog),
                   null, Timeout.Infinite, true);
                evt1.Set();
            }
        }
        catch
        {

        }
        finally
        {
            blogs.removedictionaryid(Username);
            if (mtx1 != null)
            {
                mtx1.ReleaseMutex();
            }
        }
        //myblogs.Save();
        //threadpool
        //ThreadPool.QueueUserWorkItem(new WaitCallback(SaveBlog), blogs);
    }

    //insert picture to blog
    protected void insertpic(List<string> picdata)
    {
        //theblog.Blogpath = "";
        theblog.Picturepath = "";
        for (int i = 0; i < picdata.Count; i++)
        {
            if (i == 0)
            {
                if (blogtext.Value == "")
                {
                    blogtext.Style.Value = "background-image:url(" + picdata[0].ToString() + "); background-position: top; background-repeat: no-repeat; border:none 0px transparent; overflow:hidden;";
                }
                else
                {
                    blogtext.Style.Value = "background-image:url(" + picdata[0].ToString() + ") background-position: bottom; background-repeat: no-repeat; border:none 0px transparent; overflow:hidden;";
                }
                blogtext.Disabled = true;
                inpHide.Value = textcontent[0].ToString();
                PlaceHolder1.Controls.Add(new LiteralControl("<div><textarea cols='47' style='border:none 0px transparent; overflow:hidden;'"));
                PlaceHolder1.Controls.Add(new LiteralControl(" id= '1' onload='return assignText()' onclick='return getText()'></textarea></div>"));
                textcontent.RemoveAt(0);
                textcontent.Insert(0, inpHide.Value);
            }
            else
            {
                string nam = i.ToString();
                PlaceHolder1.Controls.Add(new LiteralControl("<div><textarea style='background-image:url("));
                PlaceHolder1.Controls.Add(new LiteralControl(picdata[i].ToString()));
                PlaceHolder1.Controls.Add(new LiteralControl("); background-position: bottom; background-repeat: no-repeat; height:120px; overflow:hidden; border:none 0px transparent;' cols='47' disabled='disabled'></textarea></div>"));
                inpHide.Value = textcontent[i].ToString();
                PlaceHolder1.Controls.Add(new LiteralControl("<div><textarea cols='47' style='border:none 0px transparent; overflow:auto;'"));
                PlaceHolder1.Controls.Add(new LiteralControl(" id= '" + nam + "' onLoad='return assignText()' onclick='return getText()'></textarea></div>"));
                //put textarea value into list
                textcontent.RemoveAt(i);
                textcontent.Insert(0, inpHide.Value);
            }
            theblog.Picturepath += picdata[i].ToString() + ",";
        }

    }
}
