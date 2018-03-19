using System;
using Microsoft.Xna.Framework;


namespace ArmyBattle.Framework.Graphics
{
    public class Animation
    {
        public Rectangle[] FrameRects;
        public int TicksPerFrame;

        public Animation()
        {
        }

        static public Animation Create(int ticksPerFrame, params Rectangle[] rects)
        {
            Animation anim = new Animation();

            anim.TicksPerFrame = ticksPerFrame;
            anim.FrameRects = rects;

            return anim;
        }
    }
}
