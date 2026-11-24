using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseClicker
{
    internal class AnimationManager
    {
        public Animation CurrentAnimation { get; private set; }

        public AnimationManager(Animation firstAniamtion)
        {
            CurrentAniamtion = firstAnimation;
        }

        public void ChangeAnimation(Aniamtion newAnimation)
        {
            CurrentAniamtion = newAnimation;
        }

        public void Update(float deltaTime) => CurrentAnimation.Update(deltaTime);

        public void Draw() => CurrentAnimation.Draw(); //this should be draw, not sure how to make sure it is cycling tho


    }
}
