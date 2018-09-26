using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using DataAccess;

namespace vennobjects
{
    [Serializable]
    public class Picturecollection : Idrepositorybase
    {
        #region variables
        private static string myTableName = "Pictureinfo";
        private static Dictionary<string, DataTable> dictionarypic = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dictionarybyuser = new Dictionary<string, DataTable>();
        private static Dictionary<string, int> dictionaryid = new Dictionary<string, int>();


        #endregion

        #region constructor
        public Picturecollection()
            : base()
        { }

        public Picturecollection(string Username)
            : base(Username)
        { }

        public Picturecollection(int Id)
            : base(Id)
        { }

        #endregion

        #region override methods
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
            if (Id is Picture)
            {
                Picture thePicture = Id as Picture;
                this.Row["Id"] = thePicture.Id;
                this.Row["Username"] = thePicture.Username;
                this.Row["Picture"] = thePicture.Picturepath;
                this.Row["Time"] = thePicture.Time;
                this.Row["Description"] = thePicture.Description;
            }
        }

        public override void Delete(IId Id)
        {
            base.Delete(Id);
        }

        public override void Update(IId Id)
        {
            base.Update(Id);
            if (Id is Picture)
            {
                Picture thePicture = Id as Picture;
                this.Row["Id"] = thePicture.Id;
                this.Row["Username"] = thePicture.Username;
                this.Row["Picture"] = thePicture.Picturepath;
                this.Row["Time"] = thePicture.Time;
                this.Row["Description"] = thePicture.Description;
            }
        }

       


        #endregion

        #region non-override methods
        /// <summary>
        /// dictionaries for threadpool
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, DataTable> getdictionarypic()
        {
            return dictionarypic;
        }

        public void filldictionarypic(string Username, DataTable table)
        {
            if (!dictionarypic.ContainsKey(Username))                        
            dictionarypic.Add(Username, table);
        }

        public void removedictionarypic(string Username)
        {
            dictionarypic.Remove(Username);
        }

        public Dictionary<string, DataTable> getdictionarybyuser()
        {
            return dictionarybyuser;
        }

        public void filldictionarybyuser(string Username, DataTable table)
        {
            if (!dictionarybyuser.ContainsKey(Username))                        
            dictionarybyuser.Add(Username, table);
        }

        public void removedictionarybyuser(string Username)
        {
            dictionarybyuser.Remove(Username);
        }

        public Dictionary<string, int> getdictionaryid()
        {
            return dictionaryid;
        }

        public void filldictionaryid(string Username, int id)
        {
            if (!dictionaryid.ContainsKey(Username))                        
            dictionaryid.Add(Username, id);
        }

        public void removedictionaryid(string Username)
        {
            dictionaryid.Remove(Username);
        }

        /// <summary>
        /// get Picture item by identify the blog it belongs to. Username, Time and Picturecontent are selected into datatable
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Time"></param>
        /// <returns></returns>
        public DataTable GetPictureByUser(string Username)
        {
            DataTable mytable = dataAccess.GetByUsername(TableName, Username, SqlAd);
            return mytable;
        }

        public DataTable GetPictureById(int Id)
        {
            DataTable mytable = dataAccess.GetTable(TableName, "Id", Id, SqlAd);
            return mytable;
        }

        public int GetPictureId()
        {
            int id = dataAccess.GetId(TableName, SqlAd);
            return id;
        }
        #endregion
    }
}
