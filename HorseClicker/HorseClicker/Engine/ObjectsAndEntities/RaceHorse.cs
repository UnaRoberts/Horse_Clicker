using Raylib_cs;

namespace HorseClicker;

internal class RaceHorse : Sprite
{
    public string Name;
    public float Speed; // pixels per second

    public RaceHorse(Texture2D texture, string name) : base(texture)
    {
        Name = name;
    }

    public override void Update(float deltaTime)
    {
        Position.X += Speed * deltaTime; // straight to the right
    }
}