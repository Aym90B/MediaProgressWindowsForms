using System;
using System.Configuration;
using System.Data.SqlClient;


namespace MediaProgressDataAccessLayer
{
    public static class clsDataAccessSettings
    {
        public static string ConnectionString
        {
            get
            {
                var conn = ConfigurationManager.ConnectionStrings["MediaDbConn"];
                if (conn != null)
                    return conn.ConnectionString;
                
                conn = ConfigurationManager.ConnectionStrings["MediaProgressWindowsForms.Properties.Settings.MovieDataConnectionString"];
                if (conn != null)
                    return conn.ConnectionString;

                throw new Exception("Connection string 'MediaDbConn' or 'MovieDataConnectionString' not found in configuration.");
            }
        }
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