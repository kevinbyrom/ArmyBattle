using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ArmyBattle.Components
{
    public class AnimationComponent : GameComponent
    {
        public SpriteComponent Sprite;


        public AnimationComponent(Game game) : base(game)
        {

        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
