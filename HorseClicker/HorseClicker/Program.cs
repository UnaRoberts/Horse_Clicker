using HorseClicker;
using Raylib_cs;

namespace HelloWorld;

internal static class Program
{
    [System.STAThread]

    
    public static void Main()
    {

        Raylib.InitWindow(800, 480, "Hello, World");
        Raylib.SetTargetFPS(60);

        Game game = new Game();

        while (!Raylib.WindowShouldClose())
        {
            game.Update();
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            game.Draw();
            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
    }
}