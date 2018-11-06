using Savanna.Enums;
using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savanna.Services
{
   public class PathHandler
    {
        public Point GetAnimalNextWaypoint(Field field, Point startPoint, Point destinationPoint, int speed, MovingType movingType)
        {
            DistanceHandler distanceHandler = new DistanceHandler();

            int resultX = 0, resultY = 0;
            double distance;

            distance = distanceHandler.GetDistance(startPoint, destinationPoint);

            if (movingType == MovingType.Pursuit)
            {
                resultX = startPoint.X + (int)Math.Round((destinationPoint.X - startPoint.X) * speed / distance);
                resultY = startPoint.Y + (int)Math.Round((destinationPoint.Y - startPoint.Y) * speed / distance);
            }
            else if (movingType == MovingType.Runaway)
            {
                resultX = startPoint.X - (int)Math.Round((destinationPoint.X - startPoint.X) * speed / distance);
                resultY = startPoint.Y - (int)Math.Round((destinationPoint.Y - startPoint.Y) * speed / distance);
            }

            return new Point(resultX, resultY);
        }
    }
}
