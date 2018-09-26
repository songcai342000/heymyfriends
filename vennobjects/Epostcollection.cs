using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using System.Timers;
using System.Threading;

namespace vennobjects
{
    [Serializable]
    public class Epostcollection: Idrepositorybase
    {
        #region variables
        private static string myTableName = "Epostinfo";
        //public static DataTable outmails = dataAccess.Outmails();
        private static Dictionary<string, DataTable> dictionaryinbox = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dicmailbyid = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dicmailbyreceiver = new Dictionary<string, DataTable>();
        private static Dictionary<string, DataTable> dicmailbyreceiverstat = new Dictionary<string, DataTable>();
        private static Dictionary<string, int> dicmailid = new Dictionary<string, int>();
        private static Dictionary<string, DataTable> dicoutmail = new Dictionary<string, DataTable>();
        private static Dictionary<string, int> dicinboxnum = new Dictionary<string, int>();
        private static Dictionary<string, int> dicoutboxnum = new Dictionary<string, int>();
        private static Dictionary<string, DataTable> dicsearch = new Dictionary<string, DataTable>();

        #endregion

        #region constructor
        public Epostcollection()
            : base()
        {
        }

        public Epostcollection(string Username)
            : base(Username)
        {
        }

        public Epostcollection(int Id)
            : base(Id)
        { }
        #endregion

        #region properties
        protected override string TableName
        {
            get
            {
                return myTableName;
            }
        }

        /// <summary>
        /// Add, Delete, Update methods for updating database, objects data are first mapped to a datarow's data
        /// </summary>
        /// <param name="Record"></param>
        public override void Add(IId Id)
        {
            base.Add(Id);
            if (Id is Epost)
            {
                Epost theEpost = Id as Epost;
                this.Row["Id"] = theEpost.Id;
                this.Row["Username"] = theEpost.Username;
                this.Row["Receiver"] = theEpost.Receiver;
                this.Row["Mailtitle"] = theEpost.Mailtitle;
                this.Row["Mailcontent"] = theEpost.Mailcontent;
                this.Row["Time"] = theEpost.Time;
                this.Row["Mailstatus"] = theEpost.Mailstatus;
                this.Row["Picturepath"] = theEpost.Picturepath;
                this.Row["Inboxdele"] = theEpost.Inboxdele;
                this.Row["Outboxdele"] = theEpost.Outboxdele;
                this.Row["IP"] = theEpost.IP;
            }
        }

        public override void Delete(IId Id)
        {
            base.Delete(Id);
        }

        public override void Update(IId Id)
        {
            base.Update(Id);
            if (Id is Epost)
            {
                Epost theEpost = Id as Epost;
                this.Row["Id"] = theEpost.Id;
                this.Row["Username"] = theEpost.Username;
                this.Row["Receiver"] = theEpost.Receiver;
                this.Row["Mailtitle"] = theEpost.Mailtitle;
                this.Row["Mailcontent"] = theEpost.Mailcontent;
                this.Row["Time"] = theEpost.Time;
                this.Row["Mailstatus"] = theEpost.Mailstatus;
                this.Row["Picturepath"] = theEpost.Picturepath;
                this.Row["Inboxdele"] = theEpost.Inboxdele;
                this.Row["Outboxdele"] = theEpost.Outboxdele;
                this.Row["IP"] = theEpost.IP;
            }
        }

        //dictionaries
        public Dictionary<string, DataTable> getdicinbox()
        {
            return dictionaryinbox;
        }

        public void filldictinbox(string Username, DataTable table)
        {
            if (dictionaryinbox != null && !dictionaryinbox.ContainsKey(Username))
            {
                dictionaryinbox.Add(Username, table);
            }
        }

        public void removedictinbox(string username)
        {
            dictionaryinbox.Remove(username);
        }

        public Dictionary<string, DataTable> getdicmailbyid()
        {
            return dicmailbyid;
        }

        public void filldicmailbyid(string Username, DataTable table)
        {
            if (dicmailbyid != null && !dicmailbyid.ContainsKey(Username))
            {
                dicmailbyid.Add(Username, table);
            }
        }

        public void removedicmailbyid(string username)
        {
            dicmailbyid.Remove(username);
        }

        public Dictionary<string, DataTable> getdicmailbyreceiver()
        {
            return dicmailbyreceiver;
        }

        public void filldicmailbyreceiver(string Username, DataTable table)
        {
            if (dicmailbyreceiver != null && !dicmailbyreceiver.ContainsKey(Username))
            {
                dicmailbyreceiver.Add(Username, table);
            }
        }

        public void removedicmailbyreceiver(string username)
        {
            dicmailbyreceiver.Remove(username);
        }

        public Dictionary<string, DataTable> getdicmailbyreceiverstat()
        {
            return dicmailbyreceiverstat;
        }

        public void filldicmailbyreceiverstat(string Username, DataTable table)
        {
            if (dicmailbyreceiverstat != null && !dicmailbyreceiverstat.ContainsKey(Username))
            {
                dicmailbyreceiverstat.Add(Username, table);
            }
        }

        public void removedicmailbyreceiverstat(string username)
        {
            dicmailbyreceiverstat.Remove(username);
        }

        public Dictionary<string, int> getdicid()
        {
            return dicmailid;
        }

        public void filldictid(string Username, int id)
        {
            if (dicmailid != null && !dicmailid.ContainsKey(Username) && !dicmailid.ContainsValue(id))
            {
                dicmailid.Add(Username, id);
            }
        }

        public void removedictid(string username)
        {
            dicmailid.Remove(username);
        }

        public Dictionary<string, DataTable> getdicoutmail()
        {
            return dicoutmail;
        }

        public void filldicoutmail(string Username, DataTable table)
        {
            if (dicoutmail != null && !dicoutmail.ContainsKey(Username))
            {
                dicoutmail.Add(Username, table);
            }
        }

        public void removedicoutmail(string username)
        {
            dicoutmail.Remove(username);
        }

        public Dictionary<string, int> getdicinboxnum()
        {
            return dicinboxnum;
        }

        public void filldicinboxnum(string Username, int num)
        {
            if (dicinboxnum != null && !dicinboxnum.ContainsKey(Username))
            {
                dicinboxnum.Add(Username, num);
            }
        }

        public void removedicinboxnum(string username)
        {
            dicoutmail.Remove(username);
        }

        public Dictionary<string, int> getdicoutboxnum()
        {
            return dicoutboxnum;
        }

        public void filldicoutboxnum(string username, int num)
        {
            if (dicoutboxnum != null && !dicoutboxnum.ContainsKey(username))
            {
                dicoutboxnum.Add(username, num);
            }
        }

        public void removedicoutboxnum(string username)
        {
            dicoutboxnum.Remove(username);
        }

        public Dictionary<string, DataTable> getdicsearch()
        {
            return dicsearch;
        }

        public void filldicsearch(string Username, DataTable table)
        {
            if (dicsearch != null && !dicsearch.ContainsKey(Username))
            {
                dicsearch.Add(Username, table);
            }
        }

        public void removedicsearch(string username)
        {
            dicsearch.Remove(username);
        }



        //get last id value
        public int GetId()
        {
            int id = dataAccess.GetId(TableName, SqlAd);
            return id;
        }

        public DataTable GetEpostBySender(string Username)
        {
            DataTable table = dataAccess.GetEpostBySender(Username, SqlAd);
            return table;
        }

        public DataTable GetEpostById(int id)
        {
            DataTable table = dataAccess.GetById(TableName, id, SqlAd);
            return table;
        }

        /*public DataTable GetEpostByTime(DateTime time)
        {
            DataTable table = dataAccess.GetEpostByTime(time, SqlAd);
            return table;
        }*/

        public DataTable GetEpostByReceiverTime(string receiver, string time)
        {
            DataTable table = dataAccess.GetEpostByReceiverTime(receiver, time, SqlAd);
            return table;
        }


        /*public DataTable GetEpostBySenderStatus(string Username)
        {
            DataTable table = dataAccess.GetEpostBySenderStatus(Username, SqlAd);
            return table;
        }*/


        public DataTable GetEpostByReceiver(string Receivername)
        {
            DataTable table = dataAccess.GetEpostByReceiver(Receivername, SqlAd);
            string c = table.Rows.Count.ToString();
            return table;
        }

        public DataTable GetSimiliarUsername(string Keyname)
        {
            DataTable table = dataAccess.GetSimiliarUsernames(Keyname, SqlAd);
            return table;
        }

        public DataTable GetEpostByReceiverStatus(string Receivername)
        {
            DataTable table = dataAccess.GetEpostByReceiverSatus(Receivername, SqlAd);
            return table;
        }

      
        public int InboxCount(string Receiver)
        {
            int inboxnum = dataAccess.CountMyInbox(Receiver, SqlAd);
            return inboxnum;
        }

        public int OutboxCount(string Username)
        {
            int outboxnum = dataAccess.CountMyInbox(Username, SqlAd);
            return outboxnum;
        }

        //update another table than the private table in the class
        /*public void UpDateEpostinfo(DataTable thetable)
        {
            dataAccess.UpdateSeveral(thetable, SqlAd);
        }*/

        public void DeleteOutMail(string Username, DataTable thetable)
        {
            dataAccess.DeleteOutMail(TableName, Username, thetable, SqlAd);
        }

        public void DeleteInMail(string Username, DataTable thetable)
        {
            dataAccess.DeleteOutMail(TableName, Username, thetable, SqlAd);
        }

        #endregion
    }
}
