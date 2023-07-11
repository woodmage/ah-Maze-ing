using ah_Maze_ing.Properties;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ah_Maze_ing
{
    public partial class Form1 : Form
    {
        //global variables used by program
        Size client = new();
        Bitmap mazeBmp = new(1000, 1000);
        readonly Bitmap wallBmp = new(10, 10);
        readonly Bitmap floorBmp = new(10, 10);
        int wide, high;
        readonly List<string> mapdata = new();
        bool exitnow = false;
        public Form1()
        {
            InitializeComponent(); //windows requirement
        }

        private void MazeLoad(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(wallBmp); //draw to wall bitmap
            {
                using Bitmap tempbmp = Resources.DarkStone; //use dark stone for it
                    g.DrawImage(tempbmp, new Rectangle(0, 0, 10, 10), new Rectangle(0, 0, tempbmp.Width, tempbmp.Height), GraphicsUnit.Pixel);
            }
            using Graphics gb = Graphics.FromImage(floorBmp); //draw to floor bitmap
            {
                using Bitmap tempbmp = Resources.LightStone; //use light stone for it
                    gb.DrawImage(tempbmp, new Rectangle(0, 0, 10, 10), new Rectangle(0, 0, tempbmp.Width, tempbmp.Height), GraphicsUnit.Pixel);
            }
        }

        private void MazeResize(object sender, EventArgs e)
        {
            int bordersize = 10; //10 pixels between edges and such
            client = ClientSize; //get new client size
            controlPanel.Location = new(bordersize, bordersize); //put control panel in place
            mazePanel.Location = new(bordersize + controlPanel.Width + bordersize, bordersize); //same with maze panel
            mazePanel.Width = client.Width - mazePanel.Left - bordersize; //set width of maze panel
            mazePanel.Height = controlPanel.Height = client.Height - bordersize * 2; //set height of both panels
            int h = client.Height - label1.Height - 5 - widthUpDown.Height - label2.Height - 5 - heightUpDown.Height
                - genButton.Height - picButton.Height - mapButton.Height - quitButton.Height;
            h /= 7; //compute distance between controls
            label1.Location = new(bordersize, h); //set location of label
            widthUpDown.Location = new(bordersize, h + label1.Height + 5); //and on it goes
            label2.Location = new(bordersize, widthUpDown.Bottom + h);
            heightUpDown.Location = new(bordersize, label2.Bottom + 5);
            genButton.Location = new(bordersize, heightUpDown.Bottom + h);
            picButton.Location = new(bordersize, genButton.Bottom + h);
            mapButton.Location = new(bordersize, picButton.Bottom + h);
            quitButton.Location = new(bordersize, mapButton.Bottom + h);
            mazeBox.Location = new(bordersize, bordersize);
        }

        private void MazeGenerate(object sender, EventArgs e)
        {
            int w = (int)widthUpDown.Value, h = (int)heightUpDown.Value; //get values from controls
            int ww = w / 10; if (ww % 2 == 0) ww++; //compute units to use
            int hh = h / 10; if (hh % 2 == 0) hh++; //and don't let them be even
            ResizeMaze(ww * 10, hh * 10); //resize the maze
            MazeGen m = new(ww, hh); //make a new maze
            m.GenerateMaze();
            m.WriteToBitmap(mazeBmp, floorBmp, wallBmp); //write it to the bitmap
            SaveData(m); //and store a copy in string format
            mazeBox.Image = mazeBmp; //set picturebox to use bitmap
            mazeBox.Invalidate(); //tell windows to repaint the picturebox
        }

        private void SaveData(MazeGen m)
        {
            wide = m.GetWidth(); //get maze dimensions
            high = m.GetHeight();
            bool[,] mdata; //storage for maze map
            mdata = m.GetMap(); //get map
            mapdata.Clear(); //clear our map data
            for (int i = 0; i < high; i++) //for each line
            {
                string buf = ""; //set up a buffer
                for (int j = 0; j < wide; j++) //for each column
                {
                    if (mdata[i, j]) buf += "#"; //if its a wall, add a "#" to the buffer
                    else buf += " "; //othewise, add a space
                }
                mapdata.Add(buf); //add the buffer to our map data
            }
        }

        private void MazeQuit(object sender, EventArgs e)
        {
            if (!exitnow) //if we aren't exiting (yet)
                if (MessageBox.Show("Quit?  You sure?", "QUIT?", MessageBoxButtons.YesNo) == DialogResult.Yes) //if we agree to quit
                    MazeExit(); //exit
        }

        private void ResizeMaze(int w, int h)
        {
            mazeBmp.Dispose(); //get rid of maze bitmap
            mazeBmp = new(w, h); //make new one
            mazeBox.Size = new Size(w, h); //size the picturebox the same
        }

        private void MazeClosed(object sender, FormClosedEventArgs e)
        {
            mazeBmp.Dispose(); //get rid of maze bitmap
            Application.Exit(); //exit the program
        }

        private void MazeSavePic(object sender, EventArgs e)
        {
            using SaveFileDialog save = new() //using a (new) save file dialog
            {
                Filter = "Png image file (*.png)|*.png|Jpg image file (*.jpg)|*.jpg|Gif image file (*.gif)|*.gif|Bmp image file (*.bmp)|*.bmp|Tiff image file (*.tiff)|*.tiff|Any file (*.*)|*.*",
                Title = "Save image file",
                AddExtension = true,
                DefaultExt = ".png"
            };
            {
                save.ShowDialog(); //show the dialog
                if (save.FileName != "") //if the filename is not empty
                {
                    using Stream fs = save.OpenFile(); //using a stream from the file
                    {
                        ImageFormat imf = ImageFormat.Png; //assume png format
                        if (save.FileName.Contains(".jpg")) imf = ImageFormat.Jpeg; //but we can do others
                        if (save.FileName.Contains(".gif")) imf = ImageFormat.Gif;
                        if (save.FileName.Contains(".bmp")) imf = ImageFormat.Bmp;
                        if (save.FileName.Contains(".tiff")) imf = ImageFormat.Tiff;
                        mazeBmp.Save(fs, imf); //save the bitmap to the stream with the proper format
                    }
                }
            }
        }

        private void MazeSaveMap(object sender, EventArgs e)
        {
            using SaveFileDialog save = new() { Filter = "ah-MAZE-ing text file (*.txt)|*.txt|Any file (*.*)|*.*", Title = "Save Ah-MAZE-ing Text File" };
            {
                save.ShowDialog(); //show a save file dialog
                if (save.FileName != "") //if the filename isn't empty
                {
                    using Stream fs = save.OpenFile(); //using a stream from the file
                    {
                        using StreamWriter sw = new(fs); //use the streamwriter
                        {
                            for (int y = 0; y < high; y++) //for each line
                                sw.WriteLine(mapdata[y]); //write that line of map data
                            sw.WriteLine(wide + "," + high); //write the dimensions
                        }
                    }
                }
            }
        }

        private void MazeClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitnow) //if we aren't (yet) exiting
            {
                if (MessageBox.Show("Quit?  You sure?", "QUIT?", MessageBoxButtons.YesNo) == DialogResult.Yes) //if we agree
                    MazeExit(); //exit
                else //otherwise
                    e.Cancel = true; //cancel the closing
            }
        }

        private void MazeExit()
        {
            exitnow = true; //we ARE exiting
            mazeBmp.Dispose(); //get rid of maze bitmap
            Application.Exit(); //exit program
        }
    }
}