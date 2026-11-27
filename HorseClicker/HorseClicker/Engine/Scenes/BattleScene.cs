using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using System.Numerics;

namespace HorseClicker
{
    public class BattleScene : Scene
    {
        private const int MaxHorses = 5;

        private readonly PenScene pen;
        private readonly Texture2D[] textures;
        private readonly List<BattleHorse> fighters = new();
        private readonly List<Vector2> collisionPoints = new();

        public BattleScene(PenScene pen)
        {
            this.pen = pen;
            string dir = Path.Combine(AppContext.BaseDirectory, "Assets", "Horses");
            textures = new[]
            {
                Raylib.LoadTexture(Path.Combine(dir, "Horse.png")),
                Raylib.LoadTexture(Path.Combine(dir, "Unicorn.png")),
                Raylib.LoadTexture(Path.Combine(dir, "Pegasus.png")),
            };
        }

        public override void OnEnter() => SetupBattle();

        private void SetupBattle()
        {
            // Clear out the last battle
            foreach (BattleHorse f in fighters) Remove(f);
            fighters.Clear();
            collisionPoints.Clear();

            int playerCount = Math.Min(pen.HorseCount, MaxHorses);
            if (playerCount == 0) return; 

            // Same amount +/- 1, between 1 and 5
            int enemyCount = Math.Clamp(playerCount + Random.Shared.Next(-1, 2), 1, MaxHorses);

            Spawn(playerCount, isPlayer: true);
            Spawn(enemyCount, isPlayer: false);
        }

        private void Spawn(int count, bool isPlayer)
        {
            int screenW = Raylib.GetScreenWidth();
            int screenH = Raylib.GetScreenHeight();
            float x = isPlayer ? Sidebar.Width + 60 : screenW - 60; // left side vs right side

            for (int i = 0; i < count; i++)
            {
                var f = new BattleHorse(textures[i % textures.Length], isPlayer);
                f.Scale = (screenH / 7f) / f.Texture.Height; 
                f.Position = new Vector2(x, screenH * (i + 1f) / (count + 1)); 
                fighters.Add(f);
                Add(f);
            }
        }

        public override void Update(float deltaTime)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space)) 
            {
                SetupBattle();
                return;
            }

            foreach (BattleHorse f in fighters)
            {
                if (f.Stopped) continue;

                BattleHorse? nearest = null;
                float nearestDist = float.MaxValue;

                foreach (BattleHorse other in fighters)
                {
                    if (other.IsPlayer == f.IsPlayer) continue;

                    if (Raylib.CheckCollisionRecs(f.Bounds, other.Bounds))
                    {
                        f.Stopped = true;
                        other.Stopped = true;
                        collisionPoints.Add((f.Position + other.Position) / 2); 
                        break;
                    }

                    float dist = Vector2.Distance(f.Position, other.Position);
                    if (dist < nearestDist)
                    {
                        nearestDist = dist;
                        nearest = other;
                    }
                }

                if (!f.Stopped && nearest != null)
                {
                    Vector2 dir = Vector2.Normalize(nearest.Position - f.Position);
                    f.Position += dir * f.Speed * deltaTime;
                }
            }

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            int screenW = Raylib.GetScreenWidth();
            int screenH = Raylib.GetScreenHeight();

            if (fighters.Count == 0)
            {
                Raylib.DrawText("You need a horse in your Pen to battle!", Sidebar.Width + 20, screenH / 2 - 10, 20, Color.Black);
                return;
            }

            base.Draw(); 

            foreach (Vector2 p in collisionPoints)
            {
                const string msg = "Collision!";
                int w = Raylib.MeasureText(msg, 20);
                Raylib.DrawText(msg, (int)p.X - w / 2, (int)p.Y - 50, 20, Color.Red);
            }

            Raylib.DrawText("Space: new battle", screenW - 160, screenH - 25, 16, Color.Gray);
        }
    }
}
