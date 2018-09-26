using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using System.Data.SqlClient;
using System.Threading;
using System.Collections;

namespace vennobjects
{
    [Serializable]
    public class Blogcollection: Idrepositorybase
    {
        #region variables
        private static string myTableName = "Bloginfo";
  
        public static DataTable partylist;
        public static DataTable relationlist;
        public static DataTable travellist;
        public static DataTable foodlist;
        public static DataTable thinklist;
        public static DataTable otherlist;
        public static DataTable blogwritterlist;
        public static DataTable usercatrylist;

      
        public static List<string> ladylist = new List<string>();
        public static List<string> manlist = new List<string>();
        //this logic must change after website get enough user
        public static DataTable newbloglist;
        //this logic must change after website get enough user
        public static DataTable popularbloglist;

        private static Dictionary<string, DataTable> dictionarypopublog = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dictionaryfavoblog = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dictionarynewblog = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dictionarybyuser = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dictionarybyusercatry = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dictionarybycatry = new Dictionary<string, DataTable>();
        private static Dictionary<string, int> dictionaryid = new Dictionary<string, int>();
        private static Dictionary<string, DataTable> dictionarybyusertitle = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dictionarybytitle = new Dictionary<string, DataTable>();
        private static Dictionary<string, Blog> dictionaryblog = new Dictionary<string, Blog>();
        private static Dictionary<string, int> dicblognumber = new Dictionary<string, int>();
        private static Dictionary<string, string> dicpage = new Dictionary<string, string>();

        public static int count = 0;
         #endregion

        #region constructor
        public Blogcollection()
            : base()
        { }

        public Blogcollection(string Username)
            : base(Username)
        { }

        public Blogcollection(int Id)
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
            if (Id is Blog)
            {
                Blog theBlog = Id as Blog;
                this.Row["Id"] = theBlog.Id;
                this.Row["Username"] = theBlog.Username;
                this.Row["Blogtitle"] = theBlog.Blogtitle;
                this.Row["Blogpath"] = theBlog.Blogpath;
                this.Row["Time"] = theBlog.Time;
                this.Row["Blogcategory"] = theBlog.Blogcategory;
                this.Row["Blogtopicmeaning"] = theBlog.Blogtopicmeaning;
                this.Row["Picturepath"] = theBlog.Picturepath;
            }
        }

        public override void Delete(IId Id)
        {
            base.Delete(Id);
        }

        public override void Update(IId Id)
        {
            base.Update(Id);
            if (Id is Blog)
            {
                Blog theBlog = Id as Blog;
                this.Row["Id"] = theBlog.Id;
                this.Row["Username"] = theBlog.Username;
                this.Row["Blogtitle"] = theBlog.Blogtitle;
                this.Row["Blogpath"] = theBlog.Blogpath;
                this.Row["Time"] = theBlog.Time;
                this.Row["Blogcategory"] = theBlog.Blogcategory;
                this.Row["Blogtopicmeaning"] = theBlog.Blogtopicmeaning;
                this.Row["Picturepath"] = theBlog.Picturepath;
            }
        }

      
        //static methods
        //dictionary to treat thread
        public Dictionary<string, Blog> getdictionaryblog()
        {
            return dictionaryblog;
        }

        public Dictionary<string, DataTable> getdictionarybyuser()
        {
            return dictionarybyuser;
        }

        public Dictionary<string, DataTable> getdictionarybyusercatry()
        {
            return dictionarybyusercatry;
        }

        public Dictionary<string, DataTable> getdictionarybycatry()
        {
            return dictionarybycatry;
        }

        public Dictionary<string, int> getdictionaryid()
        {
            return dictionaryid;
        }

        public Dictionary<string, DataTable> getdictionarybyusertitle()
        {
            return dictionarybyusertitle;
        }

        public Dictionary<string, DataTable> getdictionarypopublog()
        {
            return dictionarypopublog;
        }

        public Dictionary<string, DataTable> getdictionarynewblog()
        {
            return dictionarynewblog;
        }

        public Dictionary<string, DataTable> getdictionaryfavoblog()
        {
            return dictionaryfavoblog;
        }

        public Dictionary<string, int> getdicblognumber()
        {
            return dicblognumber;
        }

        public Dictionary<string, string> getdicpage()
        {
            return dicpage;
        }

        public void filldicblognum(string Username, int number)
        {
            if (!dicblognumber.ContainsKey(Username))
            {
                dicblognumber.Add(Username, number);
            }
        }

        public void removedicblognum(string Username)
        {
            dicblognumber.Remove(Username);
        }

       /* public Dictionary<string, DataTable> getdictionarypositive()
        {
            return dictionarypositive;
        }

        public Dictionary<string, DataTable> getdictionarynegative()
        {
            return dictionarynegative;
        }*/

        public void filldictionaryblog(string Username, Blog blog)
        {
            if (!dictionaryblog.ContainsKey(Username))
            {
                dictionaryblog.Add(Username, blog);
            }
        }

        public void filldictionarybyuser(string Username, DataTable table)
        {
            if (!dictionarybyuser.ContainsKey(Username))
            {
                dictionarybyuser.Add(Username, table);
            }
        }
        public void filldictionarybyusercatry(string Username, DataTable table)
        {
            if (!dictionarybyusercatry.ContainsKey(Username))
            {
                dictionarybyusercatry.Add(Username, table);
            }
        }
        public void filldictionarypopublog(string Username, DataTable table)
        {
            if (!dictionarypopublog.ContainsKey(Username))
            {
                dictionarypopublog.Add(Username, table);
            }
        }

        public void filldictionaryfavoblog(string Username, DataTable table)
        {
            if (!dictionaryfavoblog.ContainsKey(Username))
            {
                dictionaryfavoblog.Add(Username, table);
            }
        }

        public void filldictionarynewblog(string Username, DataTable table)
        {
            if (!dictionarynewblog.ContainsKey(Username))
            {
                dictionarynewblog.Add(Username, table);
            }
        }

        public void filldictionarybycatry(string Username, DataTable table)
        {
            if (!dictionarybycatry.ContainsKey(Username))
            {
                dictionarybycatry.Add(Username, table);
            }
        }
        public void filldictionaryid(string Username, int id)
        {
            if (!dictionaryid.ContainsKey(Username))
            {
                dictionaryid.Add(Username, id);
            }
        }

        public void filldictionarybyusertitle(string Username, DataTable table)
        {
            if (!dictionarybyusertitle.ContainsKey(Username))
            {
                dictionarybyusertitle.Add(Username, table);
            }
        }

        public void filldicpage(string Username, string Page)
        {
            if (!dictionarybyusertitle.ContainsKey(Username))
            {
                dicpage.Add(Username, Page);
            }
        }

        /*public void filldictionarypositive(string username, DataTable table)
        {
            dictionarypositive.Add(username, table);
        }

        public void filldictionarynegative(string username, DataTable table)
        {
            dictionarynegative.Add(username, table);
        }*/

        public void removedictionaryblog(string Username)
        {
            dictionaryblog.Remove(Username);
        }

        public void removedictionarybyuser(string Username)
        {
            dictionarybyuser.Remove(Username);
        }

        public void removedictionarypopublog(string Username)
        {
            dictionarypopublog.Remove(Username);
        }

        public void removedictionarynewblog(string Username)
        {
            dictionarynewblog.Remove(Username);
        }

        public void removedictionaryfavoblog(string Username)
        {
            dictionaryfavoblog.Remove(Username);
        }

        public void removedictionarybycatry(string Username)
        {
            dictionarybycatry.Remove(Username);
        }
        public void removedictionarybyusercatry(string Username)
        {
            dictionarybyusercatry.Remove(Username);
        }
        public void removedictionaryid(string Username)
        {
            dictionaryid.Remove(Username);
        }

        public void removedictionarybyusertitle(string Username)
        {
            dictionarybyusertitle.Remove(Username);
        }

        public void removedicpage(string Username)
        {
            dicpage.Remove(Username);
        }

        public Dictionary<string, DataTable> getdicbytitle()
        {
            return dictionarybyuser;
        }

        public void removedicbytitle(string Username)
        {
            dictionarybytitle.Remove(Username);
        }

        public void filldicbytitle(string Username, DataTable table)
        {
            if (!dictionarybytitle.ContainsKey(Username))
                dictionarybytitle.Add(Username, table);
        }

        /*public void removedictionarypositive(string username)
        {
            dictionarypositive.Remove(username);
        }

        public void removedictionarynegative(string username)
        {
            dictionarynegative.Remove(username);
        }*/

        public DataTable Usercatrylist()
        {
            return usercatrylist;
        }
        public DataTable Travellist()
        {
            return travellist;
        }
        public DataTable Relationlist()
        {
            return relationlist;
        }
        public DataTable Partylist()
        {
            return partylist;
        }

        public DataTable Thinkllist()
        {
            return thinklist;
        }
        public DataTable Foodlist()
        {
            return foodlist;
        }
        
        public DataTable Otherlist()
        {
            return otherlist;
        }
        public DataTable Blogwritterlist()
        {
            return blogwritterlist;
        }
        //this logic must change after website get enough user
        public DataTable Newbloglist()
        {
            return newbloglist;
        }
        //this logic must change after website get enough user
        public DataTable Popularbloglist()
        {
            return popularbloglist;
        }
        /// <summary>
        /// clear old records and fill up new 
        /// </summary>
        public void filltravellist()
        {
            if (travellist != null)
            {
                travellist.Clear();
            }
            travellist = dataAccess.GetBlogByCategory("travel");
        }
        public void fillrelationlist()
        {
            if (relationlist != null)
            {
                relationlist.Clear();
            }
            relationlist = dataAccess.GetBlogByCategory("relation");
        }
        public void fillpartylist()
        {
            if (partylist != null)
            {
                partylist.Clear();
            }
            partylist = dataAccess.GetBlogByCategory("party");
        }
        public void fillfoodllist()
        {
            if (foodlist != null)
            {
                foodlist.Clear();
            }
            foodlist = dataAccess.GetBlogByCategory("food");
        }
        public void fillthinklist()
        {
            if (thinklist != null)
            {
                thinklist.Clear();
            }
            relationlist = dataAccess.GetBlogByCategory("think");
        }
        public void fillotherlist()
        {
            if (otherlist != null)
            {
                otherlist.Clear();
            }
            otherlist = dataAccess.GetBlogByCategory("other");
        }
        public void fillblogwritterlist()
        {
            if (blogwritterlist != null)
            {
                blogwritterlist.Clear();
            }
            blogwritterlist = dataAccess.GetBlogWritters();
        }
        //this logic must change after website get enough user
        public void fillnewbloglist()
        {
            if (newbloglist != null)
            {
                newbloglist.Clear();
            }
            newbloglist = dataAccess.GetBlogs();
        }
        //this logic must change after website get enough user
        public void fillpopularbloglist()
        {
            if (popularbloglist != null)
            {
                popularbloglist.Clear();
            }
            popularbloglist = dataAccess.GetBlogsbyComment(SqlAd);
        }
       //get man and lady list
        public List<string> Manlist()
        {
            return manlist;
        }

        public List<string> Womanlist()
        {
            return ladylist;
        }
        //add to kvinne blog
        public void AddToLadyList(string ladyuser)
        {
            //lock (ladylist)
            //{
                ladylist.Add(ladyuser);
            //}
        }

        //add to man blog
        public void AddToManList(string manuser)
        {
            //lock (manlist)
            //{
                manlist.Add(manuser);
            //}
        }

        

        #endregion 

        #region non-override Usernamee methods
        /// <summary>
        /// add a mail object to the out-mail list
        /// </summary>
        /// <param name="outnew"></param>
        public DataTable GetTodaysBlogs()
        {
            DataTable mytable = dataAccess.GetTodaysBlogs(SqlAd);
            return mytable;
        }

        public DataTable GetByUserBlogcategory(string Username, string Blogcategory)
        {
            DataTable mytable = dataAccess.GetByUserBlogType(Username, SqlAd, Blogcategory);
            return mytable;
        }

        public DataTable GetByBlogcategory(string Blogcategory)
        {
            DataTable mytable = dataAccess.GetBlogByCategory(Blogcategory);
            return mytable;
        }

        public DataTable GetByBlogTitleUser(string Username, string Blogtitle)
        {
            DataTable mytable = dataAccess.GetBlogByTitleUser(Username, SqlAd, Blogtitle);
            return mytable;
        }

        //get all topic blogs
        public DataTable GetTopicBlog()
        {
            DataTable mytable = dataAccess.GetTopicBlogs();
            return mytable;
        }

        public DataTable GetByUsername(string Username)
        {
            DataTable mytable = dataAccess.GetBlogsByUsername(Username, SqlAd);
            return mytable;
        }

        public int CountMyBlogs(string Username)
        {
            int blogcount = dataAccess.CountMyBlogs(Username, SqlAd);
            return blogcount;
        }

        public DataTable GetMyFavoriteBlogs(string Username)
        {
            DataTable mytable = dataAccess.GetFavoriteBlog(Username, SqlAd);
            return mytable;
        }

        public DataTable GetBlogByUserTitle(string Username, string Blogtitle)
        {
           DataTable mytable = dataAccess.GetBlogByUserTitle(Username, SqlAd, Blogtitle);
           return mytable;
        }

        public DataTable GetBlogNew(int id)
        {
            DataTable mytable = dataAccess.GetBlogNew(SqlAd, id);
            return mytable;
        }

      
        public DataTable SearchBlogByUsername(string Username)
        {
            DataTable mytable = dataAccess.SearchBlogByUser(Username, SqlAd);
            return mytable;
        }

        public DataTable SearchBlogByTitle(string Blogtitle)
        {
            DataTable mytable = dataAccess.SearchBlogByTitle(Blogtitle, SqlAd);
            return mytable;
        }
        public Blog Find(string path)
        {

            DataTable table = dataAccess.GetBlogsByPath(path);
            if (table.Rows.Count == 1)
            {
                return new Blog(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString(), DateTime.Parse(table.Rows[0][4].ToString()), table.Rows[0][5].ToString(), table.Rows[0][6].ToString(), table.Rows[0][7].ToString());
            }
            else
            {
                //throw new Exception("Bloggen finnes ikke");
                return null;
            }
        }

       

        //create blog id
        public int CreateBlogId()
        {
            int id = dataAccess.GetId(TableName, SqlAd);
            return id;
        }

        //get all blogs
        public DataTable GetAllBlogs()
        {
            DataTable table = dataAccess.GetTable("Bloginfo", SqlAd);
            return table;
        }

        //get blogid table sorted by comment number
        public DataTable GetBlogsByComment()
        {
            DataTable mytable = dataAccess.GetBlogsbyComment(SqlAd);
            return mytable;
        }

        //get blog by id
        public DataTable GetBlogById(int id)
        {
            DataTable mytable = dataAccess.GetBlogbyId(SqlAd, id);
            return mytable;
        }

        public DataTable GetBlogByTitle(string title)
        {
            DataTable mytable = dataAccess.GetBlogByTitle(SqlAd, title);
            return mytable;
        }


     
        #endregion


    }
}
