using BLL.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IUserServiceManager
    {
        //bir kullanıcının hangi rollere sahip olduğunun listelenmesi
        List<UserAndRoleDTO> GetUsersAndRoles();
    }
}
