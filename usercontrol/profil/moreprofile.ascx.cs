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
using System.Threading;
using System.Diagnostics;


public partial class usercontrol_profil_moreprofile : System.Web.UI.UserControl
{
    List<userselectedparameters> profiles = new List<userselectedparameters>();
    int profileage;
    string onlineStatus;
    ProfileCommon theprofile;
    string Username;
    string Searchname;
    Epostcollection eposts;
    DataTable searchedusers;
    /*Exceptncollection myex;
    Exceptncollection myexs;*/
    Mutex mtx2;

    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        Searchname = Session["profilesearch"].ToString();
        if (Request.QueryString["searchsimiliarprofile"] != null)
        {
            searchsimiliar();
        }
        else
        {
            string[] users = Roles.GetUsersInRole("user");
            for (int i = 0; i < users.Length; i++)
            {
                theprofile = Profile.GetProfile(users.ElementAt<string>(i));
                MembershipUser theuser = Membership.GetUser(theprofile.UserName);
                if (theprofile.UserName != Username)
                {
                    useronline(theprofile, theuser);
                    //nowyear = int.Parse(DateTime.Now.Year.ToString());
                    if (theprofile != null && theprofile.General.Year.ToString() != "")
                    {
                        profileage = int.Parse(theprofile.General.Year);
                    }
                    if (profileage <= int.Parse(Session["Max"].ToString()) &&
                        profileage >= int.Parse(Session["Min"].ToString()))
                    {
                        userselectedparameters profileparameters = useronline(theprofile, theuser);
                        getbycondition(profileparameters);
                    }
                }
            }
        }
        
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "username")
        {
            Session["Profil"] = ((LinkButton)(e.Item.FindControl("usernameLi"))).Text;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofile={0}");
        }
        if (e.CommandName == "album")
        {
            Session["Profil"] = ((LinkButton)(e.Item.FindControl("usernameLi"))).Text;
            Response.Redirect("/vennskap/functions/Nye.aspx?seealbum={0}");
        }
        if (e.CommandName == "blog")
        {
            Session["Profil"] = ((LinkButton)(e.Item.FindControl("usernameLi"))).Text;
            Response.Redirect("/vennskap/general/moreblog.aspx?profileblogsearch={0}");
        }
    }

    //event when LinkButton for page number is clicked
    protected void pageLBtn_Click(object source, CommandEventArgs e)
    {
        //ViewState["CurrentPage"] = CurrentPage;
        CurrentPage = e.CommandName;
        List<userselectedparameters> pagelist = ItemsGet(CurrentPage);
        Repeater1.DataSource = pagelist;
        Repeater1.DataBind();
    }

    private string currentpage;
    public string CurrentPage
    {
        get
        {
            return currentpage;
        }
        set
        {
            currentpage = value;
        }
    }

    //regist controlstate
    protected override void OnInit(System.EventArgs e)
    {

        Page.RegisterRequiresControlState(this);

        base.OnInit(e);

    }

    protected override object SaveControlState()
    {
        return this.profiles;
    }

    protected override void LoadControlState(object savedState)
    {
        if (savedState != null)
        {
            profiles = (List<userselectedparameters>)savedState;
        }

    }

    private void cmdPrev_Click(object sender, EventArgs e)
    {
        // Set viewstate variable as the previous page
        //ViewState["CurrentPage"] = (int.Parse(CurrentPage) - 1).ToString();
        CurrentPage = (int.Parse(CurrentPage) - 1).ToString();
        if (int.Parse(CurrentPage) > 0 && int.Parse(CurrentPage) <= (profiles.Count % 2) + 1)
        {
            List<userselectedparameters> pagelist = ItemsGet(CurrentPage);
            Repeater1.DataSource = pagelist;
            Repeater1.DataBind();
        }
    }

    //next page
    private void cmdNext_Click(object sender, EventArgs e)
    {
        // Set viewstate variable as the next page
        //ViewState["CurrentPage"] = (int.Parse(CurrentPage) + 1).ToString();
        CurrentPage = (int.Parse(CurrentPage) + 1).ToString();
    }

    //get items of each page
    private List<userselectedparameters> ItemsGet(string pagenumber)
    {
        List<userselectedparameters> pageusers = new List<userselectedparameters>();
        //for (int i = int.Parse(pagenumber + "0"); i < int.Parse(pagenumber + "0") + 1; i++)
        for (int i = 0; i <= 20; i++)
        {
            if (profiles.Count > int.Parse(pagenumber.ToString() + i.ToString()))
            {
                pageusers.Add(profiles[int.Parse(pagenumber.ToString() + i.ToString())]);
            }
            else if (profiles.Count > i)
            {
                pageusers.Add(profiles[i]);
            }
            else
            {
                break;
            }
        }
        return pageusers;
    }

    /*protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Repeater1.ItemCommand +=
           new RepeaterCommandEventHandler(Repeater1_ItemCommand);
    }*/

    protected void searchsimiliar()
    {
        try
        {
            eposts = new Epostcollection();
            lock (eposts)
            {
                //get similiar usernames from epostinfo table, it is not complete but it represents those active
                ThreadPool.QueueUserWorkItem(new WaitCallback(getsimiliarusers), eposts);
                Dictionary<string, DataTable> thesearch = eposts.getdicsearch();
                searchedusers = thesearch[Username];
                Debug.Assert(searchedusers != null, "no searchedusers found");
            }
            //get profile data
            foreach (DataRow dr in searchedusers.Rows)
            {
                theprofile = Profile.GetProfile(dr["Receiver"].ToString());
                MembershipUser theuser = Membership.GetUser(theprofile.UserName);
                if (theuser.IsOnline)
                {
                    onlineStatus = "OnLine";
                }
                else
                {
                    onlineStatus = "";
                }
                userselectedparameters profileparameters = new userselectedparameters(theprofile.UserName, theprofile.General.Year, theprofile.General.City,
                    onlineStatus, theprofile.General.Album.ToString(), theprofile.General.Blog.ToString());
                profiles.Add(profileparameters);
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myex = new Exceptncollection();
            lock (myex)
            {
                myex.exceptiondata(Username, ex.Message, myex);
            }
        }
        finally
        {
            /*if (myex != null)
            {
                lock (myex)
                {
                    myex.removedicid(Username);
                }
            }
            if (mtx2 != null)
            {
                mtx2.ReleaseMutex();
            }*/
            lock (eposts)
            {
                eposts.removedicsearch(Username);
            }
        }
    }

    protected userselectedparameters useronline(ProfileCommon theprofile, MembershipUser theuser)
    {
        if (theuser.IsOnline)
        {
            onlineStatus = "OnLine";
        }
        else
        {
            onlineStatus = "";
        }
        userselectedparameters profileparameters = new userselectedparameters(theprofile.UserName, theprofile.General.Year, theprofile.General.City,
            onlineStatus, theprofile.General.Album.ToString(), theprofile.General.Blog.ToString());
        return profileparameters;
    }

    protected void getbycondition(userselectedparameters profileparameters)
    {
        lock (profiles)
        {
            profiles.Clear();
            if (Session["allprofile"].ToString() == "Yes")
            {
                profiles.Add(profileparameters);
            }
            else if (Session["selectedprovince"].ToString() != "" && theprofile.General.Province == Session["selectedprovince"].ToString())
            {
                if (theprofile.General.Gender == Session["selectedgender"].ToString())
                {
                    profiles.Add(profileparameters);
                }
            }
            else if (Session["selectedprovince"].ToString() == "")
            {
                if (theprofile.General.Gender == Session["selectedprovince"].ToString())
                {
                    profiles.Add(profileparameters);
                }
            }
            else if (Session["profilepicture"].ToString() == "Yes" && theprofile.General.Picture != "")
            {
                if (theprofile.General.Gender == Session["selectedgender"].ToString())
                {
                    profiles.Add(profileparameters);
                }
            }
            else if (Session["profilealbum"].ToString() == "Yes" && theprofile.General.Album.ToString() != "0")
            {
                if (theprofile.General.Gender == Session["selectedgender"].ToString())
                {
                    profiles.Add(profileparameters);
                }
            }
            else if (Session["profileblog"].ToString() == "Yes" && theprofile.General.Blog != "")
            {
                if (theprofile.General.Gender == Session["selectedgender"].ToString())
                {
                    profiles.Add(profileparameters);
                }
            }
            today(theprofile, profileparameters);
            lastthreedays(theprofile, profileparameters);
            lastweek(theprofile, profileparameters);
            lastmonth(theprofile, profileparameters);
        }
    }
  
    protected void today(ProfileCommon theprofile, userselectedparameters profileparameters)
    {
        if (Session["selectedmembershipstart"].ToString() == "I dag")
        {
            if (theprofile.General.Membershipstart != "" && (DateTime.Parse(theprofile.General.Membershipstart)).Date == DateTime.Now.Date)
            {
                profiles.Add(profileparameters);
            }
        }
    }
    protected void lastthreedays(ProfileCommon theprofile, userselectedparameters profileparameters)
    {
        if (Session["selectedmembershipstart"].ToString() == "De siste tre dagene")
        {
            if (theprofile.General.Membershipstart != "" && ((DateTime.Parse(theprofile.General.Membershipstart)).Date == (DateTime.Now.AddDays(-2)).Date ||
                (DateTime.Parse(theprofile.General.Membershipstart)).Date == (DateTime.Now.AddDays(-1)).Date ||
                (DateTime.Parse(theprofile.General.Membershipstart)).Date == DateTime.Now.Date))
            {
                profiles.Add(profileparameters);
            }
        }
    }

    protected void lastweek(ProfileCommon theprofile, userselectedparameters profileparameters)
    {
        if (Session["selectedmembershipstart"].ToString() == "Den seneste uken")
        {
            if (theprofile.General.Membershipstart != "" && ((DateTime.Parse(theprofile.General.Membershipstart)).Date == (DateTime.Now.AddDays(-6)).Date ||
                (DateTime.Parse(theprofile.General.Membershipstart)).Date == (DateTime.Now.AddDays(-5)).Date ||
                (DateTime.Parse(theprofile.General.Membershipstart)).Date == (DateTime.Now.AddDays(-4)).Date ||
                (DateTime.Parse(theprofile.General.Membershipstart)).Date == (DateTime.Now.AddDays(-3)).Date ||
                (DateTime.Parse(theprofile.General.Membershipstart)).Date == (DateTime.Now.AddDays(-2)).Date ||
                (DateTime.Parse(theprofile.General.Membershipstart)).Date == (DateTime.Now.AddDays(-1)).Date ||
                (DateTime.Parse(theprofile.General.Membershipstart)).Date == DateTime.Now.Date))
            {
                profiles.Add(profileparameters);
            }
        }
    }

    protected void lastmonth(ProfileCommon theprofile, userselectedparameters profileparameters)
    {
        if (Session["selectedmembershipstart"].ToString() == "Den seneste måneden")
        {
            if (theprofile.General.Membershipstart != "" && (DateTime.Parse(theprofile.General.Membershipstart)).Year == DateTime.Now.Year)
            {
                if ((DateTime.Parse(theprofile.General.Membershipstart)).Month == DateTime.Now.Month &&
                    ((DateTime.Parse(theprofile.General.Membershipstart)).Day < DateTime.Now.Day))
                {
                    profiles.Add(profileparameters);
                }
                if (((DateTime.Parse(theprofile.General.Membershipstart)).Month == (DateTime.Now.AddMonths(-1)).Month) &&
                    ((DateTime.Parse(theprofile.General.Membershipstart)).Day > DateTime.Now.Day))
                {
                    profiles.Add(profileparameters);
                }
            }
        }
    }

    protected void profilepages()
    {
        if (profiles.Count > 0)
        {
            //get paging of repeater
            List<userselectedparameters> currentlist = ItemsGet(CurrentPage);
            Repeater1.DataSource = currentlist;
            Repeater1.DataBind();
            //add previouspage nextpage symbol and event
            if (profiles.Count % 2 > 0)
            {
                LinkButton previousBtn = new LinkButton();
                previousBtn.Text = "PreviousPage";
                previousBtn.Click += new EventHandler(cmdPrev_Click);
                pagePan.Controls.Add(previousBtn);
                pagePan.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
            }
            for (int i = 0; i < ((profiles.Count % 2) + 1); i++)
            {
                LinkButton pageLBtn = new LinkButton();
                pageLBtn.Text = (i + 1).ToString();
                //CurrentPage = pageLBtn.Text;
                pageLBtn.CommandName = (i+1).ToString();
                pageLBtn.Command += new CommandEventHandler(pageLBtn_Click);
                pagePan.Controls.Add(pageLBtn);
                pagePan.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
            }
            if (profiles.Count % 2 > 0)
            {
                LinkButton nextBtn = new LinkButton();
                nextBtn.Text = "NextPage";
                nextBtn.Click += new EventHandler(cmdNext_Click);
                pagePan.Controls.Add(nextBtn);
            }
            //Repeater1.DataSource = profiles;
            //Repeater1.DataBind();
        }
        else
        {
            Response.Redirect("/vennskap/functions/Profilopprettet.aspx?noprofilefound={0}");
        }
    }

    protected void getsimiliarusers(object obj)
    {
        DataTable table = ((Epostcollection)obj).GetSimiliarUsername(Searchname);
        ((Epostcollection)obj).filldicsearch(Username, table);
    }

    protected void getexid(object obj)
    {
        int Exid = ((Exceptncollection)obj).GetId();
        ((Exceptncollection)obj).filldicid(Username, Exid);
    }

    protected void exconstru(object obj, bool TimeOut)
    {
        obj = new Exceptncollection(1);
    }

    protected void saveex(object obj, bool TimeOut)
    {
        ((Exceptncollection)obj).Save();
    }
}
