<<<<<<<< HEAD:SOLID/27.07/SOLID_InsanKaynakları/CA_InsanKaynakları/Entities/Concretes/Candidate.cs
﻿using CA_InsanKaynakları.Entities.Abstract;
========
﻿using Entities.Abstract;
>>>>>>>> 03b9a9fbbcdc0fb8928c71c0d28e73f9e7654116:SOLID/27.07/RecruitmentNTier/Entities/Concretes/Candidate.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:SOLID/27.07/SOLID_InsanKaynakları/CA_InsanKaynakları/Entities/Concretes/Candidate.cs
namespace CA_InsanKaynakları.Entities.Concretes
========
namespace Entities.Concretes
>>>>>>>> 03b9a9fbbcdc0fb8928c71c0d28e73f9e7654116:SOLID/27.07/RecruitmentNTier/Entities/Concretes/Candidate.cs
{
    public class Candidate : ICandidate
    {
        public string FirstName { get  ; set  ; }
        public string LastName { get  ; set ; }

        public Candidate(string firstName ,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
