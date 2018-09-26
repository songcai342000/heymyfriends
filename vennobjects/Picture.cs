using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    [Serializable]
    public class Picture : Idbase
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

        private string picturepath;
        public string Picturepath
        {
            get
            {
                return picturepath;
            }
            set
            {
                picturepath = value;
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }


        #endregion

        #region constructor
        public Picture() : base() { }
        public Picture(int Id, string Username, string Picturepath, DateTime Time, string Description)
            : base(Id)
        {
            username = Username;
            time = Time;
            picturepath = Picturepath;
            description = Description;
        }
        #endregion
    }
}
