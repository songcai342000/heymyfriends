using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace vennobjects
{
    [Serializable]
    public class Visitor: Idbase
    {
        #region variables
        private string time;
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        private string favoritename;
        public string Favoritename
        {
            get
            {
                return favoritename;
            }
            set
            {
                favoritename = value;
            }
        }

        #endregion
        #region constructor
        public Visitor() : base() { }
        public Visitor(string Username)
        {
            username = Username;
        }
        public Visitor(int Id, string Username, string Favoritename, string Time)
            : base(Id)
        {
            username = Username;
            favoritename = Favoritename;
            time = Time;
        }
        #endregion
         #region methods
        public DataTable Getvisitorid()
        {
            DataTable table = dataAccess.Getvisitorid();
            return table;
        }
        public DataTable Getvisitor(string Username)
        {
            DataTable table = dataAccess.Getvisitor(Username);
            return table;
        }
        public DataTable Getvisitors(string Username)
        {
            DataTable table = dataAccess.GetVisitsByUser(Username);
            return table;
        }
        public void Addvisitor(int Id, string Username, string Favoritename, string Time)
        {
            dataAccess.AddVisitors(Id, Username, Favoritename, Time);
        }
        public void Updatetvisitor(string Username, string Favoritename)
        {
            dataAccess.UpdateVisitorByUser(Username, Favoritename);
        }
        #endregion
    
    }
}
