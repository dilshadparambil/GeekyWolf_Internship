using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Database
    {
        public string GetUserName(int userId)
        {
            if (userId == 1)
            {
                return "dilshad";
            }
                
            if (userId == 2)
            {
                return "DK";
            }
            return null;
        }


    }
}
