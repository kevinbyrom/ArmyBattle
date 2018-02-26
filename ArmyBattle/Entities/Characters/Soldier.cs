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
using ArmyBattle.Framework.Graphics;


namespace ArmyBattle.Entities.Characters
{
    public enum SolderStates
    {
        Normal,
        Dying
    }

    public class Soldier : EntityBase
    {
        public Vector2 Velocity;
        public Vector2 Facing;
        public SpriteComponent Sprite;
        public AnimationComponent Animator;

        private StateMachine<SolderStates> entityState;

        private Animation standAnimation;
        private Animation runAnimation;


        public Soldier(Game game) : base(game)
        {
            this.Sprite = new SpriteComponent(game);
            this.Animator = new AnimationComponent(game);

            this.entityState = new StateMachine<SolderStates>();
            this.entityState[SolderStates.Normal].Update = Update_NormalState;
        }


        public override void Initialize()
        {
            base.Initialize();

            this.standAnimation = Animation.Create(new Rectangle(0, 0, 32, 32));
            this.runAnimation = Animation.Create(new Rectangle(0, 0, 32, 32));
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            // Update Components

            this.Animator.Update(gameTime);


            // Update state machines

            this.entityState.Update(gameTime); 
        }


        public void Update_NormalState(GameTime gameTime)
        {
            // Process input
            // Move character
            // Set animation based on current movement / shooting

            if (this.Velocity == Vector2.Zero) 
            {
                this.Animator.Animation = standAnimation;
            }
            else 
            {
                this.Animator.Animation = runAnimation;
            }
        }

        public void Update_DyingState(GameTime gameTime)
        {

        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            this.Sprite.Draw(gameTime);
        }

    }
}
