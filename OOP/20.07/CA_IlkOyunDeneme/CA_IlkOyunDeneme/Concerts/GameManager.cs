

using CA_IlkOyunDeneme.Abstract;

namespace CA_IlkOyunDeneme.Concerts
{
    public class GameManager
    {
        private Player player;
        private List<Monster> monsters;
        private Random rnd = new Random();

        public void StartGame()
        {
            Console.Write("Oyuncu adını gir: ");
            string name = Console.ReadLine();
            player = new Player(name);

            monsters = new List<Monster>
        {
            new Monster("Zombi", 50, 10),
            new Monster("İskelet", 40, 12),
            new Monster("Dev", 80, 15)
        };

            Console.Clear();
            Console.WriteLine($"Hoş geldin, {player.Name}!\n");

            while (!player.IsDead())
            {
                var monster = GetRandomMonster();
                Console.WriteLine($"\nYeni canavar çıktı: {monster.Name} ({monster.Health} can / {monster.AttackPower} saldırı gücü)");

                while (!monster.IsDead() && !player.IsDead())
                {
                    Console.WriteLine("\nSeçim yap:");
                    Console.WriteLine("1. Saldır");
                    Console.WriteLine("2. İyileş");
                    Console.WriteLine("3. Kaç");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            player.Attack(monster);
                            if (!monster.IsDead())
                                monster.Attack(player);
                            break;

                        case "2":
                            player.Heal();
                            monster.Attack(player);
                            break;

                        case "3":
                            Console.WriteLine($"{player.Name} kaçtı!");
                            return;

                        default:
                            Console.WriteLine("Geçersiz seçim!");
                            break;
                    }

                    Console.WriteLine($"{player.Name} can: {player.Health} | {monster.Name} can: {monster.Health}");
                }

                if (player.IsDead())
                {
                    Console.WriteLine("Oyuncu öldü! Oyun bitti.");
                    break;
                }

                if (monster.IsDead())
                {
                    Console.WriteLine($"{monster.Name} yok edildi!");
                    player.Score++;
                }
            }

            Console.WriteLine($"\nToplam skor: {player.Score}");
        }

        private Monster GetRandomMonster()
        {
            int index = rnd.Next(monsters.Count);
            var template = monsters[index];
            return new Monster(template.Name, template.Health, template.AttackPower);
        }
    }

}
