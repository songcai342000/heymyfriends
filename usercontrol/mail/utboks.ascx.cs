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
using System.Collections.Generic;
using vennobjects;
using System.IO;
using System.Web.Caching;
using System.Threading;
using System.Diagnostics;


public partial class usercontrol_mail_utboks : System.Web.UI.UserControl
{
    string Username;
     //used in two functions
    DataTable updatetable;
    DataTable thetable;
    /*Exceptncollection myexoutmail;
    Exceptncollection myexdelete;
    Mutex mtxoutmail;
    Mutex mtxdelete;*/
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        //get outmails
        Epostcollection maillist = new Epostcollection();
        Dictionary<string, DataTable> thedicoutmail = null;
        DataTable thetable = null;
        lock (maillist)
        {
            try
            {
                //create cache
                if (Cache["epostutbox"] == null)
                {
                    SqlCacheDependency SqlDp = new SqlCacheDependency("Venner", "Epostinfo");
                    SqlCacheDependencyAdmin.EnableNotifications("Venner");
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getoutbox), maillist);
                    thedicoutmail = maillist.getdicoutmail();
                    thetable = thedicoutmail[Username];
                    Cache.Insert("epostutbox", thetable, SqlDp);
                    Debug.Assert(SqlDp != null, "no cachedependency created");
                }
                else
                {
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(getoutbox), maillist);
                    //thedicoutmail = maillist.getdicoutmail();
                    //thetable = thedicoutmail[Username];
                    Debug.Assert(thetable.Rows.Count > 0, "thetable is empty");
                }
            }
            catch (DatabaseNotEnabledForNotificationException ex)
            {
                //logic
            }
            catch (Exception ex)
            {
                Exceptncollection myexoutmail = new Exceptncollection();
                myexoutmail.exceptiondata(Username, ex.Message, myexoutmail);
            }
            finally
            {
                /*lock (myexoutmail)
                {
                    if (myexoutmail != null)
                    {
                        myexoutmail.removedicid(Username);
                    }
                }
                if (mtxoutmail != null)
                {
                    mtxoutmail.ReleaseMutex();
                }*/
                maillist.removedicoutmail(Username);
            }
        }
        /*if (myoutbox != null)
        {
            Repeater1.DataSource = myoutbox;
            Repeater1.DataBind();
        }*/

        Repeater1.DataSource = thetable;
        Repeater1.DataBind();
    }

    protected void slettalle_Click(object sender, EventArgs e)
    {
        //Epostcollection epostcollection = new Epostcollection(Username);
        //Epostcollection theposts = null;

        //DataTable table = theposts.GetEpostBySender(Username);
        for(int i = 0; i < Repeater1.Items.Count; i++)
        {
            //remove the line which is checked
            if (((CheckBox)(Repeater1.Items[i].Controls[0])).Checked)
            {
                //Epost thepost = new Epost(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), table.Rows[i][4].ToString(), DateTime.Parse(table.Rows[i][5].ToString()), table.Rows[i][6].ToString(), table.Rows[i][7].ToString());
                //epostcollection.Delete(thepost);
                thetable.Rows.Remove(thetable.Rows[i]);
            }
        }
        //save change to database
        Epostcollection maillist = new Epostcollection();
        lock (maillist)
        {
            updatetable = thetable;
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(updatemailtable), maillist);
                Debug.Assert(updatetable.Rows.Count > 0, "update is not successful");
            }
            catch (Exception ex)
            {
                //logic
                Exceptncollection myexdelete = new Exceptncollection();
                myexdelete.exceptiondata(Username, ex.Message, myexdelete);
            }
            /*finally
            {
                if (myexdelete != null)
                {
                    myexdelete.removedicid(Username);
                }
                if (mtxdelete != null)
                {
                    mtxdelete.ReleaseMutex();
                }
            }*/
        }

    }

    //read mail or profile from the outbox
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "mailtitle")
        {
            Session["Epost"] = ((LinkButton)e.Item.FindControl("titleBtn")).Text;
            Session["Profil"] = ((LinkButton)e.Item.FindControl("nameBtn")).Text;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?readmail={0}");

        }
        else if (e.CommandName == "mailreceiver")
        {
            Session["Profil"] = ((LinkButton)e.Item.FindControl("nameBtn")).Text;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?readprofile={0}");
        }
    }

    /// <summary>
    /// thread
    /// </summary>
    /// <param name="obj"></param>
    protected void getoutbox(Object obj)
    {
        DataTable table;
        table = ((Epostcollection)obj).GetEpostBySender(Username);
        ((Epostcollection)obj).filldictinbox(Username, table);
    }

    protected void updatemailtable(Object obj)
    {
        ((Epostcollection)obj).UpDateEpostinfo(updatetable);
    }
}
