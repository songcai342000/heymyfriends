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
using System.Drawing;
using System.Diagnostics;
using System.Threading;

public partial class usercontrol_profil_annenprofil : System.Web.UI.UserControl
{
    //Exceptncollection myex1;
    //Mutex mymtx1;
    string Username;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
            MembershipUser theuser = Membership.GetUser(Username);
            if (theuser.IsOnline)
            {
                online.Text = " - Online";
            }
            else
            {
                online.Text = "";
            }
        //check if the profile is approved

            name.Text = Profile.UserName;
            gender.Text = Profile.General.Gender;
            age.Text = Profile.General.Year;
            country.Text = Profile.General.Country;
            province.Text = Profile.General.Province;
            city.Text = Profile.General.City;
            marital.Text = Profile.General.Maritalstatus;
            star.Text = Profile.General.Star;
            child.Text = Profile.General.Children;
            drink.Text = Profile.General.Drink;
            smoke.Text = Profile.General.Smoke;
            ethenic.Text = Profile.Background.Ethnicbackground;
            religion.Text = Profile.Background.Religion;
            occupation.Text = Profile.Background.Occupation;
            education.Text = Profile.Background.Education;
            language1.Text = Profile.Background.Language1;
            language2.Text = Profile.Background.Language2;
            haircolor.Text = Profile.Outlook.Haircolor;
            hobby.Text = Profile.Interest;
            physique.Text = Profile.Outlook.Physique;
            height.Text = Profile.Outlook.Height;
            eyecolor.Text = Profile.Outlook.Eyecolor;
            music.Text = Profile.Freetime.Music;
            sport.Text = Profile.Freetime.Sporttype;
            pet.Text = Profile.Freetime.Pet;
            search.Text = Profile.Expection;
            searchage.Text = Profile.General.Searchage;
            kontakttype.Text = Profile.Relationshiptype;
            selv.Text = Profile.Selvdescription;
            profileImg.ImageUrl = Profile.General.Picture;
        }
      
    protected void  loadBtn_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                String fileName = FileUpload1.FileName;
                System.Drawing.Image theimage = Bitmap.FromFile(fileName);
                Bitmap bmp = new Bitmap(theimage, 90, 110);
                // Append the name of the file to upload to the path.
                string picturepath = @"C:\Users\mhelenem\Documents\Visual Studio 2008\Websites\vennskaper\images\" + Session["Username"].ToString() + ".jpg";
                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                bmp.Save(picturepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                UploadStatusLabel.Text = "Profilbildet er last opp.";
                profileImg.ImageUrl = "/vennskap/images/" + Session["Username"].ToString() + ".jpg";
                Profile.General.Picture = profileImg.ImageUrl;
            }
            catch (Exception ex)
            {
                Exceptncollection myex1 = new Exceptncollection();
                lock (myex1)
                {
                    myex1.exceptiondata(Username, ex.Message, myex1);
                }
                Debug.Assert(ex == null, ex.Message);
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
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "Det finns ingen profil bilde. Venligst spesifere et bilde for din profil.";
        }
    }


}
