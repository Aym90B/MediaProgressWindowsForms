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
    public class ImdbService
    {
        public string Tconst { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
        public int? RuntimeMinutes { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string ImdbRating { get; set; }
        public bool IsAdult { get; set; }

        private const string ApiKey = "944c9115"; // 🔑 Your OMDb API key
        private static readonly HttpClient httpClient = new HttpClient();

        // Refactored to use the centralized connection string
        private static string ConnectionString => clsDataAccessSettings.ConnectionString;

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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data from OMDb: {ex.Message}");
            }

            return new List<ImdbService>();
        }

        public static async Task<ImdbService> GetMediaDetailsAsync(string tconst)
        {
            var requestUrl = $"http://www.omdbapi.com/?i={tconst}&apikey={ApiKey}";

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
                        RuntimeMinutes = runtime,
                        IsAdult = false // OMDb doesn't strictly provide isAdult in the free tier usually, defaulting to false or need another logic
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching details: {ex.Message}");
            }
            return null;
        }
        
        // Helper classes for OMDb JSON deserialization
        public class OmdbSearchResult
        {
            public List<OmdbApplyItem> Search { get; set; }
            public string totalResults { get; set; }
            public string Response { get; set; }
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
            public string Runtime { get; set; }
            public string Response { get; set; }
        }
    }
}