using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaProgressDataAccessLayer;

namespace MediaProgressBusinessLayer


{
    public class clsUser :UserData
    {
       
        public bool ValidateUser(string username, string password)
        {
            return UserData.ValidateUser(username, password);
        }
    }
}
