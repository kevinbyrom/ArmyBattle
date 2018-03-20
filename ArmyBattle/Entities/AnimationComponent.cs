using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ArmyBattle.Framework.Graphics;


namespace ArmyBattle.Components
{
    public class AnimationComponent : GameComponent
    {
        public Sprite Sprite;

        public Animation Animation 
        {
            get
            {
                return this.animation;
            }
            set
            {
                if (this.animation != value)
                    this.currFrame = 0;
                
                this.animation = value;
            }
        }

        private Animation animation;
        private int currTicks;
        private int currFrame;

        public AnimationComponent(Game game) : base(game)
        {
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.Sprite.Frame = this.animation.Frames[this.currFrame];

            this.currTicks += 1;

            if (this.currTicks >= this.animation.TicksPerFrame)
            {
                this.currTicks = this.currTicks % this.animation.TicksPerFrame;
                this.currFrame++;

                if (this.currFrame >= this.animation.Frames.Count())
                    this.currFrame = 0;
            }
        }
    }
}
