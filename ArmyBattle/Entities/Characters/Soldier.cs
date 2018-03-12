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
using ArmyBattle.Utilities;


namespace ArmyBattle.Entities.Characters
{
    public enum SolderStates
    {
        Normal,
        Dying
    }

    public static class SoldierAnimations
    {
        public static Rectangle StandRect = new Rectangle(0, 0, 32, 32);
        public static Rectangle Run1Rect = new Rectangle(32, 0, 32, 32);
        public static Rectangle Run2Rect = new Rectangle(64, 0, 32, 32);

        public static Rectangle FeetStandRect = new Rectangle(5 * 32, 0, 32, 32);
        public static Rectangle FeetRun1Rect = new Rectangle(6 * 32, 0, 32, 32);
        public static Rectangle FeetRun2Rect = new Rectangle(7 * 32, 0, 32, 32);

        public static Animation Stand = Animation.Create(StandRect);
        public static Animation Run = Animation.Create(StandRect, Run1Rect, StandRect, Run2Rect);
        public static Animation FeetStand = Animation.Create(FeetStandRect);
        public static Animation FeetRun = Animation.Create(FeetStandRect, FeetRun1Rect, FeetStandRect, FeetRun2Rect);
    }

    public class Soldier : EntityBase
    {
        public Vector2 Velocity;
        public Vector2 Facing;
        public SpriteComponent BodySprite;
        public AnimationComponent BodyAnimator;
        public SpriteComponent FeetSprite;
        public AnimationComponent FeetAnimator;

        private StateMachine<SolderStates> entityState;

        public Soldier(Game game) : base(game)
        {
            this.BodySprite = new SpriteComponent(game);
            this.BodySprite.Origin = new Vector2(16, 16);
            this.BodyAnimator = new AnimationComponent(game);
            this.BodyAnimator.TargetSprite = this.BodySprite;

            this.FeetSprite = new SpriteComponent(game);
            this.FeetSprite.Origin = new Vector2(16, 16);
            this.FeetAnimator = new AnimationComponent(game);
            this.FeetAnimator.TargetSprite = this.FeetSprite;

            this.entityState = new StateMachine<SolderStates>();
            this.entityState[SolderStates.Normal].Update = Update_NormalState;
            this.entityState.SetState(SolderStates.Normal);
        }


        public override void Initialize()
        {
            base.Initialize();
        }

        public void LoadContent()
        {
            var texture = this.Game.Content.Load<Texture2D>("Soldier");
            this.BodySprite.Texture = texture;
            this.FeetSprite.Texture = texture;
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            // Update state machines

            this.entityState.Update(gameTime); 


            // Update Components

            this.BodyAnimator.Update(gameTime);
            this.FeetAnimator.Update(gameTime);


            // Move player and set rotations

            this.Pos += this.Velocity;
            this.BodySprite.Rotation = this.Facing.ToRadians();
            this.FeetSprite.Rotation = this.Velocity.ToRadians();
            this.BodySprite.ScreenPos = this.Pos;
            this.FeetSprite.ScreenPos = this.Pos;
        }


        public void Update_NormalState(GameTime gameTime)
        {

            // Process input

            var padState = GamePad.GetState(PlayerIndex.One);

            this.Velocity.X = padState.ThumbSticks.Left.X;
            this.Velocity.Y = -padState.ThumbSticks.Left.Y;

            if (Math.Abs(padState.ThumbSticks.Right.X) > 0.5 || Math.Abs(padState.ThumbSticks.Right.Y) > 0.5) 
                this.Facing = padState.ThumbSticks.Right;


            // Set animation based on current movement / shooting

            if (this.Velocity == Vector2.Zero) 
            {
                this.BodyAnimator.Animation = SoldierAnimations.Stand;
                this.FeetAnimator.Animation = SoldierAnimations.FeetStand;
            }
            else 
            {
                this.BodyAnimator.Animation = SoldierAnimations.Run;
                this.FeetAnimator.Animation = SoldierAnimations.FeetRun;
            }
        }

        public void Update_DyingState(GameTime gameTime)
        {

        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            this.FeetSprite.Draw(gameTime);
            this.BodySprite.Draw(gameTime);
        }

    }
}
