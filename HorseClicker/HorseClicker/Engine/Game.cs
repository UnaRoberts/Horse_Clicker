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
    /// <summary>
    /// Do not put one billion things in here, 
    /// </summary>
    internal class Game
    {
        private readonly SceneManager scenes; // the scenes in the game
        private readonly Sidebar sidebar; 

        public Game()
        {
            Console.Title = "HorseClicker";
            // This is where we would add more scenes to the game
            scenes = new SceneManager();
            scenes.ChangeScene(SceneId.Pen);

            sidebar = new Sidebar(scenes);
        }

        public void Update()
        {
            float deltaTime = Raylib.GetFrameTime();

            sidebar.Update(deltaTime);
            scenes.Update(deltaTime); // update the current scene
        }
        public void Draw()
        {
            scenes.Draw(); // draw the current scene
            sidebar.Draw();
        }
    }
}
