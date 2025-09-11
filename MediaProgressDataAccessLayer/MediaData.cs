using System;
using System.Data;
using System.Data.SqlClient;

namespace MediaProgressDataAccessLayer
{
    public class clsMovieDataAccess
    {
        public static bool GetMediaInfoByID(int ID, ref string Name, ref double Rating, ref int Season, ref int EpisodeNumber,  ref int Duration, ref bool Completed,ref int SeriesID, ref int CategoryID, ref bool WatchAgain
           )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Main WHERE ID = @ID";

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
                    Rating = (double)reader["Rating"];
                    //Season = (int)reader["Season"];
                    //EpisodeNumber = (int)reader["EpisodeNumber"];
                    Duration = (int)reader["Duration"];
                    Completed = (bool)reader["Completed"];
                    //SeriesID = (int)reader["SeriesID"];
                    CategoryID = (int)reader["CategoryID"];
                    WatchAgain = (bool)reader["WatchAgain"];


                    // allows null in database so we should handle null
                    if (reader["Season"] != DBNull.Value)
                    {
                        Season = (int)reader["Season"];
                    }
                    else
                    {
                        Season = -1;
                    }
                    if (reader["SeriesID"] != DBNull.Value)
                    {
                        SeriesID = (int)reader["SeriesID"];
                    }
                    else
                    {
                        SeriesID = -1;
                    }

                    if (reader["EpisodeNumber"] != DBNull.Value)
                    {
                        EpisodeNumber = (int)reader["EpisodeNumber"];
                    }
                    else
                    {
                        EpisodeNumber = -1;
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

 
        public static int AddNewMedia(string Name, double Rating, int Season, int EpisodeNumber,
            int Duration, bool Completed, int SeriesID, int CategoryID, bool WatchAgain)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Main (Name, Rating, Season, EpisodeNumber, Duration, Completed, SeriesID, CategoryID)
                             VALUES (@Name, @Rating, @Season, @EpisodeNumber, @Duration, @Completed, @SeriesID, @CategoryID, @WatchAgain);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Rating", Rating);
            //command.Parameters.AddWithValue("@Season", Season);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Completed", Completed);
            //command.Parameters.AddWithValue("@SeriesID", SeriesID);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@WatchAgain", WatchAgain);


            if (Season != -1 && Season.ToString() != null)
                command.Parameters.AddWithValue("@Season", Season);
            else
                command.Parameters.AddWithValue("@Season", System.DBNull.Value);

            if (SeriesID != -1 && SeriesID.ToString() != null)
                command.Parameters.AddWithValue("@SeriesID", SeriesID);
            else
                command.Parameters.AddWithValue("@SeriesID", System.DBNull.Value);

            if (EpisodeNumber != -1 && EpisodeNumber.ToString() != null)
                command.Parameters.AddWithValue("@EpisodeNumber", EpisodeNumber);
            else
                command.Parameters.AddWithValue("@EpisodeNumber", System.DBNull.Value);

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

        public static bool UpdateMedia(int ID, string Name, double Rating, int Season, int EpisodeNumber,
            int Duration, bool Completed,int SeriesID, int CategoryID, bool WatchAgain)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Main  
                            set Name = @Name, 
                                Rating = @Rating, 
                                Season = @Season,
                                EpisodeNumber = @EpisodeNumber,
                                Duration = @Duration, 
                                Completed = @Completed,
                                SeriesID = @SeriesID,
                                CategoryID = @CategoryID,
                                WatchAgain = @WatchAgain
                            
                              
                                where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Rating", Rating);
            //command.Parameters.AddWithValue("@Season", Season);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Completed", Completed);
            //command.Parameters.AddWithValue("@SeriesID", SeriesID);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@WatchAgain", WatchAgain);


            if (Season != -1 && Season.ToString() != null)
                command.Parameters.AddWithValue("@Season", Season);
            else
                command.Parameters.AddWithValue("@Seasons", System.DBNull.Value);

            if (SeriesID != -1 && SeriesID.ToString() != null)
                command.Parameters.AddWithValue("@SeriesID", SeriesID);
            else
                command.Parameters.AddWithValue("@SeriesID", System.DBNull.Value);

            if (EpisodeNumber != -1 && EpisodeNumber.ToString() != null)
                command.Parameters.AddWithValue("@EpisodeNumber", EpisodeNumber);
            else
                command.Parameters.AddWithValue("@EpisodeNumber", System.DBNull.Value);


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

        public static DataTable GetAllMedia()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT\r\nseriesBasics.primaryTitle as seriesName,\r\nepisodeBasics.primaryTitle as episodeTitle,\r\nRatings.averageRating,\r\nEpisodes.seasonNumber,\r\nEpisodes.episodeNumber,\r\nRatings.numVotes,\r\nEpisodes.tconst,\r\nEpisodes.Completed as Episode_Completed,\r\nseriesBasics.Completed as Series_Completed,\r\nseriesBasics.whereToWatch,\r\nseriesBasics.runtimeMinutes\r\n\r\nFrom\r\nBasics as seriesBasics\r\n\r\nJoin\r\nEpisodes on seriesBasics.tconst = Episodes.parentTconst\r\n\r\njoin\r\nBasics as episodeBasics on Episodes.tconst = episodeBasics.tconst\r\n\r\nJoin\r\nRatings on Episodes.tconst = Ratings.tconst\r\n\r\nwhere\r\nRatings.averageRating >= 9.5 and Ratings.numVotes >= 5000 and seriesBasics.runtimeMinutes <= 30\r\n\r\norder by\r\nEpisodes.seasonNumber,\r\nEpisodes.episodeNumber asc,\r\nRatings.averageRating desc";

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

        public static DataTable GetAllMovies()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT\r\nMovieBasics.primaryTitle as MovieName,\r\n\r\nRatings.averageRating,\r\n\r\nRatings.numVotes,\r\n\r\nMovieBasics.whereToWatch,\r\nMovieBasics.runtimeMinutes,\r\nMovieBasics.titleType,MovieBasics.WatchAgain\r\n\r\nFrom\r\nBasics as MovieBasics\r\n\r\nJoin\r\nRatings on MovieBasics.tconst = Ratings.tconst\r\n\r\nwhere\r\nRatings.averageRating >= 8.5 and Ratings.numVotes >= 5000 and MovieBasics.Completed IS NULL and MovieBasics.titleType = 'movie' \r\n\r\norder by\r\nRatings.averageRating desc\r\n";

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

        public static bool DeleteMedia(int ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Main 
                                where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsMediaExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Movies WHERE ID = @ID";

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
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable getAllMediaWithinAvailableTime(int Duration)
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
	Episodes.Completed as Episode_Completed,
	mediaBasics.Completed as Media_Completed,
    mediaBasics.WatchAgain as Media_Watch_Again
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
        mediaBasics.titleType IN ('movie', 'series', 'tvMovie', 'tvShort', 'short', 'tvEpisode') OR
        (mediaBasics.titleType = 'tvEpisode' AND Episodes.Completed IS NULL)
    )
ORDER BY
 
    Episodes.seasonNumber ASC,
    Episodes.episodeNumber ASC,
	 Ratings.averageRating DESC
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

        

        public static DataTable getAllMoviesWithinAvailableTime(int Duration)
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
	mediaBasics.Completed as Media_Completed,
    mediaBasics.WatchAgain as Media_Watch_Again
FROM
    Basics AS mediaBasics
LEFT JOIN
    Episodes ON mediaBasics.tconst = Episodes.tconst
LEFT JOIN
    Basics AS seriesBasics ON Episodes.parentTconst = seriesBasics.tconst
JOIN
    Ratings ON mediaBasics.tconst = Ratings.tconst
WHERE

    mediaBasics.runtimeMinutes <= 120 AND 
    Ratings.numVotes >= 5000 AND 
    mediaBasics.Completed IS NULL AND
    (
        mediaBasics.titleType IN ('movie', 'tvMovie', 'tvShort', 'short') OR
        (mediaBasics.titleType = 'tvEpisode' AND Episodes.Completed IS NULL)
    )
ORDER BY
 
    Episodes.seasonNumber ASC,
    Episodes.episodeNumber ASC,
	 Ratings.averageRating DESC
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

        public static DataTable GetMediaInfoByName(string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT TOP (200) Basics.tconst, Basics.titleType, Basics.primaryTitle, Basics.originalTitle, Basics.isAdult, Basics.startYear, Basics.endYear, Basics.runtimeMinutes, Basics.genres, Basics.Completed, Basics.whereToWatch, Basics.Category, Ratings.averageRating, Ratings.numVotes\r\n FROM  Basics INNER JOIN\r\n         Ratings ON Basics.tconst = Ratings.tconst AND Basics.tconst = Ratings.tconst -- join Episodes on Episodes.parentTconst = basics.tconst\r\nWHERE Basics.primaryTitle Like @Name and (Ratings.numVotes >= 10000)\r\nORDER BY Ratings.averageRating DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", "%" + Name + "%");

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
    }
}

