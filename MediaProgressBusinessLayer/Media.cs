using MediaProgressDataAccessLayer;
using MediaProgressWindowsForms;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MediaProgressBusinessLayer
{
    public class clsMedia
    {
         

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }
        public double Rating { set; get; }
       
    
        public int Duration { set; get; }
        public bool Completed { set; get; }
     
        public int CategoryID { set; get; }
        public bool WatchAgain { set; get; }
        public string WhereToWatch { set; get; }
        public bool StartPlaying { set; get; }


        public clsMedia()

        {
            this.ID = -1;
            this.Name = "";
            this.Rating = -1;
           
           
            this.Duration = -1;
            this.Completed = false;
           
            this.CategoryID = -1;
            this.WatchAgain = false;
            this.WhereToWatch = "";
            this.StartPlaying = false;

            Mode = enMode.AddNew;
        }

        private clsMedia(int ID, string Name, double Rating,
            int Duration, bool Completed,  int CategoryID, bool WatchAgain, string WhereToWatch, bool StartPlaying)

        {
            this.ID = ID;
            this.Name = Name;
            this.Rating = Rating;
          
            this.Duration = Duration;
            this.Completed = Completed;
          
            this.CategoryID = CategoryID;
            this.WatchAgain = WatchAgain;
            this.WhereToWatch = WhereToWatch;
            this.StartPlaying = StartPlaying;


            Mode = enMode.Update;

        }

        private bool _AddNewMedia()
        {
            //call DataAccess Layer 

            this.ID = clsMovieDataAccess.AddNewMedia(this.Name, this.Rating,this.Duration, this.Completed, this.CategoryID, this.WatchAgain, this.WhereToWatch, this.StartPlaying);

            return (this.ID != -1);
        }

        private bool _UpdateMedia()
        {
            //call DataAccess Layer 

            return clsMovieDataAccess.UpdateMedia(this.ID,this.Name, this.Rating,   this.Duration, this.Completed,  this.CategoryID, this.WatchAgain, this.WhereToWatch, this.StartPlaying);

        }

        public static clsMedia Find(int ID)
        {

            string Name = "";
           double Rating = -1;
           
            int Duration = -1;
            bool Completed = false;
          
            int CategoryID = -1;
            bool WatchAgain = false;
            string WhereToWatch = "";
            bool StartPlaying = false;


            if (clsMovieDataAccess.GetMediaInfoByID(ID, ref Name, ref Rating, 
                          ref Duration, ref Completed, ref CategoryID, ref WatchAgain, ref WhereToWatch, ref StartPlaying))

                return new clsMedia(ID, Name, Rating, 
                           Duration, Completed,  CategoryID, WatchAgain, WhereToWatch,StartPlaying);
            else
                return null;
        }

        

        

        public bool Save(enMode Mode)
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMedia())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateMedia();

            }




            return false;
        }

        public static async Task<OmdbApiResponse> SearchImdbOnlineAsync(string title)
        {
            return await OmdbApiResponse.SearchImdbOnlineAsync(title);
        }

        public static async Task<ImdbService> SearchLocalImdbDatabaseAsync(string title)
        {
            return await ImdbService.SearchLocalImdbDatabaseAsync(title);
        }

        public static  Task UpdateTconstInDatabaseAsync(string originalTitle, string tconst)
        {
            return  ImdbService.UpdateTconstInDatabaseAsync(originalTitle, tconst);
        }


        public static async Task<bool>  AddNewMediaToMainAsync(string title, string tconst, bool isAdult, int runtimeMinutes)
        {
            return await clsMovieDataAccess.AddNewMediaToMainAsync(title, tconst, isAdult, runtimeMinutes);
        }

        public static DataTable GetAllMoviesWithinAvailableTime(int duration)
        {
            return clsMovieDataAccess.getAllMoviesWithinAvailableTime(duration);
        }

        public static DataTable getAllMovies()
        {
            return clsMovieDataAccess.GetAllMovies();
        }

        public static DataTable getAllSeriesFromIMDB()
        {
            return clsSeriesDataAccess.GetAllSeriesFromIMDB();
        }

        public static DataTable GetAllMedia()
        {
            return clsMovieDataAccess.GetAllMedia();

        }

        public static bool DeleteMedia(int ID)
        {
            return clsMovieDataAccess.DeleteMedia(ID);
        }

        public static bool isMediaExist(int ID)
        {
            return clsMovieDataAccess.IsMediaExistInIMDB(ID);
        }

        public static DataTable getAllMediaWithinAvailableTime(int Duration)
        {
            return clsMovieDataAccess.getAllMediaWithinAvailableTime(Duration);
        }

        public static DataTable getAllMoviesWithinAvailableTime(int Duration)
        {
            return clsMovieDataAccess.getAllMoviesWithinAvailableTime(Duration);
        }

        public static DataTable getAllMediaWithinName(string Name)
        {
            return clsMovieDataAccess.GetMediaInfoByName(Name);
        }

        public static bool IsMediaExistInMain(string Name)
        {
            return clsMovieDataAccess.IsMediaExistInMain(Name);
        }

        public static int getMediaIDByName(string Name)
        {
            return clsMovieDataAccess.getMediaIDByName(Name);
        }

        public static DataTable GetAllGames()
        {
            return clsMovieDataAccess.GetAllGames();
        }

        public static DataTable GetAllBooks()
        {
            return clsMovieDataAccess.GetAllBooks();
        }

    }
}

