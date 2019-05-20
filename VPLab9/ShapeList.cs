using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VPLab9
{
    [Serializable]
    public class ShapeList
    {
        public List<Circle> Circles;
        public const int RADIUS = 25;

        public ShapeList()
        {
            Circles = new List<Circle>();
        }
        public void AddShape(int x, int y, Color color)
        {
            Circle s = null;
            s = new Circle(x, y, color, RADIUS);
            Circles.Add(s);
        }

        public void Draw(Graphics g)
        {
            foreach (Circle s in Circles)
            {
                s.Draw(g);
            }
        }
    }
}
