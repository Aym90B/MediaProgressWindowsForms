using System;
using System.Data;
using System.Xml.Linq;
using MediaProgressDataAccessLayer;

namespace MediaProgressBusinessLayer
{
    public class clsSeries
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int Seasons { set; get; }
        public string Name { set; get; }
        public double Rating { set; get; }
        public int Duration { set; get; }
        public bool Completed { set; get; }



        public clsSeries()

        {
            this.ID = -1;
            this.Seasons = -1;
            this.Name = "";
            this.Rating = -1;
            this.Duration = -1;
            this.Completed = false;


            Mode = enMode.AddNew;
        }

        private clsSeries(int ID, string Name, int Seasons, double Rating,
            int Duration, bool Completed)

        {
            this.ID = ID;
            this.Name = Name;
            this.Seasons = Seasons;
            this.Rating = Rating;
            this.Duration = Duration;
            this.Completed = Completed;


            Mode = enMode.Update;

        }

        private bool _AddNewSeries()
        {
            //call DataAccess Layer 

            this.ID = clsSeriesDataAccess.AddNewSeries(this.Name, this.Seasons, this.Rating, this.Duration, this.Completed);

            return (this.ID != -1);
        }

        private bool _UpdateSeries()
        {
            //call DataAccess Layer 

            return clsSeriesDataAccess.UpdateSeries(this.ID, this.Name, this.Seasons, this.Rating, this.Duration, this.Completed);

        }

        public static clsSeries Find(int ID)
        {

            string Name = "";
            int Seasons = -1;
            double Rating = -1;
            int Duration = -1;
            bool Completed = false;

            //int SeriesID = -1;

            if (clsSeriesDataAccess.GetSeriesInfoByID(ID, ref Seasons, ref Name,  ref Rating,
                          ref Duration, ref Completed))

                return new clsSeries(ID, Name, Seasons, Rating,
                           Duration, Completed);
            else
                return null;
        }

        public static clsSeries Find(string SeriesName)
        {
            int ID = -1;
          
            int Seasons = -1;
            double Rating = -1;
            int Duration = -1;
            bool Completed = false;


            if (clsSeriesDataAccess.GetSeriesInfoByName(SeriesName, ref ID, ref Seasons, ref Rating, ref Duration, ref Completed))

                return new clsSeries(ID, SeriesName, Seasons, Rating, Duration, Completed);
            else
                return null;

        }



        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSeries())
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

        public static DataTable GetAllSeries()
        {
            return clsSeriesDataAccess.GetAllSeries();

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


    }
}
