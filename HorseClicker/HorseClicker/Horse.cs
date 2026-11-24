using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    /// <summary>
    /// A horse has:
    ///     Type
    ///     Size
    ///     Health
    ///     Speed
    ///     Damage
    /// </summary>
    
    enum HorseType { Earth, Unicorn, Pegasus, } // different types of horses
    enum HorseSize { Small, Medium, Large, } // different sizes of horses

    internal class Horse : Sprite
    {
        public HorseType Type { get; private set; } // a horse has a "type"
        public HorseSize Size { get; private set; } // and a "size"
        public int Health { get; private set; }
        public int Speed { get; private set; }
        public int Damage { get; private set; }


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

        // A horse can move
        private void UpdateMove(float deltaTime) { }
        // A horse can eat
        private void Eat() { }
        // A horse can grow
        private void growSize() { }
    }
}
