using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_InsanKaynakları.Entities.Abstract
{
    public interface IEmployee
    {
        string Email { get; set; }
        string Department { get; set; }
        decimal HourlyWage { get; set; }

    }
}
