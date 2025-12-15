using System;
using System.Data;
using System.Xml.Linq;
using MediaProgressDataAccessLayer;

namespace MediaProgressBusinessLayer
{
    public class clsEpisode 
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int SeriesID { set; get; }
        public int Season { set; get; }
        public int EpisodeNumber { set; get; }  

        public string Name { set; get; }
        public double Rating { set; get; }
        public short Duration { set; get; }
        public bool Completed { set; get; }
        public bool WatchAgain { set; get; }



        public clsEpisode()

        {
            this.ID = -1;
            this.SeriesID = -1;
            this.Season = -1;
            this.EpisodeNumber = -1;
            this.Name = "";
            this.Rating = -1;
            this.Duration = -1;
            this.Completed = false;
            this.WatchAgain = false;


            Mode = enMode.AddNew;
        }

        private clsEpisode(int ID, int SeriesID, int Season, int EpisodeNumber, string Name, double Rating,
            short Duration, bool Completed, bool WatchAgain)

        {
            this.ID = ID;
            this.SeriesID = SeriesID;
            this.Season = Season;
            this.EpisodeNumber = EpisodeNumber;
            this.Name = Name;
            this.Rating = Rating;
            this.Duration = Duration;
            this.Completed = Completed;
            this.WatchAgain = WatchAgain;


            Mode = enMode.Update;

        }

        private bool _AddNewEpisode(int SeriesID)
        {
            //call DataAccess Layer 

            this.ID = clsEpisodeDataAccess.AddNewEpisode(SeriesID, this.Season, this.EpisodeNumber, this.Name, this.Rating, this.Duration, this.Completed, this.WatchAgain);

            return (this.ID != -1);
        }

        private bool _UpdateEpisode()
        {
            //call DataAccess Layer 

            return clsEpisodeDataAccess.UpdateEpisode(this.ID, this.SeriesID, this.Season, this.EpisodeNumber, this.Name, this.Rating, this.Duration, this.Completed, this.WatchAgain);

        }

        public static clsEpisode Find(int ID)
        {


            int SeriesID = -1;
            int Season = -1;
            int EpisodeNumber = -1;
            string Name = "";
            double Rating = -1;
            short Duration = -1;
            bool Completed = false;
            bool WatchAgain = false;


            if (clsEpisodeDataAccess.GetEpisodeInfoByID(ID, ref SeriesID, ref Season, ref EpisodeNumber, ref Name, ref Rating,
                          ref Duration, ref Completed, ref WatchAgain))

                return new clsEpisode(ID, SeriesID, Season, EpisodeNumber, Name, Rating,
                           Duration, Completed, WatchAgain);
            else
                return null;
        }



        public bool Save(enMode Mode, int SeriesID)
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEpisode(SeriesID))
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateEpisode();

            }




            return false;
        }

        public static DataTable GetAllEpisodes()
        {
            return clsEpisodeDataAccess.GetAllEpisodes();
        }

        //public static DataTable GetAllEpisodesFromSeries(int SeriesID)
        //{
        //    return clsEpisodeDataAccess.GetAllEpisodesFromSeries(SeriesID);

        //}

        public static bool DeleteEpisode(int ID)
        {
            return clsEpisodeDataAccess.DeleteEpisode(ID);
        }

        public static bool IsEpisodeExist(string Name)
        {
            return clsEpisodeDataAccess.IsEpisodeExist(Name);
        }

        public static DataTable getAllEpisodesWithinAvailableTime(int Duration, string Choices, string ScreenResolution, char Difficulty)
        {
            return clsEpisodeDataAccess.getAllEpisodesWithinAvailableTime(Duration, Choices, ScreenResolution, Difficulty);
        }

        public static DataTable GetAllEpisodes2025(int Duration, string Choices)
        {
            return clsEpisodeDataAccess.GetAllEpisodes2025(Duration, Choices);
        }

        public static bool MarkEpisodeAsCompleted(string SeriesName, int Season, int EpisodeNumber)
        {
            return clsEpisodeDataAccess.MarkEpisodeAsCompleted(SeriesName, Season, EpisodeNumber);
        }
        }
}
