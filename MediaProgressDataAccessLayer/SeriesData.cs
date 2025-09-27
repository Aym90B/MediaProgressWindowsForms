using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace MediaProgressDataAccessLayer
{
    public class clsSeriesDataAccess
    {
        public static bool GetSeriesInfoByID(int SeriesID, ref int NumberOfSeasons, ref int NumberOfEpisodes, ref bool StartWatching, ref int WatchedEpisodes
           )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Series WHERE SeriesID = @SeriesID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeriesID", SeriesID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    NumberOfSeasons = (int)reader["NumberOfSeasons"];
                    NumberOfEpisodes = (int)reader["NumberOfEpisodes"];
                    
                    StartWatching = (bool)reader["StartWatching"];
                   
                    WatchedEpisodes = (int)reader["WatchedEpisodes"];





                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static float GetSeriesPercentageCompletion(int ID)
        {
            float PercentageOfCompletion = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT PercentageOfCompletion FROM Main WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["PercentageOfCompletion"] != DBNull.Value)
                    {
                        PercentageOfCompletion = (float)(double)reader["PercentageOfCompletion"];
                    }
                    else
                    {
                        PercentageOfCompletion = 0;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                PercentageOfCompletion = 0;
            }
            finally
            {
                connection.Close();
            }
            return PercentageOfCompletion;
        }

        public static bool GetSeriesInfoByName(string Name, ref int ID, ref int Seasons, ref double Rating, ref int Duration, ref bool Completed)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Series WHERE Name = @Name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ID = (int)reader["SeriesID"];

                    if (reader["Name"] != DBNull.Value)
                    {
                        Name = (string)reader["Name"];
                    }
                    else
                    {
                        Name = "";
                    }



                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int getNumberOfSeasonsForSeries(string SeriesName)
        {
            int numberOfSeasons = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT NumberOfSeasons FROM NewSeries INNER JOIN Main ON Main.ID = NewSeries.ID Where Name = @SeriesName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeriesName", SeriesName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Use the correct column name and check for DBNull
                    if (reader["NumberOfSeasons"] != DBNull.Value)
                    {
                        numberOfSeasons = (int)reader["NumberOfSeasons"];
                    }
                    else
                    {
                        numberOfSeasons = 0;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
             
            }
            finally
            {
                connection.Close();
            }

            return numberOfSeasons;

        }

        public static int AddNewSeries(int NumberOfSeasons, int NumberOfEpisodes, int ID, bool StartWatching, int WatchedEpisodes) 
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int SeriesID = -1;
       
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO NewSeries (NumberOfSeasons, NumberOfEpisodes, ID, StartWatching,  WatchedEpisodes)
                             VALUES (@NumberOfSeasons, @NumberOfEpisodes, @ID,  @StartWatching,  @WatchedEpisodes);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

          if(NumberOfSeasons != -1 && NumberOfSeasons.ToString() != null)
                command.Parameters.AddWithValue("@NumberOfSeasons", NumberOfSeasons);
            else
                command.Parameters.AddWithValue("@NumberOfSeasons", System.DBNull.Value);

          if(NumberOfEpisodes != -1 && NumberOfEpisodes.ToString() != null)
                command.Parameters.AddWithValue("@NumberOfEpisodes", NumberOfEpisodes);
            else
                command.Parameters.AddWithValue("@NumberOfEpisodes", System.DBNull.Value);

            if (ID != -1 && ID.ToString() != null)
                command.Parameters.AddWithValue("@ID", ID);
            else
                command.Parameters.AddWithValue("@ID", System.DBNull.Value);

            if (StartWatching.ToString() != null)
                command.Parameters.AddWithValue("@StartWatching", StartWatching);
            else
                command.Parameters.AddWithValue("@StartWatching", System.DBNull.Value);

       
          if(WatchedEpisodes != 1 && WatchedEpisodes.ToString() != null)
                command.Parameters.AddWithValue("@WatchedEpisodes", WatchedEpisodes);
            else
                command.Parameters.AddWithValue("@WatchedEpisodes", System.DBNull.Value);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    SeriesID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return SeriesID;
        }

        public static bool UpdateSeries(int SeriesID, int NumberOfSeasons, int NumberOfEpisodes, bool StartWatching, int WatchedEpisodes)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Series  
                            set 
                                NumberOfSeasons = @NumberOfSeasons,
                                NumberOfEpisodes = @NumberOfEpisodes, 
                                StartWatching = @StartWatching,
                               
                                Watchdepisodes = @WatchedEpisodes
                              
                              
                                where SeriesID = @SeriesID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeriesID", SeriesID);
            command.Parameters.AddWithValue("@NumberOfSeasons", NumberOfSeasons);
            command.Parameters.AddWithValue("@NumberOfEpisodes", NumberOfEpisodes);
            command.Parameters.AddWithValue("@StartWatching", StartWatching);
           
            command.Parameters.AddWithValue("@WatchedEpisodes", WatchedEpisodes);



            if (NumberOfSeasons != -1 && NumberOfSeasons.ToString() != null)
                command.Parameters.AddWithValue("@NumberOfSeasons", NumberOfSeasons);
            else
                command.Parameters.AddWithValue("@NumberOfSeasons", System.DBNull.Value);

          if(NumberOfEpisodes != -1 && NumberOfEpisodes.ToString() != null)
                command.Parameters.AddWithValue("@NumberOfEpisodes", NumberOfEpisodes);
            else
                command.Parameters.AddWithValue("@NumberOfEpisodes", System.DBNull.Value);
            if(StartWatching.ToString() != null)
                command.Parameters.AddWithValue("@StartWatching", StartWatching);
            else
                command.Parameters.AddWithValue("@StartWatching", System.DBNull.Value);
           
            if(WatchedEpisodes != 1 && WatchedEpisodes.ToString() != null)
                command.Parameters.AddWithValue("@WatchedEpisodes", WatchedEpisodes);
            else
                command.Parameters.AddWithValue("@WatchedEpisodes", System.DBNull.Value);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllSeriesFromIMDB()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT\r\nSeriesBasics.primaryTitle as SeriesName,\r\n\r\nRatings.averageRating,\r\n\r\nRatings.numVotes,\r\n\r\nSeriesBasics.whereToWatch, SeriesBasics.StartWatching, SeriesBasic.PercentageOfCompletion,\r\nSeriesBasics.runtimeMinutes,\r\nSeriesBasics.titleType\r\n\r\nFrom\r\nBasics as SeriesBasics\r\n\r\nJoin\r\nRatings on SeriesBasics.tconst = Ratings.tconst\r\n\r\nwhere\r\nRatings.averageRating >= 8.5 and Ratings.numVotes >= 5000 and SeriesBasics.titleType = 'tvSeries' \r\n\r\norder by\r\nRatings.averageRating desc";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeleteSeries(int ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Series 
                                where SeriesID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsSeriesExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Series WHERE SeriesID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable getAllSeriesWithinAvailableTime(int Duration)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
  SELECT
SeriesBasics.primaryTitle as SeriesName,

Ratings.averageRating,

Ratings.numVotes,

SeriesBasics.whereToWatch,
SeriesBasics.runtimeMinutes,
SeriesBasics.titleType,
SeriesBasics.watchAgain,
SeriesBasics.StartWatching,
SeriesBasics.PercentageOfCompletion

From
Basics as SeriesBasics

Join
Ratings on SeriesBasics.tconst = Ratings.tconst

where
Ratings.averageRating >= 8.5 and Ratings.numVotes >= 5000 and SeriesBasics.titleType = 'tvSeries' 

order by
Ratings.averageRating desc
	";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Duration", Duration);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static List<string> getAllSeriesNames()
        {
            List<string> seriesNames = new List<string>();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Name FROM Main where CategoryID = 2";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Name"] != DBNull.Value)
                        seriesNames.Add(reader["Name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return seriesNames;
        }

        public static DataTable GetAllSeries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Name FROM Main where CategoryID = 2";
            SqlCommand command = new SqlCommand (query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
               Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;


        }

        public static DataTable GetAllSeasons(string SeriesName)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            // Implement the Iterator for the less than the number of seasons
            string query = "WITH SeasonCounter AS (\r\n    SELECT 1 AS SeasonNumber\r\n    UNION ALL\r\n    SELECT SeasonNumber + 1\r\n    FROM SeasonCounter\r\n    WHERE SeasonNumber < (\r\n        SELECT NumberOfSeasons \r\n        FROM NewSeries \r\n        INNER JOIN Main ON Main.ID = NewSeries.ID \r\n        WHERE Name = @SeriesName\r\n    )\r\n)\r\nSELECT \r\n    SeasonNumber\r\nFROM \r\n    SeasonCounter\r\nOPTION (MAXRECURSION 0);\r\n";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SeriesName", SeriesName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                 Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;


        }

        public static int GetSeriesIDByName(string SeriesName)
        {
            int seriesID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID FROM Main WHERE Name = @SeriesName AND CategoryID = 2";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SeriesName", SeriesName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["ID"] != DBNull.Value)
                    {
                        seriesID = (int)reader["ID"];
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                seriesID = -1;
            }
            finally
            {
                connection.Close();
            }
            return seriesID;
        }
    }
}
