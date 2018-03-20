using System;
using Microsoft.Xna.Framework;


namespace ArmyBattle.Framework.Graphics
{
    public class Animation
    {
        public int[] Frames;
        public int TicksPerFrame;

        public Animation()
        {
        }

        static public Animation Create(int ticksPerFrame, params int[] frames)
        {
            Animation anim = new Animation();

            anim.TicksPerFrame = ticksPerFrame;
            anim.Frames = frames;

            return anim;
        }
    }
}
