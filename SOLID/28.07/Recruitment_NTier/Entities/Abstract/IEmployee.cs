using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface IEmployee
    {
        public string EMail { get; set; }
        public string Department { get; set; }
        public decimal   HourlyWage { get; set; }
    }
}
