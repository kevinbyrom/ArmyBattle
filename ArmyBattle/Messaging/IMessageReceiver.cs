using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBattle.Messaging
{
    interface IMessageReceiver
    {
        void ReceiveMessage(Message msg);
    }
}
