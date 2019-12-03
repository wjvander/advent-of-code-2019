using System;
using System.Numerics;

namespace CodeKata.Day03
{
    public static class DistanceCalculator
    {
        public static int Calculate(Vector2 point1, Vector2 point2)
        {
            return (int)(Math.Abs((point1.X - point2.X)) + Math.Abs((point1.Y - point2.Y)));
        }
    }
}
