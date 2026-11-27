using Raylib_cs;
using System.Numerics;

namespace HorseClicker
{
    public class RaceScene : Scene
    {
        private const int LaneCount = 5;
        private const float StartX = Sidebar.Width + 60; // where horses line up

        private readonly List<RaceHorse> racers = new();
        private RaceHorse? winner;

        private float LaneHeight => Raylib.GetScreenHeight() / (float)LaneCount;
        private float FinishX => Raylib.GetScreenWidth() - 40;

        public RaceScene()
        {
            string dir = Path.Combine(AppContext.BaseDirectory, "Assets", "Horses");
            Texture2D[] textures =
            {
                Raylib.LoadTexture(Path.Combine(dir, "Horse.png")),
                Raylib.LoadTexture(Path.Combine(dir, "Unicorn.png")),
                Raylib.LoadTexture(Path.Combine(dir, "Pegasus.png")),
            };

            for (int i = 0; i < LaneCount; i++)
            {
                string name = i == 0 ? "You" : $"Horse {i + 1}";
                var racer = new RaceHorse(textures[i % textures.Length], name);
                racers.Add(racer);
                Add(racer);
            }

            ResetRace();
        }

        private void ResetRace()
        {
            for (int i = 0; i < racers.Count; i++)
            {
                RaceHorse r = racers[i];
                r.Scale = LaneHeight * 0.7f / r.Texture.Height; 
                r.Position = new Vector2(StartX, LaneHeight * (i + 0.5f)); 
                r.Speed = Random.Shared.Next(80, 160);
            }
            winner = null;
        }

        public override void Update(float deltaTime)
        {
            if (winner == null)
            {
                base.Update(deltaTime);

                foreach (RaceHorse r in racers)
                {
                    if (r.Bounds.X + r.Bounds.Width >= FinishX)
                    {
                        winner = r;
                        break;
                    }
                }
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                ResetRace();
            }
        }

        public override void Draw()
        {
            DrawTrack();
            base.Draw();

            // Name in the corner of each lane
            foreach (RaceHorse r in racers)
            {
                int laneTop = (int)(r.Position.Y - LaneHeight / 2);
                Raylib.DrawText(r.Name, Sidebar.Width + 6, laneTop + 6, 14, Color.DarkGray);
            }

            if (winner != null)
            {
                string msg = $"{winner.Name} wins!  (Space to race again)";
                int w = Raylib.MeasureText(msg, 24);
                int centerX = Sidebar.Width + (Raylib.GetScreenWidth() - Sidebar.Width - w) / 2;
                Raylib.DrawText(msg, centerX, Raylib.GetScreenHeight() / 2 - 12, 24, Color.Black);
            }
        }

        private void DrawTrack()
        {
            int screenW = Raylib.GetScreenWidth();
            int screenH = Raylib.GetScreenHeight();

            //  - - - - - -
            for (int lane = 1; lane < LaneCount; lane++)
            {
                int y = (int)(lane * LaneHeight);
                for (int x = Sidebar.Width; x < screenW; x += 20)
                    Raylib.DrawLine(x, y, x + 10, y, Color.Gray);
            }

            // start and finish lines
            Raylib.DrawLine((int)StartX, 0, (int)StartX, screenH, Color.LightGray);
            Raylib.DrawLineEx(new Vector2(FinishX, 0), new Vector2(FinishX, screenH), 4, Color.Red);
        }
    }
}