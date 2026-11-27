using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// A scene has the sprites, the objects
/// A scene is a collection of sprites and objects that make up a specific part of the game. 
/// It can represent different levels, menus, or any other distinct area within the game. 
/// Each scene can have its own unique set of sprites, background, and logic.

namespace HorseClicker
{
    public abstract class Scene
    {
        private readonly List<GameComponent> _components = [];

        public void Add(GameComponent c) => _components.Add(c);
        public void Remove(GameComponent c) => _components.Remove(c);
        
        public virtual void OnEnter() { } 

        public virtual void Update(float deltaTime)
        {
            foreach (GameComponent c in _components.ToList())
                c.Update(deltaTime);
        }

        public virtual void Draw()
        {
            foreach (DrawableGameComponent c in _components.OfType<DrawableGameComponent>().ToList())
                c.Draw();
        }
    }
}
