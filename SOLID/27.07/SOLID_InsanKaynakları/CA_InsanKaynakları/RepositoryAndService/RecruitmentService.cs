using CA_InsanKaynakları.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_InsanKaynakları.Concretes;
using CA_InsanKaynakları.Abstract;

namespace CA_InsanKaynakları.RepositoryAndService
{
    public static class RecruitmentService
    {
        public static List<IEmployee> HireEmployees(List<ICandidate> candidates)
        {
            return new List<IEmployee>
        {
            Department.Hire(candidates[0], "Muhasebe"),
            Department.Hire(candidates[1], "Bilgi İşlem"),
            Department.Hire(candidates[2], "Satış Pazarlama")
        };
        }
    }
}
