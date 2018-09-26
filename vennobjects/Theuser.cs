using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    [Serializable]
    public class Theuser: Idbase
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
        private string age;
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        [NonSerialized]
        private string province;
        public string Province
        {
            get
            {
                return province;
            }
            set
            {
                province = value;
            }
        }

        [NonSerialized]
        private string profilepic;
        public string Profilepic
        {
            get
            {
                return profilepic;
            }
            set
            {
                profilepic = value;
            }
        }

        [NonSerialized]
        private string online;
        public string Online
        {
            get
            {
                return online;
            }
            set
            {
                online = value;
            }
        }

      

        [NonSerialized]
        private int blog;
        public int Blog
        {
            get
            {
                return blog;
            }
            set
            {
                blog = value;
            }
        }

        [NonSerialized]
        private int album;
        public int Album
        {
            get
            {
                return album;
            }
            set
            {
                album = value;
            }
        }

        [NonSerialized]
        private string gender;
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        [NonSerialized]
        private DateTime timestart;
        public DateTime Timestart
        {
            get
            {
                return timestart;
            }
            set
            {
                timestart = value;
            }
        }

        private string activate;
        public string Activate
        {
            get
            {
                return activate;
            }
            set
            {
                activate = value;
            }
        }

        private string approve;
        public string Approve
        {
            get
            {
                return approve;
            }
            set
            {
                approve = value;
            }
        }


        #endregion

        #region constructor
        public Theuser() : base() { }
        public Theuser(int Id, string Username, string Age, string Province, string Profilepic, string Online, int Album, int Blog, string Gender, DateTime Timestart, string Activate, string Approve)
            : base(Id)
        {
            username = Username;
            age = Age;
            province = Province;
            online = Online;
            profilepic = Profilepic;
            blog = Blog;
            album = Album;
            gender = Gender;
            timestart = Timestart;
            activate = Activate;
            approve = Approve;
        }
        #endregion
    }
}
