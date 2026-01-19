using MediaProgressDataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MediaProgressBusinessLayer
{
    public class ImdbService
    {
        public string Tconst { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
        public int? RuntimeMinutes { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string ImdbRating { get; set; }
        public int? ImdbVotes { get; set; }
        public bool IsAdult { get; set; }

        private const string ApiKey = "944c9115"; // 🔑 Your OMDb API key
        private static readonly HttpClient httpClient = new HttpClient();

        // Refactored to use the centralized connection string
        private static string ConnectionString = clsDataAccessSettings.ConnectionString;

        public static async Task<List<ImdbService>> GetNewMediaByYearAsync(int year, string type, string searchTerm = "a", int page = 1)
        {
            // OMDb Search API: ?s={searchTerm}&y={year}&type={type}&page={page}
            // Note: OMDb requires a search term. We use a generic one if not provided, but specificity helps.
            var requestUrl = $"http://www.omdbapi.com/?s={searchTerm}&y={year}&type={type}&page={page}&apikey={ApiKey}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var searchResult = JsonConvert.DeserializeObject<OmdbSearchResult>(jsonResponse);

                if (searchResult.Response == "True" && searchResult.Search != null)
                {
                    return searchResult.Search.Select(m => new ImdbService
                    {
                        Title = m.Title,
                        Year = m.Year,
                        Tconst = m.imdbID,
                        Type = m.Type
                    }).ToList();
                }
                else if (searchResult.Response == "False")
                {
                    throw new Exception(searchResult.Error ?? "Unknown OMDb error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data from OMDb: {ex.Message}");
                throw; // Rethrow to allow UI to handle it
            }

            return new List<ImdbService>();
        }

        public static async Task<List<ImdbService>> AymanGetNewMediaByYearAsync(int year, string type, string searchTerm = "a", int page = 1)
        {
            // OMDb Search API: ?s={searchTerm}&y={year}&type={type}&page={page}
            // Note: OMDb requires a search term. We use a generic one if not provided, but specificity helps.
            var requestUrl = $"https://api.imdbapi.dev/titles?types={type}&startYear={year}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var searchResult = JsonConvert.DeserializeObject<IMDBSearchResult>(jsonResponse);

                if (searchResult.Response == "True" && searchResult.Search != null)
                {
                    return searchResult.Search.Select(m => new ImdbService
                    {
                        Title = m.primaryTitle,
                        Year = m.startYear,
                        Tconst = m.id,
                        Type = m.type
                    }).ToList();
                }
                else if (searchResult.Response == "False")
                {
                    throw new Exception(searchResult.Error ?? "Unknown IMDB error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data from IMDB: {ex.Message}");
                throw; // Rethrow to allow UI to handle it
            }

            return new List<ImdbService>();
        }

        public static async Task<ImdbService> GetMediaDetailsAsync(string tconst)
        {
            var requestUrl = $"'https://api.imdbapi.dev/titles/{tconst}'";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<IMDBDetailsResponse>(jsonResponse);

                if (details.Response == "True")
                {
                    int.TryParse(details.Runtime?.Split(' ')[0], out int runtime);
                    
                    return new ImdbService
                    {
                        Title = details.primaryTitle,
                        Year = details.startYear,
                        Tconst = details.id,
                        Type = details.type,
                        Genres = details.genres,
                        ImdbRating = details.aggregateRating,
                        ImdbVotes = int.TryParse(details.imdbVotes?.Replace(",", ""), out int votes) ? (int?)votes : null,
                        RuntimeMinutes = runtime,
                        IsAdult = false 
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching details: {ex.Message}");
            }
            return null;
        }
        
        public static async Task<ImdbService> GetMediaByTitleAsync(string title)
        {
            var requestUrl = $"http://www.omdbapi.com/?t={title}&apikey={ApiKey}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<OmdbDetailsResponse>(jsonResponse);

                if (details.Response == "True")
                {
                    int.TryParse(details.Runtime?.Split(' ')[0], out int runtime);
                    
                    return new ImdbService
                    {
                        Title = details.Title,
                        Year = details.Year,
                        Tconst = details.imdbID,
                        Type = details.Type,
                        Genres = details.Genre,
                        ImdbRating = details.imdbRating,
                        ImdbVotes = int.TryParse(details.imdbVotes?.Replace(",", ""), out int votes) ? (int?)votes : null,
                        RuntimeMinutes = runtime,
                        IsAdult = false 
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching details: {ex.Message}");
            }
            return null;
        }

        public static async Task<ImdbService> SearchLocalImdbDatabaseAsync(string title)
        {
             using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT TOP 1 * FROM Basics WHERE primaryTitle = @title";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ImdbService
                                {
                                    Tconst = reader["tconst"].ToString(),
                                    Title = reader["primaryTitle"].ToString(),
                                    Type = reader["titleType"].ToString(),
                                    Year = reader["startYear"].ToString(),
                                    IsAdult = reader["isAdult"] != DBNull.Value && Convert.ToBoolean(reader["isAdult"]),
                                    RuntimeMinutes = reader["runtimeMinutes"] != DBNull.Value ? (int?)reader["runtimeMinutes"] : null,
                                    Genres = reader["genres"].ToString()
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error searching local DB: " + ex.Message);
                    }
                }
            }
            return null;
        }

        public static async Task UpdateTconstInDatabaseAsync(string title, string tconst)
        {
             using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE Basics SET tconst = @tconst WHERE primaryTitle = @title";
                 using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tconst", tconst);
                    command.Parameters.AddWithValue("@title", title);
                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating tconst: " + ex.Message);
                    }
                }
            }
        }

        // Helper classes for OMDb JSON deserialization
        public class OmdbSearchResult
        {
            public List<OmdbApplyItem> Search { get; set; }
            public string totalResults { get; set; }
            public string Response { get; set; }
            public string Error { get; set; }
        }

        public class OmdbApplyItem
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
        }

        public class OmdbDetailsResponse
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string Genre { get; set; }
            public string imdbRating { get; set; }
            public string imdbVotes { get; set; }
            public string Runtime { get; set; }
            public string Response { get; set; }
        }

        // Helper classes for imdbapi JSON deserialization
        public class IMDBSearchResult
        {
            public List<IMDBApplyItem> Search { get; set; }
            public string totalResults { get; set; }
            public string Response { get; set; }
            public string Error { get; set; }
        }

        public class IMDBApplyItem
        {
            public string primaryTitle { get; set; }
            public string startYear { get; set; }
            public string id { get; set; }
            public string type { get; set; }
        }

        public class IMDBDetailsResponse
        {
            public string primaryTitle { get; set; }
            public string startYear { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public string genres { get; set; }
            public string aggregateRating { get; set; }
            public string imdbVotes { get; set; }
            public string Runtime { get; set; }
            public string Response { get; set; }
        }
    }
}