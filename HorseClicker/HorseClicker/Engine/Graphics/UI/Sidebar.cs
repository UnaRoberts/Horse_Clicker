using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace HorseClicker
{
    internal class Sidebar : DrawableGameComponent
    {
        public const int Width = 100; // all scenes keep their content to the right of this width

        private readonly SceneManager scenes; // needs a reference to the scene manager so it can switch between them
        private readonly List<(SceneId Id, string Label, Rectangle Area)> buttons = new();

        public Sidebar(SceneManager scenes)
        {
            this.scenes = scenes;
            AddButton(SceneId.Pen, "Pen");
            AddButton(SceneId.Race, "Race");
            AddButton(SceneId.Battle, "Battle");
        }

        private void AddButton(SceneId id, string lable)
        {
            int size = 80;
            int margin = 10;
            int gap = 20;

            float y = margin + buttons.Count * (size + gap);
            buttons.Add((id, lable, new Rectangle(margin, y, size, size)));
        }
        
        public override void Update(float deltaTime) // changes the scene to whatever you've clicked on
        {
            foreach(var button in buttons)
            {
                if (Input.ClickedOn(button.Area))
                {
                    scenes.ChangeScene(button.Id);
                }
            }
        }

        public override void Draw()
        {
            int height = Raylib.GetScreenHeight();
            Raylib.DrawRectangle(0, 0, Width, height, Color.White);
            Raylib.DrawLine(Width, 0, Width, height, Color.Black);

            foreach (var button in buttons)
            {
                bool active = button.Id == scenes.CurrentId;
                bool hover = Raylib.CheckCollisionPointRec(Input.MousePosition, button.Area);

                Raylib.DrawRectangleRec(button.Area, active ? Color.LightGray : hover ? new Color(235, 235, 235, 255) : Color.White);
                Raylib.DrawRectangleLinesEx(button.Area, 2, Color.Black);

                int textWidth = Raylib.MeasureText(button.Label, 16);
                Raylib.DrawText(button.Label,
                    (int)(button.Area.X + (button.Area.Width - textWidth) / 2),
                    (int)(button.Area.Y + button.Area.Height - 20),
                    16, Color.Black);
            }
        }
    }
}
