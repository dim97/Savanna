using Savanna.Enums;
using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public class PositionHandler
    {
        private int _seed = 1;

        PositionChecker positionChecker = new PositionChecker();

        public Point GetRandomNewPosition(Field field, Point position, int animalSpeed)
        {
            Random random = new Random(_seed);
            _seed++;
            Point newPosition;

            List<Point> PositionsToMove = GetAllPositionsToMove(field, position, animalSpeed);

            if (PositionsToMove.Count > 0)
            {
                newPosition = PositionsToMove[random.Next(PositionsToMove.Count)];
            }
            else
            {
                newPosition = position;
            }
            return newPosition;
        }

        public Point GetSuitableNewPosition(Field field, Point currentPosition, Point desiredPosition, int animalSpeed, AnimalType animalType)
        {
            Point newPosition = new Point(currentPosition.X,currentPosition.Y);

            if (positionChecker.CheckFieldBorders(field, desiredPosition) && positionChecker.CheckSuitability(field, desiredPosition,animalType))
            {
                newPosition = desiredPosition;
            }
            else
            {
                double minimumDistance = Math.Sqrt(field.Heigth * field.Heigth + field.Width * field.Width);
                DistanceHandler distanceHandler = new DistanceHandler();
                List<Point> PositionsToMove = GetAllPositionsToMove(field, currentPosition, animalSpeed);

                foreach (Point position in PositionsToMove)
                {
                    double distance = distanceHandler.GetDistance(position, desiredPosition);
                    if (distance < minimumDistance)
                    {
                        minimumDistance = distance;
                        newPosition = position;
                    }
                }
            }

            return newPosition;
        }

        public List<Point> GetAllPositionsToMove(Field field, Point position, int animalSpeed)
        {
            List<Point> PositionsToMove = new List<Point>();

            for (int i = position.Y - animalSpeed; i < position.Y + animalSpeed + 1; i++)
            {
                for (int j = position.X - animalSpeed; j < position.X + animalSpeed + 1; j++)
                {
                    Point pointToAdd = new Point(j, i);
                    if (positionChecker.CheckFieldBorders(field, pointToAdd) && positionChecker.CheckEmpty(field, pointToAdd) && (pointToAdd != new Point(position.X, position.Y)))
                    {
                        PositionsToMove.Add(pointToAdd);
                    }
                }
            }
            return PositionsToMove;
        }

        public Point GetAnimalNextWaypoint(Field field, Point startPoint, Point destinationPoint, int speed, MovingType movingType)
        {

            DistanceHandler distanceHandler = new DistanceHandler();

            int resultX = 0, resultY = 0 ;
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
