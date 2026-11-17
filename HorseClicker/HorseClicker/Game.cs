using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    internal class Game
    {

        public bool buttonPressed = false;
        public void Update()
        {
            Console.WriteLine("Update running");

            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {  buttonPressed = true; }

        }

        public void Draw()
        {

                if (buttonPressed == true)
                {
                Raylib.DrawText("Button Clicked!", 12, 12, 20, Color.Black);
                buttonPressed = false;
                //increment money
                //
                }

                Raylib.EndDrawing();
            }



    }
}
