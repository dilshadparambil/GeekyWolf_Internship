using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserDetails
    {
        private Database db = new Database();

        public string GetUser(int userId)
        {
            string name = db.GetUserName(userId);
            if (name == null )
            {
                return "Unknown user";
            }
            return $"Welcome, {name}!";
        }
    }
}
