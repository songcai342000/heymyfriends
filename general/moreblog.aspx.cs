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
using System.Diagnostics;
using System.Threading;

public partial class general_moreblog : System.Web.UI.Page
{
    string Bloguser;
    string Username;
    string Title;
    DataTable searchedblogs;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        if (Request.QueryString["blogusernamesearch"] != null)
        {
            Blogcollection blogs = new Blogcollection();
            Dictionary<string, DataTable> thedicbyuser = null;
            Bloguser = Session["keyword"].ToString();
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyuser), blogs);
                    thedicbyuser = blogs.getdictionarybyuser();
                    searchedblogs = thedicbyuser[Username];
                    Debug.Assert(searchedblogs != null, "blogs table searched by writter is null");
                }
                catch
                {

                }
                finally
                {
                    blogs.removedictionarybyuser(Username);
                }
            }

        }
        else if (Request.QueryString["profileblogsearch"] != null)
        {
            Blogcollection blogs = new Blogcollection();
            Dictionary<string, DataTable> thedicbyuser = null;
            Bloguser = Session["Profil"].ToString();
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbyuser), blogs);
                    thedicbyuser = blogs.getdictionarybyuser();
                    searchedblogs = thedicbyuser[Username];
                    Debug.Assert(searchedblogs != null, "blogs table searched by writter is null");
                }
                catch
                {

                }
                finally
                {
                    blogs.removedictionarybyuser(Username);
                }
            }
        }
        else if (Request.QueryString["searchsimiliarprofile"] != null)
        {
            //use epost data to find usernames similiar with the key word
        }
        else if (Request.QueryString["blogtitlesearch"] != null)
        {
            Title = Session["keyword"].ToString();
            Blogcollection blogs = new Blogcollection();
            Dictionary<string, DataTable> thedicbytitle = null;
            lock (blogs)
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(getbytitle), blogs);
                    thedicbytitle = blogs.getdicbytitle();
                    searchedblogs = thedicbytitle[Username];
                }
                catch
                {

                }
                finally
                {
                    blogs.removedicbytitle(Username);
                }
            }
        }
        else if (Request.QueryString["contentsortedblog"] != null)
        {
            Blogcollection blogs = new Blogcollection();
            //searchedblogs = blogs.GetByBlogcategory(Session["sort"].ToString());
            if (Session["sort"].ToString() == "relation")
            {
                searchedblogs = Blogcollection.relationlist;
            }
            else if (Session["sort"].ToString() == "activity")
            {
                searchedblogs = Blogcollection.activitylist;
            }
            else if (Session["sort"].ToString() == "other")
            {
                searchedblogs = Blogcollection.otherlist;
            }
        }
        else if (Request.QueryString["writter"] != null)
        {
            Blogcollection blogs = new Blogcollection();
            Dictionary<string, DataTable> thedicbyuser = null;
            DataTable searchedblogs = null;
            lock (blogs)
            {
                try
                {
                    searchedblogs = blogs.GetByUsername(Session["bloguser"].ToString());
                    thedicbyuser = blogs.getdictionarybyuser();
                    searchedblogs = thedicbyuser[Username];
                    Debug.Assert(searchedblogs != null, "blogs table searched by writter is null");
                }
                catch
                {

                }
                finally
                {
                    blogs.removedictionarybyuser(Username);
                }
            }
        }
        else if (Request.QueryString["newblog"] != null)
        {
            Blogcollection blogs = new Blogcollection();
            searchedblogs = Blogcollection.newbloglist;
        }
        /*else if (Request.QueryString["relation"] != null)
        {
            Blogcollection blogs = new Blogcollection();
            searchedblogs = blogs.GetByBlogcategory("relation");
        }
        else if (Request.QueryString["other"] != null)
        {
            Blogcollection blogs = new Blogcollection();
            searchedblogs = blogs.GetByBlogcategory("other");
        }
        else if (Request.QueryString["activity"] != null)
        {
            Blogcollection blogs = new Blogcollection();
            searchedblogs = blogs.GetByBlogcategory("activity");
        }*/
        //get paging of repeater
        //ViewState["CurrentPage"] = null;
        
       
        //add previouspage nextpage symptom and event
        if (searchedblogs != null)
        {
            if (CurrentPage == "")
            {
                //DataTable currentTable = ItemsGet(1);
                DataTable currentList = ItemsGet("1");
                CurrentPage = "1";
                moreblogs.DataSource = currentList;
                moreblogs.DataBind();
                if (searchedblogs.Rows.Count % 2 > 0)
                {
                    LinkButton previousBtn = new LinkButton();
                    previousBtn.Text = "PreviousPage";
                    previousBtn.Click += new EventHandler(cmdPrev_Click);
                    pagePan.Controls.Add(previousBtn);
                    pagePan.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                }
                for (int i = 0; i < ((searchedblogs.Rows.Count % 2) + 1); i++)
                {
                    LinkButton pageLBtn = new LinkButton();
                    pageLBtn.Text = (i + 1).ToString();
                    //CurrentPage = pageLBtn.Text;
                    pageLBtn.CommandName = (i + 1).ToString();
                    pageLBtn.Command += new CommandEventHandler(pageLBtn_Click);
                    pagePan.Controls.Add(pageLBtn);
                    pagePan.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                }
                if (searchedblogs.Rows.Count % 2 > 0)
                {
                    LinkButton nextBtn = new LinkButton();
                    nextBtn.Text = "NextPage";
                    nextBtn.Click += new EventHandler(cmdNext_Click);
                    pagePan.Controls.Add(nextBtn);
                }
            }
            else
            {
                DataTable currentList = ItemsGet(CurrentPage);
                moreblogs.DataSource = currentList;
                moreblogs.DataBind();
            }
        }
        else
        {
            Response.Redirect("/vennskap/general/Hjelp.aspx?Noblogfound={0}");
        }
    }

    //event when LinkButton for page number is clicked
    /*protected void pageLBtn_Click(object source, EventArgs e)
    {
        DataTable pagetable = ItemsGet(CurrentPage);
        ViewState["CurrentPage"] = CurrentPage;
        moreblogs.DataSource = pagetable;
        moreblogs.DataBind();
    }*/

    protected void moreblogs_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        //read blog
        if (e.CommandName == "blogtitleearlierCN")
        {
            string blogtitle = ((LinkButton)e.Item.FindControl("blogtitleearlier")).Text;
            string writter = ((LinkButton)e.Item.FindControl("blogwritter")).Text;
            Session["Blog"] = blogtitle;
            Session["bloguser"] = writter;
            Blogcollection blogs = new Blogcollection();
            DataTable theblogtable = blogs.GetBlogByUserTitle(writter, blogtitle);
            if (theblogtable.Rows.Count > 0)
            {
                Session["chosenblogpath"] = theblogtable.Rows[0][0].ToString();
                Response.Redirect("/vennskap/functions/Blogtarget.aspx?readblog={0}");
            }
       
        }
        //read profile
        if (e.CommandName == "writterprofileCN")
        {
            Session["Profil"] = ((LinkButton)e.Item.FindControl("blogwritter")).Text;
            //string x = Session["Profil"].ToString();
            Response.Redirect("/vennskap/functions/Readmailprofil.aspx?annenprofile={0}");

        }
    }

   /// <summary>
   /// repeater paging
   /// </summary>

    //event when LinkButton for page number is clicked
    protected void pageLBtn_Click(object source, CommandEventArgs e)
    {
        //ViewState["CurrentPage"] = CurrentPage;
        CurrentPage = e.CommandName;
        DataTable pagelist = ItemsGet(CurrentPage);
        moreblogs.DataSource = pagelist;
        moreblogs.DataBind();
    }

    //current page for repeater
    /*private string currentpage;
    public string CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
            {
                currentpage = "1";
            }
            else
            {
                currentpage = ViewState["CurrentPage"].ToString();
            }
            return currentpage;
        }
        set
        {
            currentpage = value;
        }
    }*/

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
        return this.searchedblogs;
    }

    protected override void LoadControlState(object savedState)
    {
        if (savedState != null)
        {
            searchedblogs = (DataTable)savedState;
        }
    }

    private void cmdPrev_Click(object sender, EventArgs e)
    {
        // Set viewstate variable as the previous page
        //ViewState["CurrentPage"] = (int.Parse(CurrentPage) - 1).ToString();
        CurrentPage = (int.Parse(CurrentPage) - 1).ToString();
        if (int.Parse(CurrentPage) > 0 && int.Parse(CurrentPage) <= (searchedblogs.Rows.Count % 2) + 1)
        {
            DataTable pagelist = ItemsGet(CurrentPage);
            moreblogs.DataSource = pagelist;
            moreblogs.DataBind();
        }
    }

    //next page
    private void cmdNext_Click(object sender, EventArgs e)
    {
        // Set viewstate variable as the next page
        //ViewState["CurrentPage"] = (int.Parse(CurrentPage) + 1).ToString();
        CurrentPage = (int.Parse(CurrentPage) + 1).ToString();
        if (int.Parse(CurrentPage) > 0 && int.Parse(CurrentPage) <= (searchedblogs.Rows.Count % 2) + 1)
        {
            DataTable pagelist = ItemsGet(CurrentPage);
            moreblogs.DataSource = pagelist;
            moreblogs.DataBind();
        }
    }

    //get items of each page
    private DataTable ItemsGet(string pagenumber)
    {
        //List<userselectedparameters> pageusers = new List<userselectedparameters>();
        //for (int i = int.Parse(pagenumber + "0"); i < int.Parse(pagenumber + "0") + 1; i++)
        DataTable currentTable = searchedblogs.Clone();
        for (int i = 0; i <= 20; i++)
        {
            if (searchedblogs.Rows.Count > int.Parse(pagenumber.ToString() + i.ToString()))
            {
                currentTable.ImportRow(searchedblogs.Rows[int.Parse(pagenumber.ToString() + i.ToString())]);
            }
            else if (searchedblogs.Rows.Count > i)
            {
                currentTable.ImportRow(searchedblogs.Rows[i]);
            }
            else
            {
                break;
            }
        }
        return currentTable;
    }

   /*protected override void OnInit(EventArgs e)
   {
      base.OnInit(e);
      moreblogs.ItemCommand +=
         new RepeaterCommandEventHandler(moreblogs_ItemCommand);
   }*/

    /*protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       LoadData();
    }
    private void LoadData()
    {
       SqlConnection cn = new SqlConnection("your connection goes
                                             here");
       cn.Open();
       SqlDataAdapter da = new SqlDataAdapter("your query goes
                                               here", cn);
       DataTable dt = new DataTable();
       da.Fill(dt);
       cn.Close();
       PagedDataSource pgitems = new PagedDataSource();
       DataView dv = new DataView(dt);
       pgitems.DataSource = dv;
       pgitems.AllowPaging = true;
       pgitems.PageSize = 25;
       pgitems.CurrentPageIndex = PageNumber;
       if (pgitems.PageCount > 1)
       {
          rptPages.Visible = true;
          ArrayList pages = new ArrayList();
          for (int i = 0; i < pgitems.PageCount; i++)
          pages.Add((i + 1).ToString());
          rptPages.DataSource = pages;
          rptPages.DataBind();
       }
       else
          rptPages.Visible = false;
       rptItems.DataSource = pgitems;
       rptItems.DataBind();
    }
    void rptPages_ItemCommand(object source,
                              RepeaterCommandEventArgs e)
    {
       PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
       LoadData();
    }*/

    protected void getbyuser(object obj)
    {
        DataTable table = ((Blogcollection)obj).GetByUsername(Bloguser);
        ((Blogcollection)obj).filldictionarybyuser(Username, table);
    }

    protected void getbytitle(object obj)
    {
        DataTable table = ((Blogcollection)obj).GetBlogByTitle(Title);
        ((Blogcollection)obj).filldictionarybyuser(Username, table);
    }
   
}
