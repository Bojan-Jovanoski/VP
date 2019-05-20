using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VILab8.Properties;

namespace VILab8
{
    public partial class Form1 : Form
    {
        Pacman pacman;
        static readonly int TIMER_INTERVAL = 250;
        static readonly int WORLD_WIDTH = 15;
        static readonly int WORLD_HEIGHT = 11;
        Image foodImage;
        bool[][] foodWorld;
        int poeni;
        bool[][] obstacles;

        public Form1()
        {
            InitializeComponent();
            foodImage = Resources.orange_icon;
            DoubleBuffered = true;
            newGame();
        }

        public void newGame()
        {
            pacman = new Pacman();
            this.Width = pacman.radius * 2 * (WORLD_WIDTH + 1);
            this.Height = pacman.radius * 2 * (WORLD_HEIGHT + 1);
            foodWorld = new bool[11][];
            
            for (int i = 0; i < foodWorld.Length; i++)
            {
                foodWorld[i] = new bool[15];
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    foodWorld[i][j] = true;
                }
            }

            //иницијализација на матрицата obstacles
            this.obstacles = new bool[WORLD_HEIGHT][];

            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i] = new bool[WORLD_WIDTH];
                for (int j = 0; j < obstacles[i].Length; j++)
                {
                    obstacles[i][j] = false;
                }
            }
            poeni = 0;
            timer1.Interval = TIMER_INTERVAL;
            timer1.Enabled = true;

            InitializeObsticles();


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            for (int i = 1; i < foodWorld.Length; i++)
            {
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    if (foodWorld[i][j])
                    {
                        g.DrawImageUnscaled(foodImage, j * pacman.radius * 2 + (pacman.radius * 2 - foodImage.Height) / 2, i * pacman.radius * 2 + (pacman.radius * 2 - foodImage.Width) / 2);
                    }
                }
            }
            pacman.Draw(g);
            Pen pen = new Pen(Color.DarkBlue, 3);
            g.DrawRectangle(pen, new Rectangle(new Point(1 * pacman.radius * 2, 2 * pacman.radius * 2), new Size(1 * pacman.radius * 2, 3 * pacman.radius * 2)));
            g.DrawRectangle(pen, new Rectangle(new Point(1 * pacman.radius * 2, 8 * pacman.radius * 2), new Size(1 * pacman.radius * 2, 3 * pacman.radius * 2)));
            g.DrawRectangle(pen, new Rectangle(new Point(3 * pacman.radius * 2, 5 * pacman.radius * 2), new Size(1 * pacman.radius * 2, 3 * pacman.radius * 2)));
            g.DrawRectangle(pen, new Rectangle(new Point(6 * pacman.radius * 2, 4 * pacman.radius * 2), new Size(1 * pacman.radius * 2, 3 * pacman.radius * 2)));
            g.DrawRectangle(pen, new Rectangle(new Point(8 * pacman.radius * 2, 1 * pacman.radius * 2), new Size(1 * pacman.radius * 2, 3 * pacman.radius * 2)));
            g.DrawRectangle(pen, new Rectangle(new Point(10 * pacman.radius * 2, 8 * pacman.radius * 2), new Size(1 * pacman.radius * 2, 3 * pacman.radius * 2)));
            g.DrawRectangle(pen, new Rectangle(new Point(11 * pacman.radius * 2, 3 * pacman.radius * 2), new Size(1 * pacman.radius * 2, 3 * pacman.radius * 2)));
            g.DrawRectangle(pen, new Rectangle(new Point(13 * pacman.radius * 2, 6 * pacman.radius * 2), new Size(1 * pacman.radius * 2, 3 * pacman.radius * 2)));
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                pacman.ChangeDirection(DIRECTION.Up);
            }
            else if (e.KeyCode == Keys.Down)
            {
                pacman.ChangeDirection(DIRECTION.Down);
            }
            else if (e.KeyCode == Keys.Left)
            {
                pacman.ChangeDirection(DIRECTION.Left);
            }
            else if (e.KeyCode == Keys.Right)
            {
                pacman.ChangeDirection(DIRECTION.Right);
            }

            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pacman.Move(obstacles);
            if (foodWorld[pacman.positionY][pacman.positionX])
            {
                foodWorld[pacman.positionY][pacman.positionX] = false;
                poeni++;
                progressBar1.Increment(1);
                textBox1.Text = poeni.ToString();

                if (poeni == 126)
                {

                    string message = "Do you want to start a new game?";
                    string title = "New Game";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        newGame();
                    }

                }
            }
            Invalidate();
        }
        public void InitializeObsticles()
        {
            //prva prepreka
            //obstacle 1
            obstacles[2][1] = true;
            obstacles[3][1] = true;
            obstacles[4][1] = true;

            foodWorld[2][1] = false;
            foodWorld[3][1] = false;
            foodWorld[4][1] = false;

            //obstacle 2
            obstacles[8][1] = true;
            obstacles[9][1] = true;
            obstacles[10][1] = true;

            foodWorld[8][1] = false;
            foodWorld[9][1] = false;
            foodWorld[10][1] = false;

            //obstacle 3
            obstacles[5][3] = true;
            obstacles[6][3] = true;
            obstacles[7][3] = true;

            foodWorld[5][3] = false;
            foodWorld[6][3] = false;
            foodWorld[7][3] = false;

            //obstacle 4
            obstacles[4][6] = true;
            obstacles[5][6] = true;
            obstacles[6][6] = true;

            foodWorld[4][6] = false;
            foodWorld[5][6] = false;
            foodWorld[6][6] = false;

            //obstacle 5
            obstacles[1][8] = true;
            obstacles[2][8] = true;
            obstacles[3][8] = true;

            foodWorld[1][8] = false;
            foodWorld[2][8] = false;
            foodWorld[3][8] = false;

            //obstacle 6
            obstacles[8][10] = true;
            obstacles[9][10] = true;
            obstacles[10][10] = true;

            foodWorld[8][10] = false;
            foodWorld[9][10] = false;
            foodWorld[10][10] = false;

            //obstacle 7
            obstacles[3][11] = true;
            obstacles[4][11] = true;
            obstacles[5][11] = true;

            foodWorld[3][11] = false;
            foodWorld[4][11] = false;
            foodWorld[5][11] = false;

            //obstacle 8
            obstacles[6][13] = true;
            obstacles[7][13] = true;
            obstacles[8][13] = true;

            foodWorld[6][13] = false;
            foodWorld[7][13] = false;
            foodWorld[8][13] = false;


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            /////////
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////////////////////////
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            ////////////////////////
        }
    }
}
