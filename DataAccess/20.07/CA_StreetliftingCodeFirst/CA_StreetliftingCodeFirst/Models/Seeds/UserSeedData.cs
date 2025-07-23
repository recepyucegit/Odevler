using CA_StreetliftingCodeFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_StreetliftingCodeFirst.Models.Seeds
{
    public class UserSeedData
    {
        public static List<User> usersData = new List<User>
        {
            new User
            {
                Id=1,
                NickName="StreetLifterManiac1",
                Email="Streetlifter1@Streetlifter",
                Password="1234"
            },
            new User
            {
                Id=2,
                NickName="StreetLifterManiac2",
                Email="Streetlifter2@Streetlifter",
                Password="1234"
            },
            new User
            {
                Id=3,
                NickName="StreetLifterManiac3",
                Email="Streetlifter3@Streetlifter",
                Password="1234"
            },

        };
    }
}
