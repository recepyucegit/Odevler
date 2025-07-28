using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Candidate : ICandidate
    {
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }

        public Candidate(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }
    }
}
