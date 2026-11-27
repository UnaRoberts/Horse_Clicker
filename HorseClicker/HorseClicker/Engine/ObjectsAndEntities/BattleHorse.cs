using Raylib_cs;

namespace HorseClicker
{
    internal class BattleHorse : Sprite
    {
        public bool IsPlayer;   // which side it's on
        public float Speed = 80;
        public bool Stopped;    // true once it has collided

        public BattleHorse(Texture2D texture, bool isPlayer) : base(texture)
        {
            IsPlayer = isPlayer;
            if (!isPlayer)
            {
                Source.Width = -Source.Width; // flip 
                Tint = new Color(255, 170, 170, 255); 
            }
        }
    }
}