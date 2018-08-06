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
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

public partial class usercontrol_profil_annenprofil : System.Web.UI.UserControl
{
    ProfileCommon theprofile;
    //get asked user
    string Username;
    string Profilename;
    Favoritecollection myvisitors;
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

    //Favoritecollection favorites;
    //Epostcollection newmails;
    //Epostcollection getmailcollection;
    //Mutex mtx2;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        if (Profile.GetProfile(Username).General.Gender == "Kvinne")
        {
            flower.ToolTip = "Sende en kupp til vedrørende profil";
        }
        else
        {
            flower.ToolTip = "Sende en rose til vedrørende profil";        
        }
        Profilename = Session["Profil"].ToString();
        //check the user is user or administrator
        MembershipUser theuser = Membership.GetUser();
        theprofile = Profile.GetProfile(Profilename);
        if (theuser != null)
        {
            if (Roles.IsUserInRole(Username, "admin") || theprofile.Profileapproved == "Yes")
            {
                //get profile data
                if (theuser.IsOnline)
                {
                    online.Text = " - Online";
                }
                else
                {
                    online.Text = "";
                }
                getotherprodata(theprofile);
                //add visitor to myvisitors
                addvisitor();
                //if the user is administrator, add dynamic button to approve or deny profile
                getapproved(theprofile);
            }
            else
            {
                Response.Redirect("/vennskap/functions/Profilopprettet.aspx?novalidprofile={0}");
            }
        }
        else
        {
            Response.Redirect("/vennskap/functions/Profilopprettet.aspx?noprofilefound={0}");
        }
    }

    //click event of approve profile
    protected void approve_Click(object sender, EventArgs e)
    {
        MembershipUser theuser = Membership.GetUser(Profilename);
        //theuser.IsApproved = true;
        //Favoritecollection myfavorites = new Favoritecollection();
        //don't need this function, listbox reload every time
        //myfavorites.RemoveUpdatedUserFromList(Session["Profil"].ToString());
        //add the user to role user
        Roles.AddUserToRole(Profilename, "user");
        //approve profile
        ProfileCommon theprofile = Profile.GetProfile(Profilename);
        theprofile.Profileapproved = "Yes";
        //means the profile has been checked
        //don't need
        //theprofile.Profileupdated = "";
        Response.Redirect("~/administrator/Default");
    }

    //click event of deny profile
    protected void deny_Click(object sender, EventArgs e)
    {
        MembershipUser theuser = Membership.GetUser(Profilename);
        //add the user to role user
        Roles.AddUserToRole(Profilename, "user");
        //approve profile
        ProfileCommon theprofile = Profile.GetProfile(Profilename);
        //means the profile has been checked
        //theprofile.Profileupdated = "";
        Response.Redirect("~/administrator/Default");
    }
    //send flower to profile owner
    protected void flower_Click(object sender, EventArgs e)
    {
        string title;
        string content;
        Mutex mtx2 = null;
        Epostcollection newmails = new Epostcollection();
        Epostcollection getmailcollection = null;

        try
        {
            if (Profile.GetProfile(Username).General.Gender == "Kvinne")
            {
                title = "Kupp";
                content = "Du har fått en gule kupp fra " + Username;
            }
            else
            {
                title = "Blomste";
                content = "Du har fått en rose fra " + Username;
            }
            int MailId;
            lock (newmails)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createmailid), newmails);
                Dictionary<string, int> thedicmailid = newmails.getdicid();
                MailId = thedicmailid[Username];
            }
            Debug.Assert(MailId != -1, "mailid create not successfully");
            if (MailId != -1)
            {
                ManualResetEvent evt2 = new ManualResetEvent(false);
                mtx2 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(evt2,
              new WaitOrTimerCallback(mailconstru),
              null, Timeout.Infinite, true);
                ThreadPool.RegisterWaitForSingleObject(mtx2,
                   new WaitOrTimerCallback(SaveMail),
                   null, Timeout.Infinite, true);
                Epost thenewmail = new Epost(MailId, Username, theprofile.UserName, title, content, DateTime.Now, "Not readed", "/vennskap/images/flower.png");
                getmailcollection.Add(thenewmail);
                Debug.Assert(getmailcollection != null, "getmailcollection table is null");
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
            Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
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
            lock (newmails)
            {
                newmails.removedictid(Username);
            }
            if (mtx2 != null)
            {
                mtx2.ReleaseMutex();
            }
        }
        Response.Redirect("~/functions/Profilopprettet.aspx?newmailreceip={0}");
    }

    //put profile as my favorite profile
    protected void favorittprofil_Click(object sender, EventArgs e)
    {
        int favoriteid;
        Favoritecollection favorites = new Favoritecollection();
        Favoritecollection myvisitors = null;
        Mutex mtx2 = null;
        try
        {
            lock (favorites)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createid), favorites);
                Dictionary<string, int> thedicid = favorites.getdictionaryid();
                favoriteid = thedicid[Username];
            }
            Debug.Assert(favoriteid != -1, "create id not successfully");
            if (favoriteid != -1)
            {
                ManualResetEvent evt2 = new ManualResetEvent(false);
                mtx2 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(evt2,
              new WaitOrTimerCallback(idconstru),
              null, Timeout.Infinite, true);
                ThreadPool.RegisterWaitForSingleObject(mtx2,
                   new WaitOrTimerCallback(SaveFav),
                   null, Timeout.Infinite, true);
                Favorite myfavoriteprofile = new Favorite(favoriteid, Username, theprofile.UserName, "myfavoriteprofile", DateTime.Now);
                myvisitors.Add(myfavoriteprofile);
                Debug.Assert(myvisitors != null, "myvisitors table is null");
                evt2.Set();
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myex2 = new Exceptncollection();
            lock (myex2)
            {
                myex2.exceptiondata(Username, ex.Message, myex2);
            }
            Response.Redirect("~/functions/Profilopprettet.aspx?favoriteprofile={0}");            
        }
        finally
        {
            /*lock (myex2)
            {
                if (myex2 != null)
                {
                    myex2.removedicid(Username);
                }
            }
            if (mymtx2 != null)
            {
                mymtx2.ReleaseMutex();
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
        Response.Redirect("~/functions/Profilopprettet.aspx?newmailreceip={0}");
    }

    //send a blink to the profile owner
    protected void blink_Click(object sender, EventArgs e)
    {
        Epostcollection newmails = new Epostcollection();
        Epostcollection getmailcollection = null;
        Mutex mtx2 = null;
        try
        {
            string title = "Blunk";
            string content = Session["Username"].ToString() + " blunker til deg.";
            
            int MailId;
            lock (newmails)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createmailid), newmails);
                Dictionary<string, int> thedicmailid = newmails.getdicid();
                MailId = thedicmailid[Username];
            }
            Debug.Assert(MailId != -1, "create mailid not successfully");
            if (MailId != -1)
            {
                ManualResetEvent evt2 = new ManualResetEvent(false);
                mtx2 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(evt2,
              new WaitOrTimerCallback(mailconstru),
              null, Timeout.Infinite, true);
                ThreadPool.RegisterWaitForSingleObject(mtx2,
                   new WaitOrTimerCallback(SaveMail),
                   null, Timeout.Infinite, true);
                Epost thenewmail = new Epost(MailId, Username, theprofile.UserName, title, content, DateTime.Now, "Not readed", "/vennskap/images/flower.png");
                getmailcollection.Add(thenewmail);
                Debug.Assert(getmailcollection != null, "getmailcollection is not initialized");
                evt2.Set();
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myex3 = new Exceptncollection();
            lock (myex3)
            {
                myex3.exceptiondata(Username, ex.Message, myex3);
            }
            Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
        }
        finally
        {
            /*lock (myex3)
            {
                if (myex3 != null)
                {
                    myex3.removedicid(Username);
                }
            }
            if (mymtx3 != null)
            {
                mymtx3.ReleaseMutex();
            }*/
            lock (newmails)
            {
                newmails.removedictid(Username);
            }
            if (mtx2 != null)
            {
                mtx2.ReleaseMutex();
            }
        }
        Response.Redirect("~/functions/Profilopprettet.aspx?newmailreceip={0}");
    }

    //send a mail to the profileowner
    protected void post_Click(object sender, EventArgs e)
    {
        Response.Redirect("/vennskap/functions/Profilepage.aspx?writetoprofile={0}");
    }

    //ask the profile owner load up a profile picture
    protected void loadBtn_Click(object sender, EventArgs e)
    {
        Mutex mtx2 = null;
        Epostcollection newmails = new Epostcollection();
        Epostcollection getmailcollection = null;
        try
        {
            //get id number for the new object
            int MailId;
            lock (newmails)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createmailid), newmails);
                Dictionary<string, int> thedicmailid = newmails.getdicid();
                MailId = thedicmailid[Username];
            }
            Debug.Assert(MailId != -1, "create mailid not successfully");
            if (MailId != -1)
            {
                ManualResetEvent evt2 = new ManualResetEvent(false);
                mtx2 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(evt2,
              new WaitOrTimerCallback(mailconstru),
              null, Timeout.Infinite, true);
                ThreadPool.RegisterWaitForSingleObject(mtx2,
                   new WaitOrTimerCallback(SaveMail),
                   null, Timeout.Infinite, true);
                string Mailpath = @"C:\Users\mhelenem\Documents\Visual Studio 2008\Websites\vennskaper\Mails\" + MailId.ToString() + ".txt";
                /*using (StreamWriter sw = new StreamWriter(Mailpath))
                {
                    //write mail content to a text file
                    sw.Write(mailcontent.Text);
                }*/
                string mailcontent = theprofile.UserName + "førespører en profilbilde av deg. Den er en god mulighet til å starte en spennende beskjenskap. Vil du svare?";
                Epost thepost = new Epost(MailId, Username, theprofile.UserName, "Førespørelse av profilbilde", Mailpath, DateTime.Now, "Not readed", "");
                //add to database
                getmailcollection.Add(thepost);
                Debug.Assert(getmailcollection != null, "getmailcollection Table initialized successfully");
                evt2.Set();
            }
            else
            {
                Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myex4 = new Exceptncollection();
            lock (myex4)
            {
                myex4.exceptiondata(Username, ex.Message, myex4);
            }
            Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
        }
        finally
        {
            /*lock (myex4)
            {
                if (myex4 != null)
                {
                    myex4.removedicid(Username);
                }
            }
            if (mymtx4 != null)
            {
                mymtx4.ReleaseMutex();
            }*/
            lock (newmails)
            {
                newmails.removedictid(Username);
            }
            if (mtx2 != null)
            {
                mtx2.ReleaseMutex();
            }
        }
        //get receip
        Response.Redirect("~/functions/Profilopprettet.aspx?newmailreceip={0}");
    }

    //set the profile owner as my friend
    protected void venner_Click(object sender, EventArgs e)
    {
        int favoriteid;
        Favoritecollection favorites = new Favoritecollection();
        Favoritecollection myvisitors = null;
        Mutex mtx2 = null;
        try
        {
            lock (favorites)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createid), favorites);
                Dictionary<string, int> thedicid = favorites.getdictionaryid();
                favoriteid = thedicid[Username];
            }
            if (favoriteid != -1)
            {
                ManualResetEvent evt2 = new ManualResetEvent(false);
                mtx2 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(evt2,
              new WaitOrTimerCallback(idconstru),
              null, Timeout.Infinite, true);
                ThreadPool.RegisterWaitForSingleObject(mtx2,
                   new WaitOrTimerCallback(SaveFav),
                   null, Timeout.Infinite, true);
                Favorite myfavoriteprofile = new Favorite(favoriteid, Username, theprofile.UserName, "friend", DateTime.Now);
                myvisitors.Add(myfavoriteprofile);
                Debug.Assert(myvisitors != null, "initialize amyvisitors table successfully");
                evt2.Set();
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myex5 = new Exceptncollection();
            lock (myex5)
            {
                myex5.exceptiondata(Username, ex.Message, myex5);
            }
            Response.Redirect("~/functions/Profilopprettet.aspx?newfriendfeil={0}");
        }
        finally
        {
            /*lock (myex5)
            {
                if (myex5 != null)
                {
                    myex5.removedicid(Username);
                }
            }
            if (mymtx5 != null)
            {
                mymtx5.ReleaseMutex();
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
    }
 
    //block the user
    protected void blockProfile_Click(object sender, EventArgs e)
    {
        Session["Profil"] = theprofile.UserName;
        Response.Redirect("/vennskap/functions/Nye.aspx?blockuser={0}");
    }

    //ask key to access album of the owner
    protected void askkey_Click(object sender, EventArgs e)
    {
        if (theprofile.General.Album != 0 && theprofile.General.Albumkey != "")
        {
            Epostcollection newmails = new Epostcollection();
            Epostcollection getmailcollection = null;
            Mutex mtx2 = null;
            int MailId;
            try
            {
            lock (newmails)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createmailid), newmails);
                Dictionary<string, int> thedicmailid = newmails.getdicid();
                MailId = thedicmailid[Username];
            }
            if (MailId != -1)
            {
                ManualResetEvent evt2 = new ManualResetEvent(false);
                mtx2 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(evt2,
              new WaitOrTimerCallback(mailconstru),
              null, Timeout.Infinite, true);
                ThreadPool.RegisterWaitForSingleObject(mtx2,
                   new WaitOrTimerCallback(SaveMail),
                   null, Timeout.Infinite, true);
                    string Mailpath = @"C:\Users\mhelenem\Documents\Visual Studio 2008\Websites\vennskaper\Mails\" + MailId.ToString() + ".txt";
                    /*using (StreamWriter sw = new StreamWriter(Mailpath))
                    {
                        //write mail content to a text file
                        sw.Write(mailcontent.Text);
                    }*/
                    string mailcontent = theprofile.UserName + "førespører nøkken til din album. Den er en god mulighet til å starte en spennende beskjenskap. Vil du godkjenne førspørelse?";
                    Epost thepost = new Epost(MailId, Session["Username"].ToString(), theprofile.UserName, "Førespørelse av nøkken til din album", Mailpath, DateTime.Now, "Not readed", "");
                    //add to database
                    getmailcollection.Add(thepost);
                    Debug.Assert(myvisitors != null, "initialize getmailcollection table successfully");
                    evt2.Set();
                }
                else
                {
                    Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
                }
            }
            catch(Exception ex)
            {
                Exceptncollection myex6 = new Exceptncollection();
                lock (myex6)
                {
                    myex6.exceptiondata(Username, ex.Message, myex6);
                }
                Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
            }
            finally
            {
                /*lock (myex6)
                {
                    if (myex6 != null)
                    {
                        myex6.removedicid(Username);
                    }
                }
                if (mymtx6 != null)
                {
                    mymtx6.ReleaseMutex();
                }*/
                lock (newmails)
                {
                    newmails.removedictid(Username);
                }
                if (mtx2 != null)
                {
                    mtx2.ReleaseMutex();
                }
            }
        }
        else
        {
            Response.Redirect("~/functions/Profilopprettet.aspx?nokey={0}");
        }
        Response.Redirect("~/functions/Profilopprettet.aspx?newkeyreceip={0}");
    }


    protected void addvisitor()
    {
        int favoriteid;
        Favoritecollection favorites = new Favoritecollection();
        Favoritecollection myvisitors = null;
        Mutex mtx2 = null;
        try
        {
            lock (favorites)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createid), favorites);
                Dictionary<string, int> thedicid = favorites.getdictionaryid();
                favoriteid = thedicid[Username];
            }
            if (favoriteid != -1)
            {
                ManualResetEvent evt2 = new ManualResetEvent(false);
                mtx2 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(evt2,
              new WaitOrTimerCallback(idconstru),
              null, Timeout.Infinite, true);
                ThreadPool.RegisterWaitForSingleObject(mtx2,
                   new WaitOrTimerCallback(SaveFav),
                   null, Timeout.Infinite, true);
                myvisitors.Add(new Favorite(favoriteid, Username, Profilename, "Mine besøkerer", DateTime.Now));
                Debug.Assert(myvisitors != null, "initialize myvisitors table successfully");
                evt2.Set();
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myex7 = new Exceptncollection();
            lock (myex7)
            {
                myex7.exceptiondata(Username, ex.Message, myex7);
            }
        }
        finally
        {
            /*lock (myex7)
            {
                if (myex7 != null)
                {
                    myex7.removedicid(Username);
                }
            }
            if (mymtx7 != null)
            {
                mymtx7.ReleaseMutex();
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
    }

    protected void getapproved(ProfileCommon theprofile)
    {
        if (theprofile.Profileapproved != "Yes")
        {
            Button approve = new Button();
            approve.Text = "Approve";
            approve.Click += new EventHandler(approve_Click);
            Button deny = new Button();
            deny.Text = "Deny";
            deny.Click += new EventHandler(deny_Click);
            approvedenypanel.Controls.Add(approve);
            approvedenypanel.Controls.Add(deny);
        }
    }

    protected void getotherprodata(ProfileCommon theprofile)
    {
        username.Text = theprofile.UserName;
        name.Text = theprofile.UserName;
        gender.Text = theprofile.General.Gender;
        age.Text = theprofile.General.Year;
        searchage.Text = theprofile.General.Searchage;
        country.Text = theprofile.General.Country;
        province.Text = theprofile.General.Province;
        city.Text = theprofile.General.City;
        marital.Text = theprofile.General.Maritalstatus;
        star.Text = theprofile.General.Star;
        child.Text = theprofile.General.Children;
        drink.Text = theprofile.General.Drink;
        smoke.Text = theprofile.General.Smoke;
        ethenic.Text = theprofile.Background.Ethnicbackground;
        religion.Text = theprofile.Background.Religion;
        occupation.Text = theprofile.Background.Occupation;
        education.Text = theprofile.Background.Education;
        language1.Text = theprofile.Background.Language1;
        language2.Text = theprofile.Background.Language2;
        haircolor.Text = theprofile.Outlook.Haircolor;
        hobby.Text = theprofile.Interest;
        physique.Text = theprofile.Outlook.Physique;
        height.Text = theprofile.Outlook.Height;
        eyecolor.Text = theprofile.Outlook.Eyecolor;
        music.Text = theprofile.Freetime.Music;
        sport.Text = theprofile.Freetime.Sporttype;
        pet.Text = theprofile.Freetime.Pet;
        search.Text = theprofile.Expection;
        kontakttype.Text = theprofile.Relationshiptype;
        selv.Text = theprofile.Selvdescription;
        profileImg.ImageUrl = theprofile.General.Picture;
    }
    /// <summary>
    /// callback methods
    /// </summary>
    /// <param name="obj"></param>
    protected void getfavoritebyuser(Object obj)
    {
        DataTable table;
        table = ((Favoritecollection)obj).GetByUsername(Username);
        ((Favoritecollection)obj).fillfavdictbyuser(Username, table);
    }
  
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

    /*protected void userconstru(Object obj)
    {
        obj = new Favoritecollection(Username);
    }*/

    protected void createmailid(Object obj)
    {
        int mailid;
        mailid = ((Epostcollection)obj).GetId();
        ((Epostcollection)obj).filldictid(Username, mailid);
    }

    protected void mailconstru(Object obj, bool TimeOut)
    {
        obj = new Epostcollection(1);
    }

    protected void SaveMail(Object obj, bool TimeOut)
    {
        ((Epostcollection)obj).Save();
    }

    protected void SaveFav(Object obj, bool TimeOut)
    {
        ((Favoritecollection)obj).Save();
    }
}
