using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using MediaProgressDataAccessLayer;

namespace MediaProgressBusinessLayer
{
    public class clsSeries : clsMedia
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int SeriesID { set; get; }
        public int NumberOfSeasons { set; get; }
       
       
        public int NumberOfEpisodes { set; get; }

        public bool startWatching { set; get; }

        public float percentageOfCompletion { set; get; }

        public int watchedEpisodes { set; get; }



        public clsSeries()

        {
            this.SeriesID = -1;
            this.NumberOfSeasons = -1;
            this.NumberOfEpisodes = -1;
            this.startWatching = false;
           
            this.watchedEpisodes = 0;




            Mode = enMode.AddNew;
        }

        private clsSeries(int SeriesID, int NumberOfSeasons, int NumberOfEpisodes, bool startWatching,  int WatchedEpisodes)

        {
           this.SeriesID = SeriesID;
            this.NumberOfSeasons = NumberOfSeasons;
            this.NumberOfEpisodes = NumberOfEpisodes;
            this.startWatching = startWatching;
           
            this.watchedEpisodes = WatchedEpisodes;


            Mode = enMode.Update;

        }

        private bool _AddNewSeries(int ID)
        {
            //call DataAccess Layer 

            this.SeriesID = clsSeriesDataAccess.AddNewSeries(this.NumberOfSeasons, this.NumberOfEpisodes, ID, this.startWatching, this.watchedEpisodes);

            return (this.SeriesID != -1);
        }

        private bool _UpdateSeries()
        {
            //call DataAccess Layer 

            return clsSeriesDataAccess.UpdateSeries(this.SeriesID, this.NumberOfSeasons, this.NumberOfEpisodes, this.startWatching,  this.watchedEpisodes);

        }

        public static clsSeries Find(int SeriesID)
        {

            
            int NumberOfSeasons = -1;
            int NumberOfEpisodes = -1;
           bool startWatching = false;
          
            int watchedEpisodes = 0;

            //int SeriesID = -1;

            if (clsSeriesDataAccess.GetSeriesInfoByID(SeriesID, ref NumberOfSeasons, ref NumberOfEpisodes, ref startWatching, ref watchedEpisodes))

                return new clsSeries(SeriesID, NumberOfSeasons, NumberOfEpisodes, startWatching,  watchedEpisodes);
            else
                return null;
        }

        //public static clsSeries Find(string SeriesName)
        //{
        //    int ID = -1;
          
        //    int Seasons = -1;
        //    double Rating = -1;
        //    int Duration = -1;
        //    bool Completed = false;


        //    if (clsSeriesDataAccess.GetSeriesInfoByName(SeriesName, ref ID, ref Seasons, ref Rating, ref Duration, ref Completed))

        //        return new clsSeries(ID, SeriesName, Seasons, Rating, Duration, Completed);
        //    else
        //        return null;

        //}

        static public float GetSeriesPercentageCompletion(int SeriesID)
        {
            return clsSeriesDataAccess.GetSeriesPercentageCompletion(SeriesID);
        }



        public bool SaveSeries(int ID)
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSeries(ID))
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateSeries();

            }




            return false;
        }

        public static int GetSeriesIDByName(string SeriesName)
        {
            return clsSeriesDataAccess.GetSeriesIDByName(SeriesName);
        }

        public static DataTable GetAllSeries()
        {
            return clsSeriesDataAccess.GetAllSeries();
        }

        public static DataTable GetAllSeasons(string SeriesName)
        {
            return clsSeriesDataAccess.GetAllSeasons(SeriesName);
        }

        public static DataTable GetAllSeriesFromIMDB()
        {
            return clsSeriesDataAccess.GetAllSeriesFromIMDB();

        }

        public static List< string>  GetAllSeriesNames()
        {
            return clsSeriesDataAccess.getAllSeriesNames();
        }

        public static bool DeleteSeries(int ID)
        {
            return clsSeriesDataAccess.DeleteSeries(ID);
        }

        public static bool isSeriesExist(int ID)
        {
            return clsSeriesDataAccess.IsSeriesExist(ID);
        }

        public static DataTable getAllSeriesWithinAvailableTime(int Duration)
        {
            return clsSeriesDataAccess.getAllSeriesWithinAvailableTime(Duration);
        }

        public static int GetNumberOfSeasonsForSeries(string seriesName)
        {
            return clsSeriesDataAccess.getNumberOfSeasonsForSeries(seriesName);
        }


    }
}
