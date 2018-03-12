using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ArmyBattle.Framework.Messaging;


namespace ArmyBattle.Entities
{
    public interface IWorld
    {
        bool CanEntityMoveTo(EntityBase entity, Vector2 pos);

        IEnumerable<EntityBase> GetCollisions(EntityBase source);
        
        void AddEntity(EntityBase entity);

        void RemoveEntity(EntityBase entity);

        void DispatchMessage(Message msg);
    }
}
