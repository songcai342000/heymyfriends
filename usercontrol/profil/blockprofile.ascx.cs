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
using System.Diagnostics;

public partial class usercontrol_profil_blockprofile : System.Web.UI.UserControl
{
    string Username;
    string Profilename;
    Exceptncollection myex1;
    Mutex mymtx1;
    //Favoritecollection favorites;
    //Favoritecollection dislikes;
    //Mutex mtx2;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        Profilename = Session["Profilename"].ToString();
    }
    protected void yesBtn_Click(object sender, EventArgs e)
    {
        int dislikeid;
        Favoritecollection favorites = new Favoritecollection();
        Favoritecollection dislikes = null;
        Mutex mtx2 = null;
        try
        {
            lock (favorites)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createid), favorites);
                Dictionary<string, int> thedicid = favorites.getdictionaryid();
                dislikeid = thedicid[Username];
            }
            if (dislikeid != -1)
            {
                ManualResetEvent evt2 = new ManualResetEvent(false);
                mtx2 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(evt2,
              new WaitOrTimerCallback(idconstru),
              null, Timeout.Infinite, true);
                ThreadPool.RegisterWaitForSingleObject(mtx2,
                   new WaitOrTimerCallback(SaveFav),
                   null, Timeout.Infinite, true);
                dislikes.Add(new Favorite(dislikeid, Username, Profilename, "blocked", DateTime.Now));
                Debug.Assert(dislikeid != null, "initialize disliked table successfully");
                evt2.Set();
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myex1 = new Exceptncollection();
            lock (myex1)
            {
                myex1.exceptiondata(Username, ex.Message, myex1);
            }
            //add logic, get receip of feil
            Response.Redirect("/vennskap/functions/Profilopprettet.aspx?blockprofilefeil={0}");
        }
        finally
        {
            /*lock (myex1)
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
            lock (favorites)
            {
                favorites.removedictionaryid(Username);
            }
            if (mtx2 != null)
            {
                mtx2.ReleaseMutex();
            }
        }
        //get receip of blocking profile
        Response.Redirect("/vennskap/functions/Profilopprettet.aspx?blockprofile={0}");
    }
    //chose no then back to the previous page
    protected void noBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofile={0}");
    }

    /// <summary>
    /// thread method
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="TimeOut"></param>
    protected void idconstru(Object obj, bool TimeOut)
    {
        obj = new Favoritecollection(1);
    }

    protected void createid(Object obj)
    {
        int favid;
        favid = ((Favoritecollection)obj).GetId();
        ((Favoritecollection)obj).filldictionaryid(Username, favid);
    }

    protected void SaveFav(Object obj, bool TimeOut)
    {
        ((Favoritecollection)obj).Save();
    }
}
