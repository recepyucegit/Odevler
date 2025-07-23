using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_StreetliftingCodeFirst.Models.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string  NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDetail AppUserDetails { get; set; }
        
        public List<Measurament> Measuraments { get; set; } 
    }
}
