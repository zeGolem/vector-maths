using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Vector
{
    class Camera
    {
        public static Grid displayedGrid;
        public static SpriteBatch defaultSB;
        public static int X = 0, Y = 0;
        public static SpriteFont defaultFont;
        public static Gui GameGui = new Gui();

        public static void SetSpriteBatch(SpriteBatch spriteBatch)
        {
            defaultSB = spriteBatch;
        }

        public static void Draw(SpriteBatch sb)
        {
            displayedGrid.Draw(sb);
            foreach (PointOnGrid p in displayedGrid.GetPoints())
            {
                if (p != null)
                {

                    p.Draw();
                }

            }
            GameGui.Draw();
            
        }

        public static void DrawPoint(float x, float y, Color color, float size=1)
        {
            Point2 p = FromGridToScreen((int)x * displayedGrid.scale, (int)y * displayedGrid.scale);
            defaultSB.DrawPoint(p, color, size);
        }
        public static void DrawLine(float x1, float y1, float x2, float y2, Color color, float size = 1)
        {
            Point2 p1 = FromGridToScreen((int)x1 * displayedGrid.scale, (int)y1 * displayedGrid.scale);
            Point2 p2 = FromGridToScreen((int)x2 * displayedGrid.scale, (int)y2 * displayedGrid.scale);
            defaultSB.DrawLine(p1, p2, color, size);
        }

        public static void DrawText(string text, float x, float y, Color color)
        {
            Point2 position = FromGridToScreen((int)x * displayedGrid.scale, (int)y * displayedGrid.scale);
            defaultSB.DrawString(defaultFont, text, position, color);
        }
        //Helper functions

        public static Point2 FromScreenToGrid(int x, int y)
        {
            Point2 positionOnTheGrid = new Point2(x, y);
            positionOnTheGrid.X += X;
            positionOnTheGrid.Y -= Y;
            return positionOnTheGrid;
        }
        public static Point2 FromGridToScreen(int x, int y)
        {
            Point2 pointPositionOnScreen = new Point2(x, y);
            pointPositionOnScreen.X -= X;
            pointPositionOnScreen.Y += Y;
            return pointPositionOnScreen;
            
        }
        public static Point2 ScaleToGrid(float x, float y)
        {
            return new Point2(x / displayedGrid.scale, y / displayedGrid.scale);
        }
        public static Point2 ScaleToGrid(Point2 point)
        {
            return new Point2(point.X / displayedGrid.scale, point.Y / displayedGrid.scale);
        }

        public static Point2 ScaleFromGrid(float x, float y)
        {
            return new Point2(x * displayedGrid.scale, y * displayedGrid.scale);
        }
        public static Point2 ScaleFromGrid(Point2 point)
        {
            return new Point2(point.X * displayedGrid.scale, point.Y * displayedGrid.scale);
        }
    }
}

