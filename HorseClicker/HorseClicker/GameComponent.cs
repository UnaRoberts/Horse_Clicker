using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    public abstract class GameComponent
    {
        public bool Enabled = true;
        public int UpdateOrder;
        public virtual void Initialize() { }
        public virtual void Update(float deltaTime) { }
        public virtual void Unload() { }
    }

    public abstract class DrawableGameComponent : GameComponent
    {
        public bool Visible = true;
        public int DrawOrder;
        public virtual void Draw() { }
    }
}
