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
using System.Collections.Generic;
using vennobjects;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Diagnostics;


public partial class usercontrol_minside_minepotensielle : System.Web.UI.UserControl
{
    string Username;
    string Favoritetype;
    DataTable UserData;
    DataTable otherfav;
    Dictionary<string, DataTable> thedicfavbyother;
    //Exceptncollection myexmyfav;
    //Exceptncollection myexothfav;
    //Mutex mtxmyfav;
    //Mutex mtxothfav;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        Favoritetype = Session["favoritetype"].ToString();
        LoadControlState(favorites);
        if (Favoritetype != "visitor")
        {
            getmyspecialtable();
            getothersspecialtable();
        }
        else
        {
            getmyvisitors();
        }
    }

    #region methods for getting table before wrap with thread
    protected void getfavoritebyuser(Object obj)
    {
        DataTable table;
        table = ((Favoritecollection)obj).GetByUsername(Username);
        ((Favoritecollection)obj).fillfavdictbyuser(Username, table);
    }

    //users i get gift from or i am favorite to
    protected void getothersfav(Object obj)
    {
        DataTable table;
        table = ((Favoritecollection)obj).GetOthersFavorite(Username);
        ((Favoritecollection)obj).filldicotherfavorite(Username, table);
    }

    //get my visitors
    protected void getdicvisitor(Object obj)
    {
        DataTable visitor;
        visitor = ((Favoritecollection)obj).GetVisitors(Username);
        ((Favoritecollection)obj).filldicvisitor(Username, visitor);
    }
#endregion

#region set control state
    private DataTable myfavtable = null;
    private DataTable othersfavtable = null;
    public DataTable Myfavtable
    {
        get
        {
            if (myfavtable == null)
            {
                //insert cache
                Favoritecollection myfavoritecollection = new Favoritecollection();
                Dictionary<string, DataTable> thedicfavbyuser = null;
                lock (myfavoritecollection)
                {
                    try
                    {
                        if (Cache["myfavoritecache"] == null)
                        {
                            SqlCacheDependency sqldep = new SqlCacheDependency("VennerConnectionString", "Favoriteinfo");
                            ThreadPool.QueueUserWorkItem(new WaitCallback(getfavoritebyuser), myfavoritecollection);
                            thedicfavbyuser = myfavoritecollection.getfavdicbyuser();
                            UserData = thedicfavbyuser[Username];
                            Cache.Insert("myfavoritecache", UserData, sqldep);
                        }
                        else
                        {
                            //ThreadPool.QueueUserWorkItem(new WaitCallback(getfavoritebyuser), myfavoritecollection);
                            //thedicfavbyuser = myfavoritecollection.getfavdicbyuser();
                            //UserData = thedicfavbyuser[Username];
                            Debug.Assert(myfavtable != null, "myfavtable is null");
                        }
                        myfavtable = UserData;
                    }
                    catch(Exception ex)
                    {
                        Exceptncollection myexmyfav = new Exceptncollection();
                        myexmyfav.exceptiondata(Username, ex.Message, myexmyfav);
                    }
                    finally
                    {
                        /*if (myexmyfav != null)
                        {
                            myexmyfav.removedicid(Username);
                        }
                        if (mtxmyfav != null)
                        {
                            mtxmyfav.ReleaseMutex();
                        }*/
                        myfavoritecollection.removefavdicbyuser(Username);
                    }
                }
            }
            return myfavtable;
        }
        set
        {
            myfavtable = value;
            favorites.Add(myfavtable);
            SaveControlState();
        }
    }

    public DataTable Othersfavtable
    {
        get
        {
            if (othersfavtable == null)
            {
                Favoritecollection myfavoritecollection = new Favoritecollection();
                lock (myfavoritecollection)
                {
                    try
                    {
                        if (Cache["othersfavoritecache"] == null)
                        {
                            SqlCacheDependency sqldep = new SqlCacheDependency("VennerConnectionString", "Favoriteinfo");
                            ThreadPool.QueueUserWorkItem(new WaitCallback(getothersfav), myfavoritecollection);
                            thedicfavbyother = myfavoritecollection.getfavdicbyuser();
                            otherfav = thedicfavbyother[Username];
                            Cache.Insert("myfavoritecache", otherfav, sqldep);
                        }
                        else
                        {
                            //ThreadPool.QueueUserWorkItem(new WaitCallback(getothersfav), myfavoritecollection);
                            //thedicfavbyother = myfavoritecollection.getfavdicbyuser();
                            //otherfav = thedicfavbyother[Username];
                            Debug.Assert(otherfav != null, "otherfav table is null");
                        }
                    }
                    catch(Exception ex)
                    {
                        Exceptncollection myexothfav = new Exceptncollection();
                        myexothfav.exceptiondata(Username, ex.Message, myexothfav);
                    }
                    finally
                    {
                        /*if (myexothfav != null)
                        {
                            myexothfav.removedicid(Username);
                        }
                        if (mtxothfav != null)
                        {
                            mtxothfav.ReleaseMutex();
                        }*/
                        myfavoritecollection.removedicotherfavorite(Username);
                    }
                    othersfavtable = otherfav;
                }
            }
            return othersfavtable;
        }
        set
        {
            othersfavtable = value;
            favorites.Add(othersfavtable);
            SaveControlState();
        }
    }

    List<DataTable> favorites = new List<DataTable>();
    protected override void OnInit(System.EventArgs e)
    {

        Page.RegisterRequiresControlState(this);

        base.OnInit(e);

    }



    protected override object SaveControlState()
    {
        return this.favorites;
    }



    protected override void LoadControlState(object savedState)
    {
        if (savedState != null)
        {
            favorites = (List<DataTable>)savedState;
        }

    }
#endregion
    #region get tables
    protected void getmyspecialtable()
    {
        DataTable UserData = favorites[0];
        List<userselectedparameters> profiles = new List<userselectedparameters>();
        foreach (DataRow dr in UserData.Rows)
        {
            if (dr["Favoritetype"].ToString() == Favoritetype)
            {
                ProfileCommon theprofile = Profile.GetProfile(dr["Favoritename"].ToString());
                //check if the user is online
                string onlineStatus;
                //get user from his name
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
        Repeater1.DataSource = profiles;
        Repeater1.DataBind();
    }

    protected void getothersspecialtable()
    {
        DataTable UserData = favorites[1];
        List<userselectedparameters> profiles = new List<userselectedparameters>();
        foreach (DataRow dr in UserData.Rows)
        {
            if (dr["Favoritetype"].ToString() == Favoritetype)
            {
                ProfileCommon theprofile = Profile.GetProfile(dr["Username"].ToString());
                //check if the user is online
                string onlineStatus;
                //get user from his name
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
        Repeater1.DataSource = profiles;
        Repeater1.DataBind();
    }

    protected void getmyvisitors()
    {
        Favoritecollection visitor = null;
        Dictionary<string, DataTable> thedictionaryvisitor = null;
        DataTable visitortable = null;
        if (Cache["myvisitorcache"] == null)
        {
            SqlCacheDependency sqldep = new SqlCacheDependency("Venner", "Favoriteinfo");
            SqlCacheDependencyAdmin.EnableNotifications("Venner");
            ThreadPool.QueueUserWorkItem(new WaitCallback(getdicvisitor), visitor);
            thedictionaryvisitor = visitor.getdicvisitor();
            visitortable = thedictionaryvisitor[Username];
            Cache.Insert("myvisitorcache", visitortable, sqldep);
        }
        else
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(getdicvisitor), visitor);
            //thedictionaryvisitor = visitor.getdicvisitor();
            //visitortable = thedictionaryvisitor[Username];
            Debug.Assert(visitortable != null, "visitortable is null");
        }
        visitor.removedicvisitor(Username);
        List<userselectedparameters> profiles = new List<userselectedparameters>();
        //List<userselectedparameters> myvisitorlist = new List<userselectedparameters>();
        for (int i = (visitortable.Rows.Count - 1); i >= 0; i--)
        {
            ProfileCommon theprofile = Profile.GetProfile(visitortable.Rows[i]["Username"].ToString());
            profiles.Add(new userselectedparameters(visitortable.Rows[i]["Username"].ToString(), theprofile.General.Year,
                theprofile.General.City, "", "", ""));
        }
        Debug.Assert(profiles != null, "profiles is null");
        Repeater1.DataSource = profiles;
        Repeater1.DataBind();

    }
    #endregion
}
