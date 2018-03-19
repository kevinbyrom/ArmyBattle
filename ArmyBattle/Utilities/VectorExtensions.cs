using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework;


namespace ArmyBattle.Utilities
{
    public static class VectorExtensions
    {
        public static double DistanceTo(this Vector2 v1, Vector2 v2)
        {
            return TrigUtils.Distance(v1, v2);
        }


        public static float ToRadians(this Vector2 v)
        {
            var rads = (float)Math.Atan2(v.Y, v.X);
            return rads;
        }


        public static Vector2 ToVector2(this float angle)
        {
            return new Vector2((float)Math.Cos(angle), -(float)Math.Sin(angle));
        }
    }
}
