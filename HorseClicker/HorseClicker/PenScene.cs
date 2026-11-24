using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    /// <summary>
    /// Where the player's horses live. This is where the player will be able to see their horses and interact with them.
    /// </summary>

    public class PenScene : Scene
    {
        public PenScene()
        {
            Texture2D horseTexture = Raylib.LoadTexture("../../../../tempAssets/Bat_Sticker.png");

            Horse horse = new Horse(horseTexture);
            horse.Position = new Vector2(200, 200);
            Add(horse);
        }
    }
}
