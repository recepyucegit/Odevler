using CA_YapayZekaIleOyunYapımı;

public enum TileType
{
    Empty,
    Monster,
    Treasure,
    Exit,
    Player
}
class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}


