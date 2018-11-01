using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savanna.Services
{
    public class DistanceHandler
    {
        public double GetDistance(Point A, Point B)
        {
            double result;
            result = Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));

            return result;
        }
    }
}
