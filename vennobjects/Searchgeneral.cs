using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public class Searchgeneral
    {
        /*private string searchword;
        public string Searchword
        {
            get
            {
                return searchword;
            }
            set
            {
                searchword = value;
            }
        }*/

        private string min;
        public string Min
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
            }
        }

        private string max;
        public string Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
            }
        }

        private string selectedprovince;
        public string Selectedprovince
        {
            get
            {
                return selectedprovince;
            }
            set
            {
                selectedprovince = value;
            }
        }

        private string selectedgender;
        public string Selectedgender
        {
            get
            {
                return selectedgender;
            }
            set
            {
                selectedgender = value;
            }
        }

        private string selectedmembershipstart;
        public string Selectedmembershipstart
        {
            get
            {
                return selectedmembershipstart;
            }
            set
            {
                selectedmembershipstart = value;
            }
        }

        private string selectprofile;
        public string Selectprofile
        {
            get
            {
                return selectprofile;
            }
            set
            {
                selectprofile = value;
            }
        }

        public Searchgeneral(string Min, string Max, string Selectedprovince, string Selectedgender, string Selectedmembershipstart, 
            string Selectprofile)
        {
            min = Min;
            max = Max;
            selectedprovince = Selectedprovince;
            selectedgender = Selectedgender;
            selectedmembershipstart = Selectedmembershipstart;
            selectprofile = Selectprofile;
        }
        
    }
}
