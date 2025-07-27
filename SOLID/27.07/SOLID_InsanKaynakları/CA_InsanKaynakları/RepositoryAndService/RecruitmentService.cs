using CA_InsanKaynakları.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_InsanKaynakları.Abstract;
using CA_InsanKaynakları.Entities.Concretes;

namespace CA_InsanKaynakları.RepositoryAndService
{
    public static class RecruitmentService
    {
        public static List<IEmployee> HireEmployees(List<ICandidate> candidates)
        {
            return new List<IEmployee>
        {
            DepartmentFactory.Hire(candidates[0], "Muhasebe"),
            DepartmentFactory.Hire(candidates[1], "Bilgi İşlem"),
            DepartmentFactory.Hire(candidates[2], "Satış Pazarlama")
        };
        }
    }
}
