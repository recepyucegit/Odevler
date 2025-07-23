namespace CA_IlkOyunDeneme.Abstract
{
    public class Character
    {

        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }


       public Character(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }


      

        public void Attack(Character target)
        {
          target.Health -= AttackPower;
            Console.WriteLine($"{Name}{target.Name}'a {AttackPower} hasar verdi!");
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}
