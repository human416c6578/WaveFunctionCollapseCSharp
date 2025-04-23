using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C411DAV_Proiect_TPL
{
    public class Cell
    {
        public List<int> PossibleTiles { get; set; }
        public bool IsCollapsed = false;
        public bool IsChecked = false;

        public int x;
        public int y;

        public Cell(int tilesCount, int x, int y)
        {
            PossibleTiles = new List<int>();
            for (int i = 0; i < tilesCount; i++)
            {
                PossibleTiles.Add(i);
            }
            
            this.x = x;
            this.y = y;
        }

        public int GetCollapsedTile() => IsCollapsed ? PossibleTiles[0] : -1;
    }
}
