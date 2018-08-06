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
using System.Threading;
using System.IO;
using System.Net;
using System.Drawing;
using System.Diagnostics;

public partial class usercontrol_oppretterprofil : System.Web.UI.UserControl
{
    #region usercontrol 
    public Control uc;
    #endregion

    #region
    /*Exceptncollection myex1;
    Exceptncollection myex2;
    Exceptncollection myex3;
    Mutex mymtx1;
    Mutex mymtx2;
    Mutex mymtx3;*/
    string Username;
    #endregion
    #region properties
    /// <summary>
    /// get value of the profile
    /// </summary>
    
    public string Children
    {
        get
        {
            return children.SelectedValue.ToString();
        }
        set
        {
            children.SelectedValue = value;
        }
    }

    public string Province
    {
        get
        {
            return norwayFylke1.Province;
        }
        set
        {
            norwayFylke1.Province = value;
        }
    }

    private string city;
    public string City
    {
        get
        {
            return city;
        }
        set
        {
            city = value;
        }
    }

    public string Country
    {
        get
        {
            return landlist.SelectedValue.ToString();
        }
        set
        {
            landlist.SelectedValue = value;
        }
    }

    private string star;
    public string Star
    {
        get
        {
            if (321 <= int.Parse(monthlist.SelectedValue.ToString() + dob_day.SelectedValue.ToString()) && int.Parse(monthlist.SelectedValue.ToString() + dob_day.SelectedValue.ToString()) <= 420)
            {
                star = "Vædderen";
            }
            if (421 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 520)
            {
                star = "Tyren";
            }
            if (521 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 620)
            {
                star = "Tvillingerne";
            }
            if (621 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 720)
            {
                star = "Krebsen";
            }
            if (721 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 820)
            {
                star = "Løven";
            }
            if (821 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 920)
            {
                star = "Jomfruen";
            }
            if (921 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 1020)
            {
                star = "Vægten";
            }
            if (1021 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 1120)
            {
                star = "Skorpionen";
            }
            if (1121 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 1220)
            {
                star = "Skytten";
            }
            if (1221 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) || (1 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 120))
            {
                star = "Stenbukken";
            }
            if (121 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 220)
            {
                star = "Vandmanden";
            }
            if (221 <= int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) && int.Parse(monthlist.SelectedValue + dob_day.SelectedValue) <= 320)
            {
                star = "Fiskene";
            }
            return star;
        }
        set
        {
            star = value;
        }
    }

    public string Day
    {
        get
        {
            return dob_day.SelectedValue;
        }
        set
        {
            dob_day.SelectedValue = value;
        }
    }

    public string Month
    {
        get
        {
            return monthlist.SelectedValue;
        }
        set
        {
            monthlist.SelectedValue = value;
        }
    }

    private string year;
    public string Year
    {
        get
        {
            year = (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(yearlist.SelectedValue.ToString())).ToString();
            return year;
        }
        set
        {
            year = (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(yearlist.SelectedValue.ToString())).ToString();
            year = value;
        }
    }

    public string Maritalstatus
    {
        get
        {
            return sivilstand.SelectedValue.ToString();
        }
        set
        {
            sivilstand.SelectedValue = value;
        }
    }

    public string Drink
    {
        get
        {
            return drinking.SelectedValue.ToString();
        }
        set
        {
            drinking.SelectedValue = value;
        }
    }

    public string Smoke
    {
        get
        {
            return smoking.SelectedValue.ToString();
        }
        set
        {
            smoking.SelectedValue = value;
        }
    }

   
    public string Physique
    {
        get
        {
            return body.SelectedValue.ToString();
        }
        set
        {
            body.SelectedValue = value;
        }
    }

    public string Height
    {
        get
        {
            return height.SelectedValue.ToString();
        }
        set
        {
            height.SelectedValue = value;

        }
    }

  

    public string Eyecolor
    {
        get
        {
            return eyecolor.SelectedValue.ToString();
        }
        set
        {
            eyecolor.SelectedValue = value;
        }
    }

    public string Ethnicbackground
    {
        get
        {
            return  ethenic.SelectedValue.ToString();
        }
        set
        {
            ethenic.SelectedValue = value;
        }
    }

    public string Religion
    {
        get
        {
            return religion.SelectedValue.ToString();
        }
        set
        {
            religion.SelectedValue = value;
        }
    }

    public string Profession
    {
        get
        {
            return profession.SelectedValue.ToString();
        }
        set
        {
            profession.SelectedValue = value;

        }
    }

    public string Education
    {
        get
        {
            return education.SelectedValue.ToString();
        }
        set
        {
            education.SelectedValue = value;

        }
    }

    public string Language1
    {
        get
        {
            return language1.SelectedValue.ToString();
        }
        set
        {
            language1.SelectedValue = value;
        }
    }

    public string Language2
    {
        get
        {
            return language2.SelectedValue.ToString();
        }
        set
        {
            language2.SelectedValue = value;
        }
    }

    private string paymentstatus;
    public string Paymentstatus
    {
        get
        {
            return paymentstatus;
        }

        set
        {
            paymentstatus = value;
        }
    }

    private DateTime paydate;
    public DateTime Paydate
    {
        get
        {
            return paydate;
        }

        set
        {
            paydate = value;
        }
    }

    private string music;
    public string Music
    {
        get
        {
            return music;
        }
        set
        {
            music = value;
        }
    }

    public string Booktype
    {
        get
        {
            return boktype.Text;
        }
        set
        {
            boktype.Text = value;
        }
    }

    public string Sport
    {
        get
        {
            return sport.Text;
        }
        set
        {
            sport.Text = value;
        }
    }

    public string Pet
    {
        get
        {
            return dyr.Text;
        }
        set
        {
            dyr.Text = value;
        }
    }

    private string interest;
    public string Interest
    {
        get
        {
            return interest;
        }
        set
        {
            interest = value;
        }
    }

    private string expection;
    public string Expection
    {
        get
        {
            return expection;
        }
        set
        {
            expection = value;
        }

    }

    private string relationshiptype;
    public string Relationshiptype
    {
        get
        {
            return relationshiptype;
        }
        set
        {
            relationshiptype = value;
        }
    }

    public string Selvdescription
    {
        get
        {
            return seldescription.Text;
        }
        set
        {
            seldescription.Text = value;

        }
    }

    public string Haircolor
    {
        get
        {
            return haircolor.SelectedValue.ToString();
        }
        set
        {
            haircolor.SelectedValue = value;
        }
    }

    /*private string status;
    public string Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;

        }
    }*/

    private string searchage;
    public string Searchage
    {
        get
        {
            searchage = "Mellom " + min.SelectedValue + " og " + maks.SelectedValue;
            return searchage;
        }
        set
        {
            searchage = "Mellom " + min.SelectedValue + " og " + maks.SelectedValue;
            searchage = value;
        }
    }

    public string Searchgender
    {
        get
        {
            return DropDownList2.SelectedValue;
        }
        set
        {
            DropDownList2.SelectedValue = value;
        }
    }

    public string Gender
    {
        get
        {
            return genderList.SelectedValue;
        }
        set
        {
            genderList.SelectedValue = value;
        }
    }

    public string Picture
    {
        get
        {
            return profilePic.ImageUrl;
        }
        set
        {
            profilePic.ImageUrl = value;
        }
    }

    private string membershipstart;
    public string MembershipStart
    {
        get
        {
            return membershipstart;
        }
        set
        {
            membershipstart = value;
        }
    }
    #endregion

    //load eksisterte profildata
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        //myProfile = Profile.GetProfile(Session["Username"].ToString());
        try
        {
            if (!IsPostingFromMenu())
            {
                Session["city"] = Profile.General.City;
                children.SelectedValue = Profile.General.Children;
                landlist.SelectedValue = Profile.General.Country;
                norwayFylke1.Province = Profile.General.Province;
                sivilstand.SelectedValue = Profile.General.Maritalstatus;
                getprovincelist();

                drinking.SelectedValue = Profile.General.Drink;
                sivilstand.SelectedValue = Profile.General.Maritalstatus;
                smoking.SelectedValue = Profile.General.Smoke;
                //dob_day.SelectedValue = Profile.General.Star;
                //besure the yearlist get a valid value
                if (Profile.General.Year != "")
                {
                    yearlist.SelectedValue = (DateTime.Now.Year - int.Parse(Profile.General.Year)).ToString();
                }
                else
                {
                    yearlist.SelectedValue = "";
                }
                dob_day.SelectedValue = Profile.General.Day;
                monthlist.SelectedValue = Profile.General.Month;
                profilePic.ImageUrl = Profile.General.Picture;
                interestcheck();
                musiccheck();
                relationcheck();
                education.SelectedValue = Profile.Background.Education;
                ethenic.SelectedValue = Profile.Background.Ethnicbackground;
                language1.SelectedValue = Profile.Background.Language1;
                language2.SelectedValue = Profile.Background.Language2;
                profession.SelectedValue = Profile.Background.Occupation;
                religion.SelectedValue = Profile.Background.Religion;
                boktype.Text = Profile.Freetime.Booktype;
                sport.Text = Profile.Freetime.Sporttype;
                dyr.Text = Profile.Freetime.Pet;
                eyecolor.Text = Profile.Outlook.Eyecolor;
                height.SelectedValue = Profile.Outlook.Height;
                body.SelectedValue = Profile.Outlook.Physique;
                haircolor.SelectedValue = Profile.Outlook.Haircolor;
                seldescription.Text = Profile.Selvdescription;
                DropDownList2.SelectedValue = Profile.General.Searchgender;
                min.SelectedValue = Profile.General.SearchageMin;
                maks.SelectedValue = Profile.General.SearchageMax;
                genderList.SelectedValue = Profile.General.Gender;
                profilePic.ImageUrl = Profile.General.Picture;
            }
        }
        catch(Exception ex)
        {
            Exceptncollection myex1 = new Exceptncollection();
            lock (myex1)
            {
                myex1.exceptiondata(Username, ex.Message, myex1);
                //logic
            }
        }
        /*finally
        {
            lock (myex1)
            {
                if (myex1 != null)
                {
                    myex1.removedicid(Username);
                }
            }
            if (mymtx1 != null)
            {
                mymtx1.ReleaseMutex();
            }
        }*/
    }

    //opprettere/oppdatere profildata
    protected void profilBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Profile.General.Children = Children;
            Profile.General.Province = Province;
            Profile.General.Country = Country;
            if (Profile.General.Membershipstart == "")
            {
                Profile.General.Membershipstart = DateTime.Now.ToString();
            }
            //check if the city has a value than "";
            if (Session["city"].ToString() != "")
            {
                string chcity = Session["city"].ToString();
                Profile.General.City = Session["city"].ToString();
            }
            if (Session["city"].ToString() == "")
            {
                Profile.General.City = "";
            }
            Profile.General.Drink = Drink;
            Profile.General.Gender = Gender;
            Profile.General.Searchage = Searchage;
            Profile.General.Searchgender = Searchgender;
            Profile.General.Maritalstatus = Maritalstatus;
            Profile.General.Smoke = Smoke;
            Profile.General.Star = Star;
            Profile.General.Year = Year;
            Profile.General.Month = Month;
            Profile.General.Day = Day;
            //if there is profilepicture, load it, otherwise load a common picture
            if (Profile.General.Picture == "" && Profile.General.Gender == "Kvinne")
            {
                profilePic.ImageUrl = "/vennskap/images/ladypro.png";
            }
            else if (Profile.General.Picture == "" && Profile.General.Gender == "Mann")
            {
                profilePic.ImageUrl = "/vennskap/images/manpro.png";
            }
            else
            {
                //picture exists
                profilePic.ImageUrl = Picture;
            }
            Profile.General.Picture = profilePic.ImageUrl;
            string interestcollection0 = getinterest();
            //remove space
            //string interestcollection = removespace(interestcollection0);
            //remove comma at the end of string
            Profile.Interest = removecomma(interestcollection0);
            string relationcollection0 = getrelationshiptype();
            //remove space
            //string relationcollection = removespace(relationcollection0);
            //remove comma
            Profile.Relationshiptype = removecomma(relationcollection0);
            string musiccollection0 = getmusic();
            //remove space
            //string musiccollection = removespace(musiccollection0);
            //remove comma
            Profile.Freetime.Music = removecomma(musiccollection0);
            Profile.Background.Education = Education;
            Profile.Background.Ethnicbackground = Ethnicbackground;
            Profile.Background.Language1 = Language1;
            Profile.Background.Language2 = Language2;
            Profile.Background.Occupation = Profession;
            Profile.Background.Religion = Religion;
            Profile.Freetime.Booktype = Booktype;
            Profile.Freetime.Sporttype = Sport;
            Profile.Freetime.Pet = Pet;

            Profile.Outlook.Eyecolor = Eyecolor;
            Profile.Outlook.Height = Height;
            Profile.Outlook.Physique = Physique;
            Profile.Outlook.Haircolor = Haircolor;

            Profile.Selvdescription = Selvdescription;
            Profile.General.Status = "Active";

        }
        catch (ThreadAbortException ex)
        {
            Thread.ResetAbort();

        }
        catch (Exception ex)
        {
            Exceptncollection myex2 = new Exceptncollection();
            lock (myex2)
            {
                myex2.exceptiondata(Username, ex.Message, myex2);
            }
            Response.Redirect("/vennskap/functions/Profilopprettet.aspx?newprofilefeil={0}");
        }
        /*finally
        {
            lock (myex2)
            {
                if (myex2 != null)
                {
                    myex2.removedicid(Username);
                }
            }
            if (mymtx2 != null)
            {
                mymtx2.ReleaseMutex();
            }
        }*/
        Response.Redirect("/vennskap/functions/Profilopprettet.aspx?profilereceip={0}");
    }


    #region values and method for interest parameter
    /// <summary>
    /// get value of interest when checkboxes are checked
    /// </summary>
    /// <param name="sender")</param>
    /// <param name="e")</param>
    string biler = "";
    string sportinterest = "";
    string dance = "";
    string data = "";
    string film = "";
    string trim = "";
    string art = "";
    string literaturehistory = "";
    string cooking = "";
    string nature = "";
    string politic = "";
    string science = "";
    string charity = "";
    string travelling = "";
    string clubparty = "";
    string singplay = "";
    string otherinterest = "";

    public void getinterestitems()
    {
        if (bilerChk.Checked == true)
        {
            biler = "Biler/Motorsykler, ";
            
        }
        if (sportinterestChk.Checked == true)
        {
            sportinterest = "Sport, ";
            
        }
        if (dansChk.Checked == true)
        {
            dance = "Dans, ";
            
        }
        if (dataChk.Checked == true)
        {
            data = "Data/Internet, ";
            
        }
        if (filmChk.Checked == true)
        {
            film = "Film/Kino/Teater, ";
            
        }
        if (trimChk.Checked == true)
        {
            trim = "Trim, ";
            
        }
        if (kunstChk.Checked == true)
        {
            art = "Kunst/Håndverk, ";
            
        }
        if (litteratureandhistoryChk.Checked == true)
        {
            literaturehistory = "Literatur/Historie, ";
            
        }
        if (matlagingChk.Checked == true)
        {
            cooking = "Matlaging, ";
            
        }
        if (natureChk.Checked == true)
        {
            nature = "Natur, ";
            
        }
        if (politicsChk.Checked == true)
        {
            politic = "Politikk, ";
            
        }
        if (scienceinterestChk.Checked == true)
        {
            science = "Vitenskap, ";
            
        }
        if (charityinterestChk.Checked == true)
        {
            charity = "Veldedigsarbeid, ";
            
        }
        if (travellingChk.Checked == true)
        {
            travelling = "Reise, ";
            
        }
        if (klubbfestChk.Checked == true)
        {
            clubparty = "Nattklubb/Fest, ";
            
        }
        if (singingandplayingChk.Checked == true)
        {
            singplay = "Synge/Spille instrumenter, ";
            
        }
        if (annetChk.Checked == true)
        {
            otherinterest = "Annet";
            
        }
        
            //if checkbox not checked, string is empty
        if (bilerChk.Checked == false)
        {
            biler = "";
        }
        if (sportinterestChk.Checked == false)
        {
            sportinterest = "";
        }
        if (dansChk.Checked == false)
        {
            dance = "";
        }
        if (dataChk.Checked == false)
        {
            data = "";
        }
        if (filmChk.Checked == false)
        {
            film = "";
        }
        if (trimChk.Checked == false)
        {
            trim = "";
        }
        if (kunstChk.Checked == false)
        {
            art = "";
        }
        if (litteratureandhistoryChk.Checked == false)
        {
            literaturehistory = "";
        }
        if (matlagingChk.Checked == false)
        {
            cooking = "";
        }
        if (natureChk.Checked == false)
        {
            nature = "";
        }
        if (politicsChk.Checked == false)
        {
            politic = "";
        }
        if (scienceinterestChk.Checked == false)
        {
            science = "";
        }
        if (charityinterestChk.Checked == false)
        {
            charity = "";
        }
        if (travellingChk.Checked == false)
        {
            travelling = "";
        }
        if (klubbfestChk.Checked == false)
        {
            clubparty = "";
        }
        if (singingandplayingChk.Checked == false)
        {
            singplay = "";
        }
        if (annetChk.Checked == false)
        {
            otherinterest = "";
        }
    }

    //get interest result from the users choices
    public string getinterest()
    {
        getinterestitems();
        string myinterest = biler + sportinterest + dance + data + film + trim + art + literaturehistory + cooking + nature + politic + travelling + science + charity + clubparty + singplay + otherinterest;
        return myinterest;
    }

    // check if a interest type is empty
    public void interestcheck()
    {
        //get interest type data from profile
        string originalinteresttypestring1 = Profile.Interest;
        string originalinteresttypestring2 = removespace(originalinteresttypestring1);
        //tell interest types
        int interesttypecount = tellcomma(originalinteresttypestring2);
        //remove the last comma of the string
        string interesttypestring = removecomma(originalinteresttypestring2);
        string[] splitinterest = splitstr(interesttypestring, interesttypecount);
        if (splitinterest != null)
        {
            if (splitinterest.Contains("Biler/Motorsykler"))
            {
                bilerChk.Checked = true;
            }
            if (splitinterest.Contains("Sport"))
            {
                sportinterestChk.Checked = true;
            }
            if (splitinterest.Contains("Dans"))
            {
                dansChk.Checked = true;
            }
            if (splitinterest.Contains("Data/Internett"))
            {
                dataChk.Checked = true;
            }
            if (splitinterest.Contains("Film/Kino/Teater"))
            {
                filmChk.Checked = true;
            }
            if (splitinterest.Contains("Trim"))
            {
                trimChk.Checked = true;
            }
            if (splitinterest.Contains("Art"))
            {
                kunstChk.Checked = true;
            }
            if (splitinterest.Contains("Literature/history"))
            {
                litteratureandhistoryChk.Checked = true;
            }
            if (splitinterest.Contains("Matlaging"))
            {
                matlagingChk.Checked = true;
            }
            if (splitinterest.Contains("Natur"))
            {
                natureChk.Checked = true;
            }
            if (splitinterest.Contains("Politikk"))
            {
                politicsChk.Checked = true;
            }
            if (splitinterest.Contains("Vitenskap"))
            {
                scienceinterestChk.Checked = true;
            }
            if (splitinterest.Contains("Veldedighetsarbeid"))
            {
                charityinterestChk.Checked = true;
            }
            if (splitinterest.Contains("Reise"))
            {
                travellingChk.Checked = true;
            }
            if (splitinterest.Contains("Nattklubb/Fest"))
            {
                klubbfestChk.Checked = true;
            }
            if (splitinterest.Contains("Synge/Spille instrument"))
            {
                singingandplayingChk.Checked = true;
            }
            if (splitinterest.Contains("Annet"))
            {
                annetChk.Checked = true;
            }


            //if checkbox is not checked, string is empty
            if (!splitinterest.Contains("Biler/Motorsykler"))
            {
                bilerChk.Checked = false;
            }
            if (!splitinterest.Contains("Sport"))
            {
                sportinterestChk.Checked = false;
            }
            if (!splitinterest.Contains("Dans"))
            {
                dansChk.Checked = false;
            }
            if (!splitinterest.Contains("Data/Internett"))
            {
                dataChk.Checked = false;
            }
            if (!splitinterest.Contains("Film/Kino/Teater"))
            {
                filmChk.Checked = false;
            }
            if (!splitinterest.Contains("Trim"))
            {
                trimChk.Checked = false;
            }
            if (!splitinterest.Contains("Art"))
            {
                kunstChk.Checked = false;
            }
            if (!splitinterest.Contains("Literature/history"))
            {
                litteratureandhistoryChk.Checked = false;
            }
            if (!splitinterest.Contains("Matlaging"))
            {
                matlagingChk.Checked = false;
            }
            if (!splitinterest.Contains("Natur"))
            {
                natureChk.Checked = false;
            }
            if (!splitinterest.Contains("Politikk"))
            {
                politicsChk.Checked = false;
            }
            if (!splitinterest.Contains("Vitenskap"))
            {
                scienceinterestChk.Checked = false;
            }
            if (!splitinterest.Contains("Veldedighetsarbeid"))
            {
                charityinterestChk.Checked = false;
            }
            if (!splitinterest.Contains("Reise"))
            {
                travellingChk.Checked = false;
            }
            if (!splitinterest.Contains("Nattklubb/Fest"))
            {
                klubbfestChk.Checked = false;
            }
            if (!splitinterest.Contains("Synge/Spille instrument"))
            {
                singingandplayingChk.Checked = false;
            }
            if (!splitinterest.Contains("Annet"))
            {
                annetChk.Checked = false;
            }
        }
    }

#endregion
    #region values and method for relationship parameter
    /// <summary>
    /// relationship type values
    /// </summary>
    string activity = "";
    string marriage = "";
    string relationship = "";
    string travel = "";
    string romance = "";
    string friend = "";
    string acquaintance = "";

    public void getrelation()
    { 
        if (activityChk.Checked == true)
        {
            activity = "Aktivitetsvenn, ";
        }
        if (acquaintanceChk.Checked == true)
        {
            acquaintance = "Bekjenskap, ";
        }
        if (marriageChk.Checked == true)
        {
            marriage = "Ekteskap, ";
        }
        if (relationshipChk.Checked == true)
        {
            relationship = "Forhold, ";
        }
        if (travelChk.Checked == true)
        {
            travel = "Reisevenn, ";
        }
        if (romanceChk.Checked == true)
        {
            romance = "Romanse, ";
        }
        if (friendChk.Checked == true)
        {
            friend = "Vennskap";
        }

        //if check box is not checked, string is empty
        if (activityChk.Checked == false)
        {
            activity = "";
        }
        if (acquaintanceChk.Checked == false)
        {
            acquaintance = "";
        }
        if (marriageChk.Checked == false)
        {
            marriage = "";
        }
        if (relationshipChk.Checked == false)
        {
            relationship = "";
        }
        if (travelChk.Checked == false)
        {
            travel = "";
        }
        if (romanceChk.Checked == false)
        {
            romance = "";
        }
        if (friendChk.Checked == false)
        {
            friend = "";
        }
    }
    public string getrelationshiptype()
    {
        getrelation();
        string relation = activity + acquaintance + marriage + relationship + travel + romance + friend;
        return relation;
    }
   
     // check if a relationship type is empty
    public void relationcheck()
    {
        //get relation data from profile
        string originalrelationstring1 = Profile.Relationshiptype;
        string originalrelationstring2 = removespace(originalrelationstring1);
        //tell how many relationship type in the relationstring then split them
        int relationtypecount = tellcomma(originalrelationstring2);
        //remove the last comman of the string
        string relationstring = removecomma(originalrelationstring2);
        string[] splitrelationship = splitstr(relationstring, relationtypecount);
        if (splitrelationship != null)
        {
            if (splitrelationship.Contains("Aktivitetsvenn"))
            {
                activityChk.Checked = true;
            }
            if (splitrelationship.Contains("Bekjentskap"))
            {
                acquaintanceChk.Checked = true;
            }
            if (splitrelationship.Contains("Ekteskap"))
            {
                marriageChk.Checked = true;
            }
            if (splitrelationship.Contains("Forhold"))
            {
                relationshipChk.Checked = true;
            }
            if (splitrelationship.Contains("Reise"))
            {
                travelChk.Checked = true;
            }
            if (splitrelationship.Contains("Romanse"))
            {
                romanceChk.Checked = true;
            }
            if (splitrelationship.Contains("Vennskap"))
            {
                friendChk.Checked = true;
            }

            //if string object is not in string[], checkbox is not checked
            if (!splitrelationship.Contains("Aktivitetsvenn"))
            {
                activityChk.Checked = false;
            }
            if (!splitrelationship.Contains("Bekjentskap"))
            {
                acquaintanceChk.Checked = false;
            }
            if (!splitrelationship.Contains("Ekteskap"))
            {
                marriageChk.Checked = false;
            }
            if (!splitrelationship.Contains("Forhold"))
            {
                relationshipChk.Checked = false;
            }
            if (!splitrelationship.Contains("Reise"))
            {
                travelChk.Checked = false;
            }
            if (!splitrelationship.Contains("Romanse"))
            {
                romanceChk.Checked = false;
            }
            if (!splitrelationship.Contains("Vennskap"))
            {
                friendChk.Checked = false;
            }
        }
    }
    #endregion

    protected void loadpropicBtn_Click(object sender, EventArgs e)
    {
        if (loadpropic.HasFile)
        {
            try
            {
                String fileName = loadpropic.FileName;
                System.Drawing.Image theimage = Bitmap.FromFile(fileName);
                //get picturefile extension
                //string ext = Path.GetExtension(fileName);

                // Append the name of the file to upload to the path.
                string picturepath = @"C:\Users\mhelenem\Documents\Visual Studio 2008\Websites\vennskaper\images\" + Session["Username"].ToString() + ".jpg";
                getsmallimage(theimage, picturepath);
            }
            catch (Exception ex)
            {
                Exceptncollection myex3 = new Exceptncollection();
                lock (myex3)
                {
                    myex3.exceptiondata(Username, ex.Message, myex3);
                }
            }
            /*finally
            {
                lock (myex3)
                {
                    if (myex3 != null)
                    {
                        myex3.removedicid(Username);
                    }
                }
                if (mymtx3 != null)
                {
                    mymtx3.ReleaseMutex();
                }          
            }*/
            // Call the SaveAs method to save the 
            // uploaded file to the specified path.
            // This example does not perform all
            // the necessary error checking.               
            // If a file with the same name
            // already exists in the specified path,  
            // the uploaded file overwrites it.
            //loadpropic.SaveAs(picturepath);

            // Notify the user of the name of the file
            // was saved under.
            UploadStatusLabel.Text = "Profilbildet er last opp.";
            profilePic.ImageUrl = "~/images/" + Session["Username"].ToString() + ".jpg";
            Profile.General.Picture = profilePic.ImageUrl;

        }
        else
        {
            // Notify the user that a file was not uploaded.
            //UploadStatusLabel.Text = "Det finns ingen profil bilde. Venligst spesifere et bilde for din profil.";
            if (Profile.General.Picture == "" && Profile.General.Gender == "Kvinne")
            {
                profilePic.ImageUrl = "~/images/girlprofile.jpg";
            }
            else if (Profile.General.Picture == "" && Profile.General.Gender == "Mann")
            {
                profilePic.ImageUrl = "~/images/manprofile.jpg";
            }
            Profile.General.Picture = profilePic.ImageUrl;
       }
    }
    #region values and methods for music parameter
    /// <summary>
    /// music choices
    /// </summary>
    /// <param name="sender")</param>
    /// <param name="e")</param>
    string classic = "";
    string rock = "";
    string meatl = "";
    string hiphop = "";
    string folkmusic = "";
    string thechno = "";
    string newage = "";
    string celtic = "";
    string chamber = "";
    string other = "";
    string blues = "";
    string jazz = "";
    string religious = "";
    string trance = "";

    public void getmusicitems()
    {
        if (musicclassicChk.Checked == true)
        {
            classic = "Klassisk / Opera, ";
        }
        if (musicclassicChk.Checked == false)
        {
            classic = "";
        }
        if (musicrockChk.Checked == true)
        {
            rock = "Rock, ";
        }
        if (musicrockChk.Checked == false)
        {
            rock = "";
        }
        if (musicmeatlChk.Checked == true)
        {
            meatl = "meatl, ";
        }
        if (musicmeatlChk.Checked == false)
        {
            meatl = "";
        }
        if (musichiphopChk.Checked == true)
        {
            hiphop = "Hip-Hop, ";
        }
        if (musichiphopChk.Checked == false)
        {
            hiphop = "";
        }
        if (musicfolkmusicChk.Checked == true)
        {
            folkmusic = "Folkemusikk, "; 
        }
        if (musicfolkmusicChk.Checked == false)
        {
            folkmusic = "";
        }
        if (musicthechnoChk.Checked == true)
        {
            thechno = "Thechno, "; 
        }
        if (musicthechnoChk.Checked == false)
        {
            thechno = "";
        }
        if (musicbluesChk.Checked == true)
        {
            blues = "Blues, ";
        }
        if (musicbluesChk.Checked == false)
        {
            blues = "";
        }
        if (musicnewageChk.Checked == true)
        {
            newage = "New age, ";
        }
        if (musicnewageChk.Checked == false)
        {
            newage = "";
        }
        if (musiccelticChk.Checked == true)
        {
            celtic = "Keltisk, "; 
        }
        if (musiccelticChk.Checked == false)
        {
            celtic = "";
        }
        if (musicreligionChk.Checked == true)
        {
            Religion = "Religious musikk, ";
        }
        if (musicreligionChk.Checked == false)
        {
            Religion = "";
        }
        if (musicchamberChk.Checked == true)
        {
            chamber = "Kammer, ";
        }
        if (musicchamberChk.Checked == false)
        {
            chamber = "";
        }
        if (musictranceChk.Checked == true)
        {
            trance = "Trance, ";
        }
        if (musictranceChk.Checked == false)
        {
            trance = "";
        }
        if (musicjazzChk.Checked == true)
        {
            jazz = "Jazz, ";
        }
        if (musicjazzChk.Checked == false)
        {
            jazz = "";
        }
        if (musicotherChk.Checked == true)
        {
            other = "Annet";
        }
        if (musicotherChk.Checked == false)
        {
            other = "";
        }
    }
    public string getmusic()
    {
        getmusicitems();
        string music = classic + rock + meatl + hiphop + folkmusic + thechno + blues + newage + celtic + religious + chamber + other;
        return music;
    }

    //the method to chekc if a music item is empty or not
    public void musiccheck()
    {
        //get music data from profile
        string originalmusictypestring1 = Profile.Freetime.Music;
        string originalmusictypestring2 = removespace(originalmusictypestring1);
        //tell how many music in string and split
        int musictypecount = tellcomma(originalmusictypestring2);
        //remove the last comma of the sentence
        string musictypestring = removecomma(originalmusictypestring2);
        string[] splitmusic;
        splitmusic = splitstr(musictypestring, musictypecount);
        if (splitmusic != null)
        {
            if (splitmusic.Contains("Klassisk"))
            {
                musicclassicChk.Checked = true;
            }
            if (!splitmusic.Contains("Klassisk"))
            {
                musicclassicChk.Checked = false;
            }
            if (splitmusic.Contains("Rock"))
            {
                musicrockChk.Checked = true;
            }
            if (!splitmusic.Contains("Rock"))
            {
                musicrockChk.Checked = false;
            }
            if (splitmusic.Contains("meatl"))
            {
                musicmeatlChk.Checked = true;
            }
            if (!splitmusic.Contains("meatl"))
            {
                musicmeatlChk.Checked = false;
            }
            if (splitmusic.Contains("Hiphop"))
            {
                musichiphopChk.Checked = true;
            }
            if (!splitmusic.Contains("Hiphop"))
            {
                musichiphopChk.Checked = false;
            }
            if (splitmusic.Contains("Folkmusic"))
            {
                musicfolkmusicChk.Checked = true;
            }
            if (!splitmusic.Contains("Folkmusic"))
            {
                musicfolkmusicChk.Checked = false;
            }
            if (splitmusic.Contains("Thechno"))
            {
                musicthechnoChk.Checked = true;
            }
            if (!splitmusic.Contains("Thechno"))
            {
                musicthechnoChk.Checked = false;
            }
            if (splitmusic.Contains("Blues"))
            {
                musicbluesChk.Checked = true;
            }
            if (!splitmusic.Contains("Blues"))
            {
                musicbluesChk.Checked = false;
            }
            if (splitmusic.Contains("Newage"))
            {
                musicnewageChk.Checked = true;
            }
            if (!splitmusic.Contains("Newage"))
            {
                musicnewageChk.Checked = false;
            }
            if (splitmusic.Contains("Keltisk"))
            {
                musiccelticChk.Checked = true;
            }
            if (!splitmusic.Contains("Keltisk"))
            {
                musiccelticChk.Checked = false;
            }
            if (splitmusic.Contains("Religious musikk"))
            {
                musicreligionChk.Checked = true;
            }
            if (!splitmusic.Contains("Religious musikk"))
            {
                musicreligionChk.Checked = false;
            }
            if (splitmusic.Contains("Kammer"))
            {
                musicchamberChk.Checked = true;
            }
            if (!splitmusic.Contains("Kammer"))
            {
                musicchamberChk.Checked = false;
            }
            if (splitmusic.Contains("Trance"))
            {
                musicchamberChk.Checked = true;
            }
            if (!splitmusic.Contains("Trance"))
            {
                musicchamberChk.Checked = false;
            }
            if (splitmusic.Contains("Jazz"))
            {
                musicjazzChk.Checked = true;
            }
            if (!splitmusic.Contains("Jazz"))
            {
                musicjazzChk.Checked = false;
            }
            if (splitmusic.Contains("Othermusic"))
            {
                musicotherChk.Checked = true;
            }
            if (!splitmusic.Contains("Othermusic"))
            {
                musicotherChk.Checked = false;
            }
        }
    }

    protected void getprovincelist()
    {
        if (norwayFylke1.Province == "" || norwayFylke1.Province == null)
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/non.ascx";
        }
        if (norwayFylke1.Province == "Akershus")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/akershus.ascx";
        }
        if (norwayFylke1.Province == "Aust-Agder")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/austagder.ascx";
        }
        if (norwayFylke1.Province == "Buskerud")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/buskerud.ascx";
        }
        if (norwayFylke1.Province == "Finnmark")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/finnmark.ascx";
        }
        if (norwayFylke1.Province == "Hedmark")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/hedmark.ascx";
        }
        if (norwayFylke1.Province == "Hordaland")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/hordaland.ascx";
        }
        if (norwayFylke1.Province == "Møre og Romsdal")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/møreogromsdal.ascx";
        }
        if (norwayFylke1.Province == "Nordland")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/nordtrøndelag.ascx";
        }
        if (norwayFylke1.Province == "Nord-Trøndelag")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/nordland.ascx";
        }
        if (norwayFylke1.Province == "Oppland")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/oppland.ascx";
        }
        if (norwayFylke1.Province == "Oslo")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/oslo.ascx";
        }
        if (norwayFylke1.Province == "Rogaland")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/rogaland.ascx";
        }
        if (norwayFylke1.Province == "Sogn og Fjordane")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/sognogfjord.ascx";
        }
        if (norwayFylke1.Province == "Sør-Trøndelag")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/sørtrøndelag.ascx";
        }
        if (norwayFylke1.Province == "Telemark")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/telemark.ascx";
        }
        if (norwayFylke1.Province == "Troms")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/troms.ascx";
        }
        if (norwayFylke1.Province == "Vest-Agder")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/vestagder.ascx";
        }
        if (norwayFylke1.Province == "Vestfold")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/vestfold.ascx";
        }
        if (norwayFylke1.Province == "Østfold")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/østfold.ascx";
        }
        if (norwayFylke1.Province == "Annet")
        {
            Session["ProvinceList"] = "/vennskap/usercontrol/location/annet.ascx";
        }
        if (!IsPostBack)
        {
            Control uc = LoadControl(Session["provinceList"].ToString());
            PlaceHolder2.Controls.Clear();
            PlaceHolder2.Controls.Add(uc);
        }
    }
    #endregion

    #region imagehandler function
    protected void getsmallimage(System.Drawing.Image original, string Picturepath)
    {
        Bitmap myBitmap = new Bitmap(original, 90, 110);
        lock (myBitmap)
        {
            //save picture as jpeg format
            myBitmap.Save(Picturepath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
    #endregion

    #region split function
    /// <summary>
    /// split string of interest, music, relationshiptype to words
    /// </summary>
    public string[] splitstr(string original, int wordcount)
    {
        string delimStr = ",";
        char[] delimiter = delimStr.ToCharArray();
            string[] split = null;
            if (original != null)
            {
                for (int x = 1; x <= wordcount; x++)
                {
                    split = original.Split(delimiter, x);
                }
            }
        return split;
    }

    //tell items in a sentence
    public int tellcomma(string sentence)
    {
        int count = 0;
        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i].ToString() == ",")
            {
                count++;
            }
        }
            return count;
    }
    //remove comma at the end of a sentence
    public string removecomma(string sentence)
    {
        int i = sentence.Length;
        if (i >= 2)
        {
            if (sentence[i - 1].ToString() == " ")
            {
                return sentence.Remove(i - 2);
            }
            else if (sentence[i - 1].ToString() == ",")
            {
                return sentence.Remove(i - 1);
            }
            else
            {
                return sentence;
            }
        }
        else
            return "";
    }
    //remove space in a sentence
    public string removespace(string sentence)
    {
        string newsentence = "";
        if (sentence.Length >= 1)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i].ToString() != " ")
                {
                    newsentence += sentence[i].ToString();
                }
            }
        }
        return newsentence;
    }

    //updatepanel
    bool IsPostingFromMenu()
    {
        string ctlID = ScriptManager2.AsyncPostBackSourceElementID;
        Control c = this.FindControl(ctlID);
        if (c == null)
            return false;
        return (c.ID == "norwayFylke1");
    }
    #endregion

}
