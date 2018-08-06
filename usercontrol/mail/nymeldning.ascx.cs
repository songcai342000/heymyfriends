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

public partial class usercontrol_mail_nymeldning : System.Web.UI.UserControl
{
    string Username;
    Epostcollection eposts;
    Epostcollection epost1;
    Favoritecollection blockedusers;
    //Exceptncollection myexblock;
    //Mutex mtxblock;
    Epost thepost;
    Mutex mtx1;
    Mutex mtx2;
    Dictionary<string, DataTable> thedicblocked;
    DataTable theblockedusers;

    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        //load gift picture by different gender
        if (Profile.GetProfile(Username).General.Gender == "Kvinne")
        {
            ImageButton1.ImageUrl = "/vennskap/images/rosegift.jpg";
            ImageButton1.ToolTip = "En rose";
        }
        else 
        {
            ImageButton1.ImageUrl = "/vennskap/images/cupgift.jpg";
            ImageButton1.ToolTip = "En kupp";
        }
    }
    private string picturepath;
    public string Picturepath
    {
        get 
        {
            return picturepath;
        }
        set 
        {
            picturepath = value;
        }
    }
    //send mail
    protected void send2_Click(object sender, EventArgs e)
    {
        //check if the user has valid order
        if ((Profile.GetProfile(Username).General.Validorder.CompareTo(DateTime.Now) < 0))
        {
            try
            {
                int MailId = getidmutex();
                Debug.Assert(MailId != -1, "MailId has not been created successfully");
                if (MailId != -1)
                {
                    /*string Mailpath = @"C:\Users\mhelenem\Documents\Visual Studio 2008\Websites\vennskaper\Mails\" + MailId.ToString() + ".txt";
                    using (StreamWriter sw = new StreamWriter(Mailpath))
                    {
                        //write mail content to a text file
                        sw.Write(messagetext.Text);
                    }*/
                    //get blocked users of mail receiver
                    thedicblocked = blockedusers.getdicblocked();
                    theblockedusers = thedicblocked[Username];
                    Debug.Assert(theblockedusers.Rows.Count > 0, "no user has been blocked");
                    //mtx1.ReleaseMutex();
                    if (!(theblockedusers.Rows.Contains(Username)))
                    {
                        savemailmutex(MailId);
                    }
                }
                else
                {
                    //mtx1.ReleaseMutex();
                    Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
                }
            }
            catch(Exception ex)
            {
                Exceptncollection myexblock = new Exceptncollection();
                lock (myexblock)
                {
                    myexblock.exceptiondata(Username, ex.Message, myexblock);
                }
                Response.Redirect("~/functions/Profilopprettet.aspx?newmailfeil={0}");
            }
            finally
            {
                /*lock (myexblock)
                {
                    if (myexblock != null)
                    {
                        myexblock.removedicid(Username);
                    }
                }
                if (mtxblock != null)
                {
                    mtxblock.ReleaseMutex();
                }*/
                lock (eposts)
                {
                    eposts.removedictid(Username);
                }
                blockedusers.removedictblocked(Username);
                Debug.Assert(mtx1 != null, "mtx1 is not null");
                Debug.Assert(mtx2 != null, "mtx2 is not null");
                if (mtx1 != null)
                {
                    mtx1.ReleaseMutex();
                }
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        picturepath = ImageButton1.ImageUrl;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        picturepath = ImageButton2.ImageUrl;
    }

    protected int getidmutex()
    {
        eposts = new Epostcollection();
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
        ManualResetEvent evt2 = new ManualResetEvent(false);
        ThreadPool.RegisterWaitForSingleObject(evt2,
      new WaitOrTimerCallback(mailconstru),
      null, Timeout.Infinite, true);
        mtx2 = new Mutex(true);
        ThreadPool.RegisterWaitForSingleObject(mtx2,
      new WaitOrTimerCallback(SaveMail),
      null, Timeout.Infinite, true);
        evt2.Set();
        thepost = new Epost(mailid, Username, receiver.Text, mailtitle.Text, messagetext.Value, DateTime.Now, "Not readed", Picturepath);
        if (Request.QueryString["writetoanother"] != null)
        {
            receiver.Text = Session["Emailreceiver"].ToString();
        }
        Session["Emailreceiver"] = receiver.Text;
        //add to database
        //Epostcollection eposts1 = new Epostcollection(Session["Username"].ToString());
        //Epostcollection eposts1 = new Epostcollection(1);
        epost1.Add(thepost);
        Debug.Assert(epost1 != null, "epost1 is null");
        //ThreadPool.QueueUserWorkItem(new WaitCallback(SaveMail), eposts1);
    }

    /// <summary>
    /// thread management
    /// </summary>
    /// <param name="obj"></param>
    protected void getmailid(Object obj, bool TimeOut)
    {
        int Mailid;
        Mailid = ((Epostcollection)obj).GetId();
        ((Epostcollection)obj).filldictid(Username, Mailid);
    }

    protected void mailconstru(Object obj, bool TimeOut)
    {
        obj = new Epostcollection(1);
    }

    protected void SaveMail(Object obj, bool TimeOut)
    {
        ((Epostcollection)obj).Save();
    }

   
    protected void getblocked(Object obj, bool TimeOut)
    {
        DataTable table;
        table = ((Favoritecollection)obj).GetBlockedUsers(Username);
        ((Favoritecollection)obj).filldictblocked(Username, table);
    }
}
