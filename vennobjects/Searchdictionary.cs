using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public class Searchdictionary
    {
        private static Dictionary<string, Searchgeneral> dicsearch = new Dictionary<string, Searchgeneral>();

        public Dictionary<string, Searchgeneral> getdicsearch()
        {
            return dicsearch;
        }

        public void filldicsearch(string Username, Searchgeneral Mysearch)
        {
            if (dicsearch != null && !dicsearch.ContainsKey(Username))
            {
                dicsearch.Add(Username, Mysearch);
            }
        }

        public void removedicsearch(string Username)
        {
            if (dicsearch != null && dicsearch.ContainsKey(Username))
            {
                dicsearch.Remove(Username);
            }
        }

        //search blog by keyword
        private static Dictionary<string, string> dicblogkeyword = new Dictionary<string, string>();

        public Dictionary<string, string> getdickeyword()
        {
            return dicblogkeyword;
        }

        public void filldickeyword(string Username, string Mykeyword)
        {
            if (dicblogkeyword != null && !dicblogkeyword.ContainsKey(Username))
            {
                dicblogkeyword.Add(Username, Mykeyword);
            }
        }

        public void removedickeyword(string Username)
        {
            if (dicblogkeyword != null && dicblogkeyword.ContainsKey(Username))
            {
                dicblogkeyword.Remove(Username);
            }
        }

        //search blog by sort
        private static Dictionary<string, string> dicblogsort = new Dictionary<string, string>();

        public Dictionary<string, string> getdicblogsort()
        {
            return dicblogsort;
        }

        public void filldicblogsort(string Username, string Mysort)
        {
            if (dicblogsort != null && !dicblogsort.ContainsKey(Username))
            {
                dicblogsort.Add(Username, Mysort);
            }
        }

        public void removedicblogsort(string Username)
        {
            if (dicblogsort != null && dicblogsort.ContainsKey(Username))
            {
                dicblogsort.Remove(Username);
            }
        }

        //search blog by path
        private static Dictionary<string, string> dicblogpath = new Dictionary<string, string>();

        public Dictionary<string, string> getdicblogpath()
        {
            return dicblogpath;
        }

        public void filldicblogpath(string Username, string Mypath)
        {
            if (dicblogpath != null && !dicblogpath.ContainsKey(Username))
            {
                dicblogsort.Add(Username, Mypath);
            }
        }

        public void removedicblogpath(string Username)
        {
            if (dicblogpath != null && dicblogpath.ContainsKey(Username))
            {
                dicblogpath.Remove(Username);
            }
        }
    }
}
