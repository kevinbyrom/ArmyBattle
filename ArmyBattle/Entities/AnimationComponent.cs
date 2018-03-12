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
        public SpriteComponent TargetSprite;

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
        private int currFrame;


        public AnimationComponent(Game game) : base(game)
        {
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.TargetSprite.SourceRect = this.animation.FrameRects[this.currFrame];
            this.currFrame += 1;
            if (this.currFrame >= this.animation.FrameRects.Count())
                this.currFrame = 0;
        }
    }
}
