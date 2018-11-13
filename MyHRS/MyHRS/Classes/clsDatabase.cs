using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MyHRS.Classes
{
    public class clsDatabase
    {
        public SqlConnection SQLConn;
        public string SQLType;

        public bool TestConnection(string ServerName, string Database, string Username, string Password, ref string ErrMsg)
        {
            bool result = false;
            try
            {
                string SQLConnString = string.Empty;
                if (SQLType.ToLower() == "sql")
                {
                    SQLConnString = "Server = " + ServerName + "; Database = " + Database + "; User Id = " + Username + ";Password = " + Password + ";";
                }
                if (!string.IsNullOrEmpty(SQLConnString))
                {
                    SQLConn = new SqlConnection();
                    SQLConn.ConnectionString = SQLConnString;
                    SQLConn.Open();
                    result = SQLConn.State == ConnectionState.Open ? true : false;
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message.ToString();
            }
            return result;
        }

        public bool TestConnection(string ServerName, string Database, string Username, string Password, ref string ErrMsg, ref SqlConnection SQLConn)
        {
            bool result = false;
            try
            {
                string SQLConnString = string.Empty;
                if (SQLType.ToLower() == "sql")
                {
                    SQLConnString = "Server = " + ServerName + "; Database = " + Database + "; User Id = "+ Username +";Password = "+Password+";";
                }
                if (!string.IsNullOrEmpty(SQLConnString))
                {
                    SQLConn = new SqlConnection();
                    SQLConn.ConnectionString = SQLConnString;
                    SQLConn.Open();
                    result = SQLConn.State == ConnectionState.Open ? true : false;
                }
            }
            catch(Exception ex)
            {
                ErrMsg = ex.Message.ToString();
            }
            return result;
        }

        public bool ExecuteNonQuery(string SQLStatement)
        {
            bool result = false;
            try
            {
                if (SQLType.ToLower() == "sql")
                {
                    //string SqlConnstr = SQLConnBuilder(DBPath);
                    if (SQLConn.State == ConnectionState.Closed)
                    {
                        SQLConn.Open();
                    }
                    if (SQLConn.State == ConnectionState.Open)
                    {
                        SqlCommand sqlcom = new SqlCommand(SQLStatement, SQLConn);
                        sqlcom.ExecuteReader();
                        result = true;
                    }
                }
            }
            catch
            {
            }
            return result;
        }
        public DataTable ExecuteSP(string SPName)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (SQLType.ToLower() == "sql")
                {
                    if (SQLConn.State == ConnectionState.Open)
                    {
                        SQLConn.Close();
                    }
                    SQLConn.Open();
                    if (SQLConn.State == ConnectionState.Open)
                    {
                        SqlCommand sqlcmd = new SqlCommand(SPName, SQLConn);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
                        sda.Fill(dtResult);
                    }
                } 
            }
            catch
            {
            }
            return dtResult;
        }
        public DataTable ExecuteQuery(string SQLStatement)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (SQLType.ToLower() == "sql")
                {
                    if (SQLConn.State == ConnectionState.Open)
                    {
                        SQLConn.Close();
                    }
                    SQLConn.Open();
                    if (SQLConn.State == ConnectionState.Open)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(SQLStatement, SQLConn);
                        sda.Fill(dtResult);
                    }
                }
            }
            catch
            {
            }
            return dtResult;
        }
    }
}
