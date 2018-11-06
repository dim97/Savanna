using Savanna.Enums;
using Savanna.Interfaces;
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

        public Point GetNewPositionByBehavior(Field field, IAnimal animal, Point nearestAnimal, Point oldPosition, MovingType movingType)
        {
            PathHandler pathHandler = new PathHandler();
            Point newPosition = oldPosition;
            DistanceHandler distanceHandler = new DistanceHandler();

            if ((nearestAnimal.X != -1) && (distanceHandler.GetDistance(oldPosition, nearestAnimal) <= animal.VisionRange))
            {
                if ((distanceHandler.GetDistance(oldPosition, nearestAnimal) <= animal.Speed) && (animal.Type == AnimalType.Carnivore))
                {
                    newPosition = nearestAnimal;
                }
                else
                {
                    Point desiredPosition = pathHandler.GetAnimalNextWaypoint(field, oldPosition, nearestAnimal, animal.Speed, movingType);
                    newPosition = GetSuitableNewPosition(field, oldPosition, desiredPosition, animal.Speed, animal.Type);
                }
            }
            else
            {
                newPosition = GetRandomNewPosition(field, oldPosition, animal.Speed);
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

    }
}
