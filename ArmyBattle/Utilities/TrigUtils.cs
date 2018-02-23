using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace ArmyBattle.Utilities
{
    public static class TrigUtils
    {
        public static double Distance(Vector2 v1, Vector2 v2)
        {
            float w = v2.X - v1.X;
            float h = v2.Y - v1.Y;

            return Math.Sqrt((w * w) + (h * h));
        }
    }
}
