using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_DbFirstStreetlifting.Models;

namespace CA_DbFirstStreetlifting.Managers.Abstract
{
    internal interface IUserManager
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        List<User> GetAllUsers();



    }
}
