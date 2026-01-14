using System;
using System.Configuration;
using System.Data.SqlClient;


namespace MediaProgressDataAccessLayer
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MediaDbConn"].ConnectionString;
    }
}



namespace MediaProgress.DAL
{
    public class DbConnection
    {
        // This reads the name "MediaDbConn" from whatever App.config is active
        private static string _connectionString = ConfigurationManager.ConnectionStrings["MediaDbConn"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}