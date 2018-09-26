using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    [Serializable]
    public class Favorite: Idbase
    {
        #region properites
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

        [NonSerialized]
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

        private string favoritetype;
        public string Favoritetype
        {
            get
            {
                return favoritetype;
            }
            set
            {
                favoritetype = value;
            }
        }


        private DateTime time;
        public DateTime Time
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
        #endregion

        #region constructor
        public Favorite() : base() { }
        public Favorite(int Id, string Username, string Favoritename, string Favoritetype, DateTime Time)
            : base(Id)
        {
            username = Username;
            favoritename = Favoritename;
            favoritetype = Favoritetype;
            time = Time;
        }
        #endregion
    }
}
