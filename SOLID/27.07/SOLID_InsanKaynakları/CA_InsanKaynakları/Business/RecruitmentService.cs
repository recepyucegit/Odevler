using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD:SOLID/27.07/SOLID_InsanKaynakları/CA_InsanKaynakları/Business/RecruitmentService.cs
using CA_InsanKaynakları.Concretes;
using CA_InsanKaynakları.Entities.Abstract;
=======
using CA_InsanKaynakları.Abstract;
using CA_InsanKaynakları.Entities.Concretes;
>>>>>>> 03b9a9fbbcdc0fb8928c71c0d28e73f9e7654116:SOLID/27.07/SOLID_InsanKaynakları/CA_InsanKaynakları/RepositoryAndService/RecruitmentService.cs

namespace CA_InsanKaynakları.Business
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
