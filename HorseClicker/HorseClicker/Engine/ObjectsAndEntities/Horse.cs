using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
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
    enum HorseStates { Standing, Roaming } //  different "states" of the horse

    internal class Horse : Sprite
    {
        public HorseType Type { get; private set; } // a horse has a "type"
        public HorseSize Size { get; private set; } // and a "size"
        public HorseStates State { get; private set; }
        public int Health { get; private set; }
        public int Speed { get; private set; }
        public int Damage { get; private set; }


        public Horse(Texture2D texture) : base(texture)
        {
            this.Speed = 100;
            showBounds = true; // to see bounding box
        }

        public override void Update(float deltaTime)
        {

            UpdateMove(deltaTime);


            if (Input.ClickedOn(Bounds))
            {
                Console.WriteLine("Horse clicked!");
            }
        }
        
        public Vector2 Direction = new(1, 0); 
        // A horse can move
        private void UpdateMove(float deltaTime)
        {
            Position += Direction * Speed * deltaTime;

            // Bounce off the edges of the pen (right of the sidebar, inside the window)
            Rectangle b = Bounds;
            if ((b.X < Sidebar.Width && Direction.X < 0) ||
                (b.X + b.Width > Raylib.GetScreenWidth() && Direction.X > 0))
                Direction.X = -Direction.X;

            if ((b.Y < 0 && Direction.Y < 0) ||
                (b.Y + b.Height > Raylib.GetScreenHeight() && Direction.Y > 0))
                Direction.Y = -Direction.Y;
        }
        
        // A horse can eat
        private void Eat() { }
        // A horse can grow
        private void growSize() { }

        // --- Behaviors ---
        // roaming
        private float roamTimer;

        private void Roam(float deltaTime)
        {
            roamTimer -= deltaTime;
            if (roamTimer <= 0)
            {
                float angle = Random.Shared.NextSingle() * MathF.Tau; // 0–360°
                Direction = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
                roamTimer = 2f + Random.Shared.NextSingle() * 3f;     // wait 2–5s
            }
        }
    }
}
