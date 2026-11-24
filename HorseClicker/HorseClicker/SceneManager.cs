using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The scene manager is responsible for managing the different scenes in the game.
/// It has a list of scenes and can switch between them as needed.
/// </summary>

namespace HorseClicker
{
    public class SceneManager
    {
        public Scene CurrentScene { get; private set; }

        public SceneManager(Scene firstScene)
        {
            CurrentScene = firstScene;
        }

        public void ChangeScene(Scene newScene)
        {
            CurrentScene = newScene;
        }

        public void Update(float deltaTime) => CurrentScene.Update(deltaTime);

        public void Draw() => CurrentScene.Draw();

    }
}
