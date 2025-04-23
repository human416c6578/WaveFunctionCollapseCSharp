using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C411DAV_Proiect_TPL
{
    public class Tile
    {
        public string Name { get; set; }
        public Bitmap Image { get; set; }

        public List<int>[] Neighbors { get; set; }

        public Tile()
        {
            Neighbors = new List<int>[4];
            for (int i = 0; i < 4; i++)
            {
                Neighbors[i] = new List<int>();
            }
        }
    }

    
}
