using MediaProgressDataAccessLayer;
using System;
using System.Collections.Generic;
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
        public bool StartReading { set; get; }

        public string Author { set; get; }
        public string ISBN { set; get; }


        public float PercentageOfCompletion { set; get; }
        public clsBook()
        {
            this.BookID = -1;
            this.NumberOfPages = -1;
            this.CurrentPage = -1;
            this.StartReading = false;
            this.Author = "";
            this.ISBN = "";
            this.PercentageOfCompletion = 0;
            Mode = enMode.AddNew;
        }
        private clsBook(int BookID, int NumberOfPages, int CurrentPage, bool startReading, float percentageOfCompletion)
        {
            this.BookID = BookID;
            this.NumberOfPages = NumberOfPages;
            this.CurrentPage = CurrentPage;
            this.StartReading = startReading;
            this.PercentageOfCompletion = percentageOfCompletion;
            Mode = enMode.Update;
        }

        private bool _AddNewBook(int ID)
        {
            //call DataAccess Layer 
            this.BookID = clsBookDataAccess.AddNewBook(this.NumberOfPages, this.CurrentPage, ID, this.Author, this.ISBN);

            return (this.BookID != -1);
        }

        private bool _UpdateBook()
        {
            //call DataAccess Layer 

            return clsBookDataAccess.UpdateBook(this.BookID, this.NumberOfPages, this.CurrentPage, this.Author, this.ISBN);

        }


        public bool SaveBook(int ID)
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

                    return _UpdateBook();

            }




            return false;
        }
    }

    }
