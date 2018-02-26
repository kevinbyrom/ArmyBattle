using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ArmyBattle.Components;
using ArmyBattle.Framework.States;



namespace ArmyBattle.Entities.Characters
{

    public class Soldier : EntityBase
    {
        public Vector2 Velocity;
        public Vector2 Facing;
        public SpriteComponent Sprite;
        public AnimationComponent Animation;
        public IState CurrState;

        public StateMachine EntityState;

        private IState standingState;
        private IState walkingState;

        public Soldier(Game game) : base(game)
        {
            this.Sprite = new SpriteComponent(game);
            this.Animation = new AnimationComponent(game);
            this.EntityState = new StateMachine();
        }


        public override void Initialize()
        {
            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.Animation.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            this.Sprite.Draw(gameTime);
        }


        public void Stand()
        {
            this.EntityState.SetState(this.standingState);
        }


        public void WalkTowards(Vector2 target)
        {
            this.EntityState.SetState(this.walkingState);
        }


        public void LookTowards(Vector2 target)
        {
            
        }


        public void Shoot()
        {
        }


        public void EnterVehicle()
        {
        }

    }
}
