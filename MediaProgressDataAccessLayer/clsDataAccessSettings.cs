using System;
using System.Configuration;
using System.Data.SqlClient;


namespace MediaProgressDataAccessLayer
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = "Data Source=LT-4312\\SQLEXPRESS;Initial Catalog=MovieData;Integrated Security=True";
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