using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    [Serializable]
    public class Blog: Idbase
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

        private string blogtitle;
        public string Blogtitle
        {
            get
            {
                return blogtitle;
            }
            set
            {
                blogtitle = value;
            }
        }

        private string blogpath;
        public string Blogpath
        {
            get
            {
                return blogpath;
            }
            set
            {
                blogpath = value;
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

        private string blogcategory;
        public string Blogcategory
        {
            get
            {
                return blogcategory;
            }
            set
            {
                blogcategory = value;
            }
        }

        //positive or negative meaning on a topic
        private string blogtopicmeaning;
        public string Blogtopicmeaning
        {
            get
            {
                return blogtopicmeaning;
            }
            set
            {
                blogtopicmeaning = value;
            }
        }
        #endregion

        #region constructor
        public Blog() : base() { }
        public Blog(int Id, string Username, string Blogtitle, string Blogpath, DateTime Time, string Blogcategory, string Blogtopicmeaning, string Picturepath): base(Id)
        {
            username = Username;
            blogtitle = Blogtitle;
            blogpath = Blogpath;
            time = Time;
            blogcategory = Blogcategory;
            blogtopicmeaning = Blogtopicmeaning;
            picturepath = Picturepath;
        }
        #endregion
    }
}
