namespace C411DAV_Proiect_TPL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveBtn = new System.Windows.Forms.Button();
            this.tilesLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.upLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.downLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.leftLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.rightLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.loadTileBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.loadConfigBtn = new System.Windows.Forms.Button();
            this.saveConfigBtn = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.rotateCheckBox = new System.Windows.Forms.CheckBox();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tileSizeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.depthTextBox = new System.Windows.Forms.TextBox();
            this.stopGenBtn = new System.Windows.Forms.Button();
            this.resetTiles = new System.Windows.Forms.Button();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Location = new System.Drawing.Point(746, 12);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(456, 366);
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(746, 426);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(112, 54);
            this.generateBtn.TabIndex = 1;
            this.generateBtn.Text = "Generate Map";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(1090, 425);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(112, 54);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save Map";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // tilesLayout
            // 
            this.tilesLayout.AutoScroll = true;
            this.tilesLayout.Location = new System.Drawing.Point(12, 28);
            this.tilesLayout.Name = "tilesLayout";
            this.tilesLayout.Size = new System.Drawing.Size(208, 356);
            this.tilesLayout.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tiles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Neighbors";
            // 
            // upLayout
            // 
            this.upLayout.AutoScroll = true;
            this.upLayout.Location = new System.Drawing.Point(6, 6);
            this.upLayout.Name = "upLayout";
            this.upLayout.Size = new System.Drawing.Size(467, 372);
            this.upLayout.TabIndex = 4;
            // 
            // downLayout
            // 
            this.downLayout.AutoScroll = true;
            this.downLayout.Location = new System.Drawing.Point(6, 6);
            this.downLayout.Name = "downLayout";
            this.downLayout.Size = new System.Drawing.Size(467, 372);
            this.downLayout.TabIndex = 8;
            // 
            // leftLayout
            // 
            this.leftLayout.AutoScroll = true;
            this.leftLayout.Location = new System.Drawing.Point(6, 6);
            this.leftLayout.Name = "leftLayout";
            this.leftLayout.Size = new System.Drawing.Size(467, 372);
            this.leftLayout.TabIndex = 10;
            // 
            // rightLayout
            // 
            this.rightLayout.AutoScroll = true;
            this.rightLayout.Location = new System.Drawing.Point(6, 6);
            this.rightLayout.Name = "rightLayout";
            this.rightLayout.Size = new System.Drawing.Size(467, 372);
            this.rightLayout.TabIndex = 10;
            // 
            // loadTileBtn
            // 
            this.loadTileBtn.Location = new System.Drawing.Point(12, 425);
            this.loadTileBtn.Name = "loadTileBtn";
            this.loadTileBtn.Size = new System.Drawing.Size(83, 54);
            this.loadTileBtn.TabIndex = 12;
            this.loadTileBtn.Text = "Load Tiles";
            this.loadTileBtn.UseVisualStyleBackColor = true;
            this.loadTileBtn.Click += new System.EventHandler(this.loadTileBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(253, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(487, 356);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.upLayout);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(479, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Up";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.downLayout);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(479, 330);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Down";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.leftLayout);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(479, 330);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Left";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rightLayout);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(479, 330);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Right";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // loadConfigBtn
            // 
            this.loadConfigBtn.Location = new System.Drawing.Point(263, 425);
            this.loadConfigBtn.Name = "loadConfigBtn";
            this.loadConfigBtn.Size = new System.Drawing.Size(91, 54);
            this.loadConfigBtn.TabIndex = 14;
            this.loadConfigBtn.Text = "Load Config";
            this.loadConfigBtn.UseVisualStyleBackColor = true;
            this.loadConfigBtn.Click += new System.EventHandler(this.loadConfigBtn_Click);
            // 
            // saveConfigBtn
            // 
            this.saveConfigBtn.Location = new System.Drawing.Point(360, 425);
            this.saveConfigBtn.Name = "saveConfigBtn";
            this.saveConfigBtn.Size = new System.Drawing.Size(91, 54);
            this.saveConfigBtn.TabIndex = 15;
            this.saveConfigBtn.Text = "Save Config";
            this.saveConfigBtn.UseVisualStyleBackColor = true;
            this.saveConfigBtn.Click += new System.EventHandler(this.saveConfigBtn_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // rotateCheckBox
            // 
            this.rotateCheckBox.AutoSize = true;
            this.rotateCheckBox.Location = new System.Drawing.Point(12, 485);
            this.rotateCheckBox.Name = "rotateCheckBox";
            this.rotateCheckBox.Size = new System.Drawing.Size(136, 17);
            this.rotateCheckBox.TabIndex = 16;
            this.rotateCheckBox.Text = "Generate Rotated Tiles";
            this.rotateCheckBox.UseVisualStyleBackColor = true;
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(640, 408);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.sizeTextBox.TabIndex = 19;
            this.sizeTextBox.TextChanged += new System.EventHandler(this.sizeTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(577, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "SIZE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "TILE SIZE";
            // 
            // tileSizeTextBox
            // 
            this.tileSizeTextBox.Location = new System.Drawing.Point(640, 434);
            this.tileSizeTextBox.Name = "tileSizeTextBox";
            this.tileSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.tileSizeTextBox.TabIndex = 24;
            this.tileSizeTextBox.TextChanged += new System.EventHandler(this.tileSizeTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(577, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "DEPTH";
            // 
            // depthTextBox
            // 
            this.depthTextBox.Location = new System.Drawing.Point(640, 460);
            this.depthTextBox.Name = "depthTextBox";
            this.depthTextBox.Size = new System.Drawing.Size(100, 20);
            this.depthTextBox.TabIndex = 26;
            this.depthTextBox.TextChanged += new System.EventHandler(this.depthTextBox_TextChanged);
            // 
            // stopGenBtn
            // 
            this.stopGenBtn.Location = new System.Drawing.Point(864, 426);
            this.stopGenBtn.Name = "stopGenBtn";
            this.stopGenBtn.Size = new System.Drawing.Size(112, 54);
            this.stopGenBtn.TabIndex = 28;
            this.stopGenBtn.Text = "Stop";
            this.stopGenBtn.UseVisualStyleBackColor = true;
            this.stopGenBtn.Click += new System.EventHandler(this.stopGenBtn_Click);
            // 
            // resetTiles
            // 
            this.resetTiles.Location = new System.Drawing.Point(103, 425);
            this.resetTiles.Name = "resetTiles";
            this.resetTiles.Size = new System.Drawing.Size(83, 54);
            this.resetTiles.TabIndex = 29;
            this.resetTiles.Text = "Reset Tiles";
            this.resetTiles.UseVisualStyleBackColor = true;
            this.resetTiles.Click += new System.EventHandler(this.resetTiles_Click);
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Checked = true;
            this.previewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.previewCheckBox.Location = new System.Drawing.Point(747, 385);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(64, 17);
            this.previewCheckBox.TabIndex = 30;
            this.previewCheckBox.Text = "Preview";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            this.previewCheckBox.CheckedChanged += new System.EventHandler(this.previewCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 509);
            this.Controls.Add(this.previewCheckBox);
            this.Controls.Add(this.resetTiles);
            this.Controls.Add(this.stopGenBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.depthTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tileSizeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeTextBox);
            this.Controls.Add(this.rotateCheckBox);
            this.Controls.Add(this.saveConfigBtn);
            this.Controls.Add(this.loadConfigBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.loadTileBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tilesLayout);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.mapPictureBox);
            this.Name = "Form1";
            this.Text = "Wave Function Collapse";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.FlowLayoutPanel tilesLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel upLayout;
        private System.Windows.Forms.FlowLayoutPanel downLayout;
        private System.Windows.Forms.FlowLayoutPanel leftLayout;
        private System.Windows.Forms.FlowLayoutPanel rightLayout;
        private System.Windows.Forms.Button loadTileBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Button loadConfigBtn;
        private System.Windows.Forms.Button saveConfigBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.CheckBox rotateCheckBox;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tileSizeTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox depthTextBox;
        private System.Windows.Forms.Button stopGenBtn;
        private System.Windows.Forms.Button resetTiles;
        private System.Windows.Forms.CheckBox previewCheckBox;
    }
}

