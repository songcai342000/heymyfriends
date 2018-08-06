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
using System.Web.Caching;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

public partial class usercontrol_mail_fattmail : System.Web.UI.UserControl
{
    string Username;
    DateTime Time;
    DataTable updatetable;
    DataTable thetable;
    //Mutex mtx2;
    Mutex mtx1;
    /*Mutex mtx3;
    Exceptncollection myex;
    Exceptncollection myex1;*/
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        //create sqldatadependency
        //Epostcollection myeposts = null;
        Epostcollection myeposts = new Epostcollection();
        DataTable thetable = null;
        Dictionary<string, DataTable> thedictinbox = null;
        lock (myeposts)
        {
            try
            {
                //DataTable table = myeposts.GetEpostByReceiver(Session["Username"].ToString());
                if (Cache["epostinbox"] == null)
                {
                    SqlCacheDependency SqlDep = new SqlCacheDependency("Venner", "Epostinfo");
                    SqlCacheDependencyAdmin.EnableNotifications("Venner");
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getmailbyreceiver), myeposts);
                    thedictinbox = myeposts.getdicinbox();
                    thetable = thedictinbox[Username];
                    Cache.Insert("epostinbox", thetable, SqlDep);
                    Debug.Assert(SqlDep != null, "sqlcachedependency create not successfully");
                }
                else
                {
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(getmailbyreceiver), myeposts);
                    //thedictinbox = myeposts.getdicinbox();
                    //thetable = thedictinbox[Username];
                    Debug.Assert(thetable != null, "The table doesn't exist");
                }
            }
            catch (DatabaseNotEnabledForNotificationException ex)
            {
                Debug.Assert(ex == null, "databasenotenabledfornotificationexception");
            }
            catch(Exception ex)
            {
                Debug.Fail(ex.Message);
                Exceptncollection myex = new Exceptncollection();
                myex.exceptiondata(Username, ex.Message, myex);
            }
            finally
            {
                myeposts.removedictinbox(Username);
            }
        }
        if (thetable.Rows.Count >= 0)
        {
            /*Repeater1.DataSource = inboxlist.Reverse();
            Repeater1.DataBind();*/
            Repeater1.DataSource = thetable;
            Repeater1.DataBind();
        }
        

        for (int i = 0; i < thetable.Rows.Count; i++)
        {
            if (thetable.Rows[i]["Mailstatus"].ToString() == "Not readed")
            {
                ((LinkButton)(Repeater1.Items[i].FindControl("titleBtn"))).Font.Bold = true;
                ((LinkButton)(Repeater1.Items[i].FindControl("nameBtn"))).Font.Bold = true;
                ((LinkButton)(Repeater1.Items[i].FindControl("timeBtn"))).Font.Bold = true;
            }
        }

    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        //get state management value when click linkbutton respectively

        if (e.CommandName == "mailname")
        {
            Session["Epost"] = ((LinkButton)e.Item.FindControl("titleBtn")).Text;
            Session["Time"] = ((LinkButton)e.Item.FindControl("timeBtn")).Text;
            Session["Profil"] = ((LinkButton)e.Item.FindControl("nameBtn")).Text;
            ((LinkButton)(e.Item.FindControl("titleBtn"))).Font.Bold = false;
            ((LinkButton)(e.Item.FindControl("nameBtn"))).Font.Bold = false;
            ((LinkButton)(e.Item.FindControl("timeBtn"))).Font.Bold = false;
            //assign time, use later for thread methods
            Time = DateTime.Parse(Session["Time"].ToString());
            Epostcollection myeposts = new Epostcollection();
            Mutex mtx1 = new Mutex(true);
            try
            {
                ManualResetEvent evt1 = new ManualResetEvent(false);
                ThreadPool.RegisterWaitForSingleObject(evt1,
              new WaitOrTimerCallback(getmailbytime),
              null, Timeout.Infinite, true);
                Dictionary<string, DataTable> thedicmailbytime = myeposts.getdicinbox();
                ThreadPool.RegisterWaitForSingleObject(mtx1,
                   new WaitOrTimerCallback(updatemailstatus),
                   null, Timeout.Infinite, true);
                updatetable = thedicmailbytime[Username];
                //Epost updateepoststatus = new Epost(int.Parse(posttable.Rows[0][0].ToString()), posttable.Rows[0][1].ToString(), posttable.Rows[0][2].ToString(), posttable.Rows[0][3].ToString(), posttable.Rows[0][4].ToString(), DateTime.Parse(posttable.Rows[0][5].ToString()), "Read", posttable.Rows[0][7].ToString());
                updatetable.Rows[0]["Mailstatus"] = "Readed";//mark as readed
                evt1.Set();
                Debug.Assert(updatetable == null, "update feil");
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
                myeposts.removedicmailbytime(Username);
                /*if (myex != null)
                {
                    myex.removedicid(Username);
                }
                if (mtx2 != null)
                {
                    mtx2.ReleaseMutex();
                }*/
                if (mtx1 != null)
                {
                    mtx1.ReleaseMutex();
                }
            }
            if (Session["Epost"].ToString() != "Førespørelse av nøkken til din album")
            {
                Response.Redirect("/vennskap/functions/Readmailprofil.aspx?readmail={0}");
            }
            else
            {
                Response.Redirect("/vennskap/functions/Readmailprofil.aspx?grantkey={0}");
            }
        }

        if (e.CommandName == "sendername")
        {
            //get the senders name
            Session["Profil"] = ((LinkButton)e.Item.FindControl("nameBtn")).Text;
            //((LinkButton)(e.Item.FindControl("titleBtn"))).Font.Bold = false;
            //((LinkButton)(e.Item.FindControl("nameBtn"))).Font.Bold = false;
            //((LinkButton)(e.Item.FindControl("timeBtn"))).Font.Bold = false;
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofile={0}");
        }
    }
    //delete the selected mail
    protected void slettalle_Click(object sender, EventArgs e)
    {
        //Epostcollection receiverposts = new Epostcollection();
        //DataTable table = receiverposts.GetEpostByReceiver(Session["Username"].ToString());
        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            //remove the line which is checked
            if (((CheckBox)(Repeater1.Items[i].Controls[0])).Checked)
            {
                //Epost thepost = new Epost(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), table.Rows[i][4].ToString(), DateTime.Parse(table.Rows[i][5].ToString()), table.Rows[i][6].ToString(), table.Rows[i][7].ToString());
                thetable.Rows.Remove(thetable.Rows[i]);
            }
        }
        //save change to database
        updatetable = thetable;//assign updatetable as thetable
        Epostcollection myeposts = null;
        lock (myeposts)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(updatemailstatus), myeposts);
            }
            catch (Exception ex)
            {
                Exceptncollection myex1 = new Exceptncollection();
                lock (myex1)
                {
                    myex1.exceptiondata(Username, ex.Message, myex1);
                }
                //logic
            }
            /*finally
            {
                if (myex1 != null)
                {
                    myex1.removedicid(Username);
                }
                if (mtx3 != null)
                {
                    mtx3.ReleaseMutex();
                }
            }*/
            Debug.Assert(updatetable == null, "The updatetable is null");
        }
    }

    /// <summary>
    /// create threads
    /// </summary>
    /// <param name="obj"></param>
    protected void getmailbyreceiver(Object obj)
    {
        DataTable table;
        table = ((Epostcollection)obj).GetEpostByReceiver(Username);
        ((Epostcollection)obj).filldictinbox(Username, table);
    }

    protected void getmailbytime(Object obj, bool TimeOut)
    {
        DataTable table;
        table = ((Epostcollection)obj).GetEpostByReceiverTime(Username, Time);
        ((Epostcollection)obj).filldictinbox(Username, table);
    }

    protected void updatemailstatus(Object obj, bool TimeOut)
    {
        ((Epostcollection)obj).UpDateEpostinfo(updatetable);
    }

    protected void updatemailstatus(Object obj)
    {
        ((Epostcollection)obj).UpDateEpostinfo(updatetable);
    }
}
