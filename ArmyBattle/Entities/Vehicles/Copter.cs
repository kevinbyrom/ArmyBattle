using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ArmyBattle.Components;
using ArmyBattle.Framework.Graphics;



namespace ArmyBattle.Entities.Characters
{
    
    public class Copter : EntityBase
    {
        Sprite sprite;
        AnimationComponent animation;


        public Copter(Game game) : base(game)
        {
            sprite = new Sprite(game);
        }
        

        public override void Initialize()
        {
            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.animation.Update(gameTime);
        }
        
        
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            this.sprite.Draw(gameTime);
        }
        
    }
}
