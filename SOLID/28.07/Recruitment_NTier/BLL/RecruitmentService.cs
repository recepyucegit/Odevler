using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RecruitmentService
    {
        public static List<IEmployee> HireEmployees(List<ICandidate> candidates)
        {
            return new List<IEmployee>
            {
            DepartmanFactory.Hire(candidates[0], "Muhasebe"),
            DepartmanFactory.Hire(candidates[1], "Bilgi İşlem"),
            DepartmanFactory.Hire(candidates[2], "Satış Pazarlama"),
            };
        }
    }
}
