using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C411DAV_Proiect_TPL
{
    public class WFC
    {
        private readonly List<Tile> _tiles;
        private Cell[,] _grid;
        private int _width;
        private int _height;
        private int _max_depth;
        Random rnd = new Random();

        public Cell[,] GetGrid() { return _grid; }

        public bool IsCollapsed () 
        {
            foreach (var cell in _grid)
            {
                if (!cell.IsCollapsed) return false;
            }
            return true;
        }

        public WFC(int width, int height, List<Tile> allTiles, int max_depth)
        {
            _width = width;
            _height = height;
            _grid = new Cell[width, height];
            _max_depth = max_depth;
            _tiles = allTiles;

            // Initialize the grid with all tiles
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _grid[x, y] = new Cell(allTiles.Count, x, y);
                }
            }

            _max_depth = max_depth;
        }


        public int Propagate()
        {
            foreach (var item in _grid)
                item.IsChecked = false;

            //Getting the cells with the lowest entropy ( lowest number of possible options )
            int minEntropy = 9999;
            List<Cell> lowestEntropyCells = new List<Cell>();
            for(int i=0;i<_width;i++)
            {
                for(int j=0;j<_height;j++)
                {
                    Cell cell = _grid[i,j];
                    if (cell.IsCollapsed) continue;

                    if (cell.PossibleTiles.Count < minEntropy)
                    {
                        minEntropy = cell.PossibleTiles.Count;
                        lowestEntropyCells = new List<Cell> { cell };
                    }
                    else if (cell.PossibleTiles.Count == minEntropy)
                    {
                        lowestEntropyCells.Add(cell);
                    }
                }
            }

            if(lowestEntropyCells.Count < 1)
            {
                Console.WriteLine("CONFLICT!");
                return -1;
            }
               

            Cell chosenCell = lowestEntropyCells.ElementAt(rnd.Next(lowestEntropyCells.Count));
            if(chosenCell.PossibleTiles.Count < 1)
            {
                Console.WriteLine("CONFLICT!");
                return -1;
            }
            chosenCell.PossibleTiles = new List<int> { chosenCell.PossibleTiles.ElementAt(rnd.Next(chosenCell.PossibleTiles.Count)) };
            chosenCell.IsCollapsed = true;

            reduceEntropy(chosenCell, 0);

            return chosenCell.x * _width + chosenCell.y;
        }

        private IEnumerable<Cell> GetValidNeighbors(Cell cell)
        {
            if (cell.y - 1 >= 0) yield return _grid[cell.x, cell.y - 1]; // UP
            if (cell.y + 1 < _height) yield return _grid[cell.x, cell.y + 1]; // DOWN
            if (cell.x + 1 < _width) yield return _grid[cell.x + 1, cell.y]; // RIGHT
            if (cell.x - 1 >= 0) yield return _grid[cell.x - 1, cell.y]; // LEFT
        }

        private Direction GetDirection(Cell from, Cell to)
        {
            if (to.x == from.x && to.y == from.y - 1) return Direction.Up;
            if (to.x == from.x && to.y == from.y + 1) return Direction.Down;
            if (to.x == from.x + 1 && to.y == from.y) return Direction.Right;
            if (to.x == from.x - 1 && to.y == from.y) return Direction.Left;
            throw new InvalidOperationException("Invalid neighbor relationship");
        }

        public async void reduceEntropy(Cell cell, int depth)
        {
            if (depth > _max_depth || cell.IsChecked || cell == null) return;

            cell.IsChecked = true;

            List<Task> tasks = new List<Task>();

            foreach (var neighbor in GetValidNeighbors(cell))
            {
                if (CheckOptions(cell, neighbor, GetDirection(cell, neighbor)))
                {
                    if(depth > 0)
                        reduceEntropy(neighbor, depth + 1);
                    else
                        tasks.Add(Task.Run(() => reduceEntropy(neighbor, depth + 1)));

                }
            }

            if (tasks.Count > 0)
            {
                await Task.WhenAll(tasks);
            }

            /*
            // UP
            if (cell.y - 1 >= 0)
            {
                Cell upCell = _grid[cell.x, cell.y - 1];
                if (CheckOptions(cell, upCell, Direction.Up))
                {
                    reduceEntropy(upCell, depth + 1);
                }
            }

            // Down
            if (cell.y + 1 < _height)
            {
                Cell downCell = _grid[cell.x, cell.y + 1];
                if (CheckOptions(cell, downCell, Direction.Down))
                {
                    reduceEntropy(downCell, depth + 1);
                }
            }

            // RIGHT
            if (cell.x + 1 < _width)
            {
                Cell rightCell = _grid[cell.x + 1, cell.y];
                if (CheckOptions(cell, rightCell, Direction.Right))
                {
                    reduceEntropy(rightCell, depth + 1);
                }
            }

            // LEFT
            if (cell.x - 1 >= 0)
            {
                Cell leftCell = _grid[cell.x - 1, cell.y];
                if (CheckOptions(cell, leftCell, Direction.Left))
                {
                    reduceEntropy(leftCell, depth + 1);
                }
            }
            */
        }

        bool CheckOptions(Cell cell, Cell neighbor, Direction direction)
        {
            if (neighbor == null || neighbor.IsCollapsed) return false;

            var validOptions = new HashSet<int>();

            foreach (int tileIndex in cell.PossibleTiles)
            {
                foreach (var neighborOption in _tiles[tileIndex].Neighbors[(int)direction])
                {
                    validOptions.Add(neighborOption);
                }
            }

            var oldCount = neighbor.PossibleTiles.Count;
            neighbor.PossibleTiles = neighbor.PossibleTiles
                .Where(option => validOptions.Contains(option))
                .ToList();

            return neighbor.PossibleTiles.Count != oldCount;
        }


    }
}
