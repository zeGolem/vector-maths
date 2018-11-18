using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class VectorLine
    {

        public static PointOnGrid Point1, Point2;

        public VectorLine(PointOnGrid p1, PointOnGrid p2)
        {
            Point1 = p1;
            Point2 = p2;
        }

        public PointOnGrid[] GetPoints()
        {
            PointOnGrid[] points = { Point1, Point2 };
            return points;
        }

        public void Draw()
        {
            Camera.DrawLine(Point1.X, Point1.Y, Point2.X, Point2.Y, Color.Chocolate, 3);
        }
        
    }
}
