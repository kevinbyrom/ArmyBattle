using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ArmyBattle.Utilities;
using ArmyBattle.Framework.Messaging;


namespace ArmyBattle.Entities
{
    public abstract class EntityBase : DrawableGameComponent, IMessageReceiver
    {
        public Vector2 Pos;
        public Vector2 Size;


        public SpriteBatch SpriteBatch
        {
            get
            {
                return this.Game.Services.GetService<SpriteBatch>();
            }
        }


        public IWorld World
        {
            get
            {
                return this.Game.Services.GetService<IWorld>();
            }
        }


        public Vector2 HalfSize
        {
            get
            {
                return new Vector2(this.Size.X / 2, this.Size.Y / 2);
            }
        }

        public EntityBase(Game game) : base(game)
        {
            this.Pos = Vector2.Zero;
            this.Size = new Vector2(1, 1);
        }


        public virtual bool CollidesWith(EntityBase target)
        {
            var dist = TrigUtils.Distance(target.Pos, this.Pos);

            return dist <= target.HalfSize.X + this.HalfSize.X;
        }


        public virtual void ReceiveMessage(Message msg)
        {

        }
    }
}
