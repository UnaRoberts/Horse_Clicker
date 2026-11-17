using Raylib_cs;
using System.Numerics;

namespace HorseClicker
{
    public abstract class Sprite : GameComponent
    {
        public Texture2D Texture;
        public Rectangle Source; // part of the texture to draw (for sprite sheets)
        public Vector2 Position;
        public Vector2 Pivot = new(0.5f, 0.5f); // 0..1; (0.5, 0.5) is the center
        public float Rotation; // degrees
        public float Scale = 1f;
        public Color Tint = Color.White;
        public bool Visible = true;

        protected Sprite(Texture2D texture)
        {
            Texture = texture;
            Source = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public float Width => MathF.Abs(Source.Width) * Scale;
        public float Height => MathF.Abs(Source.Height) * Scale;

        // Box for collision checks (ignores rotation); use with Raylib.CheckCollisionRecs
        public Rectangle Bounds => new(
            Position.X - Width * Pivot.X,
            Position.Y - Height * Pivot.Y,
            Width, Height);

        public virtual void Update(float dt) { }

        public virtual void Draw()
        {
            if (!Visible) return;
            var dest = new Rectangle(Position.X, Position.Y, Width, Height);
            var origin = new Vector2(Width * Pivot.X, Height * Pivot.Y);
            Raylib.DrawTexturePro(Texture, Source, dest, origin, Rotation, Tint);
        }
    }
}
