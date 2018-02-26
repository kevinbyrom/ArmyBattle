using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace ArmyBattle.Framework.States
{
    public class StateMachine
    {
        public List<IState> States;
        private IState currState;


        public StateMachine()
        {
            this.States = new List<IState>();
        }

        public void Update(GameTime gameTime)
        {
            this?.currState.Update(gameTime);
        }

        public void SetState(IState state)
        {
            this?.currState.Exit();
            this.currState = state;
            this?.currState.Enter();
        }
    }
}
