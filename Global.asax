<%@ Application Language="C#" %>
<%@ Import Namespace="vennobjects" %>


<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
         //System.Data.SqlClient.SqlDependency.Start("Data Source=localhost;Initial Catalog=Venner;Integrated Security=True");
        Application["sitevisitornum"] = 0;
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        //System.Data.SqlClient.SqlDependency.Stop("Data Source=localhost;Initial Catalog=Venner;Integrated Security=True");
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //get username
        Adminassign adminass = new Adminassign();
        int num = adminass.changetrafic(int.Parse(Application["sitevisitornum"].ToString()) + 1);
        Application["sitevisitornum"] = num;
        Session["Username"] = Application["Sitevisitornum"].ToString();
        //Session["Username"] = "";
        // Code that runs when a new session is started
        Session["abonnement"] = 0;
        Session["Profil"] = "";
        Session["Epost"] = "";
        Session["loadthecontrol"] = "";
        
        
        //Session["topiclink"] = "";
        //Session["relationlink"] = "";
        //Session["activitylink"] = "";
        //Session["otherlink"] = "";
        Session["sort"] = "";
        
        
        //Session["sortlink"] = ""; lastopp blog side, no need
        Session["favoritetype"] = "";
        Session["chosensortedblog"] = "";
        //Session["chosenblogpath"] = "";        
        //Session["selectedblogcontent1"] = "";  
        
              
        Session["bloguser"] = "";
        Session["province"] = "";
        Session["city"] = "";
        Session["provinceList"] = "";
        Session["Emailreceiver"] = "";
        Session["PictureId"] = 0;
        Session["Min"] = 0;
        Session["Max"] = 0;
        Session["Album"] = "";
        Session["Blog"] = "";
        Session["iamfavorite"] = "";
        //Session["recommand1"] = "";
        //Session["recommand2"] = "";
        //Session["recommand3"] = "";
        //Session["recommand1title"] = "";
        //Session["recommand2title"] = "";
        //Session["recommand3title"] = "";
        //Session["tematitle"] = "";
        //Session["selectedblogcontent2"] = "";
        
        
        Session["keyword"] = "";
        Session["searchword"] = "";
        //Session["allprofile"] = "";
        Session["profilepicture"] = "";
        Session["profilealbum"] = "";
        Session["profileblog"] = "";
        Session["selectedmembershipstart"] = "";
        Session["selectedprovince"] = "";
        Session["selectedgender"] = "";
        Session["profilesearch"] = "";
        //define different type of blog, f.ex topic, relation
        //Session["sort"] = ""; lastopp blog side, no need to use
        //Session["man1"] = "";
        //Session["man2"] = "";
        //Session["man3"] = "";
        //Session["lady1"] = "";
        //Session["lady2"] = "";
        //Session["lady3"] = "";
        //out mails before they are saved in database
        Session["outmail"] = null;
        //blogtitle of last opp blog. used for reading a blog
        Session["blogtitle"] = "";
        //count my blogs
        Session["myblogcount"] = "";
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        //Session["Username"] = "";
    }
       
</script>
