using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_YapayZekaIleOyunYapımı
{
    public class Map
    {
        private Tile[,] grid;
        public int Width { get; }
        public int Height { get; }

        public int PlayerX { get; private set; }
        public int PlayerY { get; private set; }

        private Random random = new Random();

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new Tile[height, width];

            GenerateMap();
            PlayerX = 0;
            PlayerY = 0;
        }

        private void GenerateMap()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    TileType type;
                    int chance = random.Next(100);

                    if (chance < 60) type = TileType.Empty;
                    else if (chance < 80) type = TileType.Monster;
                    else if (chance < 95) type = TileType.Treasure;
                    else type = TileType.Exit;

                    grid[y, x] = new Tile(type);
                }
            }

            // Başlangıç pozisyonu garanti boş
            grid[0, 0] = new Tile(TileType.Empty);
        }

        public Tile GetCurrentTile()
        {
            return grid[PlayerY, PlayerX];
        }

        public void MovePlayer(string direction)
        {
            int newX = PlayerX;
            int newY = PlayerY;

            switch (direction.ToLower())
            {
                case "w": newY--; break;
                case "s": newY++; break;
                case "a": newX--; break;
                case "d": newX++; break;
                default: Console.WriteLine("Geçersiz yön!"); return;
            }

            if (newX >= 0 && newX < Width && newY >= 0 && newY < Height)
            {
                PlayerX = newX;
                PlayerY = newY;
            }
            else
            {
                Console.WriteLine("Sınır dışı hareket!");
            }
        }

        public void Draw()
        {
            Console.WriteLine("\nHarita:");
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == PlayerX && y == PlayerY)
                        Console.Write("[P]");
                    else if (grid[y, x].Visited)
                        Console.Write("[ ]");
                    else
                        Console.Write("[?]");
                }
                Console.WriteLine();
            }
        }

        public void MarkVisited()
        {
            grid[PlayerY, PlayerX].Visited = true;
        }
    }

}
