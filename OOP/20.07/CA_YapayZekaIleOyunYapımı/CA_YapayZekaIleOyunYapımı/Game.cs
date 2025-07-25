using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA_YapayZekaIleOyunYapımı
{
   
        public class Game
        {
            private Player player;
            private Map map;

            public void Start()
            {
                Console.Write("Kahramanının adını gir: ");
                string name = Console.ReadLine();
                player = new Player(name);

                map = new Map(5, 5); // 5x5 harita
                Console.WriteLine($"Macera başlasın, {player.Name}!");

                GameLoop();
            }

            private void GameLoop()
            {
                while (player.Health > 0)
                {
                    map.Draw();
                    map.MarkVisited();
                    Tile currentTile = map.GetCurrentTile();

                    switch (currentTile.Type)
                    {
                        case TileType.Monster:
                            Console.WriteLine("Bir canavarla karşılaştın!");
                            Fight(new Monster("Canavar"));
                            currentTile.Type = TileType.Empty;
                            break;
                        case TileType.Treasure:
                            Console.WriteLine("Hazine buldun! +10 HP");
                            player.Heal(10);
                            currentTile.Type = TileType.Empty;
                            break;
                        case TileType.Exit:
                            Console.WriteLine("Çıkışı buldun! Oyunu kazandın!");
                            return;
                    }

                    Console.Write("Hareket et (W/A/S/D): ");
                    string input = Console.ReadLine();
                    map.MovePlayer(input);
                }

                Console.WriteLine("Öldün! Oyun bitti.");
            }

            private void Fight(Monster monster)
            {
                while (monster.Health > 0 && player.Health > 0)
                {
                    Console.WriteLine($"\n{player.Name}: {player.Health} HP | {monster.Name}: {monster.Health} HP");

                    int playerDamage = player.Attack();
                    monster.TakeDamage(playerDamage);
                    Console.WriteLine($"{player.Name}, {monster.Name}'a {playerDamage} hasar verdi!");

                    if (monster.Health <= 0) break;

                    int monsterDamage = monster.Attack();
                    player.TakeDamage(monsterDamage);
                    Console.WriteLine($"{monster.Name}, {player.Name}'a {monsterDamage} hasar verdi!");
                }

                Console.WriteLine($"{monster.Name} yenildi!");
            }
        }



    
}
