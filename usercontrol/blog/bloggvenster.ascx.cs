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

public partial class usercontrol_Blog_blogvenster : System.Web.UI.UserControl
{
    string Username;
    string Profilename;
    string Blogtitle;
    /*Exceptncollection myex1;
    Exceptncollection myex2;
    Exceptncollection myex3;
    Mutex mymtx1;
    Mutex mymtx2;
    Mutex mymtx3;*/
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        //get data for popular list and new list
        //Blogcollection thecollection = new Blogcollection();
        /*popularblog.DataSource = thecollection.getpopularlist();
        popularblog.DataBind();
        newbloglist.DataSource = thecollection.getnewlist();
        newbloglist.DataBind();*/
        //DataTable table = thecollection.Popularbloglist();
        DataTable popularblogs = Blogcollection.popularbloglist;
        Debug.Assert(popularblog != null, "pupularblog table is null");
        if (popularblog != null)
        {
            popularblog.DataSource = popularblogs;
            popularblog.DataBind();
        }
        DataTable newblogs = Blogcollection.newbloglist;
        //Debug.Assert(newblogs != null, "new blog table is null");
        if (newblogs != null)
        {
            newbloglist.DataSource = newblogs;
            newbloglist.DataBind();
        }
    }
    protected void clicktellblog_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "clicktellblogtitle")
        {
            //no cache dependency created
            Profilename = ((LinkButton)e.Item.FindControl("clicktellWritterBtn")).Text;
            Blogtitle = ((LinkButton)e.Item.FindControl("clicktellTitleBtn")).Text;
            //Blogcollection myblogs = null;
            //DataTable blogtablevalue;
            Blogcollection blogs = new Blogcollection();
            DataTable blogtable = null;
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusertitle), blogs);
                    Dictionary<string, DataTable> thedictbyusertitle = blogs.getdictionarybyusertitle();
                    blogtable = thedictbyusertitle[Username];
                    Debug.Assert(blogtable != null, "getuserbytitle table is null");
                }
                catch(Exception ex)
                {
                    Exceptncollection myex1 = new Exceptncollection();
                    myex1.exceptiondata(Username, ex.Message, myex1);
                }
                finally
                {
                    /*if (myex1 != null)
                    {
                        myex1.removedicid(Username);
                    }
                    if (mymtx1 != null)
                    {
                        mymtx1.ReleaseMutex();
                    }*/
                    blogs.removedictionaryblog(Username);
                }
            }
            if (blogtable.Rows.Count > 0)
            {
                Session["chosenblogpath"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            Response.Redirect("/vennskap/general/Blogtarget.aspx");
        }
    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        Session["keyword"] = searchTxt.Text;
        if(searchRadioBtn.SelectedValue.ToString() == "Søke etter brukernavn")
        {
            Response.Redirect("/vennskap/general/moreblog.aspx?blogusernamesearch={0}");
        }
        else
        {
            Response.Redirect("/vennskap/general/moreblog.aspx?blogtitlesearch={0}");
        }        
    }

    protected void newbloglist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "newblogtitle")
        {
            Profilename = ((LinkButton)e.Item.FindControl("newblogUserBtn")).Text;
            Blogtitle = ((LinkButton)e.Item.FindControl("newblogTitleBtn")).Text;
            //Blogcollection myblogs = null;
            //DataTable blogtablevalue;
            Blogcollection blogs = new Blogcollection();
            Dictionary<string, DataTable> thedictbyusertitle = new Dictionary<string, DataTable>();
            DataTable blogtable = null;
            
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusertitle), blogs);
                    thedictbyusertitle = blogs.getdictionarybyusertitle();
                    blogtable = thedictbyusertitle[Username];
                    if (blogtable.Rows.Count > 0)
                    {
                        Session["chosenblogpath"] = blogtable.Rows[0]["Blogpath"].ToString();
                    }
                }
                catch(Exception ex)
                {
                    //logic
                    Exceptncollection myex2 = new Exceptncollection();
                    myex2.exceptiondata(Username, ex.Message, myex2);
                }
                finally
                {
                    /*if (myex2 != null)
                    {
                        myex2.removedicid(Username);
                    }
                    if (mymtx2 != null)
                    {
                        mymtx2.ReleaseMutex();
                    }*/
                    thedictbyusertitle.Remove(Username);
                }
            }
            Response.Redirect("/vennskap/general/Blogtarget.aspx?newblog={0}");
        }
        if (e.CommandName == "newbloguser")
        {
            Session["Profil"] = ((LinkButton)e.Item.FindControl("newblogUserBtn")).Text;
            //string Blogtitle = ((LinkButton)e.Item.FindControl("popularblogTitleBtn")).Text;
            /*Blogcollection myblogs = new Blogcollection();
            DataTable blogtable = myblogs.GetByBlogTitleUser(Username, Blogtitle);
            if (blogtable.Rows.Count > 0)
            {
                Session["chosenblogpath"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            Response.Redirect("/vennskap/general/Blogtarget.aspx?popularblog={0}");*/
            Response.Redirect("/vennskap/funtions/Readmailprofil.aspx?annenprofile={0}");

        }
    }
    protected void searchRadioBtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["searchword"] = searchRadioBtn.SelectedValue;
    }

    //read popular blogs
    protected void popularblog_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "popularblogtitle")
        {
            Profilename = ((LinkButton)e.Item.FindControl("popularblogUserBtn")).Text;
            Blogtitle = ((LinkButton)e.Item.FindControl("popularblogTitleBtn")).Text;
            //Blogcollection myblogs = null;
            //DataTable blogtablevalue;
            Blogcollection blogs = new Blogcollection();
            DataTable blogtable = new DataTable();
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyusertitle), "blogs");
                    Dictionary<string, DataTable> thedictbyusertitle = blogs.getdictionarybyusertitle();
                    blogtable = thedictbyusertitle[Username];
                    if (blogtable.Rows.Count > 0)
                    {
                        Session["chosenblogpath"] = blogtable.Rows[0]["Blogpath"].ToString();
                    }
                }
                catch(Exception ex)
                {
                    //logic
                    Exceptncollection myex3 = new Exceptncollection();
                    myex3.exceptiondata(Username, ex.Message, myex3);
                }
                finally
                {
                    /*if (myex3 != null)
                    {
                        myex3.removedicid(Username);
                    }
                    if (mymtx3 != null)
                    {
                        mymtx3.ReleaseMutex();
                    }*/
                    blogs.removedictionarybyusertitle(Username);
                }
            }
            Response.Redirect("/vennskap/general/Blogtarget.aspx?popularblog={0}");
        }
        if (e.CommandName == "popularbloguser")
        {
            Session["Profil"] = ((LinkButton)e.Item.FindControl("popularblogUserBtn")).Text;
            //string Blogtitle = ((LinkButton)e.Item.FindControl("popularblogTitleBtn")).Text;
            /*Blogcollection myblogs = new Blogcollection();
            DataTable blogtable = myblogs.GetByBlogTitleUser(Username, Blogtitle);
            if (blogtable.Rows.Count > 0)
            {
                Session["chosenblogpath"] = blogtable.Rows[0]["Blogpath"].ToString();
            }
            Response.Redirect("/vennskap/general/Blogtarget.aspx?popularblog={0}");*/
            Response.Redirect("/vennskap/funtions/Readmailprofil.aspx?annenprofile={0}");

        }
    }
    /// <summary>
    /// call back methods for thread
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public void getbyusertitle(Object obj)
    {
        DataTable table;
        table = ((Blogcollection)obj).GetBlogByUserTitle(Profilename, Blogtitle);
        ((Blogcollection)obj).filldictionarybyusertitle(Username, table);
    }
}
