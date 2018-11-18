using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Gui
    {
        public string text;
        public Gui()
        {

        }
        public void Draw()
        {
            if (text != null)
            {
                Camera.defaultSB.DrawString(
                    Camera.defaultFont,
                    text,
                    new Point2(0, 0),
                    Color.Black);
            }
        }
    }
}
