using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace vennobjects
{
    [Serializable]
    public class Commentcollection: Idrepositorybase
    {
        #region variables
        private static string myTableName = "Commentinfo";
        private static Dictionary<string, int> dictionaryid = new Dictionary<string, int>();
        private static Dictionary<string, DataTable> dictionarybyblogid = new Dictionary<string, DataTable>();

        #endregion

        #region constructor
        public Commentcollection()
            : base()
        { }

        public Commentcollection(string Username)
            : base(Username)
        { }

        public Commentcollection(int Id)
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
            if (Id is Comment)
            {
                Comment theComment = Id as Comment;
                this.Row["Id"] = theComment.Id;
                this.Row["Username"] = theComment.Username;
                this.Row["BlogId"] = theComment.BlogId;
                this.Row["Time"] = theComment.Time;
                this.Row["Comment"] = theComment.Commentcontent;
            }
        }

        /*public override void Add(int Id)
        {
            base.Add(Id);
            if (Id is Comment)
            {
                Comment theComment = Id as Comment;
                this.Row["Id"] = theComment.Id;
                this.Row["Username"] = theComment.Username;
                this.Row["BlogId"] = theComment.BlogId;
                this.Row["Time"] = theComment.Time;
                this.Row["Comment"] = theComment.Commentcontent;
            }
        }*/

        public override void Delete(IId Id)
        {
            base.Delete(Id);
        }

        public override void Update(IId Id)
        {
            base.Update(Id);
            if (Id is Comment)
            {
                Comment theComment = Id as Comment;
                this.Row["Id"] = theComment.Id;
                this.Row["Username"] = theComment.Username;
                this.Row["BlogId"] = theComment.BlogId;
                this.Row["Time"] = theComment.Time;
                this.Row["Comment"] = theComment.Commentcontent;
            }
        }

        #endregion

        #region non-override methods
        /// <summary>
        /// get comment item by identify the blog it belongs to. Username, Time and Commentcontent are selected into datatable
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Time"></param>
        /// <returns></returns>
        public Dictionary<string, int> getdictionaryid()
        {
            return dictionaryid;
        }

        public Dictionary<string, DataTable> getdictionarybyblogid()
        {
            return dictionarybyblogid;
        }

        public void filldictionaryid(string Username, int id)
        {
            if (!dictionaryid.ContainsKey(Username))
             dictionaryid.Add(Username, id);
        }

        public void filldictionarybyblogid(string Username, DataTable table)
        {
            if (!dictionarybyblogid.ContainsKey(Username))
            dictionarybyblogid.Add(Username, table);
        }

        public void removedictionaryid(string Username)
        {
           dictionaryid.Remove(Username);
        }

        public void removedictionarybyblogid(string Username)
        {
            dictionarybyblogid.Remove(Username);
        }
        public DataTable GetCommentByUserTime(string Username, DateTime Time)
        {
           DataTable mytable = dataAccess.GetCommentByBlogUserTime(Username, SqlAd, Time);
           return mytable;
        }

        public DataTable GetCommentByUser(string Username)
        {
            DataTable mytable = dataAccess.GetByUsername(TableName, Username, SqlAd);
            return mytable;
        }

        public DataTable GetCommentByBlogId(int blogid)
        {
            DataTable mytable = dataAccess.GetTable(TableName, "BlogId", blogid, SqlAd);
            return mytable;
        }

        public int GetCommentId()
        {
            int id = dataAccess.GetId(TableName, SqlAd);
            return id;
        }
   
        #endregion
    }
}
