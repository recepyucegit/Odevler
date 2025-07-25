using CA_DbFirstStreetlifting.Managers.Concretes;
using CA_DbFirstStreetlifting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_DbFirstStreetlifting.Managers
{
    internal class ConsoleManager
    {
        UserManager userManager = new UserManager();

        #region KullanıcıOluşturma

        public void CreateUser()
        {


            Console.WriteLine("Welcome to the User Creation Console!");
            Console.WriteLine("Please enter the following details to create a new user:");

            Console.WriteLine("Enter NickName:");
            string nickName = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();
            User user = new User
            {
                NickName = nickName,
                Email = email,
                Password = password
            };
            userManager.CreateUser(user);
            Console.WriteLine("User created successfully.");
        } 
        #endregion


        #region KullanıcıSilme
        public void DeleteUser()
        {
            Console.WriteLine("Enter the User ID to delete:");
            int userId = int.Parse(Console.ReadLine());
            userManager.DeleteUser(userId);
            Console.WriteLine("User deleted successfully.");
        }
        #endregion



        #region KullanıcıGüncelleme
        public void UpdateUser(int id)
        {
            User user = userManager.GetUserById(id);
            Console.WriteLine("Güncellenecek NickName giriniz: ");
            user.NickName = Console.ReadLine();
            Console.WriteLine("Güncellenecek E-Mail yazınız:  ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Güncellenecek Password yazınız:  ");
            user.Password = Console.ReadLine();
            userManager.UpdateUser(user);


        }   
        #endregion




    }

}
