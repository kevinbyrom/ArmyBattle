using System;
using Microsoft.Xna.Framework;


namespace ArmyBattle.Framework.Graphics
{
    public class Animation
    {
        public Rectangle[] FrameRects;
        public TimeSpan TimePerFrame;

        public Animation()
        {
        }

        static public Animation Create(params Rectangle[] rects)
        {
            Animation anim = new Animation();

            anim.FrameRects = rects;

            return anim;
        }
    }
}
