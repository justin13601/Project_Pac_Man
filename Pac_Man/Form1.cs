using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Media;

namespace Pac_Man
{
    public partial class Form1 : Form
    {
        //Declare instances of Pacman & the ghosts
        PacMan Pman = new PacMan();
        Ghosts Ghost4 = new Ghosts(Color.Yellow, 13, 14, 1);
        Ghosts Ghost3 = new Ghosts(Color.HotPink, 15, 14, 0);
        Ghosts Ghost2 = new Ghosts(Color.DeepSkyBlue, 14, 14, 2);
        Ghosts Ghost1 = new Ghosts(Color.Red, 14, 13, 2);

        private SoundPlayer Player = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            InitializeMap();
            btnStart.Text = "Start";
            btnReset.Enabled = false;
            btnPause.Enabled = false;
            pbReady.BringToFront();
            pbReady.Show();


            //Plays Pacman Music
            this.Player.SoundLocation = @"C:\Users\Latitude\source\repos\Pac_Man\Pac_Man\bin\Debug\Theme.wav";
            this.Player.PlayLooping();
        }

        //Declares map size
        public int[,] Map = new int[29, 31]; //-1 = wall, 1 = food, 0 = no food

        //Initializes map
        public void InitializeMap()
        {
            //Sets all blocks to 'wall'
            for (int i = 0; i < 29; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    Map[i, j] = -1;
                }
            }

            //Row 1
            for (int col = 1; col < 28; col++)
            {
                Map[col, 1] = 1;
            }

            //Rows 2 - 4
            for (int row = 2; row < 5; row++)
            {
                Map[1, row] = 1;
                Map[6, row] = 1;
                Map[12, row] = 1;
                Map[16, row] = 1;
                Map[22, row] = 1;
                Map[27, row] = 1;
            }

            //Row 5
            for (int col = 1; col < 28; col++)
            {
                Map[col, 5] = 1;
            }

            //Rows 6 - 7
            for (int row = 6; row < 8; row++)
            {
                Map[1, row] = 1;
                Map[6, row] = 1;
                Map[9, row] = 1;
                Map[19, row] = 1;
                Map[22, row] = 1;
                Map[27, row] = 1;
            }

            //Row 8
            for (int col = 1; col < 7; col++)
            {
                Map[col, 8] = 1;
            }
            for (int col = 9; col < 13; col++)
            {
                Map[col, 8] = 1;
            }
            for (int col = 16; col < 20; col++)
            {
                Map[col, 8] = 1;
            }
            for (int col = 22; col < 28; col++)
            {
                Map[col, 8] = 1;
            }

            //Rows 9 - 10
            for (int row = 9; row < 11; row++)
            {
                Map[6, row] = 1;
                Map[12, row] = 1;
                Map[16, row] = 1;
                Map[22, row] = 1;
            }

            //Row 11
            for (int col = 6; col < 7; col++)
            {
                Map[col, 11] = 1;
            }
            for (int col = 9; col < 20; col++)
            {
                Map[col, 11] = 1;
            }
            for (int col = 22; col < 23; col++)
            {
                Map[col, 11] = 1;
            }

            //Rows 12 - 13
            for (int row = 12; row < 14; row++)
            {
                Map[6, row] = 1;
                Map[9, row] = 1;
                Map[19, row] = 1;
                Map[22, row] = 1;
            }

            //Row 14
            for (int col = 0; col < 10; col++)
            {
                Map[col, 14] = 1;
            }
            for (int col = 19; col < 29; col++)
            {
                Map[col, 14] = 1;
            }

            //Rows 15 - 16
            for (int row = 15; row < 17; row++)
            {
                Map[6, row] = 1;
                Map[9, row] = 1;
                Map[19, row] = 1;
                Map[22, row] = 1;
            }

            //Row 17
            for (int col = 6; col < 7; col++)
            {
                Map[col, 17] = 1;
            }
            for (int col = 9; col < 20; col++)
            {
                Map[col, 17] = 1;
            }
            for (int col = 22; col < 23; col++)
            {
                Map[col, 17] = 1;
            }

            //Rows 18 - 19
            for (int row = 18; row < 20; row++)
            {
                Map[6, row] = 1;
                Map[9, row] = 1;
                Map[19, row] = 1;
                Map[22, row] = 1;
            }

            //Row 20
            for (int col = 1; col < 13; col++)
            {
                Map[col, 20] = 1;
            }
            for (int col = 16; col < 28; col++)
            {
                Map[col, 20] = 1;
            }

            //Rows 21 - 22
            for (int row = 21; row < 23; row++)
            {
                Map[1, row] = 1;
                Map[6, row] = 1;
                Map[12, row] = 1;
                Map[16, row] = 1;
                Map[22, row] = 1;
                Map[27, row] = 1;
            }

            //Row 23
            for (int col = 1; col < 4; col++)
            {
                Map[col, 23] = 1;
            }
            for (int col = 6; col < 23; col++)
            {
                Map[col, 23] = 1;
            }
            for (int col = 25; col < 28; col++)
            {
                Map[col, 23] = 1;
            }

            //Rows 24 - 25
            for (int row = 24; row < 26; row++)
            {
                Map[3, row] = 1;
                Map[6, row] = 1;
                Map[9, row] = 1;
                Map[19, row] = 1;
                Map[22, row] = 1;
                Map[25, row] = 1;
            }

            //Row 26
            for (int col = 1; col < 7; col++)
            {
                Map[col, 26] = 1;
            }
            for (int col = 9; col < 13; col++)
            {
                Map[col, 26] = 1;
            }
            for (int col = 16; col < 20; col++)
            {
                Map[col, 26] = 1;
            }
            for (int col = 22; col < 28; col++)
            {
                Map[col, 26] = 1;
            }

            //Rows 27 - 28
            for (int row = 27; row < 30; row++)
            {
                Map[1, row] = 1;
                Map[12, row] = 1;
                Map[16, row] = 1;
                Map[27, row] = 1;
            }

            //Row 29            
            for (int col = 1; col < 28; col++)
            {
                Map[col, 29] = 1;
            }

            //Powerups
            Map[1, 3] = -2;
            Map[27, 3] = -2;
            Map[1, 22] = -2;
            Map[27, 22] = -2;

            //Ghost Spawns
            for (int col = 11; col < 18; col++)
            {
                for (int row = 13; row < 16; row++)
                {
                    Map[col, row] = 2;
                }
            }

            //Ghost Entrance
            Map[13, 12] = -3;
            Map[14, 12] = -3;
            Map[15, 12] = -3;

            //Boundaries
            for (int col = 0; col < 5; col++)
            {
                for (int row = 10; row < 13; row++)
                {
                    Map[col, row] = 3;
                }
            }
            for (int col = 0; col < 5; col++)
            {
                for (int row = 16; row < 19; row++)
                {
                    Map[col, row] = 3;
                }
            }
            for (int col = 24; col < 29; col++)
            {
                for (int row = 10; row < 13; row++)
                {
                    Map[col, row] = 3;
                }
            }
            for (int col = 24; col < 29; col++)
            {
                for (int row = 16; row < 19; row++)
                {
                    Map[col, row] = 3;
                }
            }

            //Intersections
            Map[14, 11] = 4;

            Map[1, 1] = 4;
            Map[1, 5] = 4;
            Map[1, 8] = 4;
            Map[6, 1] = 4;
            Map[6, 5] = 4;
            Map[6, 8] = 4;
            Map[9, 5] = 4;
            Map[9, 8] = 4;
            Map[12, 1] = 4;
            Map[12, 5] = 4;
            Map[12, 8] = 4;
            Map[16, 1] = 4;
            Map[16, 5] = 4;
            Map[16, 8] = 4;
            Map[19, 1] = 4;
            Map[19, 5] = 4;
            Map[19, 8] = 4;
            Map[22, 1] = 4;
            Map[22, 5] = 4;
            Map[22, 8] = 4;
            Map[27, 1] = 4;
            Map[27, 5] = 4;
            Map[27, 8] = 4;
            Map[9, 11] = 4;
            Map[12, 11] = 4;
            Map[16, 11] = 4;
            Map[19, 11] = 4;
            Map[6, 14] = 4;
            Map[9, 14] = 4;
            Map[19, 14] = 4;
            Map[22, 14] = 4;
            Map[9, 17] = 4;
            Map[19, 17] = 4;
            Map[1, 20] = 4;
            Map[6, 20] = 4;
            Map[9, 20] = 4;
            Map[12, 20] = 4;
            Map[16, 20] = 4;
            Map[19, 20] = 4;
            Map[22, 20] = 4;
            Map[27, 20] = 4;
            Map[1, 23] = 4;
            Map[3, 23] = 4;
            Map[6, 23] = 4;
            Map[9, 23] = 4;
            Map[12, 23] = 4;
            Map[16, 23] = 4;
            Map[19, 23] = 4;
            Map[22, 23] = 4;
            Map[25, 23] = 4;
            Map[27, 23] = 4;
            Map[1, 26] = 4;
            Map[3, 26] = 4;
            Map[6, 26] = 4;
            Map[9, 26] = 4;
            Map[12, 26] = 4;
            Map[16, 26] = 4;
            Map[19, 26] = 4;
            Map[22, 26] = 4;
            Map[25, 26] = 4;
            Map[27, 26] = 4;
            Map[1, 29] = 4;
            Map[12, 29] = 4;
            Map[16, 29] = 4;
            Map[27, 29] = 4;

        }

        public class PacMan
        {
            public int pX;
            public int pY;
            public int iDirection;  //0:Left  1:Right  2:Up  3:Down
            public Color colour;
            public bool IsEnergized;
            public int Score;
            public int Lives;

            public PacMan()
            {
                pX = 14;
                pY = 23;
                iDirection = -1;
                colour = Color.Yellow;
                IsEnergized = false;
                Score = 0;
                Lives = 3;
            }

            //Method that moves Pacman one slot based on its direction
            public void Move(int[,] map)
            {
                if (iDirection == 0)
                {
                    if (pX == 0)
                    {
                        pX = 28;
                    }
                    else if (map[pX - 1, pY] == -2)
                    {
                        pX = pX - 1;
                        IsEnergized = true;
                    }
                    else if (map[pX - 1, pY] != -1)
                    {
                        pX = pX - 1;
                    }
                }

                if (iDirection == 1)
                {
                    if (pX == 28)
                    {
                        pX = 0;
                    }
                    else if (map[pX + 1, pY] == -2)
                    {
                        pX = pX + 1;
                        IsEnergized = true;
                    }
                    else if (map[pX + 1, pY] != -1)
                    {
                        pX = pX + 1;
                    }
                }

                if (iDirection == 2)
                {
                    if (map[pX, pY - 1] == -2)
                    {
                        pY = pY - 1;
                        IsEnergized = true;
                    }
                    else if (map[pX, pY - 1] != -1)
                    {
                        pY = pY - 1;
                    }
                }

                if (iDirection == 3)
                {
                    if (map[pX, pY + 1] == -2)
                    {
                        pY = pY + 1;
                        IsEnergized = true;
                    }
                    else if (map[pX, pY + 1] != -1)
                    {
                        pY = pY + 1;
                    }
                }

                //Sets tiles with food to tiles with no food once Pacman 'runs over' them
                if (map[pX, pY] == 4)
                {
                    map[pX, pY] = -4;
                    Score = Score + 10;
                }
                else if (map[pX, pY] == -4)
                {
                    map[pX, pY] = -4;
                }
                else if (map[pX, pY] == 1)
                {
                    map[pX, pY] = 0;
                    Score = Score + 10;
                }
                else if (map[pX, pY] == -2)
                {
                    map[pX, pY] = 0;
                }

            }

            public void setScore(int prevScore)
            {
                if (prevScore < 0)
                {
                    Score = 0;
                }
                else
                {
                    Score = prevScore;
                }
            }

            public void addScore(int additionalScore)
            {
                if (additionalScore < 0)
                {
                    additionalScore = 0;
                }
                else
                {
                    Score = Score + additionalScore;
                }
            }

            public int getScore()
            {
                return Score;
            }

            public void setpX(int p)
            {
                if (p < 0)
                {
                    pX = 0;
                }
                else if (p > 29)
                {
                    pX = 29;
                }
                else
                {
                    pX = p;
                }
            }

            public int getpX()
            {
                return pX;
            }

            public int getLives()
            {
                return Lives;
            }

            public void setLives(int p)
            {
                if (p < 0)
                {
                    Lives = 0;
                }
                else
                {
                    Lives = p;
                }
            }

            public void setpY(int p)
            {
                if (p < 0)
                {
                    pY = 0;
                }
                else if (p > 30)
                {
                    pY = 30;
                }
                else
                {
                    pY = p;
                }
            }

            public int getpY()
            {
                return pY;
            }

            public void setDirection(int setDirection)
            {
                iDirection = setDirection;
            }

            //Tests for viable directions
            public void ChangeDirection(int[,] map, int newDirection)
            {
                if (newDirection == 2)
                {
                    if (map[pX, pY - 1] != -1)
                    {
                        iDirection = newDirection;
                    }
                }
                else if (newDirection == 3)
                {
                    if (map[pX, pY + 1] != -1 && map[pX, pY + 1] != -3)
                    {
                        iDirection = newDirection;
                    }
                }
                else if (newDirection == 0)
                {
                    if (pX == 0)
                    {
                        pX = 29;
                    }
                    else if (map[pX - 1, pY] != -1)
                    {
                        iDirection = newDirection;
                    }
                }
                else if (newDirection == 1)
                {
                    if (pX == 28)
                    {
                        pX = -1;
                    }
                    else if (map[pX + 1, pY] != -1)
                    {
                        iDirection = newDirection;
                    }
                }
            }

            //Tests for game winning conditions (i.e. when all food is eaten)
            public bool GameWin(int[,] map)
            {
                for (int i = 0; i < 29; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        if (map[i, j] == 1 || map[i, j] == 4 || map[i, j] == -2)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            //Draws Pacman
            public void DrawPacMan(Graphics gr)
            {
                SolidBrush PacBrush = new SolidBrush(colour);
                gr.FillEllipse(PacBrush, pX * 15, pY * 15, 14, 14);

                //Pacman's mouth relative to its direction
                if (iDirection == -1)
                {
                    SolidBrush myBrush = new SolidBrush(colour);
                    gr.FillEllipse(myBrush, pX * 15, pY * 15, 14, 14);
                }
                else if (iDirection == 1)
                {
                    Point[] point = new Point[3];

                    point[0].X = pX * 15 + 7;
                    point[0].Y = pY * 15 + 7;

                    point[1].X = pX * 15 + 15;
                    point[1].Y = pY * 15 + 3;

                    point[2].X = pX * 15 + 15;
                    point[2].Y = pY * 15 + 11;

                    SolidBrush myBrush = new SolidBrush(Color.Black);
                    gr.FillPolygon(myBrush, point);
                }
                else if (iDirection == 0)
                {
                    Point[] point = new Point[3];

                    point[0].X = pX * 15 + 8;
                    point[0].Y = pY * 15 + 7;

                    point[1].X = pX * 15;
                    point[1].Y = pY * 15 + 3;

                    point[2].X = pX * 15;
                    point[2].Y = pY * 15 + 11;

                    SolidBrush myBrush = new SolidBrush(Color.Black);
                    gr.FillPolygon(myBrush, point);
                }
                else if (iDirection == 2)
                {
                    Point[] point = new Point[3];

                    point[0].X = pX * 15 + 7;
                    point[0].Y = pY * 15 + 8;

                    point[1].X = pX * 15 + 3;
                    point[1].Y = pY * 15;

                    point[2].X = pX * 15 + 11;
                    point[2].Y = pY * 15;

                    SolidBrush myBrush = new SolidBrush(Color.Black);
                    gr.FillPolygon(myBrush, point);
                }
                else if (iDirection == 3)
                {
                    Point[] point = new Point[3];

                    point[0].X = pX * 15 + 7;
                    point[0].Y = pY * 15 + 7;

                    point[1].X = pX * 15 + 2;
                    point[1].Y = pY * 15 + 15;

                    point[2].X = pX * 15 + 12;
                    point[2].Y = pY * 15 + 15;

                    SolidBrush myBrush = new SolidBrush(Color.Black);
                    gr.FillPolygon(myBrush, point);
                }
            }
        }

        public class Ghosts
        {
            public int pX;
            public int pY;
            public int iDirection;  //0:Left  1:Right  2:Up  3:Down
            public Color colour;
            public bool IsVulnerable;

            public Ghosts(Color color, int pointX, int pointY, int initialDir)
            {
                pX = pointX;
                pY = pointY;
                iDirection = initialDir;
                colour = color;
                IsVulnerable = false;
            }

            //Tests for valid directions for a ghost at intersections
            public List<int> ValidDirections(int[,] map)
            {
                if (iDirection == 2)
                {
                    if ((map[pX, pY - 1] != -1) && (map[pX - 1, pY] != -1) && (map[pX, pY + 1] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0, 2 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX + 1, pY] != -1) && (map[pX, pY + 1] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 1, 2 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY + 1] != -1) && (map[pX + 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 1 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY + 1] != -1) && (map[pX - 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY + 1] != -1) && (map[pX - 1, pY] != -1) && (map[pX + 1, pY] != -1) && (map[pX, pY - 1] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0, 1, 2 };
                        return ValidDirections;
                    }
                    else
                    {
                        List<int> ValidDirections = new List<int> { 2 };
                        return ValidDirections;
                    }
                }
                else if (iDirection == 3)
                {
                    if ((map[pX, pY - 1] != -1) && (map[pX - 1, pY] != -1) && (map[pX, pY + 1] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0, 3 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX + 1, pY] != -1) && (map[pX, pY + 1] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 1, 3 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX + 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 1 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX - 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX - 1, pY] != -1) && (map[pX + 1, pY] != -1) && (map[pX, pY + 1] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0, 1, 3 };
                        return ValidDirections;
                    }
                    else
                    {
                        List<int> ValidDirections = new List<int> { 3 };
                        return ValidDirections;
                    }
                }
                else if (iDirection == 0)
                {
                    if ((map[pX, pY - 1] != -1) && (map[pX + 1, pY] != -1) && (map[pX - 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0, 2 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY + 1] != -1) && (map[pX - 1, pY] != -1) && (map[pX + 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0, 3 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX + 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 2 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY + 1] != -1) && (map[pX + 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 3 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX - 1, pY] != -1) && (map[pX + 1, pY] != -1) && (map[pX, pY + 1] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0, 2, 3 };
                        return ValidDirections;
                    }
                    else
                    {
                        List<int> ValidDirections = new List<int> { 0 };
                        return ValidDirections;
                    }
                }
                else
                {
                    if ((map[pX, pY - 1] != -1) && (map[pX - 1, pY] != -1) && (map[pX + 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 2, 1 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY + 1] != -1) && (map[pX + 1, pY] != -1) && (map[pX - 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 1, 3 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX - 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 2 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY + 1] != -1) && (map[pX - 1, pY] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 3 };
                        return ValidDirections;
                    }
                    else if ((map[pX, pY - 1] != -1) && (map[pX - 1, pY] != -1) && (map[pX + 1, pY] != -1) && (map[pX, pY + 1] != -1))
                    {
                        List<int> ValidDirections = new List<int> { 0, 1, 2 };
                        return ValidDirections;
                    }
                    else
                    {
                        List<int> ValidDirections = new List<int> { 1 };
                        return ValidDirections;
                    }
                }

            }

            //Moves ghost 1 slot in a specific direction
            public void Move(int[,] map)
            {
                if (iDirection == 0)
                {
                    if (pX == 0)
                    {
                        pX = 28;
                    }
                    else if (map[pX - 1, pY] != -1)
                    {
                        pX = pX - 1;
                    }
                }

                if (iDirection == 1)
                {
                    if (pX == 28)
                    {
                        pX = 0;
                    }
                    else if (map[pX + 1, pY] != -1)
                    {
                        pX = pX + 1;
                    }
                }

                if (iDirection == 2)
                {
                    if (map[pX, pY - 1] != -1)
                    {
                        pY = pY - 1;
                    }
                }

                if (iDirection == 3)
                {
                    if (map[pX, pY + 1] != -1)
                    {
                        pY = pY + 1;
                    }
                }
            }

            //Changes direction of ghost is valid
            public void ChangeDirection(int[,] map, int newDirection)
            {
                if (newDirection == 2)
                {
                    if (map[pX, pY - 1] != -1)
                    {
                        iDirection = newDirection;
                    }
                }
                else if (newDirection == 3)
                {
                    if (map[pX, pY + 1] != -1 && map[pX, pY + 1] != -3)
                    {
                        iDirection = newDirection;
                    }
                }
                else if (newDirection == 0)
                {
                    if (pX == 0)
                    {
                        pX = 29;
                    }
                    else if (map[pX - 1, pY] != -1)
                    {
                        iDirection = newDirection;
                    }
                }
                else if (newDirection == 1)
                {
                    if (pX == 28)
                    {
                        pX = -1;
                    }
                    else if (map[pX + 1, pY] != -1)
                    {
                        iDirection = newDirection;
                    }
                }
            }

            public void setpX(int p)
            {
                if (p < 0)
                {
                    pX = 0;
                }
                else if (p > 29)
                {
                    pX = 29;
                }
                else
                {
                    pX = p;
                }
            }

            public int getpX()
            {
                return pX;
            }

            public void setpY(int p)
            {
                if (p < 0)
                {
                    pY = 0;
                }
                else if (p > 30)
                {
                    pY = 30;
                }
                else
                {
                    pY = p;
                }
            }

            public int getpY()
            {
                return pY;
            }

            //Draws ghosts in their own colours, along with ghost eyes and body
            public void DrawGhosts(Graphics gr)
            {
                if (IsVulnerable == true)
                {
                    SolidBrush GhostHeadBrush = new SolidBrush(Color.Blue);
                    gr.FillRectangle(GhostHeadBrush, pX * 15, pY * 15 + 9, 14, 6);

                    SolidBrush GhostBodyBrush = new SolidBrush(Color.Blue);
                    gr.FillEllipse(GhostBodyBrush, pX * 15, pY * 15, 13, 13);

                    SolidBrush GhostEyeBrush = new SolidBrush(Color.White);
                    gr.FillEllipse(GhostEyeBrush, pX * 15 + 2, pY * 15 + 2, 4, 4);
                    gr.FillEllipse(GhostEyeBrush, pX * 15 + 7, pY * 15 + 2, 4, 4);

                    SolidBrush GhostPupilBrush = new SolidBrush(Color.Black);
                    gr.FillEllipse(GhostPupilBrush, pX * 15 + 3, pY * 15 + 3, 2, 2);
                    gr.FillEllipse(GhostPupilBrush, pX * 15 + 9, pY * 15 + 3, 2, 2);
                }
                else
                {
                    SolidBrush GhostHeadBrush = new SolidBrush(colour);
                    gr.FillRectangle(GhostHeadBrush, pX * 15, pY * 15 + 9, 14, 6);

                    SolidBrush GhostBodyBrush = new SolidBrush(colour);
                    gr.FillEllipse(GhostBodyBrush, pX * 15, pY * 15, 13, 13);

                    SolidBrush GhostEyeBrush = new SolidBrush(Color.White);
                    gr.FillEllipse(GhostEyeBrush, pX * 15 + 2, pY * 15 + 2, 4, 4);
                    gr.FillEllipse(GhostEyeBrush, pX * 15 + 7, pY * 15 + 2, 4, 4);

                    SolidBrush GhostPupilBrush = new SolidBrush(Color.Black);
                    gr.FillEllipse(GhostPupilBrush, pX * 15 + 3, pY * 15 + 3, 2, 2);
                    gr.FillEllipse(GhostPupilBrush, pX * 15 + 9, pY * 15 + 3, 2, 2);
                }
            }
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < 29; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    //Paints all walls to blue tiles
                    if (Map[i, j] == -1)
                    {
                        SolidBrush BBrush = new SolidBrush(Color.Navy);
                        g.FillRectangle(BBrush, i * 15, j * 15, 15, 15);
                    }
                    //Paints tiles with no food black
                    else if (Map[i, j] == 0)
                    {
                        SolidBrush YBrush = new SolidBrush(Color.Black);
                        g.FillRectangle(YBrush, i * 15, j * 15, 15, 15);
                    }
                    //Paints tiles with food black along with a dot representing food
                    else if (Map[i, j] == 1)
                    {
                        SolidBrush YBrush = new SolidBrush(Color.Black);
                        g.FillRectangle(YBrush, i * 15, j * 15, 15, 15);

                        SolidBrush OBrush = new SolidBrush(Color.LightSalmon);
                        g.FillEllipse(OBrush, i * 15 + 5, j * 15 + 5, 5, 5);
                    }
                    //Paints tiles with powerup black along with a large dot representing the powerup
                    else if (Map[i, j] == -2)
                    {
                        SolidBrush YBrush = new SolidBrush(Color.Black);
                        g.FillRectangle(YBrush, i * 15, j * 15, 15, 15);

                        SolidBrush OBrush = new SolidBrush(Color.LightSalmon);
                        g.FillEllipse(OBrush, i * 15 + 3, j * 15 + 2, 10, 10);
                    }
                    //Paints tiles guarding ghost spawn pink
                    else if (Map[i, j] == -3)
                    {
                        SolidBrush YBrush = new SolidBrush(Color.Magenta);
                        g.FillRectangle(YBrush, i * 15, j * 15, 15, 5);
                    }
                    //Paints intersecting tiles
                    else if (Map[i, j] == 4)
                    {
                        SolidBrush YBrush = new SolidBrush(Color.Black);
                        g.FillRectangle(YBrush, i * 15, j * 15, 15, 15);

                        SolidBrush OBrush = new SolidBrush(Color.LightSalmon);
                        g.FillEllipse(OBrush, i * 15 + 5, j * 15 + 5, 5, 5);
                    }
                }
            }

            Pman.DrawPacMan(g);
            Ghost1.DrawGhosts(g);
            Ghost2.DrawGhosts(g);
            Ghost3.DrawGhosts(g);
            Ghost4.DrawGhosts(g);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //Arrow key controls
            if (e.KeyCode == Keys.Up)
            {
                Pman.ChangeDirection(Map, 2);
            }
            if (e.KeyCode == Keys.Down)
            {
                Pman.ChangeDirection(Map, 3);
            }
            if (e.KeyCode == Keys.Left)
            {
                Pman.ChangeDirection(Map, 0);
            }
            if (e.KeyCode == Keys.Right)
            {
                Pman.ChangeDirection(Map, 1);
            }

            //WASD controls
            if (e.KeyCode == Keys.W)
            {
                Pman.ChangeDirection(Map, 2);
            }
            if (e.KeyCode == Keys.A)
            {
                Pman.ChangeDirection(Map, 0);
            }
            if (e.KeyCode == Keys.S)
            {
                Pman.ChangeDirection(Map, 3);
            }
            if (e.KeyCode == Keys.D)
            {
                Pman.ChangeDirection(Map, 1);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Pman.Move(Map);
            pictureBox1.Invalidate();

            //Tests if Pacman ate a powerup
            if (Pman.IsEnergized == true)
            {
                //Tests for grace period on ghost
                if (ghostGraceTimer.Enabled == true && Ghost1.IsVulnerable == false)
                {
                    Ghost1.IsVulnerable = false;
                }
                //Allows ghost to be eaten
                else
                {
                    Ghost1.IsVulnerable = true;
                }

                if (ghostGraceTimer.Enabled == true && Ghost2.IsVulnerable == false)
                {
                    Ghost2.IsVulnerable = false;
                }
                else
                {
                    Ghost2.IsVulnerable = true;
                }

                if (ghostGraceTimer.Enabled == true && Ghost3.IsVulnerable == false)
                {
                    Ghost3.IsVulnerable = false;
                }
                else
                {
                    Ghost3.IsVulnerable = true;
                }

                if (ghostGraceTimer.Enabled == true && Ghost4.IsVulnerable == false)
                {
                    Ghost4.IsVulnerable = false;
                }
                else
                {
                    Ghost4.IsVulnerable = true;
                }
                energizedTimer.Start();
            }

            //Displays score
            lblScore.Text = (Pman.getScore()).ToString();

            //Tests for collisions between Pacman and ghosts
            if (Pman.getpX() == Ghost1.getpX() && Pman.getpY() == Ghost1.getpY())
            {
                //When Pacman is energized, ghost is eaten
                if (Pman.IsEnergized == true && Ghost1.IsVulnerable == true)
                {
                    Ghost1.setpX(14);
                    Ghost1.setpY(13);
                    Ghost1.ChangeDirection(Map, 2);
                    Ghost1.IsVulnerable = false;
                    ghostGraceTimer.Start();
                    Pman.addScore(200);
                    lblScore.Text = (Pman.getScore()).ToString();
                    return;
                }
                //When Pacman is not energized, Pacman loses a life
                else
                {
                    gameTimer.Stop();
                    ghost1Timer.Stop();
                    ghost2Timer.Stop();
                    ghost3Timer.Stop();
                    ghost4Timer.Stop();
                    ghostWaitTimer.Stop();

                    //Tests if Pacman still has lives; if he does, game continues
                    if (Pman.getLives() > 0)
                    {
                        Pman.setDirection(-1);
                        Pman.setpX(14);
                        Pman.setpY(23);
                        Ghost1.setpX(14);
                        Ghost1.setpY(13);
                        Ghost1.ChangeDirection(Map, 2);
                        Ghost2.setpX(14);
                        Ghost2.setpY(14);
                        Ghost2.ChangeDirection(Map, 2);
                        Ghost3.setpX(15);
                        Ghost3.setpY(14);
                        Ghost3.ChangeDirection(Map, 0);
                        Ghost4.setpX(13);
                        Ghost4.setpY(14);
                        Ghost4.ChangeDirection(Map, 1);
                        pictureBox1.Invalidate();
                        btnStart.Text = "Continue";
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        btnImport.Enabled = false;
                        return;
                    }
                    //Pacman has no more lives, game is over
                    else
                    {
                        MessageBox.Show("Game Over!");
                        string name = Interaction.InputBox("Enter a Name to save your score on the Scoreboard.", "Enter Player Name", "Player 1", -1, -1);
                        if (name == "")
                        {
                            name = "Guest";
                        }
                        lbScoreNames.Items.Add(name);
                        lbScore.Items.Add(Pman.getScore().ToString());
                        SortScoreboard();
                        btnPause.Enabled = false;
                        btnStart.Enabled = false;
                        btnReset.Enabled = true;
                        return;
                    }
                }
            }
            else if (Pman.getpX() == Ghost2.getpX() && Pman.getpY() == Ghost2.getpY())
            {
                if (Pman.IsEnergized == true && Ghost2.IsVulnerable == true)
                {
                    Ghost2.setpX(14);
                    Ghost2.setpY(14);
                    Ghost2.ChangeDirection(Map, 2);
                    Ghost2.IsVulnerable = false;
                    ghostGraceTimer.Start();
                    Pman.addScore(200);
                    lblScore.Text = (Pman.getScore()).ToString();
                    return;
                }
                else
                {
                    gameTimer.Stop();
                    ghost1Timer.Stop();
                    ghost2Timer.Stop();
                    ghost3Timer.Stop();
                    ghost4Timer.Stop();
                    ghostWaitTimer.Stop();

                    if (Pman.getLives() > 0)
                    {
                        Pman.setDirection(-1);
                        Pman.setpX(14);
                        Pman.setpY(23);
                        Ghost1.setpX(14);
                        Ghost1.setpY(13);
                        Ghost1.ChangeDirection(Map, 2);
                        Ghost2.setpX(14);
                        Ghost2.setpY(14);
                        Ghost2.ChangeDirection(Map, 2);
                        Ghost3.setpX(15);
                        Ghost3.setpY(14);
                        Ghost3.ChangeDirection(Map, 0);
                        Ghost4.setpX(13);
                        Ghost4.setpY(14);
                        Ghost4.ChangeDirection(Map, 1);
                        pictureBox1.Invalidate();
                        btnStart.Text = "Continue";
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        btnImport.Enabled = false;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Game Over!");
                        string name = Interaction.InputBox("Enter a Name to save your score on the Scoreboard.", "Enter Player Name", "Player 1", -1, -1);
                        if (name == "")
                        {
                            name = "Guest";
                        }
                        lbScoreNames.Items.Add(name);
                        lbScore.Items.Add(Pman.getScore().ToString());
                        SortScoreboard();
                        btnPause.Enabled = false;
                        btnStart.Enabled = false;
                        btnReset.Enabled = true;
                        return;
                    }

                }
            }
            else if (Pman.getpX() == Ghost3.getpX() && Pman.getpY() == Ghost3.getpY())
            {
                if (Pman.IsEnergized == true && Ghost3.IsVulnerable == true)
                {
                    Ghost3.setpX(15);
                    Ghost3.setpY(14);
                    Ghost3.ChangeDirection(Map, 0);
                    Ghost3.IsVulnerable = false;
                    ghostGraceTimer.Start();
                    Pman.addScore(200);
                    lblScore.Text = (Pman.getScore()).ToString();
                    return;
                }
                else
                {
                    gameTimer.Stop();
                    ghost1Timer.Stop();
                    ghost2Timer.Stop();
                    ghost3Timer.Stop();
                    ghost4Timer.Stop();
                    ghostWaitTimer.Stop();

                    if (Pman.getLives() > 0)
                    {
                        Pman.setDirection(-1);
                        Pman.setpX(14);
                        Pman.setpY(23);
                        Ghost1.setpX(14);
                        Ghost1.setpY(13);
                        Ghost1.ChangeDirection(Map, 2);
                        Ghost2.setpX(14);
                        Ghost2.setpY(14);
                        Ghost2.ChangeDirection(Map, 2);
                        Ghost3.setpX(15);
                        Ghost3.setpY(14);
                        Ghost3.ChangeDirection(Map, 0);
                        Ghost4.setpX(13);
                        Ghost4.setpY(14);
                        Ghost4.ChangeDirection(Map, 1);
                        pictureBox1.Invalidate();
                        btnStart.Text = "Continue";
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        btnImport.Enabled = false;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Game Over!");
                        string name = Interaction.InputBox("Enter a Name to save your score on the Scoreboard.", "Enter Player Name", "Player 1", -1, -1);
                        if (name == "")
                        {
                            name = "Guest";
                        }
                        lbScoreNames.Items.Add(name);
                        lbScore.Items.Add(Pman.getScore().ToString());
                        SortScoreboard();
                        btnPause.Enabled = false;
                        btnStart.Enabled = false;
                        btnReset.Enabled = true;
                        return;
                    }

                }
            }
            else if (Pman.getpX() == Ghost4.getpX() && Pman.getpY() == Ghost4.getpY())
            {
                if (Pman.IsEnergized == true && Ghost4.IsVulnerable == true)
                {
                    Ghost4.setpX(13);
                    Ghost4.setpY(14);
                    Ghost4.ChangeDirection(Map, 1);
                    Ghost4.IsVulnerable = false;
                    ghostGraceTimer.Start();
                    Pman.addScore(200);
                    lblScore.Text = (Pman.getScore()).ToString();
                    return;
                }
                else
                {
                    gameTimer.Stop();
                    ghost1Timer.Stop();
                    ghost2Timer.Stop();
                    ghost3Timer.Stop();
                    ghost4Timer.Stop();
                    ghostWaitTimer.Stop();

                    if (Pman.getLives() > 0)
                    {
                        Pman.setDirection(-1);
                        Pman.setpX(14);
                        Pman.setpY(23);
                        Ghost1.setpX(14);
                        Ghost1.setpY(13);
                        Ghost1.ChangeDirection(Map, 2);
                        Ghost2.setpX(14);
                        Ghost2.setpY(14);
                        Ghost2.ChangeDirection(Map, 2);
                        Ghost3.setpX(15);
                        Ghost3.setpY(14);
                        Ghost3.ChangeDirection(Map, 0);
                        Ghost4.setpX(13);
                        Ghost4.setpY(14);
                        Ghost4.ChangeDirection(Map, 1);
                        pictureBox1.Invalidate();
                        btnStart.Text = "Continue";
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        btnImport.Enabled = false;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Game Over!");
                        string name = Interaction.InputBox("Enter a Name to save your score on the Scoreboard.", "Enter Player Name", "Player 1", -1, -1);
                        if (name == "")
                        {
                            name = "Guest";
                        }
                        lbScoreNames.Items.Add(name);
                        lbScore.Items.Add(Pman.getScore().ToString());
                        SortScoreboard();
                        btnPause.Enabled = false;
                        btnStart.Enabled = false;
                        btnReset.Enabled = true;
                        return;
                    }

                }
            }

            if (btnStart.Enabled == false)
            {
                ghost1Timer.Start();
            }

            //Ends game when win conditions are met
            if (Pman.GameWin(Map) == true)
            {
                gameTimer.Stop();
                ghost1Timer.Stop();
                ghost2Timer.Stop();
                ghost3Timer.Stop();
                ghost4Timer.Stop();
                ghostWaitTimer.Stop();
                btnPause.Enabled = false;
                btnStart.Enabled = false;
                btnReset.Enabled = true;

                MessageBox.Show("Congratulations! Click 'OK' to begin the next round!");

                //Map is regenerated to allow player to continue playing
                InitializeMap();
                pbReady.Show();
                pbReady.BringToFront();
                Pman.setDirection(-1);
                Pman.setpX(14);
                Pman.setpY(23);
                pictureBox1.Invalidate();
                btnStart.Text = "Continue";
                btnStart.Enabled = true;
                btnPause.Enabled = false;
                btnReset.Enabled = false;
                btnSave.Enabled = false;
                btnImport.Enabled = false;
                lblScore.Text = Pman.Score.ToString();

                //Restores ghost positions to their spawns
                Ghost1.setpX(14);
                Ghost1.setpY(13);
                Ghost1.ChangeDirection(Map, 2);
                Ghost2.setpX(14);
                Ghost2.setpY(14);
                Ghost2.ChangeDirection(Map, 2);
                Ghost3.setpX(15);
                Ghost3.setpY(14);
                Ghost3.ChangeDirection(Map, 0);
                Ghost4.setpX(13);
                Ghost4.setpY(14);
                Ghost4.ChangeDirection(Map, 1);
            }

            //Shows and hides graphics representing number of Pacman lives leftover
            if (Pman.getLives() == 3)
            {
                pbLife1.Show();
                pbLife2.Show();
                pbLife3.Show();
            }
            else if (Pman.getLives() == 2)
            {
                pbLife1.Show();
                pbLife2.Show();
                pbLife3.Hide();
            }
            else if (Pman.getLives() == 1)
            {
                pbLife1.Show();
                pbLife2.Hide();
                pbLife3.Hide();
            }
            else if (Pman.getLives() <= 0)
            {
                pbLife1.Hide();
                pbLife2.Hide();
                pbLife3.Hide();
            }
        }

        //Method that sorts the scoreboard based on players' scores in descending order
        private void SortScoreboard()
        {
            int[] scores = new int[lbScore.Items.Count];
            string[] names = new string[lbScoreNames.Items.Count];

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = Convert.ToInt32(lbScore.Items[i]);
            }

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = lbScoreNames.Items[i].ToString();
            }

            Array.Sort(scores, names);
            Array.Reverse(scores);
            Array.Reverse(names);

            lbScore.Items.Clear();
            lbScoreNames.Items.Clear();

            foreach (int score in scores)
            {
                lbScore.Items.Add(score);
            }

            foreach (string name in names)
            {
                lbScoreNames.Items.Add(name);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Map[Ghost1.getpX(), Ghost1.getpY()] == Map[14, 13])
            {
                //One life is 'used' to play
                Pman.Lives = Pman.Lives - 1;
            }

            Pman.ChangeDirection(Map, -1);
            pbReady.Hide();
            gameTimer.Start();

            //Resumes ghost activity if game is paused
            if (Map[Ghost1.getpX(), Ghost1.getpY()] != Map[14, 13])
            {
                ghost1Timer.Start();
            }
            if (Map[Ghost2.getpX(), Ghost2.getpY()] != Map[14, 14])
            {
                ghost2Timer.Start();
            }
            if (Map[Ghost3.getpX(), Ghost3.getpY()] != Map[15, 14])
            {
                ghost3Timer.Start();
            }
            if (Map[Ghost4.getpX(), Ghost4.getpY()] != Map[13, 14])
            {
                ghost4Timer.Start();
            }
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnReset.Enabled = false;
            btnSave.Enabled = false;
            btnImport.Enabled = false;
        }

        private void ReadyTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void energizedTimer_Tick(object sender, EventArgs e)
        {
            //5 second timer for Pacman's energized period
            Pman.IsEnergized = false;
            Ghost1.IsVulnerable = false;
            Ghost2.IsVulnerable = false;
            Ghost3.IsVulnerable = false;
            Ghost4.IsVulnerable = false;
            energizedTimer.Stop();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
            energizedTimer.Stop();
            ghostWaitTimer.Stop();
            ghost1Timer.Stop();
            ghost2Timer.Stop();
            ghost3Timer.Stop();
            ghost4Timer.Stop();
            btnStart.Text = "Resume";
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnReset.Enabled = true;
            btnSave.Enabled = false;
            btnImport.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Regenerates map and resets game
            InitializeMap();
            pbReady.BringToFront();
            pbReady.Show();
            Pman.setDirection(-1);
            Pman.setpX(14);
            Pman.setpY(23);
            pictureBox1.Invalidate();
            btnStart.Text = "Start";
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnReset.Enabled = false;
            btnSave.Enabled = true;
            btnImport.Enabled = true;
            Pman.setScore(0);
            Pman.setLives(3);
            lblScore.Text = Pman.Score.ToString();

            //Restores ghost initial positions
            Ghost1.setpX(14);
            Ghost1.setpY(13);
            Ghost1.ChangeDirection(Map, 2);
            Ghost2.setpX(14);
            Ghost2.setpY(14);
            Ghost2.ChangeDirection(Map, 2);
            Ghost3.setpX(15);
            Ghost3.setpY(14);
            Ghost3.ChangeDirection(Map, 0);
            Ghost4.setpX(13);
            Ghost4.setpY(14);
            Ghost4.ChangeDirection(Map, 1);

            pbLife1.Show();
            pbLife2.Show();
            pbLife3.Show();
        }

        //Timer spacing out when ghosts begin their activities
        private void ghostWaitTimer_Tick(object sender, EventArgs e)
        {
            ghostWaitTimer.Stop();

            if (ghost2Timer.Enabled == false)
            {
                ghost2Timer.Start();
            }
            else if (ghost3Timer.Enabled == false)
            {
                ghost3Timer.Start();
            }
            else if (ghost4Timer.Enabled == false)
            {
                ghost4Timer.Start();
            }
        }

        private void ghost2Timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            Ghost2.Move(Map);
            pictureBox1.Invalidate();

            //Tests for collisions between Pacman and ghosts
            if (Pman.getpX() == Ghost2.getpX() && Pman.getpY() == Ghost2.getpY())
            {
                //When Pacman is energized, ghost is eaten
                if (Pman.IsEnergized == true && Ghost2.IsVulnerable == true)
                {
                    Ghost2.setpX(14);
                    Ghost2.setpY(14);
                    Ghost2.ChangeDirection(Map, 2);
                    Ghost2.IsVulnerable = false;
                    ghostGraceTimer.Start();
                    Pman.addScore(200);
                    lblScore.Text = (Pman.getScore()).ToString();
                    return;
                }
                //When Pacman is not energized, Pacman loses a life
                else
                {
                    gameTimer.Stop();
                    ghost1Timer.Stop();
                    ghost2Timer.Stop();
                    ghost3Timer.Stop();
                    ghost4Timer.Stop();
                    ghostWaitTimer.Stop();

                    //Tests if Pacman still has lives; if he does, game continues
                    if (Pman.getLives() > 0)
                    {
                        Pman.setDirection(-1);
                        Pman.setpX(14);
                        Pman.setpY(23);
                        Ghost1.setpX(14);
                        Ghost1.setpY(13);
                        Ghost1.ChangeDirection(Map, 2);
                        Ghost2.setpX(14);
                        Ghost2.setpY(14);
                        Ghost2.ChangeDirection(Map, 2);
                        Ghost3.setpX(15);
                        Ghost3.setpY(14);
                        Ghost3.ChangeDirection(Map, 0);
                        Ghost4.setpX(13);
                        Ghost4.setpY(14);
                        Ghost4.ChangeDirection(Map, 1);
                        pictureBox1.Invalidate();
                        btnStart.Text = "Continue";
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        btnImport.Enabled = false;
                        return;
                    }
                    //Pacman has no more lives, game is over
                    else
                    {
                        MessageBox.Show("Game Over!");
                        string name = Interaction.InputBox("Enter a Name to save your score on the Scoreboard.", "Enter Player Name", "Player 1", -1, -1);
                        if (name == "")
                        {
                            name = "Guest";
                        }
                        lbScoreNames.Items.Add(name);
                        lbScore.Items.Add(Pman.getScore().ToString());
                        SortScoreboard();
                        btnPause.Enabled = false;
                        btnStart.Enabled = false;
                        btnReset.Enabled = true;
                        return;
                    }
                }
            }

            //Random direction is chosen based on valid directions
            if (Map[Ghost2.getpX(), Ghost2.getpY()] == 4 || Map[Ghost2.getpX(), Ghost2.getpY()] == -4)
            {
                IEnumerable<int> iDirection = Ghost2.ValidDirections(Map).OrderBy(x => random.Next());
                Ghost2.ChangeDirection(Map, iDirection.First());
            }

            ghostWaitTimer.Start();
        }

        private void ghost3Timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            Ghost3.Move(Map);
            pictureBox1.Invalidate();

            //Tests for collisions between Pacman and ghosts
            if (Pman.getpX() == Ghost3.getpX() && Pman.getpY() == Ghost3.getpY())
            {
                //When Pacman is energized, ghost is eaten
                if (Pman.IsEnergized == true && Ghost3.IsVulnerable == true)
                {
                    Ghost3.setpX(15);
                    Ghost3.setpY(14);
                    Ghost3.ChangeDirection(Map, 0);
                    Ghost3.IsVulnerable = false;
                    ghostGraceTimer.Start();
                    Pman.addScore(200);
                    lblScore.Text = (Pman.getScore()).ToString();
                    return;
                }
                //When Pacman is not energized, Pacman loses a life
                else
                {
                    gameTimer.Stop();
                    ghost1Timer.Stop();
                    ghost2Timer.Stop();
                    ghost3Timer.Stop();
                    ghost4Timer.Stop();
                    ghostWaitTimer.Stop();

                    //Tests if Pacman still has lives; if he does, game continues
                    if (Pman.getLives() > 0)
                    {
                        Pman.setDirection(-1);
                        Pman.setpX(14);
                        Pman.setpY(23);
                        Ghost1.setpX(14);
                        Ghost1.setpY(13);
                        Ghost1.ChangeDirection(Map, 2);
                        Ghost2.setpX(14);
                        Ghost2.setpY(14);
                        Ghost2.ChangeDirection(Map, 2);
                        Ghost3.setpX(15);
                        Ghost3.setpY(14);
                        Ghost3.ChangeDirection(Map, 0);
                        Ghost4.setpX(13);
                        Ghost4.setpY(14);
                        Ghost4.ChangeDirection(Map, 1);
                        pictureBox1.Invalidate();
                        btnStart.Text = "Continue";
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        btnImport.Enabled = false;
                        return;
                    }
                    //Pacman has no more lives, game is over
                    else
                    {
                        MessageBox.Show("Game Over!");
                        string name = Interaction.InputBox("Enter a Name to save your score on the Scoreboard.", "Enter Player Name", "Player 1", -1, -1);
                        if (name == "")
                        {
                            name = "Guest";
                        }
                        lbScoreNames.Items.Add(name);
                        lbScore.Items.Add(Pman.getScore().ToString());
                        SortScoreboard();
                        btnPause.Enabled = false;
                        btnStart.Enabled = false;
                        btnReset.Enabled = true;
                        return;
                    }

                }
            }

            if (Map[Ghost3.getpX(), Ghost3.getpY()] == Map[14, 14])
            {
                Ghost3.ChangeDirection(Map, 2);
            }

            if (Map[Ghost3.getpX(), Ghost3.getpY()] == 4 || Map[Ghost3.getpX(), Ghost3.getpY()] == -4)
            {
                IEnumerable<int> iDirection = Ghost3.ValidDirections(Map).OrderBy(x => random.Next());
                Ghost3.ChangeDirection(Map, iDirection.First());
            }

            ghostWaitTimer.Start();
        }

        private void ghost4Timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            Ghost4.Move(Map);
            pictureBox1.Invalidate();

            //Tests for collisions between Pacman and ghosts
            if (Pman.getpX() == Ghost4.getpX() && Pman.getpY() == Ghost4.getpY())
            {
                //When Pacman is energized, ghost is eaten
                if (Pman.IsEnergized == true && Ghost4.IsVulnerable == true)
                {
                    Ghost4.setpX(13);
                    Ghost4.setpY(14);
                    Ghost4.ChangeDirection(Map, 1);
                    Ghost4.IsVulnerable = false;
                    ghostGraceTimer.Start();
                    Pman.addScore(200);
                    lblScore.Text = (Pman.getScore()).ToString();
                    return;
                }
                //When Pacman is not energized, Pacman loses a life
                else
                {
                    gameTimer.Stop();
                    ghost1Timer.Stop();
                    ghost2Timer.Stop();
                    ghost3Timer.Stop();
                    ghost4Timer.Stop();
                    ghostWaitTimer.Stop();

                    //Tests if Pacman still has lives; if he does, game continues
                    if (Pman.getLives() > 0)
                    {
                        Pman.setDirection(-1);
                        Pman.setpX(14);
                        Pman.setpY(23);
                        Ghost1.setpX(14);
                        Ghost1.setpY(13);
                        Ghost1.ChangeDirection(Map, 2);
                        Ghost2.setpX(14);
                        Ghost2.setpY(14);
                        Ghost2.ChangeDirection(Map, 2);
                        Ghost3.setpX(15);
                        Ghost3.setpY(14);
                        Ghost3.ChangeDirection(Map, 0);
                        Ghost4.setpX(13);
                        Ghost4.setpY(14);
                        Ghost4.ChangeDirection(Map, 1);
                        pictureBox1.Invalidate();
                        btnStart.Text = "Continue";
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        btnImport.Enabled = false;
                        return;
                    }
                    //Pacman has no more lives, game is over
                    else
                    {
                        MessageBox.Show("Game Over!");
                        string name = Interaction.InputBox("Enter a Name to save your score on the Scoreboard.", "Enter Player Name", "Player 1", -1, -1);
                        if (name == "")
                        {
                            name = "Guest";
                        }
                        lbScoreNames.Items.Add(name);
                        lbScore.Items.Add(Pman.getScore().ToString());
                        SortScoreboard();
                        btnPause.Enabled = false;
                        btnStart.Enabled = false;
                        btnReset.Enabled = true;
                        return;
                    }
                }
            }

            if (Map[Ghost4.getpX(), Ghost4.getpY()] == Map[14, 14])
            {
                Ghost4.ChangeDirection(Map, 2);
            }

            if (Map[Ghost4.getpX(), Ghost4.getpY()] == 4 || Map[Ghost4.getpX(), Ghost4.getpY()] == -4)
            {
                IEnumerable<int> iDirection = Ghost4.ValidDirections(Map).OrderBy(x => random.Next());
                Ghost4.ChangeDirection(Map, iDirection.First());
            }
        }

        //Timer that symbolizes a grace period for the ghost, allowing them not to be eaten immediately after they respawn
        private void ghostGraceTimer_Tick(object sender, EventArgs e)
        {
            ghostGraceTimer.Stop();
        }

        private void ghost1Timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            Ghost1.Move(Map);
            pictureBox1.Invalidate();

            //Tests for collisions between Pacman and ghosts
            if (Pman.getpX() == Ghost1.getpX() && Pman.getpY() == Ghost1.getpY())
            {
                //When Pacman is energized, ghost is eaten
                if (Pman.IsEnergized == true && Ghost1.IsVulnerable == true)
                {
                    Ghost1.setpX(14);
                    Ghost1.setpY(13);
                    Ghost1.ChangeDirection(Map, 2);
                    Ghost1.IsVulnerable = false;
                    ghostGraceTimer.Start();
                    Pman.addScore(200);
                    lblScore.Text = (Pman.getScore()).ToString();
                    return;
                }
                //When Pacman is not energized, Pacman loses a life
                else
                {
                    gameTimer.Stop();
                    ghost1Timer.Stop();
                    ghost2Timer.Stop();
                    ghost3Timer.Stop();
                    ghost4Timer.Stop();
                    ghostWaitTimer.Stop();

                    //Tests if Pacman still has lives; if he does, game continues
                    if (Pman.getLives() > 0)
                    {
                        Pman.setDirection(-1);
                        Pman.setpX(14);
                        Pman.setpY(23);
                        Ghost1.setpX(14);
                        Ghost1.setpY(13);
                        Ghost1.ChangeDirection(Map, 2);
                        Ghost2.setpX(14);
                        Ghost2.setpY(14);
                        Ghost2.ChangeDirection(Map, 2);
                        Ghost3.setpX(15);
                        Ghost3.setpY(14);
                        Ghost3.ChangeDirection(Map, 0);
                        Ghost4.setpX(13);
                        Ghost4.setpY(14);
                        Ghost4.ChangeDirection(Map, 1);
                        pictureBox1.Invalidate();
                        btnStart.Text = "Continue";
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        btnImport.Enabled = false;
                        return;
                    }
                    //Pacman has no more lives, game is over
                    else
                    {
                        MessageBox.Show("Game Over!");
                        string name = Interaction.InputBox("Enter a Name to save your score on the Scoreboard.", "Enter Player Name", "Player 1", -1, -1);
                        if (name == "")
                        {
                            name = "Guest";
                        }
                        lbScoreNames.Items.Add(name);
                        lbScore.Items.Add(Pman.getScore().ToString());
                        SortScoreboard();
                        btnPause.Enabled = false;
                        btnStart.Enabled = false;
                        btnReset.Enabled = true;
                        return;
                    }
                }
            }

            if (Map[Ghost1.getpX(), Ghost1.getpY()] == 4 || Map[Ghost1.getpX(), Ghost1.getpY()] == -4)
            {
                IEnumerable<int> iDirection = Ghost1.ValidDirections(Map).OrderBy(x => random.Next());
                Ghost1.ChangeDirection(Map, iDirection.First());
            }

            ghostWaitTimer.Start();
        }

        //Saves current scoreboard (both player names and their respective scores) into a text file.
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Notifies user is current scoreboard is empty
                if (lbScore.Items.Count == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Highscores are currently empty. Would you still like to continue with the save?", "Empty Scores", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }

                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();       //Declares a new savefile dialog
                saveFileDialog.Title = "Save as a Text Document";           //Sets the title of the dialog
                saveFileDialog.FileName = "Highscores.txt";                 //Default file name if user chooses not to insert a new name
                saveFileDialog.Filter = "Text Documents|*.txt";             //Limits selection of file types

                if (saveFileDialog.ShowDialog() == DialogResult.OK)         //If user clicks 'save'
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        for (int i = 0; i < lbScoreNames.Items.Count; i++)
                        {
                            sw.Write(lbScoreNames.Items[i] + "~");
                            sw.WriteLine(lbScore.Items[i]);
                        }

                        sw.Flush();
                        sw.Close();
                    }
                    MessageBox.Show("Highscores successfully saved to " + "'" + saveFileDialog.FileName + "'.");
                }
            }
            catch
            {
                MessageBox.Show("Oops, something went wrong. Please try again.");
            }
        }

        //Imports saved scoreboard files
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string strInput;
                string[] splittedInput;

                OpenFileDialog openFileDialog = new OpenFileDialog();           //Declares openfile dialog
                openFileDialog.Title = "Open a Text Document";                  //Sets dialog title
                openFileDialog.Filter = "Text Documents|*.txt";                 //Limits the file types a user can open

                if (openFileDialog.ShowDialog() == DialogResult.OK)             //If user clicks 'open'
                {
                    //Notifies user if selected file is empty
                    if (new FileInfo(openFileDialog.FileName).Length == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("The selected text file is empty. Would you still like to open it?", "Empty Text File Found", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MessageBox.Show("Empty Scoreboard Successfully Opened!");
                            return;
                        }
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    //Initiates reader
                    StreamReader sr = new StreamReader(openFileDialog.FileName);

                    //Inserts data from the text file into the program until the end of the file
                    while ((strInput = sr.ReadLine()) != null)
                    {
                        splittedInput = strInput.Split('~');
                        lbScoreNames.Items.Add(splittedInput[0]);
                        lbScore.Items.Add(splittedInput[1]);
                    }

                    sr.Close();


                    MessageBox.Show("Scoreboard Successfully Imported!");
                    btnSave.Enabled = true;
                    btnImport.Enabled = true;

                }

            }

            catch
            {
                MessageBox.Show("Oops, something went wrong. Your file may be corrupt or unreadable.");
            }
        }
    }
}

