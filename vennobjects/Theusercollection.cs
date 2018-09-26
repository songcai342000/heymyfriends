using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using System.Timers;
using System.Threading;

namespace vennobjects
{
    [Serializable]
    public class Theusercollection: Idrepositorybase
    {
        #region variables
        private static string myTableName = "vennjia1_Helen.Theuserinfo";

        #endregion

        #region constructor
        public Theusercollection()
            : base()
        {
        }

        public Theusercollection(string Username)
            : base(Username)
        {
        }

        public Theusercollection(int Id)
            : base(Id)
        { }
        #endregion

        #region properties
        protected override string TableName
        {
            get
            {
                return myTableName;
            }
        }

        /// <summary>
        /// Add, Delete, Update methods for updating database, objects data are first mapped to a datarow's data
        /// </summary>
        /// <param name="Record"></param>
        public override void Add(IId Id)
        {
            base.Add(Id);
            if (Id is Theuser)
            {
                Theuser theUser = Id as Theuser;
                this.Row["Id"] = theUser.Id;
                this.Row["Username"] = theUser.Username;
                this.Row["Age"] = theUser.Age;
                this.Row["Province"] = theUser.Province;
                this.Row["Online"] = theUser.Online;
                this.Row["Profilepic"] = theUser.Profilepic;
                this.Row["Blog"] = theUser.Blog;
                this.Row["Album"] = theUser.Album;
                this.Row["Gender"] = theUser.Gender;
                this.Row["Timestart"] = theUser.Timestart;
                this.Row["Activate"] = theUser.Activate;
                this.Row["Approve"] = theUser.Approve;

            }
        }

        public override void Delete(IId Id)
        {
            base.Delete(Id);
        }

        public override void Update(IId Id)
        {
            base.Update(Id);
            if (Id is Theuser)
            {
                Theuser theUser = Id as Theuser;
                this.Row["Id"] = theUser.Id;
                this.Row["Username"] = theUser.Username;
                this.Row["Age"] = theUser.Age;
                this.Row["Province"] = theUser.Province;
                this.Row["Online"] = theUser.Online;
                this.Row["Profilepic"] = theUser.Profilepic;
                this.Row["Blog"] = theUser.Blog;
                this.Row["Album"] = theUser.Album;
                this.Row["Gender"] = theUser.Gender;
                this.Row["Timestart"] = theUser.Timestart;
                this.Row["Activate"] = theUser.Activate;
                this.Row["Approve"] = theUser.Approve;

            }
        }

        //dictionaries
       
        //get last id value
        public int GetId()
        {
            int id = dataAccess.GetId(TableName, SqlAd);
            return id;
        }

        /// <summary>
        /// get only username, age, province of users
        /// </summary>
        /// <param name="minage"></param>
        /// <param name="maxage"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public DataTable GetUserInfoByAgeGener(int minage, int maxage, string gender)
        {
           DataTable thetable = dataAccess.GetUserinfoByAgeGender(minage, maxage, gender, SqlAd);
           return thetable;
        }

        public DataTable GetUserInfoByAge(int minage, int maxage)
        {
            DataTable thetable = dataAccess.GetUserinfoByAge(minage, maxage, SqlAd);
            return thetable;
        }

        /// <summary>
        /// get more parameters of the users
        /// </summary>
        /// <param name="minage"></param>
        /// <param name="maxage"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public DataTable GetAllUserInfoByAgeGener(int minage, int maxage, string gender)
        {
            DataTable thetable = dataAccess.GetAllUserinfoByAgeGender(minage, maxage, gender, SqlAd);
            return thetable;
        }

        //get users for search with gender "spiller ingen rolle" condition
        public DataTable GetAllUserInfoByAge(int minage, int maxage)
        {
            DataTable thetable = dataAccess.GetAllUserinfoByAge(minage, maxage, SqlAd);
            return thetable;
        }

        //get new users
        public DataTable GetAllUserInfoByNoApprove()
        {
            DataTable thetable = dataAccess.GetUserinfoByApprove(SqlAd);
            return thetable;
        }

        //get approve status 
        public DataTable GetApproveinfoByUser(string theprofilename)
        {
            DataTable thetable = dataAccess.GetApproveinfoByUser(theprofilename, SqlAd);
            return thetable;
        }

        //get approve status 
        public DataTable GetActivateApproveinfoByUser(string theprofilename)
        {
            DataTable thetable = dataAccess.GetUserinfoActiveApprove(theprofilename, SqlAd);
            return thetable;
        }

        //search by similiar username
        public DataTable GetSimilarUser(string similarname)
        {
            DataTable thetable = dataAccess.GetSimilarUser(similarname, SqlAd);
            return thetable;
        }
        public DataTable GetUserByProfilepic(int minage, int maxage, string gender, string province)
        {
            DataTable thetable = dataAccess.GetUserinfoByProfilepic(minage, maxage, gender, province, SqlAd);
            return thetable;
        }

        public DataTable GetUserByProfilepic(int minage, int maxage, string gender)
        {
            DataTable thetable = dataAccess.GetUserinfoByProfilepic(minage, maxage, gender, SqlAd);
            return thetable;
        }

        public DataTable GetUserByAlbum(int minage, int maxage, string gender, string province)
        {
            DataTable thetable = dataAccess.GetUserinfoByAlbum(minage, maxage, gender, province, SqlAd);
            return thetable;
        }

        public DataTable GetUserByAlbum(int minage, int maxage, string gender)
        {
            DataTable thetable = dataAccess.GetUserinfoByAlbum(minage, maxage, gender, SqlAd);
            return thetable;
        }

        //get user of a province who has blog
        public DataTable GetUserByBlog(int minage, int maxage, string gender, string province)
        {
            DataTable thetable = dataAccess.GetUserinfoByBlog(minage, maxage, gender, province, SqlAd);
            return thetable;
        }

        //get user of whole country who has blog
        public DataTable GetUserByBlog(int minage, int maxage, string gender)
        {
            DataTable thetable = dataAccess.GetUserinfoByBlog(minage, maxage, gender, SqlAd);
            return thetable;
        }

        //get new users in the last 7 days
        public DataTable GetUserByStartTime7(int minage, int maxage, string gender)
        {
            DataTable thetable = dataAccess.GetUserinfoByStartTime7(minage, maxage, gender, SqlAd);
            return thetable;
        }

        //get new users in the last month
        public DataTable GetUserByStartTime30(int minage, int maxage, string gender)
        {
            DataTable thetable = dataAccess.GetUserinfoByStartTime30(minage, maxage, gender, SqlAd);
            return thetable;
        }

        public DataTable GetUserByProvince(int minage, int maxage, string province, string gender)
        {
            DataTable thetable = dataAccess.GetAllUserinfoByAgeGenderProvince(minage, maxage, province, gender, SqlAd);
            return thetable;
        }

        //get full set of new user
        public DataTable GetAllNewUser(string gender)
        {
            DataTable thetable = dataAccess.GetAllNewUser(gender, SqlAd);
            return thetable;
        }

        //get 14 of full set of new users
        public DataTable GetNewUser(string gender)
        {
            DataTable thetable = dataAccess.GetNewUser(gender, SqlAd);
            return thetable;
        }

        public void UpdateOnline(string Username, string Online)
        {
            dataAccess.UpdateUserinfoOnline(Username, Online);
        }

        public void UpdateAlbum(string Username)
        {
            dataAccess.UpdateUserinfoAlbum(Username);
        }

        public void UpdateAlbumDelete(string Username)
        {
            dataAccess.UpdateUserinfoDeleteAlbum(Username);
        }

        public void UpdateBlog(string Username)
        {
            dataAccess.UpdateUserinfoBlog(Username);
        }

        public void UpdateActivate(string Username, string activate)
        {
            dataAccess.UpdateUserinfoActivate(Username, activate);
        }

        public void UpdateApprove(string Username, string approve)
        {
            dataAccess.UpdateUserinfoApprove(Username, approve);
        }

        public void UpdateUserinfo(string age, string province, string gender, string profilepic, string username)
        {
            dataAccess.UpdateUserinfo(age, province, gender, profilepic, username);
        }

        public void UpdateUserinfoWoman(string age, string province, string gender, string profilepic, string username)
        {
            dataAccess.UpdateUserinfo(age, province, gender, profilepic, username);
        }
        public DataTable GetNewMenWomen()
        {
            DataTable table = dataAccess.GetNewMenWomen(SqlAd);
            return table;
        }
        /*public void GetNewProfilepic()
         {
             dataAccess.GetNewProfilepic();
         }*/
        #endregion
    }
}
