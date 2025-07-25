using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_YapayZekaIleOyunYapımı
{
    
        public abstract class Character
        {
            public string Name { get; protected set; }
            public int Health { get; protected set; }
            public int AttackPower { get; protected set; }

            public Character(string name, int health, int attackPower)
            {
                Name = name;
                Health = health;
                AttackPower = attackPower;
            }

            public virtual void TakeDamage(int damage)
            {
                Health -= damage;
                if (Health < 0) Health = 0;
            }

            public abstract int Attack();
        }

    
}
