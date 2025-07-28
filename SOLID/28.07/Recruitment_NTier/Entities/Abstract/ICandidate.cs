using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract

{
    public interface ICandidate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
