using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess
{
    public class dataAccess
    {
        #region ConnectionString
        private static string connectionString = "Data Source=MHELENEM2-PC\\SQLEXPRESS;Initial Catalog=db169342;Integrated Security=True";
        //private static string connectionString = "Server=204.93.174.60;Database=vennjia1_Venner;Uid=vennjia1_Helen;Password=songpassword12";
        //private static string connectionString = "Data Source=SQL5004.Smarterasp.net;Initial Catalog=DB_9AAFFD_heymyfriendsnet;User Id=DB_9AAFFD_heymyfriendsnet_admin;Password=197011sC;";
        #endregion

        #region public methods
        public static DataTable GetTable(string tableName, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetTable(string tableName, string id, int myId, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where " + id + " = " + myId;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetById(string tableName, int id, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Id = " + id;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }


        /*
        public static DataTable Outmails()
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            DataTable table = GetById("Epostinfo", 1, SqlAd);
            DataTable outmails = table.Clone();
            return outmails;
        }*/

        public static DataTable GetByUsername(string tableName, string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Username = '" + username + "' and Id != 0";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        //get blocked users
        public static DataTable GetBlockedUsers(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select Favoritename from Favoriteinfo where Username = '" + username + "' and Favoritetype = 'blocked'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetBlogsbyComment(SqlDataAdapter SqlAd)
        {
            string commandText = "select distinct BlogId, Count(BlogId) from Commentinfo group by BlogId order by Count(BlogId)";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }
        public static DataTable CountComment(SqlDataAdapter SqlAd, int id)
        {
            string commandText = "select count(*) from Commentinfo where Id = " + id;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }


        public static DataTable GetBlogbyId(SqlDataAdapter SqlAd, int id)
        {
            string commandText = "select * from Bloginfo where Id = " + id;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

      

        //get a mail
        public static DataTable GetEpostByReceiverTime(string receiver, string time, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Epostinfo where Receiver = '" + receiver + "' and cast (Time as nvarchar(50)) = '" + time + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        //search similiar user name, all registed user have got mails
        /*public static DataTable GetSearchedEpostReceivers(SqlDataAdapter SqlAd, string searchword)
        {
            string commandText = "select DISTINCT Receiver from Epostinfo where Receiver like '%" + searchword + "%'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }*/

        //get out box mails
        public static DataTable GetEpostBySender(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Epostinfo where Username = '" + username + "' and Outboxdele = 'y' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }


        public static DataTable GetSimiliarUsernames(string receiver, SqlDataAdapter SqlAd)
        {
            string thenamestring = "";
            DataTable table = null;
            if (receiver != null && receiver.Length >= 3)
            {
                thenamestring = receiver.Substring(0, 3);
                string commandText = "select distinct receiver from Epostinfo where Receiver like '%" + thenamestring + "%' or Receiver like '%" + thenamestring + "' or Receiver like '" + thenamestring + "%'";
                table = CreateTableByQuery(commandText, SqlAd);
            }
          

            return table;
        }

        //get inbox mails
        public static DataTable GetEpostByReceiver(string receiver, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Epostinfo where Receiver = '" + receiver + "' and Inboxdele = 'y' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        //new mails
        public static DataTable GetEpostByReceiverSatus(string receiver, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Epostinfo where Receiver = '" + receiver + "' and Mailstatus = 'Not readed' and Inboxdele = 'y' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetSimilarUser(string similiarame, SqlDataAdapter SqlAd)
        {
            string thenamestring = "";
            DataTable table = null;
            if (similiarame != null && similiarame.Length >= 3)
            {
                thenamestring = similiarame.Substring(0, 3);
                string commandText = "select Username, Age, Province, Online, Blog, Album from vennjia1_Helen.Theuserinfo where Username like '%" + thenamestring + "%' or Username like '%" + thenamestring + "' or Username like '" + thenamestring + "%'";
                table = CreateTableByQuery(commandText, SqlAd);
            }
            return table;
        }

        public static DataTable GetUserinfoActiveApprove(string profilename, SqlDataAdapter SqlAd)
        {
            string commandText = "select Activate, Approve, Username from vennjia1_Helen.Theuserinfo where Username = '" + profilename + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByApprove(SqlDataAdapter SqlAd)
        {
            string commandText = "select Username from vennjia1_Helen.Theuserinfo where Approve != 'Yes' and Activate='Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetApproveinfoByUser(string theprofile, SqlDataAdapter SqlAd)
        {
            string commandText = "select Approve from  vennjia1_Helen.Theuserinfo where Username = '" + theprofile + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByAgeGender(int minage, int maxage, string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province from vennjia1_Helen.Theuserinfo where Gender = '" + gender + "' and Age >= " + minage + " and Age <= " + maxage + " and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByAge(int minage, int maxage, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province from vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetAllUserinfoByAgeGender(int minage, int maxage, string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Blog, Album from vennjia1_Helen.Theuserinfo where Gender = '" + gender + "' and Age >= " + minage + " and Age <= " + maxage + " and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetAllUserinfoByAge(int minage, int maxage, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Blog, Album  from vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetAllUserinfoByAgeGenderProvince(int minage, int maxage, string gender, string province, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Blog, Album  from vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Province = '" + province + "' and Gender = '" + gender + "' and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByProfilepic(int minage, int maxage, string gender, string province, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Album, Blog from vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Gender = '" + gender + "' and Profilepic = '1' and Province = '" + province + "' and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByProfilepic(int minage, int maxage, string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Album, Blog from vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Gender = '" + gender + "' and Profilepic = '1' and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByAlbum(int minage, int maxage, string gender, string province, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Album, Blog from vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Gender = '" + gender + "' and Album >= 1 and Province = '" + province + "' and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByAlbum(int minage, int maxage, string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Album, Blog from vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Gender = '" + gender + "' and Album >= 1 and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByBlog(int minage, int maxage, string gender, string province, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Album, Blog from vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Gender = '" + gender + "' and Blog >= 1 and Province = '" + province + "' and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserinfoByBlog(int minage, int maxage, string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Album, Blog from  vennjia1_Helen.Theuserinfo where Age >= " + minage + " and Age <= " + maxage + " and Gender = '" + gender + "' and Blog >= 1 and Activate = 'Yes' and Approve = 'Yes'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static void UpdateUserinfo(string age, string province, string gender, string profilepic, string username)
        {
            string commandText = "update vennjia1_Helen.Theuserinfo set Age = '" + age + "', Province = '" + province + "', Gender = '" + gender + "', Profilepic = '" + profilepic + "', Activate = 'Yes' where Username = '" + username + "'";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        public static void UpdateUserinfoWoman(string age, string province, string gender, string profilepic, string username)
        {
            string commandText = "update vennjia1_Helen.Theuserinfo set Age = '" + age + "', Province = '" + province + "', Gender = '" + gender + "', Profilepic = '" + profilepic + "', Activate = 'Yes', Approve = 'Yes' where Username = '" + username + "'";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        public static void UpdateUserinfoOnline(string username, string online)
        {
            string commandText = "update vennjia1_Helen.Theuserinfo set Online = '" + online + "' where Username = '" + username + "'";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        public static void UpdateUserinfoBlog(string username)
        {
            string commandText = "update vennjia1_Helen.Theuserinfo set Blog = Blog + 1 where Username = '" + username + "'";
             using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }
        public static void UpdateUserinfoAlbum(string username)
        {
            string commandText = "update vennjia1_Helen.Theuserinfo set Album = Album + 1 where Username = '" + username + "'";
             using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        public static void UpdateUserinfoDeleteAlbum(string username)
        {
            string commandText = "update vennjia1_Helen.Theuserinfo set Album = Album - 1 where Username = '" + username + "'";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        public static void UpdateUserinfoActivate(string username, string activate)
        {
            string commandText = "update vennjia1_Helen.Theuserinfo set Activate = '" + activate + "' where Username = '" + username + "'";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        public static void UpdateUserinfoApprove(string username, string approve)
        {
            string commandText = "update vennjia1_Helen.Theuserinfo set Approve = '" + approve + "' where Username = '" + username + "'";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        public static DataTable GetNewUser(string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Timestart from vennjia1_Helen.Theuserinfo where Gender = '" + gender + "' and Timestart > GETDATE() - 3 and Activate = 'Yes' and Approve = 'Yes' order by Timestart Desc";
          
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetAllNewUser(string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Blog, Album, Timestart from vennjia1_Helen.Theuserinfo where Gender = '" + gender + "' and Timestart > GETDATE() - 3 and Activate = 'Yes' and Approve = 'Yes' order by Timestart Desc";
           
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;

        }

        public static DataTable GetUserinfoByStartTime7(int minage, int maxage, string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Blog, Album, Timestart from vennjia1_Helen.Theuserinfo where Age >= '" + minage + "' and Age <= '" + maxage + "' and Gender = '" + gender + "' and Timestart > GETDATE() - 7 and Activate = 'Yes' and Approve = 'Yes' order by Timestart Desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);

            return table;
        }

        public static DataTable GetUserinfoByStartTime30(int minage, int maxage, string gender, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Age, Province, Online, Blog, Album, Timestart from vennjia1_Helen.Theuserinfo where Age >= '" + minage + "' and Age <= '" + maxage + "' and Gender = '" + gender + "' and Timestart > GETDATE() - 30 and Activate = 'Yes' and Approve = 'Yes' order by Timestart Desc";
            DataTable table =  CreateTableByQuery(commandText, SqlAd);
            
            return table;
        }
        //get history
        public static DataTable GetHistoryByTypeCategory(string type, string category, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from vennjia1_Helen.Historyinfo where Storytype = '" + type + "' and Historycategory = '" + category + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetHistoryByTypeTime(string type, string time, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from vennjia1_Helen.Historyinfo where Storytype = '" + type + "' and Time like '%" + time + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetTipsByTypeCategory(string type, string category, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from vennjia1_Helen.Historyinfo where Storytype = '" + type + "' and Historycategory = '" + category + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetTipsByTypeTime(string type, string time, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from vennjia1_Helen.Historyinfo where Storytype = '" + type + "' and Time like '%" + time + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetTodaysBlogs(SqlDataAdapter SqlAd)
        {
            string commandText = "select Id from Bloginfo where Time = GETDATE()";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetTodaysHistories(SqlDataAdapter SqlAd)
        {
            string commandText = "select Id from vennjia1_Helen.Historyinfo where Time = GETDATE()";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }


        public static DataTable GetBlogs()
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select * from Bloginfo";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetFavoriteBlogsByPath(string username, string targetpath, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Favoriteinfo where Username = '" + username + "' and Favoritename = '" + targetpath + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }


        public static DataTable GetBlogsByUsername(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select Username, Blogtitle, Blogpath, Time, Blogcategory from Bloginfo where Username = '" + username + "' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetBlogsByPath(string path)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select * from Bloginfo where Blogpath = '" + path + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetBlogWritters()
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select distinct Username from Bloginfo";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }


        public static DataTable GetByUserFavoriteType(string username, SqlDataAdapter SqlAd, string favoritetype)
        {
            string commandText = "select Favoriteinfo.Favoritename, vennjia1_Helen.Theuserinfo.Age, vennjia1_Helen.Theuserinfo.Province, vennjia1_Helen.Theuserinfo.Online, vennjia1_Helen.Theuserinfo.Profilepic, vennjia1_Helen.Theuserinfo.Album, vennjia1_Helen.Theuserinfo.Blog from Favoriteinfo inner join vennjia1_Helen.Theuserinfo on Favoriteinfo.Favoritename = vennjia1_Helen.Theuserinfo.Username where Favoriteinfo.Username = '" + username + "' and Favoritetype = '" + favoritetype + "' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

       /* public static DataTable GetByFavoriteNameType(string username, string favoritetype, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Favoriteinfo where Favoritename = '" + username + "' and Favoritetype = '" + favoritetype + "' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }*/
        //get userinfo by favoritename type
        public static DataTable GetByFavoriteNameType(string username, string favoritetype, SqlDataAdapter SqlAd)
        {
            string commandText = "select vennjia1_Helen.Theuserinfo.Username, Age, Province, Online, Profilepic, Album, Blog from vennjia1_Helen.Theuserinfo inner join Favoriteinfo on Favoriteinfo.Username =  vennjia1_Helen.Theuserinfo.Username where Favoritename = '" + username + "' and Favoritetype = '" + favoritetype + "' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }
        //my favorites
     
        /// <summary>
        /// my gifts or i am favorite to others
        /// </summary>
        /// <param name="username"></param>
        /// <param name="SqlAd"></param>
        /// <returns></returns>
      

        public static DataTable GetFavoriteByFavoritenametype(string Username, string Favoritename, string Favoritetype, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Favoriteinfo where Username = '" + Username + "' and Favoritetype = '" + Favoritetype + "' and Favoritename = '" + Favoritename + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }
        //get the person's visit record
        public static DataTable Getvisitorid()
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select count(*) from db169342.Visitorinfo";
            DataTable table = CreateTableByQuery(commandText, SqlAd);

            return table;
        }
        public static DataTable Getvisitor(string username)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select Id from db169342.Visitorinfo where Favoritename = '" + username + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);

            return table;
        }
        //get the person's visit record
        public static void AddVisitors(int id, string username, string favoritename, string time)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "insert into db169342.Visitorinfo (Id, Username, Favoritename, Time) values (" + id + ", '" + username + "', '" + favoritename + "', '" + time + "')";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        //get the person's visit record
        public static DataTable GetVisitsByUser(string username)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select vennjia1_Helen.Theuserinfo.Username, Age, Province, Online, Profilepic, Album, Blog, Visitorinfo.Time from vennjia1_Helen.Theuserinfo inner join db169342.Visitorinfo on vennjia1_Helen.Theuserinfo.Username COLLATE DATABASE_DEFAULT = vennjia1_Helen.Visitorinfo.Username COLLATE DATABASE_DEFAULT where vennjia1_Helen.Visitorinfo.Favoritename COLLATE DATABASE_DEFAULT = '" + username + "' COLLATE DATABASE_DEFAULT and   vennjia1_Helen.Theuserinfo.Activate COLLATE DATABASE_DEFAULT = 'Yes' COLLATE DATABASE_DEFAULT and   vennjia1_Helen.Theuserinfo.Approve COLLATE DATABASE_DEFAULT = 'Yes' COLLATE DATABASE_DEFAULT order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            
            return table;
        }
        //get the person's visit record
        public static void UpdateVisitorByUser(string Username, string Favoritename)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            DataTable table = new DataTable();
            string commandText = "update db169342.Visitorinfo set Time = '" + DateTime.Now.ToString() + "' where Username = '" + Username + "' and Favoritename = '" + Favoritename + "'";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }
       
        //my visitors
        public static DataTable GetVisitors(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select vennjia1_Helen.Theuserinfo.Username, Age, Province, Online, Profilepic, Album, Blog, Favoriteinfo.Time from vennjia1_Helen.Theuserinfo inner join Favoriteinfo on vennjia1_Helen.Theuserinfo.Username COLLATE DATABASE_DEFAULT = Favoriteinfo.Username COLLATE DATABASE_DEFAULT where Favoriteinfo COLLATE DATABASE_DEFAULT = '" + username + "' COLLATE DATABASE_DEFAULT and Favoritetype COLLATE DATABASE_DEFAULT = 'visitors' COLLATE DATABASE_DEFAULT and   vennjia1_Helen.Theuserinfo.Activate COLLATE DATABASE_DEFAULT = 'Yes' COLLATE DATABASE_DEFAULT and   vennjia1_Helen.Theuserinfo.Approve COLLATE DATABASE_DEFAULT = 'Yes' COLLATE DATABASE_DEFAULT order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        //count my visitors
        public static DataTable CountVisitors(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select count(distinct Username) from Favoriteinfo where Favoritename = '" + username + "' and Username != Favoritename and Favoritetype = 'visitors'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        #region grantkeytable
        //keys table
        //get the person's visit record
        public static DataTable Getkeyid()
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select count(*) from db169342.Keyinfo";
            DataTable table = CreateTableByQuery(commandText, SqlAd);

            return table;
        }
       
        //get the person's visit record
        public static void AddKeys(int id, string username, string favoritename, string keystatus)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "insert into db169342.Keyinfo (Id, Username, Favoritename, Keystatus) values (" + id + ", '" + username + "', '" + favoritename + "', '" + keystatus + "')";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }
        //pick my key to one album
        public static DataTable Getmykey(string favoritename, string username)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select Id from db169342.Keyinfo where Username = '" + favoritename + "' and Favoritename = '" + username + "' and Keystatus = 'albumkey'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);

            return table;
        }
        //get the persons i have key
        public static DataTable GetKeysByUser(string username)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select vennjia1_Helen.Theuserinfo.Username, Age, Province, Online, Profilepic, Album, Blog, Keyinfo.Key from vennjia1_Helen.Theuserinfo inner join db169342.Keyinfo on vennjia1_Helen.Theuserinfo.Username COLLATE DATABASE_DEFAULT = db169342.Keyinfo.Username COLLATE DATABASE_DEFAULT where db169342.Keyinfo.Favoritename COLLATE DATABASE_DEFAULT = '" + username + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);

            return table;
        }
        //get the person's visit record
        public static void UpdateKeyByUser(string key, string Username, string Favoritename)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            DataTable table = new DataTable();
            string commandText = "update db169342.Keyinfo set Keystatus = '" + key + "' where Username = '" + Username + "' and Favoritename = '" + Favoritename + "'";
            using (SqlConnection SqlConn1 = new SqlConnection(connectionString))
            {
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlComm.ExecuteNonQuery();
            }
        }

        #endregion

        public static int CountMyBlogs(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select count(*) from Bloginfo where Username = '" + username + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return int.Parse(table.Rows[0][0].ToString());
        }

        public static int CountMyInbox(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select count(*) from Epostinfo where Receiver = '" + username + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return int.Parse(table.Rows[0][0].ToString());
        }

        public static int CountMyOutbox(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select count(*) from Epostinfo where Username = '" + username + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return int.Parse(table.Rows[0][0].ToString());
        }

        //get blogs by username and category
        public static DataTable GetByUserBlogType(string username, SqlDataAdapter SqlAd, string blogtype)
        {
            string commandText = "select * from Bloginfo where Username = '" + username + "' and Blogcategory = '" + blogtype + "' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }


        public static DataTable GetFavoriteBlog(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select Blogtitle, Blogpath, Bloginfo.Username, Bloginfo.Time from Bloginfo inner join Favoriteinfo on Bloginfo.Blogpath = Favoriteinfo.Favoritename where Favoriteinfo.Username = '" + username
                + "' and Favoriteinfo.Favoritetype = 'myfavoriteblogs'";

            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetBlogByUserTitle(string username, SqlDataAdapter SqlAd, string blogtitle)
        {
            string commandText = "select Blogpath from Bloginfo where Username = '" + username + "' and Blogtitle = '" + blogtitle + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetBlogByTitle(SqlDataAdapter SqlAd, string blogtitle)
        {
            string commandText = "select * from Bloginfo where Blogtitle = '" + blogtitle + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetBlogByTitleUser(string username, SqlDataAdapter SqlAd, string title)
        {
            string commandText = "select Blogpath from Bloginfo where Username = '" + username + "' and Blogtitle = '" + title + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetBlogByCategory(string category)
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select * from Bloginfo where Blogcategory = '" + category + "' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetTopicBlogs()
        {
            SqlDataAdapter SqlAd = new SqlDataAdapter();
            string commandText = "select * from Bloginfo where Blogcategory != 'other' and Blogcategory != 'relation' and Blogcategory != 'activity' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable SearchBlogByUser(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Bloginfo where Username like '%" + username + "%' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable SearchBlogByTitle(string blogtitle, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Bloginfo where Blogtitle like '%" + blogtitle + "%' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetBlogNew(SqlDataAdapter SqlAd, int id)
        {
            string commandText = "select * from Bloginfo where Id > '" + id + "' order by Time desc";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetCommentByBlogUserTime(string username, SqlDataAdapter SqlAd, DateTime time)
        {
            string commandText = "select Commentinfo.Username, Commentinfo.Time, Commentinfo.Comment from Commentinfo inner join Bloginfo on Bloginfo.Id = Commentinfo.BlogId where Bloginfo.Username = '" + username + "' and Bloginfo.Time = '" + time + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static int GetId(string tableName, SqlDataAdapter SqlAd)
        {
            //DataTable table = CreateTableByQuery(commandText, SqlAd);
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                string commandText = "select Max(Id) from " + tableName;
                SqlCommand SqlComm;
                SqlConn.Open();
                SqlComm = SqlConn.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlDataAdapter Sqlad = new SqlDataAdapter();
                Sqlad.SelectCommand = SqlComm;
                DataSet ds = new DataSet();
                Sqlad.Fill(ds);
                int con;
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count >= 0)
                {

                    if (ds.Tables[0].Rows[0][0].ToString() == "")
                    {
                        con = 1;
                        return con;
                    }
                    else if (ds.Tables[0].Rows[0][0] == null)
                    {
                        con = 1;
                        return con;
                    }
                    else
                    {
                        con = int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                        return con;
                    }
                }
                if (ds.Tables[0] == null)
                {
                    con = 1;
                    return con;
                }
                else
                {
                    con = -1;
                    return con;
                }
            }
        }

        static SqlConnection SqlConn1;
        public static DataTable ConstruById(string tableName, int id, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Id = " + id;
            SqlConn1 = new SqlConnection(connectionString);
            if (SqlConn1 != null)
            {
                DataTable table = new DataTable();
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlAd.SelectCommand = SqlComm;
                SqlAd.Fill(table);
                return table;
            }
            else
            {
                return null;
            }
        }

        public static DataTable ConstruByUsername(string tableName, string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Username = '" + username + "'";
            SqlConn1 = new SqlConnection(connectionString);
            if (SqlConn1 != null)
            {
                DataTable table = new DataTable();
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlAd.SelectCommand = SqlComm;
                SqlAd.Fill(table);
                return table;
            }
            else
            {
                return null;
            }
        }

        public static DataTable ConstruByReceiver(string tableName, string receiver, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Receiver = '" + receiver + "'";
            SqlConn1 = new SqlConnection(connectionString);
            if (SqlConn1 != null)
            {
                DataTable table = new DataTable();
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlAd.SelectCommand = SqlComm;
                SqlAd.Fill(table);
                return table;
            }
            else
            {
                return null;
            }
        }

        public static void Update(DataTable table, SqlDataAdapter SqlAd)
        {
            if (SqlConn1 != null)
            {
                try
                {
                    SqlCommandBuilder cb = new SqlCommandBuilder(SqlAd);
                    SqlAd.Update(table);
                    table.AcceptChanges();
                }
                catch
                {
                }
                finally
                {
                    SqlConn1.Close();
                    //SqlConn1.Dispose();
                }
            }
        }

        public static void DeleteOutMail(string tableName, string username, DataTable table, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Username = '" + username + "' order by Time desc";
            SqlConn1 = new SqlConnection(connectionString);
            if (SqlConn1 != null)
            {
                DataTable table0 = new DataTable();
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlAd.SelectCommand = SqlComm;
                SqlAd.Fill(table0);
                table0 = table;
                SqlCommandBuilder cb = new SqlCommandBuilder(SqlAd);
                SqlAd.Update(table0);
                table.AcceptChanges();
                SqlConn1.Close();
                //SqlConn1.Dispose();
            }
        }

        public static void DeleteInMail(string tableName, string username, DataTable table, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Receiver = '" + username + "' order by Timestart desc";
            SqlConn1 = new SqlConnection(connectionString);
            if (SqlConn1 != null)
            {
                DataTable table0 = new DataTable();
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlAd.SelectCommand = SqlComm;
                SqlAd.Fill(table0);
                table0 = table;
                SqlCommandBuilder cb = new SqlCommandBuilder(SqlAd);
                SqlAd.Update(table0);
                table.AcceptChanges();
                SqlConn1.Close();
                //SqlConn1.Dispose();
            }
        }
        public static DataTable GetNewMenWomen(SqlDataAdapter SqlAd)
        {
            string commandText = "select * from vennjia1_Helen.Theuserinfo where Timestart > GETDATE() - 30 and Activate = 'Yes' and Approve = 'Yes' order by Timestart desc";

            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;

        }

        public static DataTable GetNewProfilepic(SqlDataAdapter SqlAd)
        {
            string commandText = "select * from vennjia1_Helen.Theuserinfo where Timestart > GETDATE() - 30 and Activate = 'Yes' and Approve = 'Yes' order by Time desc";

            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;

        }

        #endregion

        #region Local Helper Methods

        protected static DataTable CreateTableByQuery(string commandText, SqlDataAdapter SqlAd)
        {
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    DataTable table = new DataTable();
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlAd.SelectCommand = SqlComm;
                    SqlAd.Fill(table);
                    //SqlConn.Close();
                    //SqlConn.Dispose();
                    return table;
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

    }
}
