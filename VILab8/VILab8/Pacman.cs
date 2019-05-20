using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VILab8
{
    enum DIRECTION
    {
        Up,
        Down,
        Left,
        Right
    }

    class Pacman
    {
        public int positionX;
        public int prev_positionX;
        public int prev_positionY;
        public int positionY;
        public DIRECTION direction;
        public int radius = 20;
        public int speed;
        public bool mouthOpen;
        public SolidBrush color;

        public Pacman()
        {
            this.speed = this.radius;
            this.positionX = 7;
            this.positionY = 5;
            this.direction = DIRECTION.Right;
            color = new SolidBrush(Color.Yellow);
            mouthOpen = true;
        }

        public void ChangeDirection(DIRECTION direction1)
        {
            this.direction = direction1;
        }

        public void Move(bool[][] obstacles)
        {
            prev_positionX = positionX;
            prev_positionY = positionY;
            if (mouthOpen) mouthOpen = false;
            else mouthOpen = true;
            

            if (direction == DIRECTION.Left)
            {
                if (positionX > 0)
                {
                    positionX--;
                }
                else
                {
                    positionX = 14;
                }
            }
            else if (direction == DIRECTION.Right)
            {
                if (positionX < 14)
                {
                    positionX++;
                }
                else
                {
                    positionX = 0;
                }
            }
            else if (direction == DIRECTION.Up)
            {
                if (positionY > 1)
                {
                    positionY--;
                }
                else
                {
                    positionY = 10;
                }
            }
            else if(direction == DIRECTION.Down)
            {
                if (positionY < 10)
                {
                    positionY++;
                }
                else
                {
                    positionY = 1;
                }
            }
            if (obstacles[positionY][positionX])
            {
                positionX = prev_positionX;
                positionY = prev_positionY;
            }

        }

        public void Draw(Graphics g)
        {
            if (direction == DIRECTION.Right)
            {
                if (mouthOpen)
                    g.FillPie(color, positionX * radius * 2 + 15, positionY * radius * 2 + 12, radius, radius, 30, 310);
                else
                    g.FillPie(color, positionX * radius * 2 + 15, positionY * radius * 2 + 12, radius, radius, 0, 360);
            }
            else if (direction == DIRECTION.Left)
            {
                if (mouthOpen)
                    g.FillPie(color, positionX * radius * 2 + 15, positionY * radius * 2 + 12, radius, radius, 210, 310);
                else
                    g.FillPie(color, positionX * radius * 2 + 15, positionY * radius * 2 + 12, radius, radius, 0, 360);
            }
            else if (direction == DIRECTION.Up)
            {
                if (mouthOpen)
                    g.FillPie(color, positionX * radius * 2 + 15, positionY * radius * 2 + 12, radius, radius, 300, 310);
                else
                    g.FillPie(color, positionX * radius * 2 + 15, positionY * radius * 2 + 12, radius, radius, 0, 360);
            }
            else if (direction == DIRECTION.Down)
            {
                if (mouthOpen)
                    g.FillPie(color, positionX * radius * 2 + 15, positionY * radius * 2 + 12, radius, radius, 120, 310);
                else
                    g.FillPie(color, positionX * radius * 2 + 15, positionY * radius * 2 + 12, radius, radius, 0, 360);
            }
        }

    }


}
