﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace ArmyBattle.Framework.States
{
    public class State
    {
        public Action Enter { get; set; }
        public Action<GameTime> Update { get; set; }
        public Action Exit { get; set; }

        public State()
        {
            
        }

        public State OnEnter(Action enter) { this.Enter = enter; return this; }
        public State OnUpdate(Action<GameTime> update) { this.Update = update; return this; }
        public State OnExit(Action exit) { this.Exit = exit; return this; }
    }
}
