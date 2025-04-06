using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CinemaManagement.Models;

namespace CinemaManagement.Repository
{
    public static class UserRepository
    {
        private static List<User> users = CinemaContext.INSTANCE.Users.ToList();

        static UserRepository()
        {
        }

        public static bool ValidateUser(string username, string password)
        {
            return users.Any(u => u.Username == username && u.Password == password);
        }
    }
}


