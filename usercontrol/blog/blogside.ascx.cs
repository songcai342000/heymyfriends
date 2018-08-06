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
using System.IO;
using vennobjects;
using System.Collections.Generic;
using System.Timers;
using System.IO.Compression;
using System.Threading;

public partial class usercontrol_blog_blogside : System.Web.UI.UserControl
{
    string positiveblogcontent;
    string negativeblogcontent;
    string blogtitle; //for positive or negative blogs
    string path;
    string Username;
    string Profilename;
    string Blogtitle;
    Blogcollection blogs;
    /*Exceptncollection myex1;
    Exceptncollection myex2;
    Exceptncollection myex3;
    Mutex mymtx1;
    Mutex mymtx2;
    Mutex mymtx3;*/

    protected void Page_Load(object sender, EventArgs e)
    {
        //blogtitle = Session["tematitle"].ToString();//tema title
        blogtitle = Adminassign.Tematitle;
        Username = Session["Username"].ToString();
        adminblog1();
        adminblog2();
       //get temablogs
        createtopictables(Blogcollection.positivetematable, Blogcollection.negativetematable);
        //moresorted hyperlink gets relation blogs as default
        Session["sort"] = "relation";

        getmenrotation();
        getwomenrotation();
        renewtoptimer();
   
    }

    //renew topic tables
    //DataTable positivetematable;
    //DataTable negativetematable;
    protected void renewtopictables(object sender, ElapsedEventArgs e)
    {
        /*Blogcollection blogs = new Blogcollection();
        positivetematable = blogs.GetPositiveTemaBlog(blogtitle);
        negativetematable = blogs.GetNegativeTemaBlog(blogtitle);*/
        Blogcollection blogs = new Blogcollection();
        Blogcollection.positivetematable = blogs.GetPositiveTemaBlog(blogtitle);
        Blogcollection.negativetematable = blogs.GetNegativeTemaBlog(blogtitle);
    }

    protected void createtopictables(DataTable positivetematable, DataTable negativetematable)
    {
        //get positive and negative blogs and dynamically set them in html table
        //set text and navigateurl for hyperlinks of positive and negative blogs
        //if the tables are null, create them 
        if (Blogcollection.positivetematable == null && Blogcollection.negativetematable == null)
        {
            Blogcollection blogs = new Blogcollection();
            Blogcollection.positivetematable = blogs.GetPositiveTemaBlog(blogtitle);
            Blogcollection.negativetematable = blogs.GetNegativeTemaBlog(blogtitle);
        }
        positivePanel.Controls.Add(new LiteralControl("<ul>"));
        if (Blogcollection.positivetematable.Rows.Count > 0)
        {
            for (int i = Blogcollection.positivetematable.Rows.Count - 1; i >= 0; i--)
            {
                posittable(i);
            }
            positivePanel.Controls.Add(new LiteralControl("</ul>"));
        }
        negativePanel.Controls.Add(new LiteralControl("<ul>"));
        if (Blogcollection.negativetematable.Rows.Count > 0)
        {
            for (int i = Blogcollection.negativetematable.Rows.Count - 1; i >= 0; i--)
            {
                negatitable(i);
            }
            negativePanel.Controls.Add(new LiteralControl("</ul>"));
        }
    }

    protected void relationtitleBtn_Click(object sender, EventArgs e)
    {
        string path;
        Blogcollection blogs = new Blogcollection();
        sortedLbl.Text = "Vi koser oss med god forhold";
        //administration function fullfills
        //Blogcollection blogs = null;
        //here should be changed
        //path = Session["chosensortedblog"].ToString();
        path = Adminassign.Relationlink;
        /*ThreadPool.QueueUserWorkItem(new WaitCallback(findblog), blogs);
        Dictionary<string, Blog> thedictionaryfind = blogs.getdictionaryblog();
        Blog theblog = thedictionaryfind[Username];
        //Stack<Blog> therelationlist = blogs.getrelationlist();
        blogs.removedictionaryblog(Username);*/
        if (path != "")
        {
            //theblog = therelationlist.Peek();
            using (StreamReader strReader = new StreamReader(path))
            {
                lock (strReader)
                {
                    string blogcontent = strReader.ReadToEnd();
                    if (blogcontent.Length > 30)
                    {
                        selectedsortedblogContentHyp.Text = blogcontent.Substring(0, 30);
                    }
                    else
                    {
                        selectedsortedblogContentHyp.Text = blogcontent;
                    }
                }
            }
            //set href til hyperlink
            //Session["chosenblogpath"] = theblog.Blogpath;
            selectedsortedblogContentHyp.NavigateUrl = "/vennskap/general/Blogtarget.aspx?readblog={0}";
            //bind to relations blogs;

            DataTable relationblogs = blogs.Relationlist();
            sortedblog.DataSource = relationblogs;
            sortedblog.DataBind();
            //more blog link will get blogs of the relevant category
            //moresorted.HRef = "/vennskap/general/moreblog.aspx?relation={0}";
            Session["sort"] = "relation";
        }
    }

    protected void activitytitleBtn_Click(object sender, EventArgs e)
    {
        string path;
        Blogcollection blogs = new Blogcollection();
        sortedLbl.Text = "Min spennende opplevelse";
        //administration function fullfills
        //Blogcollection blogs = null;
        //path = Session["chosensortedblog"].ToString();
        path = Adminassign.Activitylink;
        /*ThreadPool.QueueUserWorkItem(new WaitCallback(findblog), blogs);
        Dictionary<string, Blog> thedictionaryfind = blogs.getdictionaryblog();
        //Blog theblogvalue;
        Blog theblog = thedictionaryfind[Username];
        //Stack<Blog> theactivitylist = blogs.getactivitylist();
        blogs.removedictionaryblog(Username);*/
        if (path != "")
        {
            //Blog theblog = theactivitylist.Peek();
            using (StreamReader strReader = new StreamReader(path))
            {
                lock (strReader)
                {
                    string blogcontent = strReader.ReadToEnd();
                    if (blogcontent.Length > 30)
                    {
                        selectedsortedblogContentHyp.Text = blogcontent.Substring(0, 30);
                    }
                    else
                    {
                        selectedsortedblogContentHyp.Text = blogcontent;
                    }
                }
            }
            //set href til hyperlink
            selectedsortedblogContentHyp.NavigateUrl = path;
            //bind to activity blogs
            DataTable activityblogs = blogs.Activitylist();
            sortedblog.DataSource = activityblogs;
            sortedblog.DataBind();
            //more blog link will get blogs of the relevant category
            //moresorted.HRef = "/vennskap/general/moreblog.aspx?activity={0}";
            Session["sort"] = "activity";
        }
    }

    protected void othertitleBtn_Click(object sender, EventArgs e)
    {
        string path;
        Blogcollection blogs = new Blogcollection();
        sortedLbl.Text = "Dagenbok, tanker, kommentar......";
        //administration function fullfills
        //Blogcollection blogs = null;
        //path = Session["chosensortedblog"].ToString();
        path = Adminassign.Otherlink;
        /*ThreadPool.QueueUserWorkItem(new WaitCallback(findblog), "");
        Dictionary<string, Blog> thedictionaryfind = blogs.getdictionaryblog();
        //Blog theblogvalue;
        Blog theblog = thedictionaryfind[Username];
        //Stack<Blog> theotherlist = blogs.getotherlist();
        blogs.removedictionaryblog(Username);*/
        if (path != "")
        {
            //Blog theblog = theotherlist.Peek();
            using (StreamReader strReader = new StreamReader(path))
            {
                lock (strReader)
                {
                    string blogcontent = strReader.ReadToEnd();
                    if (blogcontent.Length > 30)
                    {
                        selectedsortedblogContentHyp.Text = blogcontent.Substring(0, 30);
                    }
                    else
                    {
                        selectedsortedblogContentHyp.Text = blogcontent;
                    }
                }
            }
            //set href til hyperlink
            selectedsortedblogContentHyp.NavigateUrl = path;
            //bind to other blogs
            DataTable otherblogs = blogs.Otherlist();
            sortedblog.DataSource = otherblogs;
            sortedblog.DataBind();
            Session["sort"] = "other";
            //more blog link will get blogs of the relevant category
            //moresorted.HRef = "/vennskap/general/moreblog.aspx?other={0}";
        }
    }

   /* protected void writterRad_CheckedChanged(object sender, EventArgs e)
    {
        Session["searchword"] = searchTxt.Text;
        searchBtn.PostBackUrl = "/vennskap/general/moreblog.aspx?usernamesearch={0}";
    }
    protected void articleRad_CheckedChanged(object sender, EventArgs e)
    {
        Session["searchword"] = searchTxt.Text;
        searchBtn.PostBackUrl = "/vennskap/general/moreblog.aspx?blogtitlesearch={0}";
    }*/
    
    protected void sortedblog_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "sortedblogtitle")
        {
            Profilename = ((LinkButton)e.Item.FindControl("sortedblogUserBtn")).Text;
            Blogtitle = ((LinkButton)e.Item.FindControl("sortedblogTitleBtn")).Text;
            //Blogcollection myblogs = null;
            blogs = new Blogcollection();
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusertitle), blogs);
                    Dictionary<string, DataTable> thedictionaryusertitle = blogs.getdictionarybyusertitle();
                    //DataTable blogtablevalue;
                    DataTable blogtable = thedictionaryusertitle[Username];
                    if (blogtable.Rows.Count > 0)
                    {
                        Session["chosensortedblog"] = blogtable.Rows[0]["Blogpath"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Exceptncollection myex1 = new Exceptncollection();
                    myex1.exceptiondata(Username, ex.Message, myex1);

                }
                finally
                {
                    /* lock (myex1)
                     {
                         if (myex1 != null)
                         {
                             myex1.removedicid(Username);
                         }
                     }
                     if (mymtx1 != null)
                     {
                         mymtx1.ReleaseMutex();
                     }*/
                    blogs.removedictionarybyusertitle(Username);
                }
            Response.Redirect("/vennskap/general/Blogtarget.aspx?sortedblog={0}");
        }
    }

    protected void adminblog1()
    {
        //administration function fullfills
        try
        {
            string path = Session["selectedblogcontent1"].ToString();
            using (StreamReader strReader1 = new StreamReader("C:\\Users\\mhelenem\\Documents\\Visual Studio 2008\\WebSites" + path.Substring(55)))
            {
                lock (strReader1)
                {
                    string blogcontent = strReader1.ReadToEnd();
                    if (blogcontent.Length > 60)
                    {
                        selectedcontent1.Text = blogcontent.Substring(0, 60);
                    }
                    else
                    {
                        selectedcontent1.Text = blogcontent;
                    }
                }
                selectedcontent1.NavigateUrl = "/vennskap/general/Blogtarget.aspx?chosen1={0}";
            }
        }
        catch (Exception ex)
        {
            //logic
            Exceptncollection myex2 = new Exceptncollection();
            lock (myex2)
            {
                myex2.exceptiondata(Username, ex.Message, myex2);
            }

        }
        /*finally
        {
            lock (myex2)
            {
                if (myex2 != null)
                {
                    myex2.removedicid(Username);
                }
            }
            if (mymtx2 != null)
            {
                mymtx2.ReleaseMutex();
            }
        }*/
        
    }

    protected void adminblog2()
    {
        try
        {
            //administration function fullfill
            string path = Session["selectedblogcontent1"].ToString();
            /*ThreadPool.QueueUserWorkItem(new WaitCallback(findblog), blogs);
            Dictionary<string, Blog> thedictionary = blogs.getdictionaryblog();
            Blog theblog = thedictionary[Username];*/
            using (StreamReader strReader2 = new StreamReader("C:\\Users\\mhelenem\\Documents\\Visual Studio 2008\\WebSites" + path.Substring(55)))
            {
                lock (strReader2)
                {
                    string blogcontent = strReader2.ReadToEnd();
                    if (blogcontent.Length > 60)
                    {
                        selectedcontent2.Text = blogcontent.Substring(0, 60);
                    }
                    else
                    {
                        selectedcontent2.Text = blogcontent;
                    }
                }
                selectedcontent2.NavigateUrl = "/vennskap/general/Blogtarget.aspx?chosen1={0}";
            }
        }
        catch(Exception ex)
        {
            //logic
            Exceptncollection myex3 = new Exceptncollection();
            lock (myex3)
            {
                myex3.exceptiondata(Username, ex.Message, myex3);
            }

        }
        /*finally
        {
            lock (myex3)
            {
                if (myex3 != null)
                {
                    myex3.removedicid(Username);
                }
            }
            if (mymtx3 != null)
            {
                mymtx3.ReleaseMutex();
            }
        }*/
    }


    protected void getmenrotation()
    {
        //get profilepicture of men gets by rotation
        ProfileCommon therprofile1;
        ProfileCommon therprofile2;
        ProfileCommon therprofile3;
        if (Adminassign.Man1 != 0)
        {
            therprofile1 = Profile.GetProfile(Blogcollection.manlist[Adminassign.Man1]);
            ImageButton7.ImageUrl = therprofile1.General.Picture;
            Literal7.Text = therprofile1.UserName;
        }
        if (Adminassign.Man2 != 0)
        {
            therprofile2 = Profile.GetProfile(Blogcollection.manlist[Adminassign.Man2]);
            ImageButton8.ImageUrl = therprofile2.General.Picture;
            Literal8.Text = therprofile2.UserName;
        }
        if (Adminassign.Man3 != 0)
        {
            therprofile3 = Profile.GetProfile(Blogcollection.manlist[Adminassign.Man3]);
            ImageButton9.ImageUrl = therprofile3.General.Picture;
            Literal9.Text = therprofile3.UserName;
        }
    }

    protected void getwomenrotation()
    {
        //get profilepicture of women gets by rotation
        ProfileCommon therprofile4;
        ProfileCommon therprofile5;
        ProfileCommon therprofile6;
        if (Adminassign.Lady1 != 0)
        {
            therprofile4 = Profile.GetProfile(Blogcollection.ladylist[Adminassign.Lady1]);
            ImageButton1.ImageUrl = therprofile4.General.Picture;
            Literal1.Text = therprofile4.UserName;
        }
        if (Adminassign.Lady2 != 0)
        {
            therprofile5 = Profile.GetProfile(Blogcollection.ladylist[Adminassign.Lady2]);
            ImageButton2.ImageUrl = therprofile5.General.Picture;
            Literal2.Text = therprofile5.UserName;
        }
        if (Adminassign.Lady3 != 0)
        {
            therprofile6 = Profile.GetProfile(Blogcollection.ladylist[Adminassign.Lady3]);
            ImageButton3.ImageUrl = therprofile6.General.Picture;
            Literal3.Text = therprofile6.UserName;
        }

    }

    protected void gettextoflink()
    {
        selectedcontent1.NavigateUrl = Adminassign.Selectedcontent1;
        selectedcontent2.NavigateUrl = Adminassign.Selectedcontent2;
        recommand1.Text = Adminassign.Recommand1title;
        recommand2.Text = Adminassign.Recommand2title;
        recommand3.Text = Adminassign.Recommand3title;
        recommand1.NavigateUrl = Adminassign.Recommand1;
        recommand2.NavigateUrl = Adminassign.Recommand2;
        recommand3.NavigateUrl = Adminassign.Recommand3;
    }

    protected void renewtoptimer()
    {
        //timer for renew topic tables
        System.Timers.Timer aTimer = new System.Timers.Timer();
        //every 1 hrs
        aTimer.Interval = 3600000;
        aTimer.Enabled = true;
        aTimer.Elapsed += new ElapsedEventHandler(renewtopictables);
    }

    protected void posittable(int i)
    {
        positivePanel.Controls.Add(new LiteralControl("<li>"));
        DataTable table = Blogcollection.positivetematable;
        decompressblog(table, i, positiveblogcontent);
            //add hyperlink to a blog with positive meaning
            HyperLink positive = new HyperLink();
            positivePanel.Controls.Add(positive);
            positive.Font.Underline = false;
            //positive.ForeColor = "#990099";
            positivePanel.Controls.Add(new LiteralControl("<br/>"));
            positivePanel.Controls.Add(new LiteralControl("<br/></li>"));
            if (positiveblogcontent.Length > 50)
            {
                positive.Text = positiveblogcontent.Substring(0, 50);
            }
            else
            {
                positive.Text = positiveblogcontent;
            }
            //Session["positiveBlog"] = positivetematable.Rows[i]["Blogpath"].ToString();
            Session["positiveBlog"] = table.Rows[i]["Blogpath"].ToString();
            positive.NavigateUrl = "/vennskap/general/Blogtarget.aspx?positive={0}";
       
    }

    protected void negatitable(int i)
    {
        negativePanel.Controls.Add(new LiteralControl("<li>"));
        DataTable table = Blogcollection.negativetematable;
        decompressblog(table, i, negativeblogcontent);
        //add hyperlink to a blog with negative meaning
        HyperLink negative = new HyperLink();
        negative.Font.Underline = false;
        negative.ForeColor = System.Drawing.Color.Blue;
        negativePanel.Controls.Add(negative);
        negativePanel.Controls.Add(new LiteralControl("<br/>"));
        negativePanel.Controls.Add(new LiteralControl("<br/></li>"));
        if (negativeblogcontent.Length > 50)
        {
            negative.Text = negativeblogcontent.Substring(0, 50);
        }
        else
        {
            negative.Text = negativeblogcontent;
        }
        // Session["negativeBlog"] = negativetematable.Rows[i]["Blogpath"].ToString();
        Session["negativeBlog"] = Blogcollection.negativetematable.Rows[i]["Blogpath"].ToString();
        negative.NavigateUrl = "/vennskap/general/Blogtarget.aspx?negative={0}";
    }

    protected void decompressblog(DataTable thetable, int i, string content)
    {
        using (FileStream fs = new FileStream(thetable.Rows[i]["Blogpath"].ToString(), FileMode.Open))
        {
            //get original file name and type
            //using (FileStream outFile = File.Create("C:\\Users\\mhelenem\\Documents\\Visual Studio 2008\\WebSites" + blogpath.Remove(blogpath.Length - 4)))
            //{
            //create decompress object
            using (GZipStream degzip = new GZipStream(fs, CompressionMode.Decompress))
            {
                using (StreamReader strReader = new StreamReader(degzip))
                {
                    lock (strReader)
                    {
                        content = strReader.ReadToEnd();
                    }
                }
            }
        }
    }

    /// <summary>
    /// thread 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    /*public void getpositive(Object obj)
    {
        DataTable table;
        obj = new Blogcollection();

        lock (obj)
        {
            table = ((Blogcollection)obj).GetPositiveTemaBlog(blogtitle);
        }
        //((Blogcollection)obj)
    }

    public void getnegative(Object obj)
    {
        DataTable table;
        obj = new Blogcollection();

        lock (obj)
        {
            table = ((Blogcollection)obj).GetNegativeTemaBlog(blogtitle);
        }
        //((Blogcollection)obj).filldictionarynegative(Username, table);
    }*/

    //consumer
    public void findblog(Object obj)
    {
        lock (obj)
        {
            Blog blog;
            blog = ((Blogcollection)obj).Find(path);
            ((Blogcollection)obj).filldictionaryblog(Username, blog);
        }
    }

    public void getbyusertitle(Object obj)
    {
        lock (obj)
        {
            DataTable table;
            table = ((Blogcollection)obj).GetBlogByUserTitle(Profilename, Blogtitle);
            ((Blogcollection)obj).filldictionarybyusertitle(Username, table);
        }
    }
    /*protected void herblog_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "hunblogtitle")
        {
            string Username = ((LinkButton)e.Item.FindControl("hunblogUserBtn")).Text;
            string Blogtitle = ((LinkButton)e.Item.FindControl("hunblogTitleBtn")).Text;
            Blogcollection myblogs = new Blogcollection();
            DataTable blogtable = myblogs.GetByBlogTitleUser(Username, Blogtitle);
            if (blogtable.Rows.Count > 0)
            {
                Session["chosensortedblog"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            Response.Redirect("/vennskap/general/Blogtarget.aspx");
        }
    }
    protected void heblog_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "hanblogtitle")
        {
            string Username = ((LinkButton)e.Item.FindControl("hanblogUserBtn")).Text;
            string Blogtitle = ((LinkButton)e.Item.FindControl("hanblogTitleBtn")).Text;
            Blogcollection myblogs = new Blogcollection();
            DataTable blogtable = myblogs.GetByBlogTitleUser(Username, Blogtitle);
            if (blogtable.Rows.Count > 0)
            {
                Session["chosensortedblog"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            Response.Redirect("/vennskap/general/Blogtarget.aspx");
        }
    }

    protected void positiveBlogs_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void negativeBlogs_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }*/
   
}
