using MediaProgressDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProgressBusinessLayer
{
    public class clsBook :clsMedia
    {
        public int BookID { set; get; }
        public int NumberOfPages { set; get; }
        public int CurrentPage { set; get; }
        public bool startReading { set; get; }

        
        public float percentageOfCompletion { set; get; }
        public clsBook()
        {
            this.BookID = -1;
            this.NumberOfPages = -1;
            this.CurrentPage = -1;
            this.startReading = false;
            this.percentageOfCompletion = 0;
            Mode = enMode.AddNew;
        }
        private clsBook( int BookID, int NumberOfPages, int CurrentPage, bool startReading, float percentageOfCompletion)
        {
            this.BookID = BookID;
            this.NumberOfPages = NumberOfPages;
            this.CurrentPage = CurrentPage;
            this.startReading = startReading;
            this.percentageOfCompletion = percentageOfCompletion;
            Mode = enMode.Update;
        }

        private bool _AddNewBook(int ID)
        {
            //call DataAccess Layer 
            this.BookID = clsBookDataAccess.AddNewBook(this.NumberOfPages, this.CurrentPage, ID);

            return (this.BookID != -1);
        }
    }

   
    }
