using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_YapayZekaIleOyunYapımı
{
    
        public class Player : Character
        {

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name}, {amount} can yeniledi. Yeni HP: {Health}");
        }

        public int Level { get; private set; } = 1;

            public Player(string name) : base(name, 100, 10) { }

            public void LevelUp()
            {
                Level++;
                AttackPower += 5;
                Health += 20;
                Console.WriteLine($"{Name} seviye atladı! Yeni seviye: {Level}");
            }

            public override int Attack()
            {
                return AttackPower;
            }
        }

    
}
