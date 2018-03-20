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
        public static Animation Stand = Animation.Create(4, new int[] { 0 });
        public static Animation Run = Animation.Create(4, new int[] { 0 });
        public static Animation FeetStand = Animation.Create(4, new int[] { 5 });
        public static Animation FeetRun = Animation.Create(4, new int[] { 5, 6, 5, 7});
    }

    public class Soldier : EntityBase
    {
        const int SOLDER_SPRITE_WIDTH = 32;
        const int SOLDER_SPRITE_HEIGHT = 32;
        const int SOLDER_SPRITE_ORIGIN_X = SOLDER_SPRITE_WIDTH / 2;
        const int SOLDER_SPRITE_ORIGIN_Y = SOLDER_SPRITE_HEIGHT / 2;

        public Vector2 Velocity;
        public Vector2 Facing;
        public Sprite BodySprite;
        public AnimationComponent BodyAnimator;
        public Sprite FeetSprite;
        public AnimationComponent FeetAnimator;

        private StateMachine<SolderStates> entityState;

        public Soldier(Game game) : base(game)
        {
            this.BodySprite = new Sprite(game, SOLDER_SPRITE_WIDTH, SOLDER_SPRITE_HEIGHT);
            this.BodySprite.Origin = new Vector2(SOLDER_SPRITE_ORIGIN_X, SOLDER_SPRITE_ORIGIN_Y);
            this.BodyAnimator = new AnimationComponent(game);
            this.BodyAnimator.Sprite = this.BodySprite;

            this.FeetSprite = new Sprite(game, SOLDER_SPRITE_WIDTH, SOLDER_SPRITE_HEIGHT);
            this.FeetSprite.Origin = new Vector2(SOLDER_SPRITE_ORIGIN_X, SOLDER_SPRITE_ORIGIN_Y);
            this.FeetAnimator = new AnimationComponent(game);
            this.FeetAnimator.Sprite = this.FeetSprite;

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
            {
                this.Facing.X = padState.ThumbSticks.Right.X;
                this.Facing.Y = -padState.ThumbSticks.Right.Y;
            }
            else if (this.Velocity != Vector2.Zero)
            {
                this.Facing = this.Velocity;
                this.Facing.Normalize();
            }

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

            this.FeetSprite.Scale = 2;
            this.BodySprite.Scale = 2;
            this.FeetSprite.Draw(gameTime);
            this.BodySprite.Draw(gameTime);
        }

    }
}
