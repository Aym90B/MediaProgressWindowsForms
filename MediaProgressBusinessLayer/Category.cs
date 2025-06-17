using System;
using System.Data;
using System.Xml.Linq;
using MediaProgressDataAccessLayer;

namespace MediaProgressBusinessLayer
{
    public class clsCategory
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }

        public clsCategory()

        {
            this.ID = -1;
            this.Name = "";
           


            Mode = enMode.AddNew;
        }

        private clsCategory(int ID, string Name)

        {
            this.ID = ID;
            this.Name = Name;
          



            Mode = enMode.Update;

        }

        private bool _AddNewCategory()
        {
            //call DataAccess Layer 

            this.ID = clsCategoryDataAccess.AddNewCategory(this.Name);

            return (this.ID != -1);
        }

        private bool _UpdateCategory()
        {
            //call DataAccess Layer 

            return clsCategoryDataAccess.UpdateCategory(this.ID, this.Name);

        }

        public static clsCategory Find(int ID)
        {

            string Name = "";
          


            if (clsCategoryDataAccess.GetCategoryInfoByID(ID, ref Name))

                return new clsCategory(ID, Name);
            else
                return null;
        }

        public static clsCategory Find(string CategoryName)
        {
            int ID = -1;

            


            if (clsCategoryDataAccess.GetCategoryInfoByName(CategoryName, ref ID))

                return new clsCategory(ID, CategoryName);
            else
                return null;

        }



        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCategory())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCategory();

            }




            return false;
        }

        public static DataTable GetAllCategories()
        {
            return clsCategoryDataAccess.GetAllCategories();

        }

        public static bool DeleteCategory(int ID)
        {
            return clsCategoryDataAccess.DeleteCategory(ID);
        }

        public static bool isCategoryExist(int ID)
        {
            return clsCategoryDataAccess.IsCategoryExist(ID);
        }

        //public static DataTable getAllMoviesWithinAvailableTime(int Duration)
        //{
        //    return clsMovieDataAccess.getAllMoviesWithinAvailableTime(Duration);
        //}
    }
}
