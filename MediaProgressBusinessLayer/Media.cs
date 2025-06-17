using System;
using System.Data;
using System.Xml.Linq;
using MediaProgressDataAccessLayer;

namespace MediaProgressBusinessLayer
{
    public class clsMedia
    {
         

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }
        public double Rating { set; get; }
        public int Season { set; get; }
        public int EpisodeNumber { set; get; }
        public int Duration { set; get; }
        public bool Completed { set; get; }
        public int SeriesID { set; get; }
        public int CategoryID { set; get; }

        
        
        public clsMedia()

        {
            this.ID = -1;
            this.Name = "";
            this.Rating = -1;
            this.Season = -1;
            this.EpisodeNumber = -1;
            this.Duration = -1;
            this.Completed = false;
            this.SeriesID = -1;
            this.CategoryID = -1;
            

            Mode = enMode.AddNew;
        }

        private clsMedia(int ID, string Name, double Rating, int Season, int EpisodeNumber,
            int Duration, bool Completed, int SeriesID, int CategoryID)

        {
            this.ID = ID;
            this.Name = Name;
            this.Rating = Rating;
            this.Season = Season;
            this.EpisodeNumber = EpisodeNumber;
            this.Duration = Duration;
            this.Completed = Completed;
            this.SeriesID = SeriesID;
            this.CategoryID = CategoryID;

         

            Mode = enMode.Update;

        }

        private bool _AddNewMedia()
        {
            //call DataAccess Layer 

            this.ID = clsMovieDataAccess.AddNewMedia(this.Name, this.Rating, this.Season, this.EpisodeNumber, this.Duration, this.Completed, this.SeriesID, this.CategoryID);

            return (this.ID != -1);
        }

        private bool _UpdateMedia()
        {
            //call DataAccess Layer 

            return clsMovieDataAccess.UpdateMedia(this.ID, this.Name, this.Rating, this.Season, this.EpisodeNumber, this.Duration, this.Completed, this.SeriesID, this.CategoryID);

        }

        public static clsMedia Find(int ID)
        {

            string Name = "";
           double Rating = -1;
            int Season = -1;    
            int EpisodeNumber = -1;
            int Duration = -1;
            bool Completed = false;
            int SeriesID = -1;
            int CategoryID = -1;
          

            if (clsMovieDataAccess.GetMediaInfoByID(ID, ref Name, ref Rating, ref Season, ref EpisodeNumber,
                          ref Duration, ref Completed, ref SeriesID, ref CategoryID))

                return new clsMedia(ID, Name, Rating, Season, EpisodeNumber,
                           Duration, Completed, SeriesID, CategoryID);
            else
                return null;
        }

        

        

        public bool Save()
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

        public static DataTable GetAllMoviesWithinAvailableTime(int duration)
        {
            return clsMovieDataAccess.getAllMoviesWithinAvailableTime(duration);
        }

        public static DataTable getAllMovies()
        {
            return clsMovieDataAccess.GetAllMovies();
        }

        public static DataTable getAllSeries()
        {
            return clsSeriesDataAccess.GetAllSeries();
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
            return clsMovieDataAccess.IsMediaExist(ID);
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


    }
}

