using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    public static class Input
    {
        // True only on the frame the left mouse button goes down
        public static bool Clicked => Raylib.IsMouseButtonPressed(MouseButton.Left);

        // Where the mouse is right now
        public static Vector2 MousePosition => Raylib.GetMousePosition();

        // True if the player clicked inside this rectangle this frame
        public static bool ClickedOn(Rectangle area) =>
            Clicked && Raylib.CheckCollisionPointRec(MousePosition, area);
    }
}
