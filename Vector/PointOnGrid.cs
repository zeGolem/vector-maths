using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class PointOnGrid
    {
        public int X, Y;
        public string Name;
        public PointOnGrid(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }
        public PointOnGrid(Point2 position, string name)
        {
            X = (int)position.X;
            Y = (int)position.Y;
            Name = name;
        }

        public void Draw()
        {
            Camera.DrawPoint(X, Y, Color.Black, 5);
            Camera.DrawText(Name, X, Y, Color.Black);
        }
    }
}
