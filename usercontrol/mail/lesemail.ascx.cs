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
using System.IO;
using System.Threading;
using System.Diagnostics;

public partial class usercontrol_mail_lesemail : System.Web.UI.UserControl
{
    Epost mypost;
    Epostcollection eposts;
    //Favoritecollection creatid;
    //Dictionary<string, int> thedicmailid;
    //Dictionary<string, int> thedictionaryid;
    //Dictionary<string, DataTable> thedicmailbytime;
    Mutex mtx1;
    Mutex mtx2;
    //Mutex mtx3;
    /*Mutex mtxdelall;
    Mutex mtxblock;
    Mutex mtx;
    Mutex mtxgetmail;
    Exceptncollection myex;
    Exceptncollection myex1;
    Exceptncollection myexall;
    Exceptncollection myexblock;
    Exceptncollection myexgetmail;*/
    //int MailId;
    //int FavId;
    string Username;
    DateTime Time;
    string Profilename;
    DataTable updatetable;//update table
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
          //check if the user has valid order
        //Epostcollection epostlist = new Epostcollection();
        if ((Profile.GetProfile(Username)).General.Validorder.CompareTo(DateTime.Now) < 0)
        {
            getthemailbytime();
            if (mypost != null)
            {
                //string mailpath = mypost.Mailcontent.Substring(55);
                //StreamReader strReader = new StreamReader("C:\\Users\\mhelenem\\Documents\\Visual Studio 2008\\WebSites" + mailpath);
                string content = mypost.Mailcontent;
                mailcontent.Text = content;
                title.Text = mypost.Mailtitle;
                time.Text = mypost.Time.ToString();
                fromto.Text = "Fra: ";
                senderLink.Text = mypost.Username;
                Session["Profil"] = mypost.Username;
                //assign profilename for later use
                Profilename = Session["Profil"].ToString();
                /*if (mypost.Picturepath != "")
                {
                    Image1.Visible = true;
                    Image1.ImageUrl = mypost.Picturepath;
                }*/
            }
        }
            //if the user has no valid order, get information about this
        else
        {
            Response.Redirect("~/general/Hjelp.aspx?Membershiprequired={0}");        
        }
    }
   
   
    private string outmailpath;
    public string Outmailpath
    {
        get
        {
            return outmailpath;
        }
        set
        {
            outmailpath = value;
        }
    }

    protected void reply_Click(object sender, EventArgs e)
    {
        flower.Visible = true;
        flower.Enabled = true;
        if (Profile.GetProfile(Username).General.Gender == "Kvinne")
        {
            flower.ImageUrl = "/vennskap/images/cupgift.jpg";
        }
        else
        {
            flower.ImageUrl = "/vennskap/images/rosegift.jpg";            
        }
        blink.Visible = true;
        blink.Enabled = true;
        if (mypost != null)
        {
            string content = mypost.Mailcontent;
            //create format
            chosenblogcontentPan.Visible = true;
            chosenblogcontentPan.Value = "--------------------------------------------------------------------" +
               mypost.Time.ToString() + "   " + mypost.Username + " skrvet:" + "<br /><br />tr " + content;
            //get elemeter value of the new post object
            title.Text = "SV: " + mypost.Mailtitle;
            fromto.Text = "Til: ";
            senderLink.Enabled = false;
        }
       
    }

    protected void flower_Click(object sender, ImageClickEventArgs e)
    {
        Outmailpath = flower.ImageUrl;
    }

    protected void blink_Click(object sender, ImageClickEventArgs e)
    {
        Outmailpath = blink.ImageUrl;
    }
    protected void sendBtn_Click(object sender, EventArgs e)
    {
       
            //ThreadPool.QueueUserWorkItem(new WaitCallback(getmailid), "");
            try
            {
                int MailId = getidmutex();
                Debug.Assert(MailId != -1, "Create new mailid not successfully");
                if (MailId != -1)
                {
                    savemailmutex(MailId);
                }
                else
                {
                    Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
                }
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
                eposts.removedictid(Username);
                Debug.Assert(mtx1 == null, "Mtx1 is null");
                Debug.Assert(mtx2 == null, "Mtx2 is null");
                /*if (myex != null)
                {
                    myex.removedicid(Username);
                }
                if (mtx3 != null)
                {
                    mtx3.ReleaseMutex();
                }*/
                if (mtx1 != null)
                {
                    mtx1.ReleaseMutex();
                }
                if (mtx2 != null)
                {
                    mtx2.ReleaseMutex();
                }
            }
           
                //get receip
        Response.Redirect("~/functions/Profilopprettet.aspx?newmailreceip={0}");
    }           
    //block an user
    protected void block_Click(object sender, EventArgs e)
    {
        Mutex mtx1 = null;
        Favoritecollection creatid = new Favoritecollection();
        Favoritecollection dislikes = null;
        Dictionary<string, int> thedictionaryid = null;
        int FavId;
        try
        {
            //int FavoriteId = 0;
            //get id
            lock (creatid)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(createfavoriteid), creatid);
                FavId = thedictionaryid[Username];
            }
            Debug.Assert(FavId != -1, "create favoriteid not successfully");
            if (FavId != -1)
            {
                ManualResetEvent evt1 = new ManualResetEvent(false);
                ThreadPool.RegisterWaitForSingleObject(evt1,
              new WaitOrTimerCallback(favconstru),
              null, Timeout.Infinite, true);
                mtx1 = new Mutex(true);
                ThreadPool.RegisterWaitForSingleObject(mtx1,
              new WaitOrTimerCallback(SaveFavorite),
              null, Timeout.Infinite, true);
                evt1.Set();
                Favorite dislike = new Favorite(FavId, Username, Profilename, "blocked", DateTime.Now);
                dislikes.Add(dislike);
                //ThreadPool.QueueUserWorkItem(new WaitCallback(SaveFavorite), dislikes);
                ThreadPool.RegisterWaitForSingleObject(mtx1,
                  new WaitOrTimerCallback(SaveFavorite),
                  null, Timeout.Infinite, true);
                Debug.Assert(dislikes != null, "dislikes object has not been initialized");
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myexblock = new Exceptncollection();
            lock (myexblock)
            {
                myexblock.exceptiondata(Username, ex.Message, myexblock);
            }
        }
        finally
        {
            creatid.removedictionaryid(Username);
            /*if (myexblock != null)
            {
                lock (myexblock)
                {
                    myexblock.removedicid(Username);
                }
            }
            if (mtxblock != null)
            {
                mtxblock.ReleaseMutex();
            }*/
            if (mtx1 != null)
            {
                mtx1.ReleaseMutex();
            }
        }

    }
    //delete a mail
    protected void deleteall_Click(object sender, EventArgs e)
    {
        Epostcollection eposts = new Epostcollection();
        Mutex mtx1 = null;
        try
        {
            //get schema
            ManualResetEvent evt1 = new ManualResetEvent(false);
            mtx1 = new Mutex(true);
            ThreadPool.RegisterWaitForSingleObject(evt1,
          new WaitOrTimerCallback(getmailbytime),
          null, Timeout.Infinite, true);
            ThreadPool.RegisterWaitForSingleObject(mtx1,
          new WaitOrTimerCallback(updatemailtable),
          null, Timeout.Infinite, true);
            /*ThreadPool.RegisterWaitForSingleObject(mtx2,
               new WaitOrTimerCallback(mailcontru),
               null, Timeout.Infinite, true);*/
            evt1.Set();
            Dictionary<string, DataTable> thedicmailinbox = eposts.getdicmailbytime();
            updatetable = thedicmailinbox[Username];
            Debug.Assert(updatetable.Rows.Count > 0, "updatetable is empty");
            //delete mail
            //Epost myupdate = new Eupdate(int.Parse(updatetable.Rows[0][0].ToString()), updatetable.Rows[0][1].ToString(), updatetable.Rows[0][2].ToString(), updatetable.Rows[0][3].ToString(), updatetable.Rows[0][4].ToString(), DateTime.Parse(updatetable.Rows[0][5].ToString()), updatetable.Rows[0][6].ToString(), updatetable.Rows[0][7].ToString());
            updatetable.Rows.Remove(updatetable.Rows[0]);
        }
        catch(Exception ex)
        {
            Exceptncollection myexall = new Exceptncollection();
            lock (myexall)
            {
                myexall.exceptiondata(Username, ex.Message, myexall);
            }
        }
        finally
        {
            eposts.removedicmailbytime(Username); 
            Debug.Assert(mtx1 != null, "mtx1 is not null");
            /*if (myexall != null)
            {
                myexall.removedicid(Username);
            }
            if (mtxdelall != null)
            {
                mtxdelall.ReleaseMutex();
            }*/

            if (mtx1 != null)
            {
                mtx1.ReleaseMutex();
            }
        }
    }

    protected void getthemailbytime()
    {
        flower.Visible = false;
        flower.Enabled = false;
        blink.Visible = false;
        blink.Enabled = false;
        sendBtn.Visible = false;
        sendBtn.Enabled = false;
        //get a mail by senders name and mail time
        Time = DateTime.Parse(Session["Time"].ToString());
        Epostcollection eposts = new Epostcollection();
        Dictionary<string, DataTable> thedicmailbytime = null;
        lock (eposts)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getmailbytime), eposts);
                thedicmailbytime = eposts.getdicmailbytime();
                DataTable posttable = thedicmailbytime[Username];
                Debug.Assert(posttable != null, "posttable is null");
                Epost mypost = new Epost(int.Parse(posttable.Rows[0][0].ToString()), posttable.Rows[0][1].ToString(), posttable.Rows[0][2].ToString(), posttable.Rows[0][3].ToString(), posttable.Rows[0][4].ToString(), DateTime.Parse(posttable.Rows[0][5].ToString()), posttable.Rows[0][6].ToString(), posttable.Rows[0][7].ToString());
            }
            catch(Exception ex)
            {
                Exceptncollection myexgetmail = new Exceptncollection();
                lock (myexgetmail)
                {
                    myexgetmail.exceptiondata(Username, ex.Message, myexgetmail);
                }
            }
            finally
            {
                /*if (myexgetmail != null)
                {
                    myexgetmail.removedicid(Username);
                }*/
                eposts.removedicmailbytime(Username);
                /*if (myexgetmail != null)
                {
                    mtxgetmail.ReleaseMutex();
                }*/
            }
        }
    }

    /// <summary>
    /// mutex threads
    /// </summary>
    /// <param name="evt1"></param>
    /// <param name="mtx1"></param>
    /// <returns></returns>
    protected int getidmutex()
    {
        Epostcollection eposts = new Epostcollection();
        ManualResetEvent evt1 = new ManualResetEvent(false);
        mtx1 = new Mutex(true);
        ThreadPool.RegisterWaitForSingleObject(evt1,
              new WaitOrTimerCallback(getmailid),
              null, Timeout.Infinite, true);

        ThreadPool.RegisterWaitForSingleObject(mtx1,
      new WaitOrTimerCallback(getblocked),
      null, Timeout.Infinite, true);
        evt1.Set();
        //ThreadPool.QueueUserWorkItem(new WaitCallback(getmailid), eposts);
        Dictionary<string, int> thedicmailid = eposts.getdicid();
        int MailId = thedicmailid[Username];
        Debug.Assert(MailId != -1, "create mailid not successfully");
        return MailId;
    }

    protected void savemailmutex(int mailid)
    {
        Epostcollection epost1 = null;
        ManualResetEvent evt2 = new ManualResetEvent(false);
        ThreadPool.RegisterWaitForSingleObject(evt2,
      new WaitOrTimerCallback(mailconstru),
      null, Timeout.Infinite, true);
        mtx2 = new Mutex(true);
        ThreadPool.RegisterWaitForSingleObject(mtx2,
      new WaitOrTimerCallback(SaveMail),
      null, Timeout.Infinite, true);
        evt2.Set();
        Epost thepost = new Epost(mailid, Session["Username"].ToString(), senderLink.Text, title.Text, chosenblogcontentPan.Value, DateTime.Now, "Not readed", Outmailpath);
        /*if (Request.QueryString["writetoanother"] != null)
        {
            receiver.Text = Session["Emailreceiver"].ToString();
        }
        Session["Emailreceiver"] = receiver.Text;*/
        sendBtn.Enabled = true;
        sendBtn.Visible = true;
        epost1.Add(thepost);
        Debug.Assert(epost1 != null, "epost1 object has not been initialized");
        //ThreadPool.QueueUserWorkItem(new WaitCallback(SaveMail), eposts1);
    }
    

    /// <summary>
    /// thread management
    /// </summary>
    /// <param name="obj"></param>
    protected void getmailbytime(Object obj)
    {
        DataTable table;
        table = ((Epostcollection)obj).GetEpostByReceiverTime(Username, Time);
        ((Epostcollection)obj).filldictinbox(Username, table);
    }

    protected void getmailbytime(Object obj, bool TimeOut)
    {
        DataTable table;
        table = ((Epostcollection)obj).GetEpostByReceiverTime(Username, Time);
        ((Epostcollection)obj).filldictinbox(Username, table);
    }

    protected void getmailid(Object obj, bool TimeOut)
    {
        int Mailid;
        Mailid = ((Epostcollection)obj).GetId();
        ((Epostcollection)obj).filldictid(Username, Mailid);
    }

    protected void getblocked(Object obj, bool TimeOut)
    {
        DataTable table;
        table = ((Favoritecollection)obj).GetBlockedUsers(Username);
        ((Favoritecollection)obj).filldictblocked(Username, table);
    }

    protected void mailconstru(Object obj, bool TimeOut)
    {
        obj = new Epostcollection(1);
    }

    protected void SaveMail(Object obj, bool TimeOut)
    {
        ((Epostcollection)obj).Save();
    }

    public void createfavoriteid(Object obj)
    {
        int Favoriteid;
        Favoriteid = ((Favoritecollection)obj).GetId();
        ((Favoritecollection)obj).filldictionaryid(Username, Favoriteid);
    }

    protected void favconstru(Object obj, bool TimeOut)
    {
        obj = new Favoritecollection(1);
    }

    public void SaveFavorite(Object obj, bool TimeOut)
    {
        ((Favoritecollection)obj).Save();
    }

    protected void updatemailtable(Object obj, bool TimeOut)
    {
        ((Epostcollection)obj).UpDateEpostinfo(updatetable);
    }
}
