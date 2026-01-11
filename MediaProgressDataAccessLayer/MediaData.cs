using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MediaProgressDataAccessLayer
{
    public class clsMovieDataAccess
    {

        // Add this method to DatabaseService.cs
        public static async Task<bool> AddNewMediaToMainAsync(string title, string tconst, bool isAdult, int runtimeMinutes)
        {
            var sqlQuery = "IF EXISTS (SELECT 1 FROM Basics WHERE tconst = @tconst)\r\nBEGIN\r\n  \r\n   update Basics set primaryTitle = @primaryTitle , isAdult = @isAdult, runtimeMinutes = @runtimeMinutes  where tconst = @tconst;\r\nEND";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@primaryTitle", title);
                    command.Parameters.AddWithValue("@tconst", tconst);
                    command.Parameters.AddWithValue("@isAdult", isAdult);
                    command.Parameters.AddWithValue("@runtimeMinutes", runtimeMinutes);

                    await connection.OpenAsync();

                    // ExecuteNonQueryAsync returns the number of rows affected.
                    // We expect it to be 1 for a successful insert.
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        public static async Task<int> AddNewMovieAndGetIdAsync(string title)
        {
            // The SQL command inserts a new record and immediately retrieves its new primary key ID.
            var sqlQuery = "INSERT INTO Main (Name) VALUES (@name); SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", title);

                    await connection.OpenAsync();

                    // ExecuteScalarAsync is used here because we expect a single value back (the new ID).
                    object result = await command.ExecuteScalarAsync();

                    // Convert the result to an integer and return it.
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return 0; // Return 0 if the insert failed.
        }

        public static void PlatformsFilter(string chk) {


        }





        public static int getMediaIDByName(string Name)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT TOP 1 ID FROM Main WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // The record was found
                    ID = (int)reader["ID"];

                }
                else
                {
                    // The record was not found
                    ID = -1;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                ID = -1;
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static bool GetMediaInfoByID(int ID, ref string Name, ref double Rating, ref int Duration, ref bool Completed, ref int CategoryID, ref bool WatchAgain, ref string WhereToWatch, ref bool StartPlaying
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
                    Duration = (int)reader["Duration"];
                    Completed = (bool)reader["Completed"];
                    CategoryID = (int)reader["CategoryID"];
                    WatchAgain = (bool)reader["WatchAgain"];
                    WhereToWatch = (string)reader["WhereToWatch"];
                    StartPlaying = (bool)reader["startPlaying"];




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


        public static int AddNewMedia(string Name, double Rating,
            int Duration, bool Completed, int CategoryID, bool WatchAgain, string WhereToWatch, bool StartPlaying)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Main (Name, Rating,  Duration, Completed,  CategoryID, WatchAgain, WhereToWatch, StartPlaying)
                             VALUES (@Name, @Rating,  @Duration, @Completed, @CategoryID, @WatchAgain, @WhereToWatch, @StartPlaying);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);



            if (Name != "" && Name != null)
            {
                command.Parameters.AddWithValue("@Name", Name);
            }
            else
            {
                command.Parameters.AddWithValue("@Name", System.DBNull.Value);
            }

            if (Rating != -1 && Rating.ToString() != null)
            {
                command.Parameters.AddWithValue("@Rating", Rating);
            }
            else
            {
                command.Parameters.AddWithValue("@Rating", System.DBNull.Value);
            }

            if (Duration != -1 && Duration.ToString() != null)
                command.Parameters.AddWithValue("@Duration", Duration);
            else
                command.Parameters.AddWithValue("@Duration", System.DBNull.Value);

            if (Completed.ToString() != null)
            {
                command.Parameters.AddWithValue("@Completed", Completed);
            }
            else
            {
                command.Parameters.AddWithValue("@Completed", System.DBNull.Value);
            }
            if (CategoryID != -1 && CategoryID.ToString() != null)
            {
                command.Parameters.AddWithValue("@CategoryID", CategoryID);
            }
            else
            {
                command.Parameters.AddWithValue("@CategoryID", System.DBNull.Value);
            }
            if (WatchAgain.ToString() != null)
            {
                command.Parameters.AddWithValue("@WatchAgain", WatchAgain);
            }
            else
            {
                command.Parameters.AddWithValue("@WatchAgain", System.DBNull.Value);
            }
            if (WhereToWatch != "" && WhereToWatch != null)
            {
                command.Parameters.AddWithValue("@WhereToWatch", WhereToWatch);
            }
            else
            {
                command.Parameters.AddWithValue("@WhereToWatch", System.DBNull.Value);
            }
            if (StartPlaying.ToString() != null)
            {
                command.Parameters.AddWithValue("@StartPlaying", StartPlaying);
            }
            else
            {
                command.Parameters.AddWithValue("@StartPlaying", System.DBNull.Value);
            }




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

        public static bool UpdateMedia(int ID, string Name, double Rating,
            int Duration, bool Completed, int CategoryID, bool WatchAgain, string WhereToWatch, bool StartPlaying)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Main  
                            set 
                                Rating = @Rating, 
                             
                                Duration = @Duration, 
                                Completed = @Completed,
                               
                                CategoryID = @CategoryID,
                                WatchAgain = @WatchAgain,
                                WhereToWatch = @WhereToWatch,
                                StartPlaying = @StartPlaying
                            
                              
                                where Name = @Name";

            SqlCommand command = new SqlCommand(query, connection);



            if (Name != "" && Name != null)
            {
                command.Parameters.AddWithValue("@Name", Name);
            }
            else
            {
                command.Parameters.AddWithValue("@Name", System.DBNull.Value);
            }

            if (Rating != -1 && Rating.ToString() != null)
            {
                command.Parameters.AddWithValue("@Rating", Rating);
            }
            else
            {
                command.Parameters.AddWithValue("@Rating", System.DBNull.Value);
            }

            if (Duration != -1 && Duration.ToString() != null)
                command.Parameters.AddWithValue("@Duration", Duration);
            else
                command.Parameters.AddWithValue("@Duration", System.DBNull.Value);

            if (Completed.ToString() != null)
            {
                command.Parameters.AddWithValue("@Completed", Completed);
            }
            else
            {
                command.Parameters.AddWithValue("@Completed", System.DBNull.Value);
            }
            if (CategoryID != -1 && CategoryID.ToString() != null)
            {
                command.Parameters.AddWithValue("@CategoryID", CategoryID);
            }
            else
            {
                command.Parameters.AddWithValue("@CategoryID", System.DBNull.Value);
            }
            if (WatchAgain.ToString() != null)
            {
                command.Parameters.AddWithValue("@WatchAgain", WatchAgain);
            }
            else
            {
                command.Parameters.AddWithValue("@WatchAgain", System.DBNull.Value);
            }
            if (WhereToWatch != "" && WhereToWatch != null)
            {
                command.Parameters.AddWithValue("@WhereToWatch", WhereToWatch);
            }
            else
            {
                command.Parameters.AddWithValue("@WhereToWatch", System.DBNull.Value);
            }
            if (StartPlaying.ToString() != null)
            {
                command.Parameters.AddWithValue("@StartPlaying", StartPlaying);
            }
            else
            {
                command.Parameters.AddWithValue("@StartPlaying", System.DBNull.Value);
            }




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

        public static DataTable GetAllGames()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Main where CategoryID = 3 order by Rating";

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

        public static DataTable GetAllBooks()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Main where CategoryID = 4 order by Rating";

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

        public static bool IsMediaExistInIMDB(int ID)
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

        public static bool IsMediaExistInMain(string Name)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Main WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
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

        public static DataTable getAllMediaWithinAvailableTime(int Duration, string choices, char Difficulty)
        {


            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("GetNextEpisodePerSeries", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120; // Increase timeout to 2 minutes
                cmd.Parameters.AddWithValue("@Duration", Duration);
                cmd.Parameters.AddWithValue("@choices", choices); // e.g., "Netflix,Hulu,Prime"
                cmd.Parameters.AddWithValue("@Difficulty", Difficulty);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);
                return resultTable;
            }
        }

        public static DataTable GetAllGamesWithinAvailableTime(int Duration, char Difficulty)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Main where CategoryID = 3 order by Rating";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Difficulty", Difficulty);
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
	mediaBasics.startYear,
	mediaBasics.isAdult,
	mediaBasics.Completed as Media_Completed,
    mediaBasics.WatchAgain as Media_Watch_Again,
    mediaBasics.screenResolution,
    mediaBasics.difficulty
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

            string query = "SELECT TOP (200) Basics.tconst, Basics.titleType, Basics.primaryTitle, Basics.originalTitle, Basics.isAdult, Basics.startYear, Basics.endYear, Basics.runtimeMinutes, Basics.genres, Basics.Completed, Basics.whereToWatch, Basics.Category, Ratings.averageRating, Ratings.numVotes\r\n FROM  Basics INNER JOIN\r\n         Ratings ON Basics.tconst = Ratings.tconst AND Basics.tconst = Ratings.tconst -- join Episodes on Episodes.parentTconst = basics.tconst\r\nWHERE Basics.primaryTitle Like @Name \r\nORDER BY Ratings.averageRating DESC";

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
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }



        public static DataTable GetTopMedia(int duration, string choices)
        {

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("GetTopMediaRecommendations", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120; // Increase timeout to 2 minutes
                cmd.Parameters.AddWithValue("@Duration", duration);
                cmd.Parameters.AddWithValue("@choices", choices); // e.g., "Netflix,Hulu,Prime"

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);
                return resultTable;
            }
        }

        public static DataTable GetAllStartedMedia(int Duration)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Main where StartPlaying = 1 and Duration >= @Duration order by Rating";
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
    } }

