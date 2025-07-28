
﻿using CA_InsanKaynakları.Entities.Abstract;

﻿
using Entities.Abstract;
using Entities.Concretes;
>>>>>>>> 03b9a9fbbcdc0fb8928c71c0d28e73f9e7654116:SOLID/27.07/RecruitmentNTier/BLL/Department.cs
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
