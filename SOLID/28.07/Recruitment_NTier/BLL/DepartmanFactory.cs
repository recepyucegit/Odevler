using Entities.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmanFactory
    {
        public static IEmployee Hire(ICandidate candidate,string department)
        {
            switch(department)
            {
                case "Muhasebe":
                    return new Employee(candidate, department, 100);
                case "Bilgi İşlem":
                    return new Employee(candidate, department, 150);
                case "Satış Pazarlama":
                    return new Employee(candidate, department, 100);

                default:
                    throw new ArgumentException("Geçersiz departman");


            }
        }
            
    }
}
