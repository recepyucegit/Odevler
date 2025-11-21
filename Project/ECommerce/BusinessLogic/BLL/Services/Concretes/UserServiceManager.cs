using BLL.Services.Abstracts;
using BLL.Services.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class UserServiceManager : IUserServiceManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserServiceManager(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public List<UserAndRoleDTO> GetUsersAndRoles()
        {
            //kullanıcılar ile rolleri joinleyip dto'ya mapleyip geriye döndüren metot.
            var users = _userManager.Users.ToList();

            var userAndRoles = new List<UserAndRoleDTO>();

            foreach (var user in users)
            {
                var roles = _userManager.GetRolesAsync(user).Result; // Kullanıcının rollerini al
                userAndRoles.Add(new UserAndRoleDTO
                {
                    UserName = user.UserName,
                    RoleName = roles.ToList(),
                    Email= user.Email

                });

            }
            return userAndRoles;
        }
    }
}
