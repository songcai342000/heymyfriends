using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace vennobjects
{
     [Serializable]
    public class Grantkey: Idbase
    {
        #region variables
      
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

         private string keystatus;
        public string Keystatus
        {
            get
            {
                return keystatus;
            }
            set
            {
                keystatus = value;
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
        public Grantkey() : base() { }
        public Grantkey(string Username)
        {
            username = Username;
        }
        public Grantkey(int Id, string Username, string Favoritename, string Keystatus)
            : base(Id)
        {
            username = Username;
            favoritename = Favoritename;
            keystatus = Keystatus;
        }
        #endregion
         #region methods
        public DataTable Getkeyid()
        {
            DataTable table = dataAccess.Getkeyid();
            return table;
        }
     
        public DataTable Getkeys(string Username)
        {
            DataTable table = dataAccess.GetKeysByUser(Username);
            return table;
        }
        public DataTable Getmykey(string Favoritename, string Username)
        {
            DataTable table = dataAccess.Getmykey(Favoritename, Username);
            return table;
        }
        public void Addkey(int Id, string Username, string Favoritename, string Key)
        {
            dataAccess.AddKeys(Id, Username, Favoritename, Key);
        }
        public void Updatekey(string Username, string Favoritename)
        {
            dataAccess.UpdateKeyByUser(Keystatus, Username, Favoritename);
        }
        #endregion
    
    }
}


