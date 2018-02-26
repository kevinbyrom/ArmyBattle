using System;
using Microsoft.Xna.Framework;
using ArmyBattle.Framework.Graphics;
using ArmyBattle.Framework.States;


namespace ArmyBattle.Entities.Characters
{
    public class SoldierStandingState : StateBase<Soldier>
    {
        public Animation StandAnimation;


        public SoldierStandingState(Game game, Soldier soldier) : base(game, soldier)
        {
            this.StandAnimation = Animation.Create(new Rectangle(0, 0, 32, 32));
        }


        public override void Enter()
        {
            base.Enter();

            this.Entity.Animation.Animation = this.StandAnimation;
            this.Entity.Velocity = Vector2.Zero;
        }
    }
}
