using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace ArmyBattle.Framework.States
{
    public interface IState
    {
        void Initialize();
        void Enter();
        void Update(GameTime gameTime);
        void Exit();
    }
}
