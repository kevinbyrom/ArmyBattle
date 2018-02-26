using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace ArmyBattle.Framework.States
{
    public class StateMachine<TID>
    {
        private Dictionary<TID, State> states;
        private State currState;


        public State this[TID id]
        {
            get
            {
                if (!this.states.ContainsKey(id))
                    this.states.Add(id, new State());
                                      
                return this.states[id];
            }
            set
            {
                this.states[id] = value;
            }
        }


        public StateMachine()
        {
            this.states = new Dictionary<TID, State>();
            this.currState = null;
        }


        public void Update(GameTime gameTime)
        {
            this.currState?.Update?.Invoke(gameTime);
        }


        public void SetState(TID id)
        {
            this.currState?.Exit?.Invoke();
            this.currState = this.states[id];
            this.currState?.Enter?.Invoke();
        }
    }
}
