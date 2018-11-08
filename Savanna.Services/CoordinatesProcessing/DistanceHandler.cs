using System;
using System.Drawing;
using Savanna.Interfaces.Services;

namespace Savanna.Services
{
    public class DistanceHandler : IDistanceHandler
    {
        public double GetDistance(Point A, Point B)
        {
            double result;
            result = Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));

            return result;
        }
    }
}
