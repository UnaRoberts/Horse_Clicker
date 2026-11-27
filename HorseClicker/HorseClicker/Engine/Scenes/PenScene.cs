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
        private readonly List<Horse> horses = new();
        private readonly Texture2D horseTexture;

        public int HorseCount => horses.Count;

        public PenScene()
        {
            horseTexture = Raylib.LoadTexture(Path.Combine(AppContext.BaseDirectory, "Assets", "Horses", "Horse.png"));
            AddHorse(new Vector2(200, 200));
        }

        public void AddHorse(Vector2 position)
        {
            var horse = new Horse(horseTexture) { Position = position };
            horses.Add(horse);
            Add(horse);
        }

        public override void Update(float deltaTime)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.H)) // testing shortcut: add a horse
                AddHorse(new Vector2(Random.Shared.Next(Sidebar.Width + 50, 700), Random.Shared.Next(50, 430)));

            base.Update(deltaTime);
        }
    }
}
