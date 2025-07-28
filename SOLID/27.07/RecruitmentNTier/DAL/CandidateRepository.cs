
using Entities.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_InsanKaynakları.RepositoryAndService
{
    public static class CandidateRepository
    {
        public static List<ICandidate> GetCandidates()
        {
            return new List<ICandidate>
        {
            new Candidate("Nancy", "Davilo"),
            new Candidate("Andrew", "Fuller"),
            new Candidate("Anne", "Dodthsworth"),
            new Candidate("Steven", "Buchanan"),
            new Candidate("Laura", "Callahan"),
            new Candidate("Robert", "King"),
            new Candidate("Michael", "Suyama"),
            new Candidate("Janet", "Leverling"),
            new Candidate("Margaret", "Peacock"),
            new Candidate("Davolio", "Nancy")
        };
        }
    }
}
