using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    public class FirstScene : Scene
    {
        public FirstScene()
        {
            Texture2D horseTexture = Raylib.LoadTexture("../../../../tempAssets/Bat_Sticker.png");

            Horse horse = new Horse(horseTexture);
            horse.Position = new Vector2(200, 200);
            Add(horse);
        }
    }
}
