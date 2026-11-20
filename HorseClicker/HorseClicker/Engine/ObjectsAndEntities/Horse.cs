using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    internal class Horse : Sprite
    {
        public Horse(Texture2D texture) : base(texture)
        {
            // constuctor
        }

        public override void Update(float deltaTime)
        {
            if (Input.ClickedOn(Bounds))
            {
                Console.WriteLine("Horse clicked!");
            }
        }
    }
}
