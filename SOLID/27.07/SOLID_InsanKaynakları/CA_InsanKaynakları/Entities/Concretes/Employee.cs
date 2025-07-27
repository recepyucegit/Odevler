using CA_InsanKaynakları.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_InsanKaynakları.Entities.Concretes
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
