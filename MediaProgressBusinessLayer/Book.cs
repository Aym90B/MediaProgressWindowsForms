using MediaProgressDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MediaProgressBusinessLayer
{
    public class clsBook : clsMedia
    {
        public int BookID { set; get; }
        public int NumberOfPages { set; get; }
        public int CurrentPage { set; get; }
     

        public string Author { set; get; }
        public string ISBN { set; get; }


     
        public clsBook()
        {
            this.BookID = -1;
            this.NumberOfPages = -1;
            this.CurrentPage = -1;
           
            this.Author = "";
            this.ISBN = "";
         
            Mode = enMode.AddNew;
        }
        private clsBook(int BookID, int NumberOfPages, int CurrentPage, string Author, string ISBN)
        {
            this.BookID = BookID;
            this.NumberOfPages = NumberOfPages;
            this.CurrentPage = CurrentPage;
            this.Author = Author;
            this.ISBN = ISBN;
           
            Mode = enMode.Update;
        }

        private bool _AddNewBook(int BookID)
        {
            //call DataAccess Layer 
            this.ID = clsBookDataAccess.AddNewBook(this.NumberOfPages, this.CurrentPage, BookID, this.Author, this.ISBN);

            return (this.ID != -1);
        }

        private bool _UpdateBook(int ID)
        {
            //call DataAccess Layer 

            return clsBookDataAccess.UpdateBook(ID, this.NumberOfPages, this.CurrentPage, this.Author, this.ISBN);

        }


        public static DataTable GetAllBooksWithinAvailableTime(int Duration, char Difficulty)
        {
             return clsBookDataAccess.GetAllBooksWithinAvailableTime(Duration, Difficulty);
        }

        public static clsBook FindBookByMediaID(int BookID)
        {
            
            int NumberOfPages = 0;
            int CurrentPage = 0;
            string Author = "";
            string ISBN = "";

            if (clsBookDataAccess.GetBookInfoByID(BookID, ref NumberOfPages, ref CurrentPage,
                          ref Author, ref ISBN))

                return new clsBook(BookID, NumberOfPages, CurrentPage,
                           Author, ISBN);
            else
                return null;
        }

        public static void UpdateBookCompletionPercentage()
        {
            clsBookDataAccess.UpdateBookCompletionPercentage();
        }


        public bool SaveBook(int ID, enMode Mode)
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBook(ID))
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateBook(ID);

            }




            return false;
        }
    }

    }
