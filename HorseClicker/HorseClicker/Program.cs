using HorseClicker;
using Raylib_cs;

namespace HelloWorld;

internal static class Program
{
    [System.STAThread]

    
    public static void Main()
    {
        Game game = new Game();

        Raylib.InitWindow(800, 480, "Hello, World");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            game.LoadContent();
            game.Update();
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            game.Draw();
            Raylib.EndDrawing();
        }
     
    Raylib.CloseWindow();
        
    }
}