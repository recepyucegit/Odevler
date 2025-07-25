using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_YapayZekaIleOyunYapımı
{
   
        public class Monster : Character
        {
            private static Random random = new Random();

            public Monster(string name) : base(name, random.Next(30, 70), random.Next(5, 15)) { }

            public override int Attack()
            {
                return AttackPower;
            }
        }

    
}
