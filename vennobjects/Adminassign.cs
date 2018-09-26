using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public sealed class Adminassign
    {
       
        public static string Recommand1;
        public static string Recommand2;
        public static string Recommand3;
        public static string Recommand1title;
        public static string Recommand2title;
        public static string Recommand3title;
        public static string Selectedcontent1;
        public static string Selectedcontent2;
        public static string Tematitle;
        public static int Man1;
        public static int Man2;
        public static int Man3;
        public static int Lady1;
        public static int Lady2;
        public static int Lady3;
        //doesn't need topiclink
        //public static string Topiclink;
        public static string Relationlink;
        public static string Thinklink;
        public static string Otherlink;
        public static string Travellink;
        public static string Partylink;
        public static string Foodlink;

        //advertisement
        public static string adurl1;
        public static string adtit1;
        public static string adtxt1;
        public static string addom1;

        public static string adurl2;
        public static string adtit2;

        public static string adtxt2;
        public static string addom2;

        public static string adurl3;
        public static string adtit3;

        public static string adtxt3;
        public static string addom3;

        public static string adurl4;
        public static string adtit4;

        public static string adtxt4;
        public static string addom4;

        public static string adurl5;
        public static string adtit5;

        public static string adtxt5;
        public static string addom5;

        public static string adurl6;
        public static string adtit6;

        public static string adtxt6;
        public static string addom6;

        public static string adurl7;
        public static string adtit7;

        public static string adtxt7;
        public static string addom7;

        public static string adurl8;
        public static string adtit8;

        public static string adtxt8;
        public static string addom8;

        public static string adurl9;
        public static string adtit9;

        public static string adtxt9;
        public static string addom9;

        public static string adurl10;
        public static string adtit10;

        public static string adtxt10;
        public static string addom10;

        public static string adurl11;
        public static string adtit11;

        public static string adtxt11;
        public static string addom11;

        public static string adurl12;
        public static string adtit12;

        public static string adtxt12;
        public static string addom12;

        public static string adurl13;
        public static string adtit13;

        public static string adtxt13;
        public static string addom13;

        public static string adurl14;
        public static string adtit14;

        public static string adtxt14;
        public static string addom14;

        public static string adurl15;
        public static string adtit15;

        public static string adtxt15;
        public static string addom15;

        public static string adurl16;
        public static string adtit16;

        public static string adtxt16;
        public static string addom16;

        public static string adurl17;
        public static string adtit17;

        public static string adtxt17;
        public static string addom17;

        public static string adurl18;
        public static string adtit18;

        public static string adtxt18;
        public static string addom18;
        private static int Trafic;
        public int gettrafic()
        {
            return Trafic;
        }

        public int changetrafic(int thenumber)
        {
            Trafic = thenumber;
            return Trafic;
        }

        //handel new register list, new registered and approved women and men list
        private static List<string> Sessionusers = new List<string>();
        private static List<string> Appnewwomen = new List<string>();
        private static List<string> Appnewmen = new List<string>();

        public void Add(string sessionuser)
        {
            Sessionusers.Add(sessionuser);
        }

        public void Remove(string sessionuser)
        {
            Sessionusers.Remove(sessionuser);
        }

        public List<string> Getsessionusers()
        {
            return Sessionusers;
        }

        //add approvednew to newwomen list
        public void Addappnewwomen(string newappname)
        {
            Appnewwomen.Add(newappname);
        }

        public void Removeappnewwomen(string newappname)
        {
            Appnewwomen.Remove(newappname);
        }

        public List<string> Getappnewwomen()
        {
            return Appnewwomen;
        }

        //add approvednew to newmen list
        public void Addappnewmen(string newappname)
        {
            Appnewmen.Add(newappname);
        }

        public void Removeappnewmen(string newappname)
        {
            Appnewmen.Remove(newappname);
        }

        public List<string> Getappnewmen()
        {
            return Appnewmen;
        }

        private static List<string> notapproved = new List<string>();

        public void AddNonApp(string sessionuser)
        {
            Sessionusers.Add(sessionuser);
        }

        public void RemoveNonApp(string sessionuser)
        {
            Sessionusers.Remove(sessionuser);
        }

        public List<string> GetNonApp()
        {
            return Sessionusers;
        }
        /*private Singleton(string Recommand1, string Recommand2, string Recommand3, string Recommand1title, string Recommand2title, string Selectedcontent1, string Selectedcontent2, 
            string Recommand3title, string Tematitle, string Man1, string Man2, string Man3, string Lady1, string Lady2, string Lady3, string Topiclink, 
            string Relationlink, string Activitylink, string Otherlink)
        {
        }*/

        /*public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instance)
                    {

                        if (instance == null)
                        {
                            instance = new Singleton(Recommand1, Recommand2, Recommand3, Recommand1title, Recommand2title, Recommand3title, Tematitle,
                                Selectedcontent1, Selectedcontent2, Man1, Man2, Man3, Lady1, Lady2, Lady3, Topiclink, Relationlink, Activitylink, Otherlink);
                        }
                    }
                    return instance;
                }
                else
                {
                    return null;
                }
            }
        }*/
    }
}
