
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    [Serializable]
    public class userselectedparameters
    {
        private string usernameparameter, ageparameter, cityparameter, onlineParameter, albumParameter, blogparameter;
        private string time;
        public string UsernameParameter
        {
            get { return usernameparameter; }
            set { usernameparameter = value; }
        }

        public string AgeParameter
        {
            get { return ageparameter; }
            set { ageparameter = value; }
        }

        public string CityParameter
        {
            get { return cityparameter; }
            set { cityparameter = value; }
        }

        public string OnlineParameter
        {
            get { return onlineParameter; }
            set { onlineParameter = value; }
        }

        public string AlbumParameter
        {
            get { return albumParameter; }
            set { albumParameter = value; }
        }

        public string BlogParameter
        {
            get { return blogparameter; }
            set { blogparameter = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public userselectedparameters(string UsernameParameter, string AgeParameter, string CityParameter, string OnlineParameter, string AlbumParameter, string BlogParameter, string Time)
        {
            usernameparameter = UsernameParameter;
            ageparameter = AgeParameter;
            cityparameter = CityParameter;
            onlineParameter = OnlineParameter;
            albumParameter = AlbumParameter;
            blogparameter = BlogParameter;
            time = Time;
        }
    }    

}
