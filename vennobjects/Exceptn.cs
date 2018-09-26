using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public class Exceptn: Idbase
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

        private string exmessage;
        public string Exmessage
        {
            get
            {
                return exmessage;
            }
            set
            {
                exmessage = value;
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

        #endregion

        #region constructor
        public Exceptn() : base() { }
        public Exceptn(int Id, string Username, string Exmessage, DateTime Time): base(Id)
        {
            username = Username;
            exmessage = Exmessage;
            time = Time;
        }
        #endregion
    }
}
