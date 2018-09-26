using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace vennobjects
{
    public class Idrepositorybase: IIdrepository
    {
        #region variables
        protected DataTable table;
        protected SqlDataAdapter SqlAd = new SqlDataAdapter();
        //protected static List<IId> mylist = new List<IId>();
        #endregion 


        #region properties
        private DataRow dr;
        protected DataRow Row
        {
            get { return dr; }
        }

        private string username;
        protected string Username
        {
            get { return username; }
            set { username = value; }
        }

        private int id;
        protected int Id
        {
            get { return id; }
            set { id = value; }
        }

        protected virtual string TableName
        {
            get { return null; }
        }
        #endregion


        #region constructor
        public Idrepositorybase() { }
        public Idrepositorybase(string Username)
        {
            username = Username;
            table = dataAccess.ConstruByUsername(TableName, username, SqlAd);
        }

        public Idrepositorybase(int Id)
        {
            id = Id;
            //table = dataAccess.GetById(TableName, id, SqlAd);
            table = dataAccess.ConstruById(TableName, id, SqlAd);
        }

        /*public Idrepositorybase(int Id)
        {
            id = Id;
        }*/
        #endregion

        #region non virtual methods
        /// <summary>
        /// update database by datatable
        /// </summary>
        public void Save()
        {
            dataAccess.Update(table, SqlAd);
            //dataAccess.Update(TableName, id, SqlAd, Row);
        }

       
       #endregion

        #region virtual methods
        /// <summary>
        /// Add, Delete, Update methods for updating database, objects data are mapped to a datarow's data
        /// </summary>
        /// <param name="Id"></param>
        /*public virtual void Add(IId Id)
        {
            dr = table.NewRow();
            dr["Id"] = Id.Id;
            table.Rows.Add(dr);
        }

        public virtual void Delete(IId Id)
        {
            foreach (DataRow r in table.Rows)
            {
                if (int.Parse(r["Id"].ToString()) == Id.Id)
                {
                    dr = r;
                    dr.Delete();
                }
            }
        }

        public virtual void Update(IId Id)
        {
            foreach (DataRow r in table.Rows)
            {
                if (int.Parse(r["Id"].ToString()) == Id.Id)
                {
                    dr = r;
                    dr["Id"] = Id.Id;
                }
            }
        }*/

        public virtual void Add(IId Id)
        {
            dr = table.NewRow();
            dr["Id"] = Id.Id;
            table.Rows.Add(dr);
        }

        public virtual void Delete(IId Id)
        {
            foreach (DataRow r in table.Rows)
            {
                if (int.Parse(r["Id"].ToString()) == Id.Id)
                {
                    dr = r;
                    dr.Delete();
                }
            }
        }

        public virtual void Update(IId Id)
        {
            foreach (DataRow r in table.Rows)
            {
                if (int.Parse(r["Id"].ToString()) == Id.Id)
                {
                    dr = r;
                    dr["Id"] = Id.Id;
                }
            }
        }
        #endregion
    }
}
