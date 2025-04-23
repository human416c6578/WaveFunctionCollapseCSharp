using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

namespace C411DAV_Proiect_TPL
{
    public partial class Form1: Form
    {
        List<Tile> tiles;
        Panel selectedTilePanel;
        WFC wfc;

        bool PREVIEW = true;
        int SIZE = 20;
        int TILE_SIZE = 16;
        int MAX_DEPTH = 5;
        bool RUNNING = false;

        Bitmap resultedImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tiles = new List<Tile>();
            sizeTextBox.Text = SIZE.ToString();
            tileSizeTextBox.Text = TILE_SIZE.ToString();
            depthTextBox.Text = MAX_DEPTH.ToString();
        }
        

        void LoadTile(string filePath)
        {
            Tile newTile = new Tile
            {
                Name = Path.GetFileNameWithoutExtension(filePath),
                Image = new Bitmap(filePath)
            };

            if(!rotateCheckBox.Checked)
            {
                tiles.Add(newTile);
                DisplayTile(newTile);
                return;
            }

            List<Tile> rotatedTiles = CreateRotatedTiles(newTile);

            tiles.AddRange(rotatedTiles);

            foreach (var item in rotatedTiles)
            {
                DisplayTile(item);
            }

        }

        List<Tile> CreateRotatedTiles(Tile originalTile)
        {
            List<Tile> rotatedTiles = new List<Tile>();

            rotatedTiles.Add(originalTile);
            rotatedTiles.Add(CreateRotatedTile(originalTile, RotateFlipType.Rotate90FlipNone));
            rotatedTiles.Add(CreateRotatedTile(originalTile, RotateFlipType.Rotate180FlipNone));
            rotatedTiles.Add(CreateRotatedTile(originalTile, RotateFlipType.Rotate270FlipNone));

            return rotatedTiles;
        }

        Tile CreateRotatedTile(Tile originalTile, RotateFlipType rotateFlipType)
        {
            Tile rotatedTile = new Tile
            {
                Name = originalTile.Name + GetRotateName(rotateFlipType),
                Image = new Bitmap(originalTile.Image) 
            };

            rotatedTile.Image.RotateFlip(rotateFlipType);

            return rotatedTile;
        }

        string GetRotateName(RotateFlipType rotateFlipType)
        {
            string name = "";
            switch(rotateFlipType)
            {
                case RotateFlipType.Rotate90FlipNone:
                    name = "_90";
                    break;
                case RotateFlipType.Rotate180FlipNone:
                    name = "_180";
                    break;
                case RotateFlipType.Rotate270FlipNone:
                    name = "_270";
                    break;
            }

            return name;
        }

        private void DisplayTile(Tile tile)
        {
            Panel tilePanel = new Panel
            {
                Width = 80, 
                Height = 110,
                Margin = new Padding(2),
                BorderStyle = BorderStyle.None, 
                Cursor = Cursors.Hand
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = tile.Image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 64,
                Height = 64,
                Tag = tile 
            };

            pictureBox.Location = new Point((tilePanel.Width - pictureBox.Width) / 2);


            Label label = new Label
            {
                Text = tile.Name,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                AutoSize = true,
                Padding = new Padding(0, 0, 0, 0)
            };

            pictureBox.Enabled = false;
            label.Enabled = false;

            tilePanel.Controls.Add(pictureBox);
            tilePanel.Controls.Add(label);


            tilesLayout.Controls.Add(tilePanel);

            tilePanel.Click += (sender, e) =>
            {
                if (selectedTilePanel != null)
                {
                    selectedTilePanel.BackColor = Color.Transparent;
                    selectedTilePanel.BorderStyle = BorderStyle.None;
                }

                selectedTilePanel = tilePanel;

                tilePanel.BackColor = Color.LightBlue;
                tilePanel.BorderStyle = BorderStyle.FixedSingle;

                SelectTile(tile);
            };
        }

        private void SelectTile(Tile tile)
        {
            PopulateDirectionLayout(upLayout, tile.Neighbors[(int)Direction.Up]);
            PopulateDirectionLayout(downLayout, tile.Neighbors[(int)Direction.Down]);
            PopulateDirectionLayout(leftLayout, tile.Neighbors[(int)Direction.Left]);
            PopulateDirectionLayout(rightLayout, tile.Neighbors[(int)Direction.Right]);
        }
        private void PopulateDirectionLayout(FlowLayoutPanel layout, List<int> allowedTiles)
        {
            layout.Controls.Clear();
            int tileIndex = 0;
            foreach (var tile in tiles)
            {
                Panel neighborPanel = new Panel
                {
                    Width = 128,
                    Height = 128,
                    Margin = new Padding(5),
                    Padding = new Padding(5)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = tile.Image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 64,
                    Height = 64,
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 5, 0, 5)
                };

                CheckBox checkBox = new CheckBox
                {
                    Text = CropTextToMaxLength(tile.Name, 16),
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(0)
                };

                neighborPanel.Controls.Add(pictureBox);
                neighborPanel.Controls.Add(checkBox);

                layout.Controls.Add(neighborPanel);

                int currentIndex = tileIndex;

                if (allowedTiles.Contains(currentIndex))
                {
                    checkBox.Checked = true;
                }
                checkBox.CheckedChanged += (sender, e) =>
                {
                    
                    UpdateNeighbors(allowedTiles, currentIndex, checkBox.Checked);
                };
                tileIndex++;
            }
        }

        private string CropTextToMaxLength(string text, int maxLength)
        {
            if (text.Length > maxLength)
                return text.Substring(0, maxLength) + "...";  // Add ellipsis if cropped
            else
                return text;
        }

        private void UpdateNeighbors(List<int> allowedTiles, int neighborTile, bool isChecked)
        {
            if (isChecked)
                allowedTiles.Add(neighborTile);
            else
                allowedTiles.Remove(neighborTile);
        }

        private async Task<bool> GenerateMapAsync()
        {
            resultedImage = new Bitmap(SIZE * TILE_SIZE, SIZE * TILE_SIZE);

            if (wfc == null)
                wfc = new WFC(SIZE, SIZE, tiles, MAX_DEPTH);

            bool success = true;

            while (!wfc.IsCollapsed() && RUNNING)
            {
                var result = await Task.Run(() => RunWFC(wfc));

                int tileIndex = result.Item1;
                int x = result.Item2;
                int y = result.Item3;

                if (tileIndex == -1)
                {
                    success = false;
                    break;
                }

                using (Graphics g = Graphics.FromImage(resultedImage))
                {
                    g.DrawImage(tiles[tileIndex].Image, x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                }

                if (PREVIEW)
                {
                    UpdateImage(resultedImage);
                }
            }

            if(success)
                RUNNING = false;
            
            return success;
        }


        public void UpdateImage(Bitmap mapImage)
        {
            mapPictureBox.Image = mapImage;
            mapPictureBox.Refresh();
        }

        public (int, int, int) RunWFC(WFC localWFC)
        {
            var grid = localWFC.GetGrid();
            int index = localWFC.Propagate();

            if (index == -1) return (-1, -1, -1);

            int y = index % SIZE;
            int x = index / SIZE;

            int tileIndex = grid[x, y].PossibleTiles[0];

            if (tileIndex == -1 || tileIndex >= tiles.Count) return (-1, -1, -1);

            return (tileIndex, x, y);
        }

        private void ResetMap()
        {
            wfc = null;
            mapPictureBox.Image = new Bitmap(30, 30);
            mapPictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void tileSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (tileSizeTextBox.Text.Length == 0) return;

            TILE_SIZE = int.Parse(tileSizeTextBox.Text);
        }

        private void depthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (depthTextBox.Text.Length == 0) return;

            MAX_DEPTH = int.Parse(depthTextBox.Text);
        }

        private void sizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sizeTextBox.Text.Length == 0) return;

            SIZE = int.Parse(sizeTextBox.Text);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG Image|*.png";
            saveFileDialog1.Title = "Save the generated map";
            saveFileDialog1.FileName = "map.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                resultedImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private async void generateBtn_Click(object sender, EventArgs e)
        {
            if (RUNNING)
            {
                MessageBox.Show("You cannot modify the tiles while the generation is running!");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RUNNING = true;

            ResetMap();
            bool success = false;
            while(!success && RUNNING)
            {
                ResetMap();
                success = await GenerateMapAsync();
            }

            stopwatch.Stop();
            if (success)
            {
                Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
                mapPictureBox.Image = resultedImage;
            }
        }

        private void stopGenBtn_Click(object sender, EventArgs e)
        {
            RUNNING = false;
        }

        private void resetTiles_Click(object sender, EventArgs e)
        {
            if(RUNNING)
            {
                MessageBox.Show("You cannot modify the tiles while the generation is running!");
                return;
            }
            tiles = new List<Tile>();
            tilesLayout.Controls.Clear();
            upLayout.Controls.Clear();
            leftLayout.Controls.Clear();
            downLayout.Controls.Clear();
            rightLayout.Controls.Clear();
        }

        private void loadTileBtn_Click(object sender, EventArgs e)
        {
            if (RUNNING)
            {
                MessageBox.Show("You cannot modify the tiles while the generation is running!");
                return;
            }

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    LoadTile(filePath);
                }
            }
        }

        private void loadConfigBtn_Click(object sender, EventArgs e)
        {
            if (RUNNING)
            {
                MessageBox.Show("You cannot modify the tiles while the generation is running!");
                return;
            }

            openFileDialog2.Filter = "Text Files|*.txt;*.json";

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                TileConfigManager.LoadTileConfig(openFileDialog2.FileName, tiles);
            }
        }

        private void saveConfigBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                TileConfigManager.SaveTileConfig(saveFileDialog2.FileName, tiles);
            }

        }

        private void previewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PREVIEW = previewCheckBox.Checked;

            if (!previewCheckBox.Checked) return;

            mapPictureBox.Image = resultedImage;
            mapPictureBox.Refresh();
        }
    }
}
