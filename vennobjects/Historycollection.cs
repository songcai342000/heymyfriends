using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using System.Data.SqlClient;
using System.Threading;
using System.Collections;
using vennobjects;

namespace vennobjects
{
    [Serializable]
    public class Historycollection: Idrepositorybase
    {
        #region variables
        private static string myTableName = "vennjia1_Helen.Historyinfo";
        private static Dictionary<string, int> dictionaryid = new Dictionary<string, int>();
        private static Dictionary<string, DataTable> dictionarysort = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dictionarytime = new Dictionary<string, DataTable>();
        private static Dictionary<string, History> dictionaryhist = new Dictionary<string, History>();
        private static Dictionary<string, Searchstory> dictionarysear = new Dictionary<string, Searchstory>();
        private static List<string> guestid = new List<string>();


        public static int count = 0;
         #endregion

        #region constructor
        public Historycollection()
            : base()
        { }

        public Historycollection(string Type)
            : base(Type)
        { }

        public Historycollection(int Id)
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
            if (Id is History)
            {
                History theHistory = Id as History;
                this.Row["Id"] = theHistory.Id;
                this.Row["Historytitle"] = theHistory.Historytitle;
                this.Row["Historypath"] = theHistory.Historypath;
                this.Row["Storytype"] = theHistory.Storytype;
                this.Row["Historycategory"] = theHistory.Historycategory;
                this.Row["Time"] = theHistory.Time;
            }
        }

        public override void Delete(IId Id)
        {
            base.Delete(Id);
        }

        public override void Update(IId Id)
        {
            base.Update(Id);
            if (Id is History)
            {
                History theHistory = Id as History;
                this.Row["Id"] = theHistory.Id;
                this.Row["Historytitle"] = theHistory.Historytitle;
                this.Row["Historypath"] = theHistory.Historypath;
                this.Row["Storytype"] = theHistory.Storytype;
                this.Row["Historycategory"] = theHistory.Historycategory;
                this.Row["Time"] = theHistory.Time;
            }
        }

      
        //static methods
        //dictionary to treat thread
        public Dictionary<string, History> getdictionaryhistory()
        {
            return dictionaryhist;
        }

        public Dictionary<string, DataTable> getdictionarybysort()
        {
            return dictionarysort;
        }

        public Dictionary<string, DataTable> getdictionarybytime()
        {
            return dictionarytime;
        }

        public Dictionary<string, int> getdictionaryid()
        {
            return dictionaryid;
        }
        
        public Dictionary<string, Searchstory> getdictionarysearch()
        {
            return dictionarysear;
        }

        public string getguestid()
        {
            if (guestid.Count > 0)
            {
                return (int.Parse(guestid[guestid.Count - 1]) + 1).ToString();
            }
            else
            {
                return "1";
            }
        }

        public List<string> getdguestlist()
        {
            return guestid;
        }

        public void filldictionaryhist(string Username, History History)
        {
            if (!dictionaryhist.ContainsKey(Username))
            {
                dictionaryhist.Add(Username, History);
            }
        }

        public void filldictionarybysort(string Username, DataTable table)
        {
            if (!dictionarysort.ContainsKey(Username))
            {
                dictionarysort.Add(Username, table);
            }
        }
        public void filldictionarybytime(string Username, DataTable table)
        {
            if (!dictionarytime.ContainsKey(Username))
            {
                dictionarytime.Add(Username, table);
            }
        }
        public void filldictionaryid(string Username, int Id)
        {
            if (!dictionaryid.ContainsKey(Username))
            {
                dictionaryid.Add(Username, Id);
            }
        }

        public void filldictionarysear(string Username, Searchstory Sear)
        {
            if (!dictionarysear.ContainsKey(Username))
            {
                dictionarysear.Add(Username, Sear);
            }
        }

        public void fillguestid()
        {
            if (guestid.Count > 0)
            {
                guestid.Add((int.Parse(guestid[guestid.Count - 1]) + 1).ToString());
            }
            else
            {
                guestid.Add("1");
            }
        }

        public void removedictionaryhist(string Username)
        {
            dictionaryhist.Remove(Username);
        }

        public void removedictionarybysort(string Username)
        {
            dictionarysort.Remove(Username);
        }

        public void removedictionarybytime(string Username)
        {
            dictionarytime.Remove(Username);
        }

        public void removedictionaryid(string Username)
        {
            dictionaryid.Remove(Username);
        }

        public void removedictionarysear(string Username)
        {
            dictionarysear.Remove(Username);
        }

        public void removeguestid(string theguestid)
        {
            guestid.Remove(theguestid);
        }
        #endregion 

        #region non-override Usernamee methods
        /// <summary>
        /// add a mail object to the out-mail list
        /// </summary>
        /// <param name="outnew"></param>
        public DataTable GetTodaysHistories()
        {
            DataTable mytable = dataAccess.GetTodaysHistories(SqlAd);
            return mytable;
        }

        public DataTable GetByHistorytypecategory(string Type, string Historycategory)
        {
            DataTable mytable = dataAccess.GetHistoryByTypeCategory(Type, Historycategory, SqlAd);
            return mytable;
        }

        public DataTable GetByHistorytypetime(string Type, string Time)
        {
            DataTable mytable = dataAccess.GetHistoryByTypeTime(Type, Time, SqlAd);
            return mytable;
        }

       
        /*public History Find(string path)
        {

            DataTable table = dataAccess.GetHistorysByPath(path);
            if (table.Rows.Count == 1)
            {
                return new History(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString(), DateTime.Parse(table.Rows[0][4].ToString()), table.Rows[0][5].ToString(), table.Rows[0][6].ToString(), table.Rows[0][7].ToString());
            }
            else
            {
                //throw new Exception("Historygen finnes ikke");
                return null;
            }
        }*/

       

        //create History id
        public int CreateHistoryId()
        {
            int id = dataAccess.GetId(TableName, SqlAd);
            return id;
        }

     
        //get History by id
        public History GetHistoryById(int id)
        {
            DataTable mytable = dataAccess.GetById(TableName, id, SqlAd);
            History history = new History(int.Parse(mytable.Rows[0]["Id"].ToString()), mytable.Rows[0]["Historytitle"].ToString(), mytable.Rows[0]["Historypath"].ToString(), mytable.Rows[0]["Storytype"].ToString(), mytable.Rows[0]["Historycategory"].ToString(), DateTime.Now.ToString());
            return history;
        }

     
        #endregion


    }
}
