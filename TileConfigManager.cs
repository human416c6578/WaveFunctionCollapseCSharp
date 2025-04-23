using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C411DAV_Proiect_TPL
{
    public static class TileConfigManager
    {
        public static void LoadTileConfig(string filePath, List<Tile> tiles)
        {
            if (!File.Exists(filePath))
                return;

            if (new FileInfo(filePath).Length == 0)
            {
                MessageBox.Show("Config file is empty.");
                return;
            }

            var json = File.ReadAllText(filePath);
            var configs = JsonSerializer.Deserialize<List<TileConfig>>(json);

            foreach (var config in configs)
            {
                var tile = tiles.FirstOrDefault(t => t.Name == config.TileName);
                if (tile == null) continue;

                tile.Neighbors = new List<int>[] {
                    tilesIndexes(tiles.Where(t => config.Neighbors[(int)Direction.Up].Contains(t.Name)).ToList(), tiles),
                    tilesIndexes(tiles.Where(t => config.Neighbors[(int)Direction.Down].Contains(t.Name)).ToList(), tiles),
                    tilesIndexes(tiles.Where(t => config.Neighbors[(int)Direction.Left].Contains(t.Name)).ToList(), tiles),
                    tilesIndexes(tiles.Where(t => config.Neighbors[(int)Direction.Right].Contains(t.Name)).ToList(), tiles)
                };
            }
        }


        private static List<int> tilesIndexes(List<Tile> inTiles, List<Tile> tiles)
        {
            List<int> indexes = new List<int>();
            foreach (var tile in inTiles)
            {
                indexes.Add(getTileIndex(tile.Name, tiles));
            }

            return indexes;
        }

        private static int getTileIndex(string name, List<Tile> tiles)
        {
            int tileIndex = 0;
            foreach (var tile in tiles)
            {
                if (tile.Name == name)
                    return tileIndex;

                tileIndex++;
            }

            return tileIndex;
        }

        public static void SaveTileConfig(string filePath, List<Tile> tiles)
        {
            var configs = new List<TileConfig>();

            foreach (var tile in tiles)
            {

                configs.Add(new TileConfig
                {
                    TileName = tile.Name,
                    Neighbors = new List<string>[]
                    {
                        tile.Neighbors[(int)Direction.Up].Select(t => tiles[t].Name).ToList(),
                        tile.Neighbors[(int)Direction.Down].Select(t => tiles[t].Name).ToList(),
                        tile.Neighbors[(int) Direction.Left].Select(t => tiles[t].Name).ToList(),
                        tile.Neighbors[(int) Direction.Right].Select(t => tiles[t].Name).ToList()
                    }
                });
            }

            var json = JsonSerializer.Serialize(configs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        private static List<int> SafeGetNeighbor(List<int>[] neighbors, int index)
        {
            return (neighbors != null && index >= 0 && index < neighbors.Length && neighbors[index] != null)
                ? neighbors[index]
                : new List<int>();
        }

    }
    public class TileConfig
    {
        public string TileName { get; set; }

        public List<string>[] Neighbors { get; set; }

        public TileConfig()
        {
            Neighbors = new List<string>[4];
            for (int i = 0; i < 4; i++)
            {
                Neighbors[i] = new List<string>();
            }
        }

    }
}
