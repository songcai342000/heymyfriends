using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using vennobjects;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

public partial class usercontrol_lagalbum : System.Web.UI.UserControl
{
    Picturecollection mypictures;
    Picturecollection savemypicture;
    string Username;
    int Id;
    /*Exceptncollection myex1;
    Exceptncollection myex2;
    Exceptncollection myex3;

    Mutex mymtx1;
    Mutex mymtx2;
    Mutex mymtx3;*/
    //Mutex mtx1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Username = Session["Username"].ToString();
        mypictures = new Picturecollection();
        UploadStatusLabel.Text = "";
        //mypictures = new Picturecollection(Session["Username"].ToString());
        //get pictures of the user
        DataTable mypticturetable = null;
        lock (mypictures)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(getbyuser), mypictures);
                Dictionary<string, DataTable> picbyuser = mypictures.getdictionarybyuser();
                mypticturetable = picbyuser[Username];
                Debug.Assert(mypticturetable != null, "get picture by user not successfully.");
                if (mypticturetable.Rows.Count > 0)
                {
                    clickPicLi.Visible = true;
                }
                else
                {
                    clickPicLi.Visible = false;
                }
                //Picturecollection pictures = new Picturecollection();
                //DataTable pictureTable = pictures.GetPictureByUser(Session["Username"].ToString());
                getpictures(mypticturetable);
            }
            catch (Exception ex)
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
                mypictures.removedictionarybyuser(Username);
            }
        }

        
    }

    protected void getpictures(DataTable mypticturetable)
    {
        photoPanel.Controls.Add(new LiteralControl("<table><tr>"));
        int i;
        for (i = 0; i < mypticturetable.Rows.Count; i++)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            ImageButton imgBtn = new ImageButton();
            imgBtn.Width = 120;
            imgBtn.Height = 100;
            imgBtn.ImageUrl = "/vennskap/images/" + (mypticturetable.Rows[i]["Picturepath"].ToString()).Substring(74);
            imgBtn.ID = mypticturetable.Rows[i]["Id"].ToString();
            imgBtn.Click += new ImageClickEventHandler(theimagebutton_Click);
            photoPanel.Controls.Add(imgBtn);
            photoPanel.Controls.Add(new LiteralControl("<br />"));
            Button cancelpicBtn = new Button();
            cancelpicBtn.Text = "Slette";
            cancelpicBtn.ID = "Btn" + mypticturetable.Rows[i]["Id"].ToString();
            cancelpicBtn.Click += new EventHandler(cancelpicBtn_Click);
            cancelpicBtn.OnClientClick = "alert('Er du sikkert du skal slette dette bildet?')";
            photoPanel.Controls.Add(cancelpicBtn);
            photoPanel.Controls.Add(new LiteralControl("</td>"));
            if (i == 4 || i == 9 || i == 14 || i == 19 || i == 24)
            {
                photoPanel.Controls.Add(new LiteralControl("</tr><tr>"));
            }
        }
        if (i < 5)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 10 && i > 5)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 15 && i > 10)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 20 && i > 15)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 25 && i > 20)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (i < 30 && i > 25)
        {
            photoPanel.Controls.Add(new LiteralControl("<td>"));
            photoPanel.Controls.Add(new LiteralControl("</td>"));
        }
        if (!(i == 4 || i == 9 || i == 14 || i == 19 || i == 24))
        {
            photoPanel.Controls.Add(new LiteralControl("</tr><tr>"));
        }
        photoPanel.Controls.Add(new LiteralControl("</table>"));
    }

    protected void theimagebutton_Click(object sender, ImageClickEventArgs e)
    {
        //get pictureid from the imagebutton clicked
        Session["PictureId"] = int.Parse(((ImageButton)sender).ID);
        //launch data on another page
        Response.Redirect("/vennskap/functions/Readmailprofil.aspx?fullsizepicture={0}");
    }

    //cancel selected picture
    protected void cancelpicBtn_Click(object sender, EventArgs e)
    {
        Mutex mtx1 = null;
        Id = int.Parse(((Button)sender).ID.Substring(3));
        try
        {
            ManualResetEvent evt1 = new ManualResetEvent(false);
            mtx1 = new Mutex(true);
            ThreadPool.RegisterWaitForSingleObject(evt1,
          new WaitOrTimerCallback(getbyid),
          null, Timeout.Infinite, true);
           
            Dictionary<string, DataTable> thedictionarybyid = mypictures.getdictionarypic();
            //int CommentId = thedictionaryid[Username];
            DataTable thetable = thedictionarybyid["Username"];
            ThreadPool.RegisterWaitForSingleObject(mtx1,
               new WaitOrTimerCallback(savechange),
               null, Timeout.Infinite, true);

            //DataTable thetable = pictures2.GetPictureById(pictureid);
            Picture thepicture = new Picture(Id, Username, thetable.Rows[0]["Picturepath"].ToString(), DateTime.Parse(thetable.Rows[0]["Time"].ToString()), thetable.Rows[0]["Description"].ToString());
            //delete the picture from table and update database
            //pictures.Delete(thepicture);
            //mypictures.Save();
            if (thetable.Rows.Count == 1)
            {
                thetable.Rows.Remove(thetable.Rows[0]);
            }
            evt1.Set();
            Debug.Assert(thetable != null, "get picture by id feil");
        }
        catch (Exception ex)
        {
            Exceptncollection myex2 = new Exceptncollection();
            lock (myex2)
            {
                myex2.exceptiondata(Username, ex.Message, myex2);
            }
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
            if (mtx1 != null)
            {
                mtx1.ReleaseMutex();
            }
            mypictures.removedictionarypic(Username);
        }
        /*Picturecollection pictures2 = new Picturecollection();
        //get picture id from button id
        int pictureid = int.Parse(((Button)sender).ID.Substring(3));
        DataTable thetable = pictures2.GetPictureById(pictureid);
        Picture thepicture = new Picture(pictureid, Session["Username"].ToString(), thetable.Rows[0]["Picturepath"].ToString(), DateTime.Parse(thetable.Rows[0]["Time"].ToString())); 
        //get schema
        Picturecollection mypictures = new Picturecollection(Session["Username"].ToString());
        mypictures.Delete(thepicture);
        mypictures.Save();*/
    }

    protected void albumBtn_Click(object sender, EventArgs e)
    {
        Mutex mtx1 = null;
        if (loadalbum.HasFile)
        {
            try
            {
                // Get the name of the file to upload.
                String filename = loadalbum.FileName;

                //get picturefile extension
                //string ext = Path.GetExtension(filename);
                System.Drawing.Image theimage = Bitmap.FromFile(filename);
                //create picture id
                //Picturecollection picCollection = new Picturecollection();
                //int PictureId = picCollection.GetPictureId();
                int Id;
                Picturecollection mypictures = new Picturecollection();
                lock (mypictures)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(createid), mypictures);
                    Dictionary<string, int> thedicid = mypictures.getdictionaryid();
                    Id = thedicid[Username];
                }
                if (Id != -1)
                {
                    ManualResetEvent evt1 = new ManualResetEvent(false);
                    mtx1 = new Mutex(true);
                    ThreadPool.RegisterWaitForSingleObject(evt1,
                  new WaitOrTimerCallback(constru),
                  null, Timeout.Infinite, true);
                    Dictionary<string, int> thedictionarybyid = mypictures.getdictionaryid();
                    //int CommentId = thedictionaryid[Username];
                    ThreadPool.RegisterWaitForSingleObject(mtx1,
                       new WaitOrTimerCallback(savechange),
                       null, Timeout.Infinite, true);
                    // Append the name of the file to upload to the path.
                    //string picturepath = @"C:\Users\mhelenem\Documents\Visual Studio 2008\Websites\vennskaper\images\" + filename;
                    string picturepath = @"C:\Users\mhelenem\Documents\Visual Studio 2008\Websites\vennskaper\images\" + filename;
                    //loadalbum.SaveAs(@"C:\Users\mhelenem\Documents\Visual Studio 2008\Websites\vennskaper\images\" + PictureId.ToString() + ext);
                    getsmallimage(theimage, picturepath);

                    // Call the SaveAs method to save the 
                    // uploaded file to the specified path.
                    // This example does not perform all
                    // the necessary error checking.               
                    // If a file with the same name
                    // already exists in the specified path,  
                    // the uploaded file overwrites it.
                    Picture thepicture = new Picture(Id, Username, filename, DateTime.Now, imagetext.Text);
                    //get schema and save change to database
                    //Picturecollection mypictures = new Picturecollection(1);
                    savemypicture.Add(thepicture);
                    evt1.Set();
                }
            }
            catch (Exception ex)
            {
                Exceptncollection myex3 = new Exceptncollection();
                lock (myex3)
                {
                    myex3.exceptiondata(Username, ex.Message, myex3);
                }
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
                if (mtx1 != null)
                {
                    mtx1.ReleaseMutex();
                }
                mypictures.removedictionaryid(Username);
            }
            //mypictures.Save();
            // Notify the user of the name of the file
            // was saved under.
            UploadStatusLabel.Text = "Bildet er last opp.";
        }
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "Du har ikke spesiferert en fil til å laste opp.";
        }
    }

    //set lock on album
    protected void keylinkBtn_Click(object sender, EventArgs e)
    {
        Profile.General.Albumkey = "albumlock";
    }
    /// <summary>
    /// methods for calling back
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="TimeOut"></param>
    protected void getbyid(Object obj, bool TimeOut)
    {
        DataTable table;
        table = ((Picturecollection)obj).GetPictureById(Id);
        ((Picturecollection)obj).filldictionarypic(Username, table);
    }

    protected void getbyuser(Object obj)
    {
        DataTable table;
        table = ((Picturecollection)obj).GetPictureByUser(Username);
        ((Picturecollection)obj).filldictionarybyuser(Username, table);
    }

    protected void createid(Object obj)
    {
        int picid;
        picid = ((Picturecollection)obj).GetPictureId();
        ((Picturecollection)obj).filldictionaryid(Username, picid);
    }

    protected void constru(Object obj, bool TimeOut)
    {
        obj = new Picturecollection(1);
        ((Picturecollection)obj).Save();
    }

    protected void savechange(Object obj, bool TimeOut)
    {
        obj = new Picturecollection(Id);
        ((Picturecollection)obj).Save();
    }

  
    //change image size
    protected void getsmallimage(System.Drawing.Image original, string Picturepath)
    {
        double ratio = original.Width / original.Height;
        int thewidth;
        int theheight;
        if (original.Width <= 360 && original.Height <= (int)(360*ratio))
        {
            thewidth = original.Width;
            theheight = original.Height;
            Bitmap myBitmap = new Bitmap(original, thewidth, theheight);
            //save picture as jpeg format
            myBitmap.Save(Picturepath, System.Drawing.Imaging.ImageFormat.Jpeg);

        }
        else if (ratio > 1 && original.Width > 360)
        {
            thewidth = 360;
            theheight = (int)(360/ratio);
            Bitmap myBitmap = new Bitmap(original, thewidth, theheight);
            //save picture as jpeg format
            myBitmap.Save(Picturepath, System.Drawing.Imaging.ImageFormat.Jpeg);

        }
        else if (ratio < 1 && original.Height > 360)
        {
            theheight = 360;
            thewidth = (int)(360 * ratio);
            Bitmap myBitmap = new Bitmap(original, thewidth, theheight);
            //save picture as jpeg format
            myBitmap.Save(Picturepath, System.Drawing.Imaging.ImageFormat.Jpeg);

        }
    }

    //save image as binary data
    /*public void EncodeWithCharArray(string inputFileName)
    {
        System.IO.FileStream inFile;
        byte[] binaryData;
        try
        {
            inFile = new System.IO.FileStream(inputFileName,
                                              System.IO.FileMode.Open,
                                              System.IO.FileAccess.Read);
            binaryData = new Byte[inFile.Length];
            long bytesRead = inFile.Read(binaryData, 0,
                                        (int)inFile.Length);
            inFile.Close();
        }
        catch (System.Exception exp)
        {
            // Error creating stream or reading from it.
            //System.Console.WriteLine("{0}", exp.Message);
            //return;
        }

        // Convert the binary input into Base64 UUEncoded output.
        // Each 3 byte sequence in the source data becomes a 4 byte
        // sequence in the character array. 
        long arrayLength = (long)((4.0d / 3.0d) * binaryData.Length);

        // If array length is not divisible by 4, go up to the next
        // multiple of 4.
        if (arrayLength % 4 != 0)
        {
            arrayLength += 4 - arrayLength % 4;
        }

        char[] base64CharArray = new char[arrayLength];
        try
        {
            System.Convert.ToBase64CharArray(binaryData,
                                             0,
                                             binaryData.Length,
                                             base64CharArray,
                                             0);
        }
        catch (System.ArgumentNullException)
        {
            //System.Console.WriteLine("Binary data array is null.");
            //return;
        }
        catch (System.ArgumentOutOfRangeException)
        {
            //System.Console.WriteLine("Char Array is not large enough.");
            //return;
        }

        // Write the UUEncoded version to the output file.
        System.IO.StreamWriter outFile;
        try
        {
            outFile = new System.IO.StreamWriter(outputFileName,
                                            false,
                                            System.Text.Encoding.ASCII);
            outFile.Write(base64CharArray);
            outFile.Close();
        }
        catch (System.Exception exp)
        {
            // Error creating stream or writing to it.
            //System.Console.WriteLine("{0}", exp.Message);
        }
    }*/

    protected void imgtxtBtn_Click(object sender, EventArgs e)
    {

    }
}
