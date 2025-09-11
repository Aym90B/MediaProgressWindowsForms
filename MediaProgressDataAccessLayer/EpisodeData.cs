using System;
using System.Data;
using System.Data.SqlClient;

namespace MediaProgressDataAccessLayer
{
    public class clsEpisodeDataAccess
    {
        public static bool GetEpisodeInfoByID(int EpisodeID, ref int SeriesID, ref int Season, ref int EpisodeNumber, ref string Name, ref double Rating, ref short Duration, ref bool Completed, ref bool WatchAgain
           )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Episodes WHERE EpisodeID = @EpisodeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EpisodeID", EpisodeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    SeriesID = (int)reader["SeriesID"];
                    Season = (int)reader["SeriesID"];
                    EpisodeNumber = (int)reader["EpisodeNumber"];
                    Name = (string)reader["Name"];
                    Rating = (double)reader["Rating"];
                    Duration = (short)reader["Duration"];
                    Completed = (bool)reader["Completed"];
                    WatchAgain = (bool)reader["WatchAgain"];


                    //ImagePath: allows null in database so we should handle null
                    //if (reader["ImagePath"] != DBNull.Value)
                    //{
                    //    ImagePath = (string)reader["ImagePath"];
                    //}
                    //else
                    //{
                    //    ImagePath = "";
                    //}

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
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewEpisode(int SeriesID, int Season, int EpisodeNumber, string Name, double Rating,
            short Duration, bool Completed, bool WatchAgain)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Episodes (SeriesID, Season, EpisodeNumber, Name, Rating, Duration, Watched)
                             VALUES (@SeriesID, @Season, @EpisodeNumber, @Name, @Rating, @Duration, @Completed, @WatchAgain);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeriesID", SeriesID);
            command.Parameters.AddWithValue("@Season", Season);
            command.Parameters.AddWithValue("@EpisodeNumber", EpisodeNumber);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Rating", Rating);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Completed", Completed);
            command.Parameters.AddWithValue("@WatchAgain", WatchAgain);


            //if (ImagePath != "" && ImagePath != null)
            //    command.Parameters.AddWithValue("@ImagePath", ImagePath);
            //else
            //    command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

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
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ID;
        }

        public static bool UpdateEpisode(int EpisodeID, int SeriesID, int Season, int EpisodeNumber, string Name, double Rating,
            short Duration, bool Completed, bool WatchAgain)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Episodes  
                            set SeriesID = @SeriesID, 
                                Season = @Season,
                                EpisodeNumber = @EpisodeNumber, 
                                Name = @Name, 
                                Rating = @Rating,
                                Duration = @Duration,
                                Completed = @Completed,
                                WatchAgain = @WatchAgain
                              
                                where EpisodeID = @EpisodeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EpisodeID", EpisodeID);
            command.Parameters.AddWithValue("@SeriesID", SeriesID);
            command.Parameters.AddWithValue("@Season", Season);
            command.Parameters.AddWithValue("@EpisodeNumber", EpisodeNumber);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Rating", Rating);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Completed", Completed);
            command.Parameters.AddWithValue("@WatchAgain", WatchAgain);


         
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        //Get all episodes from series and season
        public static DataTable GetAllEpisodesFromSeries(int SeriesID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Episodes where SeriesID = @SeriesID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeriesID", SeriesID);

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

        public static DataTable GetAllEpisodes()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Episodes";

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeleteEpisode(int EpisodeID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Episodes 
                                where EpisodeID = @EpisodeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EpisodeID", EpisodeID);

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

        public static bool IsEpisodeExist(int EpisodeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Series WHERE EpisodeID = @EpisodeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EpisodeID", EpisodeID);

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

        //Get All Episodes With Available Time
        public static DataTable getAllEpisodesWithinAvailableTime(int Duration)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //string query = "SELECT * FROM Episodes Where Duration <= @Duration and Watched = 0 order by EpisodeNumber asc";

            string query = "SELECT\r\nseriesBasics.primaryTitle as seriesName,\r\nepisodeBasics.primaryTitle as episodeTitle,\r\nRatings.averageRating,\r\nEpisodes.seasonNumber,\r\nEpisodes.episodeNumber,\r\nRatings.numVotes,\r\nEpisodes.tconst,\r\nEpisodes.Completed as Episode_Completed,\r\nseriesBasics.Completed as Series_Completed,\r\nseriesBasics.whereToWatch,\r\nseriesBasics.runtimeMinutes " +
                "From\r\nBasics as seriesBasics\r\n\r\nJoin\r\nEpisodes on seriesBasics.tconst = Episodes.parentTconst\r\n\r\njoin\r\nBasics as episodeBasics on Episodes.tconst = episodeBasics.tconst\r\n\r\nJoin\r\nRatings on Episodes.tconst = Ratings.tconst\r\n\r\nwhere\r\nRatings.averageRating >= 7 and Ratings.numVotes >= 5000 and seriesBasics.runtimeMinutes <= @duration and Episodes.Completed IS NULL and Episodes.episodeNumber = 1 and Episodes.seasonNumber = 1\r\n\r\norder by\r\nRatings.averageRating Desc";

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
