using System;
using Microsoft.Xna.Framework;
using ArmyBattle.Framework.Graphics;
using ArmyBattle.Framework.States;


namespace ArmyBattle.Entities.Characters
{
    public class SoldierWalkingState : StateBase<Soldier>
    {
        public Animation WalkAnimation;


        public SoldierWalkingState(Game game, Soldier soldier) : base(game, soldier)
        {
            this.WalkAnimation = Animation.Create(new Rectangle(32, 0, 32, 32), new Rectangle(64, 0, 32, 32));
        }

        public override void Enter()
        {
            base.Enter();

            this.Entity.Animation.Animation = this.WalkAnimation;
        }
    }
}
