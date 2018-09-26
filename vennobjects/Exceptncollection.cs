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
    public class Exceptncollection: Idrepositorybase
    {
        #region variables
        private static string myTableName = "Exceptioninfo";
        //public static DataTable outmails = dataAccess.Outmails();
        private static Dictionary<string, int> dicid = new Dictionary<string, int>();
        #endregion

        #region constructor
        public Exceptncollection()
            : base()
        {
        }
        public Exceptncollection(string Username)
            : base(Username)
        {
        }

        public Exceptncollection(int Id)
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

        /*protected string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }*/

        /// <summary>
        /// Add, Delete, Update methods for updating database, objects data are first mapped to a datarow's data
        /// </summary>
        /// <param name="Record"></param>
        public override void Add(IId Id)
        {
            base.Add(Id);
            if (Id is Exceptn)
            {
                Exceptn theEx = Id as Exceptn;
                this.Row["Id"] = theEx.Id;
                this.Row["Username"] = theEx.Username;
                this.Row["Exmessage"] = theEx.Exmessage;
                this.Row["Time"] = theEx.Time;
            }
        }

        public override void Delete(IId Id)
        {
            base.Delete(Id);
        }

        public override void Update(IId Id)
        {
            base.Update(Id);
            if (Id is Exceptn)
            {
                Exceptn theEx = Id as Exceptn;
                this.Row["Id"] = theEx.Id;
                this.Row["Username"] = theEx.Username;
                this.Row["Exmessage"] = theEx.Exmessage;
                this.Row["Time"] = theEx.Time;
            }
        }

        //dictionaries
        public Dictionary<string, int> getdicid()
        {
            return dicid;
        }

        public void filldicid(string Username, int Id)
        {
            if (Username != null && !dicid.ContainsKey(Username))
            {
                dicid.Add(Username, Id);
            }
        }

        public void removedicid(string Username)
        {
            if (Username != null && dicid.ContainsKey(Username))
            {
                dicid.Remove(Username);
            }
        }




        //get last id value
        public int GetId()
        {
            int id = dataAccess.GetId(TableName, SqlAd);
            return id;
        }

        #endregion
    }
}
