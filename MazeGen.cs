using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
///This part of the program mostly came from ChatGPT.  I did modify it a bit (mostly setting it to use a bool rather than char based map, 
///and providing a write to bitmap method).  It originally was a complete program and wrote to the console.  I'm not sure what algorithm
///it is using but it seems pretty fast and I like the look of the generated mazes.
///

namespace ah_Maze_ing
{
    internal class MazeGen
    {
        private readonly int width;
        private readonly int height;
        private readonly bool[,] map;
        private readonly Random random;

        //constructor
        public MazeGen(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new bool[height, width];
            random = new Random();
        }

        //the work horse
        //we could have returned the maze from here, but I left it this way in case there would be alterations added later
        public void GenerateMaze()
        {
            InitializeMaze();
            RecursiveGenerate(1, 1);
        }

        //internal functions
        private void InitializeMaze()
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    map[i, j] = true;
        }
        private void RecursiveGenerate(int row, int col)
        {
            map[row, col] = false;
            int[] directions = GetRandomDirections();
            foreach (int direction in directions)
            {
                int newRow = row;
                int newCol = col;
                if (direction == 0)
                    newCol -= 2; // Move left
                else if (direction == 1)
                    newRow -= 2; // Move up
                else if (direction == 2)
                    newCol += 2; // Move right
                else if (direction == 3)
                    newRow += 2; // Move down
                if (IsInRange(newRow, newCol) && map[newRow, newCol] == true)
                {
                    map[(row + newRow) / 2, (col + newCol) / 2] = false;
                    RecursiveGenerate(newRow, newCol);
                }
            }
        }
        private int[] GetRandomDirections()
        {
            int[] directions = { 0, 1, 2, 3 };
            Shuffle(directions);
            return directions;
        }
        private void Shuffle(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int j = random.Next(i, array.Length);
                (array[j], array[i]) = (array[i], array[j]);
            }
        }
        private bool IsInRange(int row, int col) => row >= 0 && row < height && col >= 0 && col < width;

        //output
        public void WriteToBitmap(Image mazebmp, Color backcolor, Color forecolor) => WriteToBitmap(mazebmp, null, null, backcolor, forecolor);
        public void WriteToBitmap(Image mazebmp, Image floorbmp, Image wallbmp) => WriteToBitmap(mazebmp, floorbmp, wallbmp, Color.Black, Color.Gray);
        public void WriteToBitmap(Image mazebmp, Image? floorbmp, Image? wallbmp, Color backcolor, Color forecolor)
        {
            using Graphics g = Graphics.FromImage(mazebmp); //draw to bitmap
            {
                for (int i = 0; i < height; i++) //for each row
                {
                    for (int j = 0; j < width; j++) //for each column
                    {
                        if (map[i, j] == true) //if it is a wall
                        {
                            if (wallbmp != null) //if we have a wall bitmap, use it
                                g.DrawImage(wallbmp, new Rectangle(j * 10, i * 10, 10, 10), new Rectangle(0, 0, 10, 10), GraphicsUnit.Pixel);
                            else //otherwise, draw a filled rectangle
                                g.FillRectangle(new SolidBrush(forecolor), j * 10, i * 10, 10, 10);
                        }
                        else //if it is not a wall (it is a space)
                        {
                            if (floorbmp != null) //if we have a floor bitmap, use it
                                g.DrawImage(floorbmp, new Rectangle(j * 10, i * 10, 10, 10), new Rectangle(0, 0, 10, 10), GraphicsUnit.Pixel);
                            else //otherwise, use a filled rectangle
                                g.FillRectangle(new SolidBrush(backcolor), j * 10, i * 10, 10, 10);
                        }
                    }
                }
            }
        }
        public int GetWidth() => width;
        public int GetHeight() => height;
        public bool[,] GetMap() => map;
    }
}
