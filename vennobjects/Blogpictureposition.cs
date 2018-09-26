using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public class Blogpictureposition
    {

        private int position;
        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        private int pathlen;
        public int Pathlen
        {
            get
            {
                return pathlen;
            }
            set
            {
                pathlen = value;
            }
        }

        private List<Blogpictureposition> blogpiclist;
        public List<Blogpictureposition> Blogpiclist
        {
            get
            {
                return blogpiclist;
            }
            set
            {
                blogpiclist = value;
            }
        }

        public Blogpictureposition()
        {
          
        }

        public Blogpictureposition(int Position, int Pathlen)
        {
            position = Position;
            pathlen = Pathlen;
        }

        private static Dictionary<string, List<Blogpictureposition>> myblogpictures = new Dictionary<string, List<Blogpictureposition>>();
        public Dictionary<string, List<Blogpictureposition>> getmyblogpictures()
        {
            return myblogpictures;
        }

        public void fillmyblogpictures(string Username, List<Blogpictureposition> blogpicdata)
        {
            myblogpictures.Add(Username, blogpicdata);
        }

        public void removeblogpictures(string Username)
        {
            myblogpictures.Remove(Username);
        }
    }
}
