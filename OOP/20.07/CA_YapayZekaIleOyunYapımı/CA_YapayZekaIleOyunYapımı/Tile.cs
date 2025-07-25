using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_YapayZekaIleOyunYapımı
{
    public class Tile
    {
        public TileType Type { get; set; }
        public bool Visited { get; set; } = false;

        public Tile(TileType type)
        {
            Type = type;
        }
    }

}
