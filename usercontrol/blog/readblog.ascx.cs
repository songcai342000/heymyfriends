using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using vennobjects;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.IO.Compression;


public partial class usercontrol_blog_readblog : System.Web.UI.UserControl
{
    #region global variables
 
    string path;
    string Username;
    Blog targetblog;
    Blogcollection blogs;
    Commentcollection blogscomments;
    Commentcollection comments;
    Favoritecollection myfriends;
    Favoritecollection friends;
   /* Exceptncollection myex1;
    Exceptncollection myex2;
    Exceptncollection myex3;
    Exceptncollection myex4;

    Mutex mymtx1;
    Mutex mymtx2;
    Mutex mymtx3;
    Mutex mymtx4;*/

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //get username
        Username = Session["Username"].ToString();
    
        //read the blog chosen by administrator to the web page
            if (Request.QueryString["chosen1"] != null)
            {
                //path = Session["selectedblogcontent1"].ToString();
                path = Adminassign.Selectedcontent1;
            }
            else if (Request.QueryString["chosen2"] != null)
            {
                path = Adminassign.Selectedcontent2;
            }
            else if (Request.QueryString["recommand1"] != null)
            {
                path = Adminassign.Recommand1;
            }
            else if (Request.QueryString["recommand2"] != null)
            {
                path = Adminassign.Recommand2;
            }
            else if (Request.QueryString["recommand3"] != null)
            {
                path = Adminassign.Recommand3;
            }
            else if (Request.QueryString["positive"] != null)
            {
                path = Session["positiveBlog"].ToString();
            }
            else if (Request.QueryString["negative"] != null)
            {
                path = Session["negativeBlog"].ToString();
            }
            else if (Request.QueryString["newblog"] != null || Request.QueryString["popularblog"] != null)
            {
                path = Session["chosenblogpath"].ToString();
            }
            else if (Request.QueryString["sortedblog"] != null)
            {
                path = Session["chosensortedblog"].ToString();
            }
            else if (Request.QueryString["readblog"] != null)
            {
                path = Session["chosenblogpath"].ToString();
            }
            //get the blog's data
            blogs = new Blogcollection();
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(findblog), blogs);
                    Dictionary<string, Blog> thedictionaryblog = blogs.getdictionaryblog();
                    targetblog = thedictionaryblog[Username];
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
                    blogs.removedictionaryblog(Username);
                }
            }
            //Blogid = targetblog.Id;
            getpicblog();
         
            //have test
            /*readblogtable.Style.Add("background-image", "url(~/images/" + targetblog.Picturepath.Substring(74) + ")");
            readblogtable.Style.Add("background-position", "bottom left");
            readblogtable.Style.Add("background-repeat", "no-repeat");*/
            usernameLi.Text = targetblog.Username;
            blogtitleLi.Text = targetblog.Blogtitle;
            //get comments
            presentComment();
            //get the writters other blogs
            Session["bloguser"] = targetblog.Username;

        moreblogstop.HRef = "/vennskap/general/moreblog.aspx?writter={0}";
    }

    protected DataTable createcomment()
    {
        //create sqldatadependency
        blogs = new Blogcollection();
        DataTable commentable = new DataTable();
        lock (blogs)
        {
            try
            {
                if (Cache["theblogcomments"] == null)
                {
                    SqlCacheDependency cachetable = new SqlCacheDependency("Venner", "Commentinfo");
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getcommentsbyblogid), blogs);
                    Dictionary<string, DataTable> theblogscomments = blogscomments.getdictionarybyblogid();
                    //get corrent users required table
                    commentable = theblogscomments[Username];
                    Cache.Insert("theblogcomments", commentable, cachetable);
                }
                else
                {
                    Dictionary<string, DataTable> theblogscomments = null;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getcommentsbyblogid), "");
                    theblogscomments = blogscomments.getdictionarybyblogid();
                    //get corrent users required table
                    commentable = theblogscomments[Username];
                }
            }
            catch(Exception ex)
            {
                Exceptncollection myex2 = new Exceptncollection();
                myex2.exceptiondata(Username, ex.Message, myex2);
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
                blogscomments.removedictionarybyblogid(Username);
            }
        }
        return commentable;
    }

    protected void presentComment()
    {
        DataTable commenttable = createcomment();
        foreach (DataRow dr in commenttable.Rows)
        {
            commentPanel.Controls.Add(new LiteralControl(dr["Time"].ToString()));
            commentPanel.Controls.Add(new LiteralControl("<br/>"));
            commentPanel.Controls.Add(new LiteralControl(dr["Username"].ToString() + ": " + dr["Comment"].ToString()));
            commentPanel.Controls.Add(new LiteralControl("<br/>"));
            commentPanel.Controls.Add(new LiteralControl("<br/>"));
        }
    }

    private string readblogcontent(string blogpath)
    {
        using(StreamReader strReader = new StreamReader("C:\\Users\\mhelenem\\Documents\\Visual Studio 2008\\WebSites" + blogpath))
        {
            lock (strReader)
            {
                return strReader.ReadToEnd();
            }
        }
    }

    protected void sendComment_Click(object sender, EventArgs e)
    {
        //user is administrator or order is still valid
        if (Username == "song" || (Profile.GetProfile(Username)).General.Validorder.CompareTo(DateTime.Now) > 0)
        {
        //get new comment
        //Commentcollection comments = null;
        blogscomments = new Commentcollection();
        int CommentId;
        Mutex mtx2 = null;
            try
            {
                lock (blogscomments)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(createcommentid), blogscomments);

                    Dictionary<string, int> thedictionaryid = blogscomments.getdictionaryid();
                    CommentId = thedictionaryid[Username];
                }
                //ThreadPool.QueueUserWorkItem(new WaitCallback(createcommentid), "");
                //get the users requirement
                if (CommentId != -1)
                {
                    Comment newcomment = new Comment(CommentId, Username, targetblog.Id, DateTime.Now, txtComment.Value);
                    //reassign object as new Commentcollection(1)
                    ManualResetEvent evt2 = new ManualResetEvent(false);
                    mtx2 = new Mutex(true);
                    ThreadPool.RegisterWaitForSingleObject(evt2,
                  new WaitOrTimerCallback(constru),
                  null, Timeout.Infinite, true);
                    ThreadPool.RegisterWaitForSingleObject(mtx2,
                       new WaitOrTimerCallback(SaveComment),
                       null, Timeout.Infinite, true);
                    comments.Add(newcomment);
                    evt2.Set();
                }
                //ThreadPool.QueueUserWorkItem(new WaitCallback(constru), blogscomments);
                //save the new comment
                //ThreadPool.QueueUserWorkItem(new WaitCallback(SaveComment), blogscomments);
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
                blogscomments.removedictionaryid(Username);
                if (mtx2 != null)
                {
                    mtx2.ReleaseMutex();
                }
            }
        }
        //user has not logged in or user's order is not valid
        else if (Username == "" || (Profile.GetProfile(Username)).General.Validorder.CompareTo(DateTime.Now) < 0)
        {
            Response.Redirect("/vennskap/general/Hjelp.aspx?Membershiprequired={0}");           
        }
    }

    //logic to contact with the user
    protected void contactme_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Profilepage.aspx?skriv={0}");
    }

     //logic to block the user
    protected void blockuser_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Nye.aspx?blockuser={0}");
    }

    protected void writetomeBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Profilepage.aspx?writetoprofile={0}");
    }
    protected void readprofileBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Profilepage.aspx?annenprofile={0}");
    }
    protected void favoriteblogBtn_Click(object sender, EventArgs e)
    {
        myfriends = new Favoritecollection();
        int FavoriteId;
        Mutex mtx2 = null;
        lock (myfriends)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createfavoriteid), myfriends);
                Dictionary<string, int> thedictionaryid = myfriends.getdictionaryid();
                FavoriteId = thedictionaryid[Username];
                if (FavoriteId != -1)
                {
                    //add new object
                    ManualResetEvent evt2 = new ManualResetEvent(false);
                    mtx2 = new Mutex(true);
                    ThreadPool.RegisterWaitForSingleObject(evt2,
                  new WaitOrTimerCallback(construfav),
                  null, Timeout.Infinite, true);
                    ThreadPool.RegisterWaitForSingleObject(mtx2,
                       new WaitOrTimerCallback(SaveFavorite),
                       null, Timeout.Infinite, true);
                    Favorite myfavoriteblog = new Favorite(FavoriteId, Username, usernameLi.Text, "myfavoriteblog", DateTime.Now);
                    friends.Add(myfavoriteblog);
                    evt2.Set();
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(construfav), "");
                    //save to database
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(SaveComment), "");
                    //myfriends.Save();
                }
            }
            catch(Exception ex)
            {
                Exceptncollection myex4 = new Exceptncollection();
                lock (myex4)
                {
                    myex4.exceptiondata(Username, ex.Message, myex4);
                }
                Response.Redirect("~/functions/Profilopprettet.aspx?favoriteblogfeil={0}");
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
                 myfriends.removedictionaryid(Username);
                 if (mtx2 != null)
                 {
                     mtx2.ReleaseMutex();
                 }
            }
        }
        Response.Redirect("~/functions/Profilopprettet.aspx?favoriteblog={0}");
    }

    //create commentcollection object
    public void constru(Object obj, bool TimeOut)
    {
        obj = new Commentcollection(1);
    }

    protected void construfav(Object obj, bool TimeOut)
    {
        obj = new Favoritecollection(1);
    }

    //producer
    public void SaveComment(Object obj, bool TimeOut)
    {
        ((Commentcollection)obj).Save();
    }

    public void SaveFavorite(Object obj, bool TimeOut)
    {
        ((Favoritecollection)obj).Save();
    }


    //consumer
    public void findblog(Object obj)
    {
        Blog blog;
        blog = ((Blogcollection)obj).Find(path);
        ((Blogcollection)obj).filldictionaryblog(Username, blog);
    }

    public void createcommentid(Object obj)
    {
        int Commentid;
        Commentid = ((Commentcollection)obj).GetCommentId();
        ((Commentcollection)obj).filldictionaryid(Username, Commentid);
    }

    public void createfavoriteid(Object obj)
    {
        int Favoriteid;
        Favoriteid = ((Favoritecollection)obj).GetId();
        ((Favoritecollection)obj).filldictionaryid(Username, Favoriteid);
    }

    public void getcommentsbyblogid(Object obj)
    {
        DataTable table;
        table = ((Commentcollection)obj).GetCommentByBlogId(targetblog.Id);
        ((Commentcollection)obj).filldictionarybyblogid(Username, table);
    }

    //decompress
    protected string decompressfile(string savePath)
    {

        string Blogcontent;
        //string origName = curFile.Remove(curFile.Length - fi.Extension.Length);
        using (FileStream fs = new FileStream(targetblog.Blogpath, FileMode.Open))
        {
            //create decompress object
            using (GZipStream degzip = new GZipStream(fs, CompressionMode.Decompress))
            {
                //using (StreamReader strReader = new StreamReader("C:\\Users\\mhelenem\\Documents\\Visual Studio 2008\\WebSites" + blogpath))
                using (StreamReader strReader = new StreamReader(degzip))
                {
                    //lock the object and read the blog
                    lock (strReader)
                    {
                        //Blogcontent = strReader.ReadToEnd();
                        Blogcontent = strReader.ReadToEnd();
                    }
                }
            }
        }
        return Blogcontent;
    }

    #region split

    public int tellcomma(string sentence)
    {
        int count = 0;
        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i].ToString() == ",")
            {
                count++;
            }
        }
        return count;
    }

    //split string by <picurl>
    public string[] splitstr(string original, int wordcount)
    {
        string delimStr = "<picurl>";
        char[] delimiter = delimStr.ToCharArray();
        string[] split = null;
        if (original != null)
        {
            for (int x = 1; x <= wordcount; x++)
            {
                split = original.Split(delimiter, x);
            }
        }
        return split;
    }

    //remove space in a sentence
    /*public string removespace(string sentence)
    {
        string newsentence = "";
        if (sentence.Length >= 1)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i].ToString() != " ")
                {
                    newsentence += sentence[i].ToString();
                }
            }
        }
        return newsentence;
    }*/

    protected void getpicblog()
    {
        string picstring = targetblog.Picturepath;
        //get text of file
        string blogcon = decompressfile(targetblog.Blogpath);
        //get pic number
        int coun = tellcomma(picstring);
        //split text
        string[] contents = splitstr(blogcon, coun);
        //split picturepath
        string[] pics = splitstr(picstring, coun);
        //add text and pictures to column
        foreach (string str in contents)
        {
            Literal content = new Literal();
            content.Text = str;
            contentcol.Controls.Add(content);
            contentcol.Controls.Add(new LiteralControl("<br/>"));
            contentcol.Controls.Add(new LiteralControl("<div style='background-image:url('" + pics[0].ToString() + "'); background-position:top; background-repeat:no-repeat; background-color:transparent;'></div>"));
        }

    }

    #endregion

}
