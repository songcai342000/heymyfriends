using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    [Serializable]
    public class Comment: Idbase
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
        private int blogid;
        public int BlogId
        {
            get
            {
                return blogid;
            }
            set
            {
                blogid = value;
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

        private string commentcontent;
        public string Commentcontent
        {
            get
            {
                return commentcontent;
            }
            set
            {
                commentcontent = value;
            }
        }

        #endregion

        #region constructor
        public Comment() : base() { }
        public Comment(int Id, string Username, int BlogId, DateTime Time, string Commentcontent): base(Id)
        {
            username = Username;
            blogid = BlogId;
            time = Time;
            commentcontent = Commentcontent;
        }
        #endregion
    }
}
