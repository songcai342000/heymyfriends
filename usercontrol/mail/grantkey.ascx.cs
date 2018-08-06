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

public partial class usercontrol_mail_grantkey : System.Web.UI.UserControl
{
    string Username;
    //Mutex mtx3;
    //Exceptncollection myex;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
    }

    protected void writenew_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Profilepage.aspx?writetoprofile={0}");        
    }

    protected void grantkey_Click(object sender, EventArgs e)
    {
        //check if the user has valid order
        if ((Profile.GetProfile(Username)).General.Validorder.CompareTo(DateTime.Now) < 0)
        {
                //Favoritecollection mykeys = new Favoritecollection(Session["Username"].ToString());
                //get schema
            //Favoritecollection defaultCollection = null;
            int FavoriteId;
            Favoritecollection mykeys = new Favoritecollection();
            Favoritecollection defaultCollection = null;
            Mutex mtx2 = null;
                try
                {
                    lock (mykeys)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(createfavoriteid), mykeys);
                        Dictionary<string, int> thedicid = mykeys.getdictionaryid();
                        FavoriteId = thedicid[Username];
                    }
                    
                    if (FavoriteId != -1)
                    {
                        //create an object
                        //ThreadPool.QueueUserWorkItem(new WaitCallback(FavConstru), "");
                        //get id
                        //ThreadPool.QueueUserWorkItem(new WaitCallback(createfavoriteid), "");
                        Favorite mykey = new Favorite(FavoriteId, Username, Session["Profile"].ToString(), "keys", DateTime.Now);
                        ManualResetEvent evt2 = new ManualResetEvent(false);
                        mtx2 = new Mutex(true);
                        ThreadPool.RegisterWaitForSingleObject(evt2,
                      new WaitOrTimerCallback(FavConstru),
                      null, Timeout.Infinite, true);
                        ThreadPool.RegisterWaitForSingleObject(mtx2,
                           new WaitOrTimerCallback(SaveFavorite),
                           null, Timeout.Infinite, true);
                        //defaultCollection = new Favoritecollection();
                        //save object
                        defaultCollection.Add(mykey);
                        evt2.Set();
                        Debug.Assert(defaultCollection == null, "defaultCollection has not been initalized successfully");
                    }
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(SaveFavorite), mykeys);
                }
                catch(Exception ex)
                {
                    Exceptncollection myex = new Exceptncollection();
                    lock (myex)
                    {
                        myex.exceptiondata(Username, ex.Message, myex);
                    }
                    Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
                }
                finally
                {
                    mykeys.removedictionaryid(Username);
                    /*if (myex != null)
                    {
                        myex.removedicid(Username);
                    }
                    if (mtx3 != null)
                    {
                        mtx3.ReleaseMutex();
                    }*/
                    if (mtx2 != null)
                    {
                        mtx2.ReleaseMutex();
                    }
                }
                Response.Redirect("~/functions/Profilopprettet.aspx?newmailreceip={0}");
            }
            //if the user has no valid order, get information about this
        else
        {
            Response.Redirect("~/general/Hjelp.aspx?Membershiprequired={0}");        
        }
    }
    /// <summary>
    /// thread managment
    /// </summary>
    /// <param name="obj"></param>
    public void createfavoriteid(Object obj)
    {
        int Favoriteid;
        Favoriteid = ((Favoritecollection)obj).GetId();
        ((Favoritecollection)obj).filldictionaryid(Username, Favoriteid);
    }

    //constructor for favoritecollection
    public void FavConstru(Object obj, bool TimeOut)
    {
        obj = new Favoritecollection(1);
    }

    public void SaveFavorite(Object obj, bool TimeOut)
    {
        ((Favoritecollection)obj).Save();
    }
}
