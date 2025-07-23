using CA_StreetliftingCodeFirst.Models.Entities;

namespace CA_StreetliftingCodeFirst.Models.Seeds
{
    public class UserDetailSeedData
    {

        public static List<UserDetail> userDetailsData = new List<UserDetail>
        {
            new UserDetail
            {
                Id=1,
                UserId=1,
                Name="StreetLifter",
                SurName="Maniac1",
                Gender="Male",
                Age=28,

            },
            new UserDetail
            {
                Id=2,
                UserId=2,
                Name="StreetLifter",
                SurName="Maniac2",
                Gender="Fmale",
                Age=30,
            },
            new UserDetail
            {
                Id=3,
                UserId=3,
                Name="StreetLifter",
                SurName="Maniac3",
                Gender="Male",
                Age=25,

            },
        };
    }
}
