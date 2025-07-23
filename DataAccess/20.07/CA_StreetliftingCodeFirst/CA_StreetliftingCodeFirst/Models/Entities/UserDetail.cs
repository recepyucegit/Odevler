using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_StreetliftingCodeFirst.Models.Entities
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }

        public int UserId { get; set; }
        public User AppUsers { get; set; }

    }
}
