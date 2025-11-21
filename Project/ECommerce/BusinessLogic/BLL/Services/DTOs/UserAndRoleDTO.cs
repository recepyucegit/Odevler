using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DTOs
{
    public class UserAndRoleDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> RoleName { get; set; }
    }
}
