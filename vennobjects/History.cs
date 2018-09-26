using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    [Serializable]
    public class History: Idbase
    {
        #region properites
  
        private string time;
        public string Time
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

       
        private string historytitle;
        public string Historytitle
        {
            get
            {
                return historytitle;
            }
            set
            {
                historytitle = value;
            }
        }

        private string historypath;
        public string Historypath
        {
            get
            {
                return historypath;
            }
            set
            {
                historypath = value;
            }
        }

        private string storytype;
        public string Storytype
        {
            get
            {
                return storytype;
            }
            set
            {
                storytype = value;
            }
        }

        private string historycategory;
        public string Historycategory
        {
            get
            {
                return historycategory;
            }
            set
            {
                historycategory = value;
            }
        }

       
        #endregion

        #region constructor
        public History() : base() { }
        public History(int Id, string Historytitle, string Historypath, string Storytype, string Historycategory, string Time)
            : base(Id)
        {
            historytitle = Historytitle;
            historypath = Historypath;
            storytype = Storytype;
            historycategory = Historycategory;
            time = Time;
        }
        #endregion
    }
}
