using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.Shapes;
using MonoGame.Extended;
using Microsoft.Xna.Framework;

namespace Vector
{
    class Grid
    {
        public int X, Y, Width, Height;
        public int scale;
        public PointOnGrid[] points = new PointOnGrid[1024];
        public VectorLine[] vectors = new VectorLine[1024];
        int pointID = 0;
        char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        int vectorID = 0;
        bool firstPoint = true;
        bool firstVector = true;
        public Origin origin;
        public Grid(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            scale = 10;
            pointID = 0;

            origin = new Origin(0, 0);
        }

        public PointOnGrid CreatePoint(int x, int y)
        {

            PointOnGrid point = new PointOnGrid(SnapPointOnGrid(x, y), alphabet[pointID].ToString());
            return point;
        }

        public Point2 SnapPointOnGrid(int x, int y)
        {
            Point2 pointPosition = new Point2(x, y);
            pointPosition = Camera.FromScreenToGrid((int)pointPosition.X, (int)pointPosition.Y);
            pointPosition.X = (int)(pointPosition.X / scale);
            pointPosition.Y = (int)(pointPosition.Y / scale);
            return pointPosition;
        }

        public void CreateVectorBetween(char firstLetter, char secondLetter)
        {
            Console.WriteLine("{0} {1}", firstLetter, secondLetter);
            PointOnGrid p1 = null;
            PointOnGrid p2 = null;
            foreach(PointOnGrid p in points)
            {
                if (p != null)
                {
                    if (p.Name.ToLower()[0] == firstLetter)
                        p1 = p;
                    if (p.Name.ToLower()[0] == secondLetter)
                        p2 = p;
                }
            }
            if(p1!=null && p2 != null)
            {
                RegisterVector(new VectorLine(p1, p2));
            }
        }

        public Point2 SnapPointOnGrid(Point2 pointPosition)
        {
            pointPosition = Camera.FromScreenToGrid((int)pointPosition.X, (int)pointPosition.Y);
            pointPosition.X = (int)(pointPosition.X / scale);
            pointPosition.Y = (int)(pointPosition.Y / scale);
            return pointPosition;
        }

        public void RegisterPoint(PointOnGrid p)
        {
            bool shouldAddPoint = true;
            foreach (PointOnGrid oP in points)
            {
                if (firstPoint)
                {

                    points[pointID] = p;
                    pointID++;
                    firstPoint = false;
                    shouldAddPoint = false;
                }
                else if (oP != null)
                {
                    for(int i = 0; i < pointID; i++)
                    {
                        if(points[i].X == p.X && points[i].Y == p.Y)
                        {
                            shouldAddPoint = false;
                            break;
                        }
                        
                    }

                    
                }
            }

            if (shouldAddPoint)
            {

                    points[pointID] = p;
                    pointID++;
               
            }

            Console.WriteLine(pointID);
            if (pointID == 2)
            {
                RegisterVector(new VectorLine(points[0], points[1]));
            }
            

        }

        public void RegisterVector(VectorLine vector)
        {
            firstVector = false;

            vectors[vectorID] = vector;
            vectorID++;
        }

        public Point2 PlaceOnGrid(Point2 point)
        {
            point.X *= scale;
            point.Y *= scale;
            point = SnapPointOnGrid(point);
            return point;
        }

        public PointOnGrid[] GetPoints()
        {
            return points;
        }
        public void Draw(SpriteBatch sb)
        {
            for(int x = 0; x<Width; x+=scale)
            {
                sb.DrawLine(Camera.FromGridToScreen(x, 0), Camera.FromGridToScreen(x, Height), Color.Gray);
            }
            for (int y = 0; y < Height; y+=scale)
            {
                sb.DrawLine(Camera.FromGridToScreen(0, y), Camera.FromGridToScreen(Width, y), Color.Gray);

            }
            foreach(VectorLine vl in vectors)
            {
                vl?.Draw();
            }
        }
    }
}
