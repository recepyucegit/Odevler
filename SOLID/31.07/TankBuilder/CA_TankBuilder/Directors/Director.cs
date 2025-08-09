using CA_TankBuilder.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_TankBuilder.Directors
{
    internal class Director
    {
        public void Construct(ITank tankBuilder)
        {
            tankBuilder.BuildTurret();
            tankBuilder.BuildHull();
            tankBuilder.BuildEngine();
            tankBuilder.BuildGun();
        }
    }
}
