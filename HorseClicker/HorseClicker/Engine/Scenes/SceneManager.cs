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
    public enum SceneId { Pen, Race, Battle }
    public class SceneManager
    {
        private readonly Dictionary<SceneId, Scene> scenes = new(); // our list of scenes in the game

        public SceneId CurrentId { get; private set; }
        public Scene CurrentScene => scenes[CurrentId];


        public SceneManager()
        {
            AddScene(SceneId.Pen, new PenScene());
            AddScene(SceneId.Race, new RaceScene());
            AddScene(SceneId.Pen, new BattleScene());
        }
        public void AddScene(SceneId id, Scene scene) 
        { 
            scenes[id] = scene; 
        }
        public void ChangeScene(SceneId id)
        {
            if (scenes.ContainsKey(id)) // ignore scenes that aren't registered yet
                CurrentId = id;
        }
        public void Update(float deltaTime) => CurrentScene.Update(deltaTime);

        public void Draw() => CurrentScene.Draw();

    }
}
