using Savanna.Enums;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using System;
using System.Drawing;

namespace Savanna.Services
{
    public class PathHandler : IPathHandler
    {
        IDistanceHandler _distanceHandler;
        IField _field;

        public PathHandler(IDistanceHandler distanceHandler, IField field)
        {
            _distanceHandler = distanceHandler;
            _field = field;
        }

        public Point GetAnimalNextWaypoint(Point startPoint, Point destinationPoint, MovingType movingType)
        {
            int resultX = 0, resultY = 0, speed;
            double distance;

            speed = _field.Animals[startPoint.Y, startPoint.X].Speed;

            distance = _distanceHandler.GetDistance(startPoint, destinationPoint);

            if (movingType == MovingType.Pursuit)
            {
                resultX = startPoint.X + CountPositionDelta(startPoint.X, destinationPoint.X, speed, distance);
                resultY = startPoint.Y + CountPositionDelta(startPoint.Y, destinationPoint.Y, speed, distance);
            }
            else if (movingType == MovingType.Runaway)
            {
                resultX = startPoint.X - CountPositionDelta(startPoint.X,destinationPoint.X,speed,distance);
                resultY = startPoint.Y - CountPositionDelta(startPoint.Y, destinationPoint.Y, speed, distance);
            }

            int CountPositionDelta(int from, int to,int animalSpeed, double distanceToPoint)
            {
                return (int)Math.Round((to - from) * animalSpeed / distanceToPoint);
            }

            return new Point(resultX, resultY);
        }
    }
}
