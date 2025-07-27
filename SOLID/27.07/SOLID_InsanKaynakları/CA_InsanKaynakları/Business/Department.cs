using CA_InsanKaynakları.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_InsanKaynakları.Concretes
{
   public  class Department
    {
        public static IEmployee Hire(ICandidate candidate, string department)
        {
            switch (department)
            {
                case "Muhasebe":
                    return new Employee(candidate, "Muhasebe", 100);

                case "Bilgi İşlem":
                    return new Employee(candidate, "Bilgi İşlem", 150);

                case "Satış Pazarlama":
                    return new Employee(candidate, "Satış Pazarlama", 125);

                default:
                    throw new ArgumentException("Geçersiz departman.");
            }
        }



    }
}
