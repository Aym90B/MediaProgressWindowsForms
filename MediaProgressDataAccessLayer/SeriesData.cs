using System;
using System.Data;
using System.Data.SqlClient;

namespace MediaProgressDataAccessLayer
{
    public class clsSeriesDataAccess
    {
        public static bool GetSeriesInfoByID(int ID, ref int Seasons, ref string Name, ref double Rating, ref int Duration, ref bool Completed
           )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Series WHERE SeriesID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Name = (string)reader["Name"];
                    Seasons = (int)reader["Seasons"];
                    Name = (string)reader["Name"];
                    Rating = (double)reader["Rating"];
                    Duration = (int)reader["Duration"];
                    Completed = (bool)reader["Completed"];


                    //ImagePath: allows null in database so we should handle null
                    if (reader["Duration"] != DBNull.Value)
                    {
                        Duration = (int)reader["Duration"];
                    }
                    else
                    {
                        Duration = -1;
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

        public static int AddNewSeries(string Name, int Seasons, double Rating,
            int Duration, bool Completed)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Series (Name, Seasons, Rating, Duration, Completed)
                             VALUES (@Name, @Seasons, @Rating, @Duration, @Completed);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Seasons", Seasons);
            command.Parameters.AddWithValue("@Rating", Rating);
            //command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Completed", Completed);


            if (Duration != -1 && Duration.ToString() != null)
                command.Parameters.AddWithValue("@Duration", Duration);
            else
                command.Parameters.AddWithValue("@Duration", System.DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
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


            return ID;
        }

        public static bool UpdateSeries(int ID, string Name, int Seasons, double Rating,
            int Duration, bool Completed)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Series  
                            set Name = @Name, 
                                Seasons = @Seasons,
                                Rating = @Rating, 
                                Duration = @Duration, 
                                Completed = @Completed
                              
                                where SeriesID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Seasons", Seasons);
            command.Parameters.AddWithValue("@Rating", Rating);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Completed", Completed);


            if (Duration != -1 /*&& Duration != null*/)
                command.Parameters.AddWithValue("@Duration", Duration);
            else
                command.Parameters.AddWithValue("@Duration", System.DBNull.Value);


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

        public static DataTable GetAllSeries()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT\r\nSeriesBasics.primaryTitle as SeriesName,\r\n\r\nRatings.averageRating,\r\n\r\nRatings.numVotes,\r\n\r\nSeriesBasics.whereToWatch,\r\nSeriesBasics.runtimeMinutes,\r\nSeriesBasics.titleType\r\n\r\nFrom\r\nBasics as SeriesBasics\r\n\r\nJoin\r\nRatings on SeriesBasics.tconst = Ratings.tconst\r\n\r\nwhere\r\nRatings.averageRating >= 8.5 and Ratings.numVotes >= 5000 and SeriesBasics.titleType = 'tvSeries' \r\n\r\norder by\r\nRatings.averageRating desc";

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
   SELECT TOP 100
    CASE 
        WHEN mediaBasics.titleType = 'series' THEN seriesBasics.primaryTitle
        ELSE mediaBasics.primaryTitle
    END AS MediaName,
    Ratings.averageRating,
    Ratings.numVotes,
    mediaBasics.runtimeMinutes,
    mediaBasics.whereToWatch,
    mediaBasics.titleType,
    Episodes.seasonNumber,
    Episodes.episodeNumber,
	seriesBasics.primaryTitle as Series_Name,
	mediaBasics.startYear,
	mediaBasics.whereToWatch,
	mediaBasics.isAdult,
	Episodes.Completed as Episode_Completed,
	mediaBasics.Completed as Media_Completed
FROM
    Basics AS mediaBasics
LEFT JOIN
    Episodes ON mediaBasics.tconst = Episodes.tconst
LEFT JOIN
    Basics AS seriesBasics ON Episodes.parentTconst = seriesBasics.tconst
JOIN
    Ratings ON mediaBasics.tconst = Ratings.tconst
WHERE

    mediaBasics.runtimeMinutes <= @Duration AND 
    Ratings.numVotes >= 5000 AND 
    mediaBasics.Completed IS NULL AND
    (
        mediaBasics.titleType IN ('tvEpisode') OR
        (mediaBasics.titleType = 'tvEpisode' AND Episodes.Completed IS NULL)
    )
ORDER BY
 
    Episodes.seasonNumber ASC,
    Episodes.episodeNumber ASC,
	 Ratings.averageRating DESC
	;
	;";

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
    }
}
