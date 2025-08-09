using CA_TankBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_TankBuilder.SingletonPattern
{
    internal class SngltonPattern
    {
        private static Tank _instance;
        public Tank tank
        {
           get
            {
                                if (_instance == null)
                {
                    _instance = new Tank();
                }
                return _instance;
            }
        }
        
    }
}
