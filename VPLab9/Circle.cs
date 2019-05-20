using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace VPLab9
{
    [Serializable]
    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public int Radius { get; set; }

        public Circle(int X , int Y, Color color , int Radius)
        {
            this.X = X;
            this.Y = Y;
            this.Color = color;
            this.Radius = Radius;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();

        }

    }
}
