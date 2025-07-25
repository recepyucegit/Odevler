using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_DbFirstStreetlifting.Managers.Abstract;
using CA_DbFirstStreetlifting.Models;

namespace CA_DbFirstStreetlifting.Managers.Concretes
{
    internal class UserManager : IUserManager
    {

        StreetliftingCodeFirstContext context= new StreetliftingCodeFirstContext();
        public void CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            User? user = GetUserById(userId);
            context.Users.Remove(user);
            context.SaveChanges();


        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            User? user = context.Users.Find(userId);
            return user;
        }

        public void UpdateUser(User user)
        {
            User? existingUser = context.Users.Find(user.Id);
            existingUser.NickName = user.NickName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            context.SaveChanges();
        }
    }
}
