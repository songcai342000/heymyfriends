using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess
{
    public class dataAccess
    {
        #region ConnectionString
        private static string connectionString = "Data Source=desktop-v7h8pou\\sqlexpress2017;Initial Catalog=Chinatravel;Integrated Security=True";
        //private static string connectionString = "Data Source=mssql03.fastname.no;Database=db165057;Uid=db165057;Password=a547yryf";
        #endregion

        #region public methods
    

        public static DataTable GetTable(string tableName, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetTable(string tableName, string id, int myId, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where " + id + " = " + myId;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetOrderById(string tableName, int id, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Orderinfo where Id = " + id;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }


        public static DataTable GetOrderByUsername(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Orderinfo where Username = '" + username + "' and Id != 0";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetOrderByStatus(string status, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Orderinfo where Status = '" + status + "' and Id != 0";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetOrdersByOrderNumber(int ordernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Orderinfo where Ordernumber = " + ordernumber + " and Id != 0";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetOrdersByRouterNumber(string routernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Orderinfo where Routernumber = '" + routernumber + "' and Id != 0";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetOrdersByOrdertime(DateTime ordertime, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Orderinfo where Ordertime = '" + ordertime + "' and Id != 0";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetUserByName(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Customerinfo where Name = '" + username + "' and Id != 0";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        //get out box mails
        public static DataTable GetEpostBySender(string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select Epost from Customerinfo where Name = '" + username + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static void DeleteOrderById(int Id, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Orderinfo where Id = " + Id;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteOrderByName(string name, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Orderinfo where Name = " + name;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteOrderByOrdernumber(int ordernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Orderinfo where Ordernumber = " + ordernumber;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteOrderByRouternumber(string routernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Orderinfo where Routernumber = '" + routernumber + "'";
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateTillInforOrderByOrder(string tilleggsinformasjon, int ordernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "Update Orderinfo set Tilleggsinformasjon = '" + tilleggsinformasjon + "' where Ordernumber = " + ordernumber;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteOrderByStatus(string status, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Orderinfo where Status = " + status;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCustomerByName(string name, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Customerinfo where Name = " + name;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCustomersByOrdernumber(int ordernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Customerinfo where Ordernumber = " + ordernumber;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCustomersByRouternumber(string routernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Customerinfo where Routernumber = '" + routernumber + "'";
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCustomerById(int id, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Customerinfo where Id = " + id;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCustomerById(int id, string name, string sunname, string fødelsdato, string gender, string address, SqlDataAdapter SqlAd)
        {
            string commandText = "Update Customerinfo set Name = '" + name + "', Sunname = '" + sunname + "', Fødelsdato = '" + fødelsdato + "', Location = '', Gender = '" + gender + "', Address = '" +  address + "', Mobil = '', Status = 'registring' where Id = " + id;
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlComm.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetPendingCustomersByOrdernumber(int ordernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Customerinfo where Ordernumber = " + ordernumber + " and Status = 'pending'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetNewCustomersByOrdernumber(int ordernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from Customerinfo where Ordernumber = " + ordernumber + " and Status = 'registrering'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetAllCustomersByOrdernumber(int ordernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "Select * from Customerinfo where Ordernumber = " + ordernumber;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable GetAllCustomersByRouternumber(int routernumber, SqlDataAdapter SqlAd)
        {
            string commandText = "Select * from Customerinfo where Routernumber = " + routernumber;
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }

        public static DataTable DeleteNewsLetterByEpost(string epost, SqlDataAdapter SqlAd)
        {
            string commandText = "delete from Newsletterinfo where Epost = '" + epost + "'";
            DataTable table = CreateTableByQuery(commandText, SqlAd);
            return table;
        }
         
 
        public static int GetId(string tableName, SqlDataAdapter SqlAd)
        {
            //DataTable table = CreateTableByQuery(commandText, SqlAd);
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                string commandText = "select Max(Id) from " + tableName;
                SqlCommand SqlComm;
                SqlConn.Open();
                SqlComm = SqlConn.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlDataAdapter Sqlad = new SqlDataAdapter();
                Sqlad.SelectCommand = SqlComm;
                DataSet ds = new DataSet();
                Sqlad.Fill(ds);
                int con;
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count >= 0)
                {

                    if (ds.Tables[0].Rows[0][0].ToString() == "")
                    {
                        con = 1;
                        return con;
                    }
                    else if (ds.Tables[0].Rows[0][0] == null)
                    {
                        con = 1;
                        return con;
                    }
                    else
                    {
                        con = int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1;
                        return con;
                    }
                }
                if (ds.Tables[0] == null)
                {
                    con = 1;
                    return con;
                }
                else
                {
                    con = -1;
                    return con;
                }
            }
        }

        static SqlConnection SqlConn1;
        public static DataTable ConstruById(string tableName, int id, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Id = " + id;
            SqlConn1 = new SqlConnection(connectionString);
            if (SqlConn1 != null)
            {
                DataTable table = new DataTable();
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlAd.SelectCommand = SqlComm;
                SqlAd.Fill(table);
                return table;
            }
            else
            {
                return null;
            }
        }

        public static DataTable ConstruByUsername(string tableName, string username, SqlDataAdapter SqlAd)
        {
            string commandText = "select * from " + tableName + " where Username = '" + username + "'";
            SqlConn1 = new SqlConnection(connectionString);
            if (SqlConn1 != null)
            {
                DataTable table = new DataTable();
                SqlCommand SqlComm;
                SqlConn1.Open();
                SqlComm = SqlConn1.CreateCommand();
                SqlComm.CommandType = CommandType.Text;
                SqlComm.CommandText = commandText;
                SqlAd.SelectCommand = SqlComm;
                SqlAd.Fill(table);
                return table;
            }
            else
            {
                return null;
            }
        }


        public static void Update(DataTable table, SqlDataAdapter SqlAd)
        {
            if (SqlConn1 != null)
            {
                try
                {
                    SqlCommandBuilder cb = new SqlCommandBuilder(SqlAd);
                    SqlAd.Update(table);
                    table.AcceptChanges();
                }
                catch
                {
                }
                finally
                {
                    SqlConn1.Close();
                    SqlConn1.Dispose();
                }
            }
        }


        #endregion

        #region Local Helper Methods

        protected static DataTable CreateTableByQuery(string commandText, SqlDataAdapter SqlAd)
        {
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                if (SqlConn != null)
                {
                    DataTable table = new DataTable();
                    SqlCommand SqlComm;
                    SqlConn.Open();
                    SqlComm = SqlConn.CreateCommand();
                    SqlComm.CommandType = CommandType.Text;
                    SqlComm.CommandText = commandText;
                    SqlAd.SelectCommand = SqlComm;
                    SqlAd.Fill(table);
                    //SqlConn.Close();
                    //SqlConn.Dispose();
                    return table;
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

    }
}
