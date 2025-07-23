namespace CA_IlkOyunDeneme.Abstract
{
    public class Player : Character
    {

        public int Score { get; set; }
        public Player(string name) : base(name, 100,20)
        {
            Score = 0;

        }

        public void Heal()
        {
            Health += 10;
            Console.WriteLine($"{Name} 10 can kazandı! (Yeni can:{Health})");
        }
    }
}
