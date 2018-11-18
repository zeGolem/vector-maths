using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class InputHandler
    {
        static bool isFirstLetter = true;
        static char firstLetter;
        public static void CheckForInputs(KeyboardState ks, MouseState ms)
        {
            //Place point
            if (ms.LeftButton == ButtonState.Pressed)
            {
                Camera.displayedGrid.RegisterPoint(Camera.displayedGrid.CreatePoint(
                    Mouse.GetState().X, Mouse.GetState().Y));
            }

            //Keyboard controls
            if (ks.IsKeyDown(Keys.D))
            {
                Camera.X++;
            }
            if (ks.IsKeyDown(Keys.Q))
            {
                Camera.X--;
            }
            if (ks.IsKeyDown(Keys.Z))
            {
                Camera.Y++;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                Camera.Y--;
            }

            if(ms.RightButton == ButtonState.Pressed)
            {
                EventHandler.ShouldListonForInput = true;
                
            }
            if (ms.RightButton == ButtonState.Released && EventHandler.ShouldListonForInput)
            {
                if (isFirstLetter) {
                    isFirstLetter = false;
                    firstLetter = Camera.GameGui.text[0];
                }
                else
                {
                    Camera.displayedGrid.CreateVectorBetween(firstLetter, Camera.GameGui.text[0]);
                    isFirstLetter = true;
                }
                EventHandler.ShouldListonForInput = false;
                Camera.GameGui.text = "";
            }


        }
    }
}
