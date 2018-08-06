using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Threading;
using System.Diagnostics;

public partial class usercontrol_minsidecontent : System.Web.UI.UserControl
{
    //get different kinds of profiles to show on the page
    List<ProfileCommon> searchprofiles = new List<ProfileCommon>();
    string Username;
    Favoritecollection myfav;
    //Dictionary<string, DataTable> thedicfavbyuser;
    DataTable UserData;
    Blogcollection myblogs;
    Epostcollection inmail;
    Epostcollection outmails;
    Favoritecollection visitors;
    DataTable visitorcount;
    Dictionary<string, DataTable> thedicvisitornum;
    //Exceptncollection myex;
    //Mutex mtx;

    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        //number of blogs the user has
        try
        {
            getfavbyuser();
            getcounts(UserData);
            getblogcount();

            getmessagecount();
            getviscount();
            getprofiles();

            //7get profile data of each username and put profile data to different profilelist
            //List<string> UsernameList = visitors.GetUserNames();
            
        }
        catch(Exception ex)
        {
            Exceptncollection myex = new Exceptncollection();
            myex.exceptiondata(Username, ex.Message, myex);
        }
        finally
        {
            /*lock (myex)
            {
                if (myex != null)
                {
                    myex.removedicid(Username);
                }
            }
            if (mtx != null)
            {
                mtx.ReleaseMutex();
            }*/
            lock (myfav)
            {
                myfav.removefavdicbyuser(Username);
            }
            lock (myblogs)
            {
                myblogs.removedicblognum(Username);
            }
            lock (inmail)
            {
                inmail.removedicinboxnum(Username);
            }
            lock (outmails)
            {
                outmails.removedicoutboxnum(Username);
            }
            lock (visitors)
            {
                visitors.removedicvisitornum(Username);
            }
        }
    }

    //list of my search defined in profile
    protected void  yoursearchlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
         //get state value when click linkbutton respectively
        if (e.CommandName == "yoursearchName" || e.CommandName == "yoursearchAge" || e.CommandName == "yoursearchCity")
        {
            Session["Profil"] = ((LinkButton)e.Item.FindControl("yoursearchNameBtn")).Text;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofil={0}");
        }
    }

    //list of visitor
    protected void visitorlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //get state value when click linkbutton respectively

        if (e.CommandName == "visitorName" || e.CommandName == "visitorAge" || e.CommandName == "visitorCity")
        {
            Session["Profil"] = ((LinkButton)e.Item.FindControl("visitorNameBtn")).Text;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofil={0}");
        }
    }

    //list of new man member
    protected void newmenlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //get state value when click linkbutton respectively

        if (e.CommandName == "newmenName" || e.CommandName == "newmenAge" || e.CommandName == "newmenCity")
        {
            Session["Profil"] = ((LinkButton)e.Item.FindControl("newmenNameBtn")).Text;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofil={0}");
        }
    }

    //list of new woman list
    protected void newwomenlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //get state value when click linkbutton respectively

        if (e.CommandName == "newwomenName" || e.CommandName == "newwomenAge" || e.CommandName == "newwomenCity")
        {
            Session["Profil"] = ((LinkButton)e.Item.FindControl("newwomenNameBtn")).Text;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofil={0}");
        }
    }

    protected void getfavbyuser()
    {
        myfav = new Favoritecollection();
        Dictionary<string, DataTable> thedicfavbyuser = null;
        lock (myfav)
        {
            if (Cache["mystafavcache"] == null)
            {
                SqlCacheDependency sqldep = new SqlCacheDependency("Venner", "Favoriteinfo");
                ThreadPool.QueueUserWorkItem(new WaitCallback(getfavoritebyuser), myfav);
                myfav = new Favoritecollection();
                thedicfavbyuser = myfav.getfavdicbyuser();
                UserData = thedicfavbyuser[Username];
                Cache.Insert("myfavoritecache", UserData, sqldep);
            }
            else
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getfavoritebyuser), myfav);
                myfav = new Favoritecollection();
                thedicfavbyuser = myfav.getfavdicbyuser();
                UserData = thedicfavbyuser[Username];
            }
            Debug.Assert(UserData != null, "UserData is null");
        }
    }

    protected void getcounts(DataTable thetable)
    {
        int friend = 0;
        int myfavprofi = 0;
        int flower = 0;
        int key = 0;
        int iamfavorite = 0;
        int myfavoriteblog = 0;
        foreach (DataRow dr in UserData.Rows)
        {
            if (dr["Favoritetype"].ToString() == "myfavoriteblog")
            {
                myfavoriteblog++;
            }
            else if (dr["Favoritetype"].ToString() == "friend")
            {
                friend++;
            }
            else if (dr["Favoritetype"].ToString() == "myfavoriteprofile")
            {
                myfavprofi++;
            }
        }
        friendLi.Text = friend.ToString();
        myfavoriteLi.Text = myfavprofi.ToString();
        iamfavoriteLi.Text = iamfavorite.ToString();
        keyLi.Text = key.ToString();
        flowerLi.Text = flower.ToString();
        membershipLi.Text = Profile.General.Validorder.ToString();
    }

    protected void getblogcount()
    {
        myblogs = new Blogcollection();
        lock (myblogs)
        {
            Dictionary<string, int> thedicblognum = null;
            int blogcount = 0;
            ThreadPool.QueueUserWorkItem(new WaitCallback(getmyblognum), myblogs);
            thedicblognum = myblogs.getdicblognumber();
            blogcount = thedicblognum[Username];
            blogLi.Text = blogcount.ToString();
            Session["myblogcount"] = blogcount.ToString();
        }
    }

    protected void getmessagecount()
    {
        //number of message the user sent
        inmail = new Epostcollection();
        lock (inmail)
        {
            int receivemessage = 0;
            ThreadPool.QueueUserWorkItem(new WaitCallback(getinboxnum), inmail);
            inmail = new Epostcollection();
            Dictionary<string, int> thedicinboxnum = inmail.getdicinboxnum();
            receivemessage = thedicinboxnum[Username];
            receivedmessageLi.Text = receivemessage.ToString();
        }
        outmails = new Epostcollection();
        lock (outmails)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(getoutboxnum), outmails);
            Dictionary<string, int> thedicoutboxnum = outmails.getdicoutboxnum();
            sentmessageLi.Text = thedicoutboxnum[Username].ToString();
            Debug.Assert(thedicoutboxnum != null, "thedicoutboxnum is 0");
        }
    }

    protected void getviscount()
    {
        //number of blogs the user has

        //get number of those who visited med
        visitors = new Favoritecollection();
        lock (visitors)
        {
            if (Cache["visitorcountcache"] == null)
            {
                SqlCacheDependency SqlDp = new SqlCacheDependency("Venn", "Favoriteinfo");
                ThreadPool.QueueUserWorkItem(new WaitCallback(getvisitornum), visitors);
                thedicvisitornum = visitors.getdicvisitornum();
                visitorcount = thedicvisitornum[Username];
                Cache.Insert("visitorcountcache", visitorcount, SqlDp);
            }
            else
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getvisitornum), visitors);
                thedicvisitornum = visitors.getdicvisitornum();
                visitorcount = thedicvisitornum[Username];
            }
            myvisitorLi.Text = visitorcount.Rows[0][0].ToString();
        }
    }

    protected void getprofiles()
    {
        MembershipUserCollection users = Membership.GetAllUsers();
        foreach (MembershipUser user in users)
        {
            ProfileCommon theprofile = Profile.GetProfile(user.UserName);
            //if the users profile is approved and the user fit the search condition
            if (theprofile.Profileapproved == "Yes" && int.Parse(theprofile.General.Year) <= (int.Parse(Profile.General.SearchageMax)) && int.Parse(theprofile.General.Year) >= (int.Parse(Profile.General.SearchageMin)))
            {
                searchprofiles.Add(theprofile);
            }
        }
        Debug.Assert(searchprofiles.Count > 0, "searchprofiles list is empty");
        Debug.Assert(Favoritecollection.newmenprofiles.Count > 0, "newmenprofiles list is empty");
        Debug.Assert(Favoritecollection.newwomenprofiles.Count > 0, "newwomenprofiles list is empty");
        newmenlist.DataSource = Favoritecollection.newmenprofiles;
        newmenlist.DataBind();
        newwomenlist.DataSource = Favoritecollection.newwomenprofiles;
        newwomenlist.DataBind();
        yoursearchlist.DataSource = searchprofiles;
        yoursearchlist.DataBind();
    }

    protected void getfavoritebyuser(Object obj)
    {
        DataTable table;
        table = ((Favoritecollection)obj).GetByUsername(Username);
        ((Favoritecollection)obj).fillfavdictbyuser(Username, table);
    }

    protected void getoutboxnum(Object obj)
    {
        DataTable table;
        table = ((Epostcollection)obj).GetEpostBySender(Username);
        ((Epostcollection)obj).filldictinbox(Username, table);
    }

    public void getmyblognum(Object obj)
    {
        int number;
        number = ((Blogcollection)obj).CountMyBlogs(Username);
        ((Blogcollection)obj).filldicblognum(Username, number);
    }

    protected void getinboxnum(Object obj)
    {
        int innum;
        innum = ((Epostcollection)obj).InboxCount(Username);
        ((Epostcollection)obj).filldicinboxnum(Username, innum);
    }

    protected void getvisitornum(Object obj)
    {
        DataTable table;
        table = ((Favoritecollection)obj).CountVisitors(Username);
        ((Favoritecollection)obj).filldicvisitornum(Username, table);
    }

}
