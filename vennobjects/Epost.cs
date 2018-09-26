using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    [Serializable]
    public class Epost: Idbase
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

        private string receiver;
        public string Receiver
        {
            get
            {
                return receiver;
            }
            set
            {
                receiver = value;
            }
        }

        [NonSerialized]
        private string mailtitle;
        public string Mailtitle
        {
            get
            {
                return mailtitle;
            }
            set
            {
                mailtitle = value;
            }
        }

        [NonSerialized]
        private string mailcontent;
        public string Mailcontent
        {
            get
            {
                return mailcontent;
            }
            set
            {
                mailcontent = value;
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

        [NonSerialized]
        private string mailstatus;
        public string Mailstatus
        {
            get
            {
                return mailstatus;
            }
            set
            {
                mailstatus = value;
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

        [NonSerialized]
        private string inboxdele;
        public string Inboxdele
        {
            get
            {
                return inboxdele;
            }
            set
            {
                inboxdele = value;
            }
        }

        [NonSerialized]
        private string outboxdele;
        public string Outboxdele
        {
            get
            {
                return outboxdele;
            }
            set
            {
                outboxdele = value;
            }
        }

        [NonSerialized]
        private string ip;
        public string IP
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        #endregion

        #region constructor
        public Epost() : base() { }
        public Epost(int Id, string Username, string Receiver, string Mailtitle, string Mailcontent, DateTime Time, string Mailstatus, string Picturepath, string Inboxdele, string Outboxdele, string IP): base(Id)
        {
            username = Username;
            mailtitle = Mailtitle;
            receiver = Receiver;
            mailcontent = Mailcontent;
            time = Time;
            mailstatus = Mailstatus;
            picturepath = Picturepath;
            inboxdele = Inboxdele;
            outboxdele = Outboxdele;
            ip = IP;
        }
        #endregion
    }
}
