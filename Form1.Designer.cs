namespace ah_Maze_ing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            controlPanel = new Panel();
            mapButton = new Button();
            picButton = new Button();
            quitButton = new Button();
            genButton = new Button();
            heightUpDown = new NumericUpDown();
            label2 = new Label();
            widthUpDown = new NumericUpDown();
            label1 = new Label();
            mazePanel = new Panel();
            mazeBox = new PictureBox();
            controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)heightUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)widthUpDown).BeginInit();
            mazePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mazeBox).BeginInit();
            SuspendLayout();
            // 
            // controlPanel
            // 
            controlPanel.BackColor = Color.LightGray;
            controlPanel.Controls.Add(mapButton);
            controlPanel.Controls.Add(picButton);
            controlPanel.Controls.Add(quitButton);
            controlPanel.Controls.Add(genButton);
            controlPanel.Controls.Add(heightUpDown);
            controlPanel.Controls.Add(label2);
            controlPanel.Controls.Add(widthUpDown);
            controlPanel.Controls.Add(label1);
            controlPanel.Location = new Point(12, 12);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(120, 358);
            controlPanel.TabIndex = 4;
            // 
            // mapButton
            // 
            mapButton.BackColor = Color.Aquamarine;
            mapButton.FlatStyle = FlatStyle.Popup;
            mapButton.Font = new Font("Arial Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            mapButton.ForeColor = Color.Navy;
            mapButton.Location = new Point(13, 255);
            mapButton.Name = "mapButton";
            mapButton.Size = new Size(98, 33);
            mapButton.TabIndex = 4;
            mapButton.Text = "Save Map";
            mapButton.UseVisualStyleBackColor = false;
            mapButton.Click += MazeSaveMap;
            // 
            // picButton
            // 
            picButton.BackColor = Color.Aquamarine;
            picButton.FlatStyle = FlatStyle.Popup;
            picButton.Font = new Font("Arial Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            picButton.ForeColor = Color.Navy;
            picButton.Location = new Point(13, 202);
            picButton.Name = "picButton";
            picButton.Size = new Size(98, 33);
            picButton.TabIndex = 4;
            picButton.Text = "Save Pic";
            picButton.UseVisualStyleBackColor = false;
            picButton.Click += MazeSavePic;
            // 
            // quitButton
            // 
            quitButton.BackColor = Color.Yellow;
            quitButton.FlatStyle = FlatStyle.Popup;
            quitButton.Font = new Font("Arial Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            quitButton.ForeColor = Color.Maroon;
            quitButton.Location = new Point(13, 311);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(98, 29);
            quitButton.TabIndex = 3;
            quitButton.Text = "QUIT";
            quitButton.UseVisualStyleBackColor = false;
            quitButton.Click += MazeQuit;
            // 
            // genButton
            // 
            genButton.BackColor = Color.PaleGreen;
            genButton.FlatStyle = FlatStyle.Popup;
            genButton.Font = new Font("Arial Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            genButton.ForeColor = Color.FromArgb(0, 32, 0);
            genButton.Location = new Point(13, 150);
            genButton.Name = "genButton";
            genButton.Size = new Size(98, 31);
            genButton.TabIndex = 2;
            genButton.Text = "Generate";
            genButton.UseVisualStyleBackColor = false;
            genButton.Click += MazeGenerate;
            // 
            // heightUpDown
            // 
            heightUpDown.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            heightUpDown.Location = new Point(13, 102);
            heightUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            heightUpDown.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            heightUpDown.Name = "heightUpDown";
            heightUpDown.Size = new Size(98, 27);
            heightUpDown.TabIndex = 1;
            heightUpDown.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 79);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 0;
            label2.Text = "Height:";
            // 
            // widthUpDown
            // 
            widthUpDown.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            widthUpDown.Location = new Point(13, 40);
            widthUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            widthUpDown.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            widthUpDown.Name = "widthUpDown";
            widthUpDown.Size = new Size(98, 27);
            widthUpDown.TabIndex = 1;
            widthUpDown.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 17);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Width:";
            // 
            // mazePanel
            // 
            mazePanel.AutoScroll = true;
            mazePanel.BackColor = Color.LightGray;
            mazePanel.Controls.Add(mazeBox);
            mazePanel.Location = new Point(138, 12);
            mazePanel.Name = "mazePanel";
            mazePanel.Size = new Size(650, 358);
            mazePanel.TabIndex = 5;
            // 
            // mazeBox
            // 
            mazeBox.BackColor = Color.Black;
            mazeBox.Location = new Point(14, 17);
            mazeBox.Name = "mazeBox";
            mazeBox.Size = new Size(623, 323);
            mazeBox.TabIndex = 0;
            mazeBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(798, 383);
            Controls.Add(mazePanel);
            Controls.Add(controlPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Ah-MAZE-ing!";
            FormClosing += MazeClosing;
            FormClosed += MazeClosed;
            Load += MazeLoad;
            Resize += MazeResize;
            controlPanel.ResumeLayout(false);
            controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)heightUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)widthUpDown).EndInit();
            mazePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mazeBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel controlPanel;
        private NumericUpDown widthUpDown;
        private Label label1;
        private Button genButton;
        private NumericUpDown heightUpDown;
        private Label label2;
        private Panel mazePanel;
        private PictureBox mazeBox;
        private Button quitButton;
        private Button picButton;
        private Button mapButton;
    }
}