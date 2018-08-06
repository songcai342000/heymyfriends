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
using System.Collections.Generic;
using System.Timers;
using System.Threading;

public partial class usercontrol_minside_administration : System.Web.UI.UserControl
{
    Favoritecollection myfavorites = new Favoritecollection();
    protected void Page_Load(object sender, EventArgs e)
    {
        //initialize singleton
        //lock functions on the page before correct code is input
        
        if (!IsPostBack)
        {
            choseBtn.Enabled = false;
            choseBlog2.Enabled = false;
            topicBtn.Enabled = false;
            topicBtn.Enabled = false;
            blog1Btn.Enabled = false;
            blog2Btn.Enabled = false;
            blog3Btn.Enabled = false;
            temaBtn.Enabled = false;
            choseBlog2.Enabled = false;
            renewBtn.Enabled = false;
            remove30daysOldBtn.Enabled = false;
            renewpopularBtn.Enabled = false;
        }
        
        //delete all old users, this function is not needed in real program
        MembershipUserCollection users = Membership.GetAllUsers();
        //get users whose profile need to be approved into listbox
        MembershipUserCollection newprofileusers = Membership.GetAllUsers();
        //newprofiles.DataSource = myfavorites.GetUpdatedUserNames();
        //newprofiles.DataBind();
        Literal1.Text = Membership.GetNumberOfUsersOnline().ToString() + " Online";
        //get visitor number (not necessary, can get statistic from hosting)
        //Adminassign adminass = new Adminassign();
        //int thetrafic = adminass.changetrafic(int.Parse(Application["Sitevisitornum"].ToString()) + 1);
        //Application["Sitevisitornum"] = thetrafic;
        //Literal2.Text = thetrafic.ToString() + " Visitors";
        //renew bloglists by interval
       System.Timers.Timer aTimer = new System.Timers.Timer();
        //every 2 hrs
       aTimer.Interval = 7200000;
       aTimer.Enabled = true;
       aTimer.Elapsed += new ElapsedEventHandler(renewlists);
      
        //renew newmemberlist every 24 hrs
       System.Timers.Timer aTimer2 = new System.Timers.Timer();
       aTimer2.Interval = 86400000;
       aTimer2.Enabled = true;
       aTimer2.Elapsed += new ElapsedEventHandler(renewmemberlist);
       //ThreadPool.QueueUserWorkItem(new WaitCallback(threadmanagement.getblogsbyusername));

    }

    protected void renewwritterlist()
    {
        //get man and woman writterlist
        //get man and lady writterlist
        Blogcollection blogwritters = new Blogcollection();
        //clear old records;
        Blogcollection.blogwritterlist.Clear();
        Blogcollection.manlist.Clear();
        Blogcollection.ladylist.Clear();
        blogwritters.fillblogwritterlist();
        foreach (DataRow dr in Blogcollection.blogwritterlist.Rows)
        {
            ProfileCommon theprofile = Profile.GetProfile(dr["Username"].ToString());
            if (theprofile.General.Gender == "Kvinne")
            {
                blogwritters.AddToLadyList(theprofile.UserName);
            }
            else
            {
                blogwritters.AddToManList(theprofile.UserName);
            }
        }
    }

    //initialize at the beginning of application
    int x1 = 0;
    int x2 = 1;
    int x3 = 2;
    int x4 = 0;
    int x5 = 1;
    int x6 = 2;
    protected void rotatewritter()
    { 
       
        string starttime = "15.04.2010 00:00:00";
        //caculate days from start date to locate the position to rotate
        int rottimes = DateTime.Now.Day - DateTime.Parse(starttime).Day;
        //need a timer her
        x1 *= rottimes;
        x2 *= rottimes;
        x3 *= rottimes;
        x4 *= rottimes;
        x5 *= rottimes;
        x6 *= rottimes;

        //position index and get
        if (x1 > Blogcollection.manlist.Count)
        {
            x1 = 0;
        }
        Adminassign.Man1 = x1;

        if (x2 > Blogcollection.manlist.Count)
        {
            x2 = 1;
        }
        Adminassign.Man2 = x2;

        if (x3 > Blogcollection.manlist.Count)
        {
            x3 = 2;
        }
        Adminassign.Man3 = x3;

        if (x4 > Blogcollection.ladylist.Count)
        {
            x4 = 0;
        }
        Adminassign.Lady1 = x4;

        if (x5 > Blogcollection.ladylist.Count)
        {
            x5 = 1;
        }
        Adminassign.Lady2 = x5;

        if (x6 > Blogcollection.ladylist.Count)
        {
            x6 = 2;
        }
        Adminassign.Lady3 = x6;

    }
    /// <summary>
    /// set file rute of chosen blogs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void choseBtn_Click(object sender, EventArgs e)
    {
        //Session["selectedblogcontent1"] = "C:\\Users\\mhelenem\\documents\\Visual Studio 2008\\WebSites\\vennskaper\\blogarticles\\" + choseFile.FileName;
        Adminassign.Selectedcontent1 = "C:\\Users\\mhelenem\\documents\\Visual Studio 2008\\WebSites\\vennskaper\\blogarticles\\" + choseFile.FileName;
    }
    //no need because it is created dynamically (positive and negative tables)
    protected void topicBtn_Click(object sender, EventArgs e)
    {
        //Session["topicblogpath"] = "C:\\Users\\mhelenem\\documents\\Visual Studio 2008\\WebSites\\vennskaper\\blogarticles\\" + topicFile.FileName;
        //Adminassign.Topiclink = "C:\\Users\\mhelenem\\documents\\Visual Studio 2008\\WebSites\\vennskaper\\blogarticles\\" + topicFile.FileName;
    }

    protected void renewmemberlist(object sender, ElapsedEventArgs e)
    {
        List<userselectedparameters> newupdatedprofiles = new List<userselectedparameters>();
        MembershipUserCollection users = Membership.GetAllUsers();
        Favoritecollection thenewprofiles = new Favoritecollection();
        foreach (MembershipUser user in users)
        {
        //for (int i = 0; i < Usernamelist.Count; i++)
        //{
            ProfileCommon theprofile = Profile.GetProfile(user.UserName);
            //if the profile is new and approved
            if (theprofile.Createtime.AddHours(192) > DateTime.Now && theprofile.General.Gender == "Mann" && theprofile.Profileapproved == "Yes")
            {
                //myfavorites.addnewman(new userselectedparameters(thetheprofile.UserName, thetheprofile.General.Year, thetheprofile.General.City, "", "", ""));
                thenewprofiles.addnewman(new userselectedparameters(theprofile.UserName, theprofile.General.Year, theprofile.General.City, "", "", ""));
            }
            if (theprofile.Createtime.AddHours(192) > DateTime.Now && theprofile.General.Gender == "Kvinne" && theprofile.Profileapproved == "Yes")
            {
                //myfavorites.addnewwoman(new userselectedparameters(theprofile.UserName, theprofile.General.Year, theprofile.General.City, "", "", ""));
                thenewprofiles.addnewwoman(new userselectedparameters(theprofile.UserName, theprofile.General.Year, theprofile.General.City, "", "", ""));
            }
            //if the profile is new updated and not approved yet
            if (theprofile.LastUpdatedDate.CompareTo(DateTime.Now.Date) > -2 && theprofile.Profileapproved == "")
            {
                //get new updatedprofiles
                newupdatedprofiles.Add(new userselectedparameters(theprofile.UserName, theprofile.General.Year, theprofile.General.City, "", "", ""));
            }
        }
        //bind to list box
        newprofiles.DataSource = newupdatedprofiles;
        newprofiles.DataBind();

        //renew writterlist, rotatewritter at the same interval as newmemberlist
        renewwritterlist();
        rotatewritter();
        renewpopularblogs();
    }

    //renew blog lists by interval
    protected void saveoutmail(object sender, ElapsedEventArgs e)
    {
        Blogcollection blogs = new Blogcollection();
        //later
    }

    //renew blog lists by interval
    protected void renewlists(object sender, ElapsedEventArgs e)
    {
        Blogcollection blogs = new Blogcollection();
        blogs.fillactivitylist();
        blogs.fillblogwritterlist();
        blogs.fillnewbloglist();
        blogs.fillotherlist();
        blogs.fillrelationlist();
        blogs.filltopiclist();
        renewpopularblogs();
    }
    //manually renew bloglists
    protected void renewBtn_Click(object sender, EventArgs e)
    {
        
        Blogcollection blogs = new Blogcollection();
        blogs.fillactivitylist();
        blogs.fillblogwritterlist();
        blogs.fillnewbloglist();
        blogs.fillotherlist();
        //blogs.fillpopularbloglist();
        blogs.fillrelationlist();
        blogs.filltopiclist();
     
    }
    /// <summary>
    /// set chosen blogs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void blog1Btn_Click(object sender, EventArgs e)
    {
        Adminassign.Recommand1 = blog1Txt.Text;
        Adminassign.Recommand1title = blog1titleTxt.Text; 
    }
    protected void blog2Btn_Click(object sender, EventArgs e)
    {
        Adminassign.Recommand2 = blog2Txt.Text;
        Adminassign.Recommand2title = blog2titleTxt.Text; 
    }
    protected void blog3Btn_Click(object sender, EventArgs e)
    {
        Adminassign.Recommand3 = blog3Txt.Text;
        Adminassign.Recommand3title = blog3titleTxt.Text; 
    }
    protected void temaBtn_Click(object sender, EventArgs e)
    {
        Adminassign.Tematitle = temaTxt.Text; 
    }
    protected void chosenblog2Btn_Click(object sender, EventArgs e)
    {
        Adminassign.Selectedcontent2 = "C:\\Users\\mhelenem\\documents\\Visual Studio 2008\\WebSites\\vennskaper\\blogarticles\\" + choseBlog2.FileName;
    }
    //renewpopularblog
    protected void renewpopularblogs()
    {
        DataTable blog;
        //Blogcollection.popularbloglist.Clear();
        Blogcollection blogs = new Blogcollection();
        //create lock
        //lock (blogs)
        //{
            //blogs.ClearPopularList();
            DataTable blogidtable = blogs.GetBlogsByComment();
            //get schema
            blog = blogs.GetBlogById(1);
            Blogcollection.popularbloglist = blog.Clone();
            //get blog data
            foreach (DataRow dr in blogidtable.Rows)
            {
                blog = blogs.GetBlogById(int.Parse(dr[0].ToString()));
                Blogcollection.popularbloglist.ImportRow(dr);
            }
        //}
    }

    //manually renew popular bloglist
    protected void renewpopularBtn_Click(object sender, EventArgs e)
    {
        DataTable blog;
        //Blogcollection.popularbloglist.Clear();
        Blogcollection blogs = new Blogcollection();
        //create lock
        lock (blogs)
        {
            //blogs.ClearPopularList();
            DataTable blogidtable = blogs.GetBlogsByComment();
            //get schema
            blog = blogs.GetBlogById(1);
            Blogcollection.popularbloglist = blog.Clone();
            foreach (DataRow dr in blogidtable.Rows)
            {
                blog = blogs.GetBlogById(int.Parse(dr[0].ToString()));
                Blogcollection.popularbloglist.ImportRow(dr);
            }
        }
    }

    protected void commentBtn_Click(object sender, EventArgs e)
    {

        if (commentTxt.Value.Length >= 23 && commentTxt.Value.Substring(0, 22) == "Si2010siter@vennerhuaxi")
        {
            //commentBtn.Enabled = true;
            choseBtn.Enabled = true;
            choseBlog2.Enabled = true;
            topicBtn.Enabled = true;
            topicBtn.Enabled = true;
            blog1Btn.Enabled = true;
            blog2Btn.Enabled = true;
            blog3Btn.Enabled = true;
            temaBtn.Enabled = true;
            choseBlog2.Enabled = true;
            renewBtn.Enabled = true;
            remove30daysOldBtn.Enabled = true;
            renewpopularBtn.Enabled = true;
        }
        else
        {
            choseBtn.Enabled = false;
            choseBlog2.Enabled = false;
            topicBtn.Enabled = false;
            topicBtn.Enabled = false;
            blog1Btn.Enabled = false;
            blog2Btn.Enabled = false;
            blog3Btn.Enabled = false;
            temaBtn.Enabled = false;
            choseBlog2.Enabled = false;
            renewBtn.Enabled = false;
            remove30daysOldBtn.Enabled = false;
            renewpopularBtn.Enabled = false;
        }
    }

    //write logic when website get more users
    protected void remove30daysOldBtn_Click(object sender, EventArgs e)
    {
        //Blogcollection.Removeold();
        //write logic when website get more users
    }
    //send information to profile page and check profile data there
    protected void evaluateprofile_Click(object sender, EventArgs e)
    {
        Session["Profil"] = newprofiles.SelectedValue;
        Response.Redirect("/vennskap/functions/Readmailprofil?annenprofile={0}");
    }

    public static void getblogsofuser()
    {
        /*if (Blogcollection.getbyusernamelist.Count == 0)
        {
            //the list is open to take new task
            Blogcollection.usertaskmonitor = 0;
        }
        //now time is not more than 1 second later than start time
        else if (DateTime.Now.AddSeconds(1).CompareTo(Blogcollection.starttime) < 2)
        {
            Blogcollection.usertaskmonitor = 0;
        }
        else
        {
            Blogcollection.usertaskmonitor = 1;
            threadmanagement.getblogsbyusername(Blogcollection.getbyusernamelist);
            Blogcollection.starttime = DateTime.Now;
        }*/
    }
   
 
}
