using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Configuration;
using System.Data;

namespace vennobjects
{
    [Serializable]
    public class Favoritecollection: Idrepositorybase
    {
        #region variables
        private static string myTableName = "Favoriteinfo";
        //new men and new women profiles as public static, shows on minside
        public static Stack<userselectedparameters> newwomenprofiles = new Stack<userselectedparameters>();
        public static Stack<userselectedparameters> newmenprofiles = new Stack<userselectedparameters>();
        private static Dictionary<string, int> dictionaryid = new Dictionary<string, int>();
        private static Dictionary<string, DataTable> dicblocked = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dicbyuser = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dicbyusertypename = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dicotherfavorite = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dicvisitornum = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dicvisitor = new Dictionary<string, DataTable>();


        //thread monitor variables for entire system
        //initializes
        public static int consumermonitor = 0;

        #endregion

        #region constructor
        public Favoritecollection()
            : base()
        { }

        public Favoritecollection(string Username)
            : base(Username)
        { }

        public Favoritecollection(int Id)
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

        private DataRow dr;
        /// <summary>
        /// Add, Delete, Update methods for updating database, objects data are first mapped to a datarow's data
        /// </summary>
        /// <param name="Record"></param>
        public override void Add(IId Id)
        {
            base.Add(Id);
            if (Id is Favorite)
            {
                Favorite theFavorite = Id as Favorite;
                this.Row["Id"] = theFavorite.Id;
                this.Row["Username"] = theFavorite.Username;
                this.Row["Favoritename"] = theFavorite.Favoritename;
                this.Row["Time"] = theFavorite.Time;
                this.Row["Favoritetype"] = theFavorite.Favoritetype;
            }
        }

        public override void Delete(IId Id)
        {
            base.Delete(Id);
        }

        public override void Update(IId Id)
        {
            base.Update(Id);
            if (Id is Favorite)
            {
                Favorite theFavorite = Id as Favorite;
                this.Row["Id"] = theFavorite.Id;
                this.Row["Username"] = theFavorite.Username;
                this.Row["Favoritename"] = theFavorite.Favoritename;
                this.Row["Time"] = theFavorite.Time;
                this.Row["Favoritetype"] = theFavorite.Favoritetype;
            }
        }

       
        #endregion 

        #region non-override Usernamee methods
        /// <summary>
        /// dictionaries, prepare to pick up result from product of threadpool
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> getdictionaryid()
        {
            return dictionaryid;
        }

        public void filldictionaryid(string Username, int id)
        {
            if (!dictionaryid.ContainsKey(Username))
            {
                dictionaryid.Add(Username, id);
            }
        }

        public void removedictionaryid(string Username)
        {
            dictionaryid.Remove(Username);
        }

        public Dictionary<string, DataTable> getdicblocked()
        {
            return dicblocked;
        }

        public void filldictblocked(string Username, DataTable table)
        {
            if (!dicblocked.ContainsKey(Username))
            {
                dicblocked.Add(Username, table);
            }
        }

        public void removedictblocked(string Username)
        {
            dicblocked.Remove(Username);
        }

        public Dictionary<string, DataTable> getfavdicbyuser()
        {
            return dicbyuser;
        }

        public void fillfavdictbyuser(string Username, DataTable table)
        {
            if (!dicbyuser.ContainsKey(Username))
            {
                dicbyuser.Add(Username, table);
            }
        }

        public void removefavdicbyuser(string Username)
        {
            dicbyuser.Remove(Username);
        }

        public Dictionary<string, DataTable> getfavdicbyusertypename()
        {
            return dicbyusertypename;
        }

        public void fillfavdictbyusertypename(string Username, DataTable table)
        {
            if (!dicbyusertypename.ContainsKey(Username))
            {
                dicbyusertypename.Add(Username, table);
            }
        }

        public void removefavdicbyusertypename(string Username)
        {
            dicbyusertypename.Remove(Username);
        }

        public Dictionary<string, DataTable> getdicotherfavorite()
        {
            return dicotherfavorite;
        }

        public void filldicotherfavorite(string Username, DataTable table)
        {
            if (!dicotherfavorite.ContainsKey(Username))
            {
                dicotherfavorite.Add(Username, table);
            }
        }

        public void removedicotherfavorite(string Username)
        {
            dicotherfavorite.Remove(Username);
        }

        public Dictionary<string, DataTable> getdicvisitornum()
        {
            return dicvisitornum;
        }

        public void filldicvisitornum(string Username, DataTable table)
        {
            if (!dicvisitornum.ContainsKey(Username))
            {
                dicvisitornum.Add(Username, table);
            }
        }

        public void removedicvisitornum(string Username)
        {
            dicvisitornum.Remove(Username);
        }

        public Dictionary<string, DataTable> getdicvisitor()
        {
            return dicvisitor;
        }

        public void filldicvisitor(string Username, DataTable table)
        {
            if (!dicvisitor.ContainsKey(Username))
            {
                dicvisitor.Add(Username, table);
            }
        }

        public void removedicvisitor(string Username)
        {
            dicvisitor.Remove(Username);
        }

        
        //add new man
        public void addnewman(userselectedparameters newman)
        {
            //thread safe
            newmenprofiles.Push(newman);
        }

        //add new woman
        public void addnewwoman(userselectedparameters newwoman)
        {
            //thread safe
            newwomenprofiles.Push(newwoman);
        }

        public DataTable GetByUserType(string Username, string Favoritetype)
        {
            DataTable myfavoritetable = dataAccess.GetByUserFavoriteType(Username, SqlAd, Favoritetype);
            
            return myfavoritetable;
        }

        public DataTable GetFavoriteBlogByPath(string Username, string Favoritename)
        {
            DataTable myfavoritetable = dataAccess.GetFavoriteBlogsByPath(Username, Favoritename, SqlAd);

            return myfavoritetable;
        }

        public DataTable GetByUserFavoriteTypeName(string Username, string Favoritetype, string Favoritename)
        {
            DataTable myfavoritetable = dataAccess.GetFavoriteByFavoritenametype(Username, Favoritename, Favoritetype, SqlAd);

            return myfavoritetable;
        }

        /*public DataTable GetVisitsByUser(string Username, string Favoritename)
        {
            DataTable table = dataAccess.GetVisitsByUser(Username, Favoritename, SqlAd);
            return table;
        }*/

       

        public DataTable GetVisitors(string Profilename)
        {
            DataTable myfavoritetable = dataAccess.GetVisitors(Profilename, SqlAd);

            return myfavoritetable;
        }

        public DataTable CountVisitors(string Profilename)
        {
            DataTable myfavoritetable = dataAccess.CountVisitors(Profilename, SqlAd);

            return myfavoritetable;
        }

        //i get gifts or i am favorite of others
        public DataTable GetOthersFavorite(string Username, string Favoritetype)
        {
            DataTable otherfavoritetable = dataAccess.GetByFavoriteNameType(Username, Favoritetype, SqlAd);

            return otherfavoritetable;
        }

        /*public DataTable GetMyFavorite(string Username, string Favoritetype)
        {
            DataTable myfavoritetable = dataAccess.GetByUserFavoriteType(Username, SqlAd, Favoritetype);

            return myfavoritetable;
        }*/

        /*
        public DataTable GetFavoriteBlog(string Username)
        {
            DataTable myfavoriteblogtable = dataAccess.GetFavoriteBlog(Username, SqlAd);
            return myfavoriteblogtable;
        }

        //get i am favorite
        public DataTable GetIamFavorite(string Favoritename)
        {
            DataTable myflowertable = dataAccess.GetByFavoriteNameType(TableName, Favoritename, SqlAd, "myfavoriteprofile");
            return myflowertable;
        }*/
        //get flower
        /*public DataTable GetFlower(string Favoritename)
        {
            DataTable myflowertable = dataAccess.GetByUserFavoriteType(TableName, Favoritename, SqlAd, "flower");
            return myflowertable;
        }
        //get key
        public DataTable GetKey(string Favoritename)
        {
            DataTable myflowertable = dataAccess.GetByFavoriteNameType(TableName, Favoritename, SqlAd, "key");
            return myflowertable;
        }

        public DataTable GetKey(string Favoritename)
        {
            DataTable myflowertable = dataAccess.GetByFavoriteNameType(TableName, Favoritename, SqlAd, "key");
            return myflowertable;
        }*/

        //get last id value
        public int GetId()
        {
            int id = dataAccess.GetId(TableName, SqlAd);
            return id;
        }

        //get blocked users
        public DataTable GetBlockedUsers(string username)
        {
            DataTable table = dataAccess.GetBlockedUsers(username, SqlAd);
            return table;
        }

        //get all favorites
        public DataTable GetByUsername(string username)
        {
            DataTable table = dataAccess.GetByUsername(TableName, username, SqlAd);
            return table;
        }

        //get by id
        public DataTable GetById(int id)
        {
            DataTable table = dataAccess.GetById(TableName, id, SqlAd);
            return table;
        }
        #endregion
    }
}
