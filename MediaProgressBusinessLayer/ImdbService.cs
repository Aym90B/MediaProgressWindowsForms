using MediaProgressDataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace MediaProgressWindowsForms
{
    // A simple class to hold the data retrieved from your local IMDb 'Basics' table
    public class ImdbService
    {
        public string Tconst { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
        public int? RuntimeMinutes { get; set; }


// Add this new search method to your DatabaseService.cs file
public static async Task<ImdbService> SearchLocalImdbDatabaseAsync(string title)
        {
            string ConnectionString = "Data Source=LT-4312\\SQLEXPRESS;Initial Catalog=MovieData;Integrated Security=True";
            // Using 'LIKE' allows for more flexible matching
            var sqlQuery = "SELECT TOP 1 tconst, primaryTitle, genres, runtimeMinutes FROM Basics WHERE primaryTitle LIKE @title;";

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    // The '%' are wildcards, so a search for "Dune" will match "Dune: Part Two"
                    command.Parameters.AddWithValue("@title", $"%{title}%");

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            // If a record was found, populate our object
                            return new ImdbService
                            {
                                Tconst = reader["tconst"] as string,
                                Title = reader["primaryTitle"] as string,
                                Genres = reader["genres"] as string,
                                // Handle potential null values from the database
                                RuntimeMinutes = reader["runtimeMinutes"] as int?
                            };
                        }
                    }
                }
            }
            return null; // Return null if no match was found
        }

        private const string ConnectionString = "Data Source=LT-4312\\SQLEXPRESS;Initial Catalog=MovieData;Integrated Security=True";

        public static async Task UpdateTconstInDatabaseAsync(string originalTitle, string tconst)
        {
            // The SQL command to update the record
            var sqlQuery = "UPDATE Basics SET originalTitle = @originalTitle WHERE tconst = @tconst;";

            // 'using' statements ensure the connection is properly closed even if errors occur
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@tconst", tconst);
                    command.Parameters.AddWithValue("@originalTitle", originalTitle);

                    try
                    {
                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        Console.WriteLine($"Database updated. Rows affected: {rowsAffected}");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine($"A database error occurred: {e.Message}");
                    }
                }
            }
        }


    }
    // Reminder: This is the class for the API response
    public class OmdbApiResponse
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("imdbID")]
        public string Tconst { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }


        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiKey = "944c9115"; // 🔑 Your OMDb API key

        public static async Task<OmdbApiResponse> SearchImdbOnlineAsync(string title)
        {
            var requestUrl = $"http://www.omdbapi.com/?t={title}&apikey={ApiKey}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<OmdbApiResponse>(jsonResponse);

                // Return the entire response object
                return apiResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"An error occurred with the API request: {e.Message}");
                return null;
            }
        }
    }

}