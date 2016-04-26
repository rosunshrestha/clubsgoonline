using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Configuration;

namespace clubsgoonline
{
    public class Connect
    {
     
        private string connectionString;
        private string connectionState;
        private string serverVersion;
        SqlConnection myconnection = new SqlConnection();
        
        public void setConnectionString()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myconnection.ConnectionString = connectionString;
        }

        public string TestConnection()
        {
            
            myconnection.Open();
            connectionState = myconnection.State.ToString();
            serverVersion = myconnection.ServerVersion;
            myconnection.Close();
            return connectionState + serverVersion;
        }

        public void OpenConnection()
        {
            setConnectionString();
            myconnection.Open();
        }

        public void CloseConnection()
        {
            myconnection.Close();
        }
    }
    
}