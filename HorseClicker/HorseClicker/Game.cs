using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    internal class Game
    {
        private readonly SceneManager scenes;

        public Game()
        {
            scenes = new SceneManager(new FirstScene());
            // This is where we would add more scenes to the game
        }

        public void Update()
        {
            scenes.Update(Raylib.GetFrameTime());
        }
        public void Draw()
        {
            scenes.Draw();
        }


        //SceneManager scenes;

        //Rectangle button = new Rectangle(300, 250, 200, 100);
        //public bool buttonPressed = false;

        //Texture2D horseTexture;


        //public void LoadContent()
        //{

        //}

        //public void Update()
        //{

        //    Vector2 mousePos = Raylib.GetMousePosition();

        //    bool mouseOverButton =
        //        Raylib.CheckCollisionPointRec(mousePos, button);

        //    if (mouseOverButton &&
        //        Raylib.IsMouseButtonPressed(MouseButton.Left))
        //    {
        //        Console.WriteLine("Button clicked!");
        //        buttonPressed = true;
        //        //increment money
        //    }
        //}

        //public void Draw()
        //{
        //    Raylib.DrawTexture(horseTexture, 100, 100, Color.White);
        //    Raylib.DrawRectangle(300, 250, 200, 100, Color.Red);

        //    if (buttonPressed == true)
        //    {
        //        Raylib.DrawText("Button Clicked!", 12, 12, 20, Color.Black);
        //        buttonPressed = false;
        //    }
        //}
    }
}
