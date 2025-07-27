<<<<<<<< HEAD:SOLID/27.07/SOLID_InsanKaynakları/CA_InsanKaynakları/Entities/Concretes/Employee.cs
﻿using CA_InsanKaynakları.Entities.Abstract;
========
﻿using Entities.Abstract;
>>>>>>>> 03b9a9fbbcdc0fb8928c71c0d28e73f9e7654116:SOLID/27.07/RecruitmentNTier/Entities/Concretes/Employee.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:SOLID/27.07/SOLID_InsanKaynakları/CA_InsanKaynakları/Entities/Concretes/Employee.cs
namespace CA_InsanKaynakları.Entities.Concretes
========
namespace Entities.Concretes
>>>>>>>> 03b9a9fbbcdc0fb8928c71c0d28e73f9e7654116:SOLID/27.07/RecruitmentNTier/Entities/Concretes/Employee.cs
{
    public class Employee : IEmployee
    {
        public string Email { get  ; set  ; }
        public string Department { get  ; set  ; }
        public decimal HourlyWage { get  ; set  ; }

        public Employee(ICandidate candidate,string department, decimal hourlyWage)
        {
            Email = GenerateEmail(candidate.FirstName,candidate.LastName);
            Department = department;
            HourlyWage = hourlyWage;
        }


        private string GenerateEmail(string firstName, string lastName)
        {
            return $"{firstName.ToLower()}.{lastName.ToLower()}@northwind.com";
        }
    }
}
