using HorseClicker;
using Raylib_cs;

namespace HelloWorld;

internal static class Program
{
    // STAThread is required if you deploy using NativeAOT on Windows
    // See https://github.com/raylib-cs/raylib-cs/issues/301
    [System.STAThread]

    
    public static void Main()
    {
        Game game = new Game();

        Raylib.InitWindow(800, 480, "Hello, World");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {

            game.Update();


            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);


            game.Draw();

        }
            Raylib.CloseWindow();

        
    }
}