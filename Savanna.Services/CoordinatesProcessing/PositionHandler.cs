using Savanna.Enums;
using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public class PositionHandler : IPositionHandler
    {
        private int _seed = 1;
        private int _animalSpeed;
        private IPositionChecker _positionChecker;
        private IField _field;
        private IPathHandler _pathHandler;

        public PositionHandler(IPositionChecker positionChecker, IField field, IPathHandler pathHandler)
        {
            _positionChecker = positionChecker;
            _field = field;
            _pathHandler = pathHandler;
        }

        public Point GetRandomNewPosition(Point position)
        {
            _animalSpeed = _field.Animals[position.Y, position.X].Speed;

            Random random = new Random(_seed);
            _seed++;
            Point newPosition;

            List<Point> PositionsToMove = GetAllPositionsToMove(position);

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

        public Point GetSuitableNewPosition(Point currentPosition, Point desiredPosition, AnimalType animalType)
        {
            Point newPosition = new Point(currentPosition.X, currentPosition.Y);

            if (_positionChecker.CheckFieldBorders(desiredPosition) && _positionChecker.CheckSuitability(desiredPosition, animalType))
            {
                newPosition = desiredPosition;
            }
            else
            {
                double minimumDistance = Math.Sqrt(_field.Heigth * _field.Heigth + _field.Width * _field.Width);
                DistanceHandler distanceHandler = new DistanceHandler();
                List<Point> PositionsToMove = GetAllPositionsToMove(currentPosition);

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

        public Point GetNewPositionByBehavior(IAnimal animal, Point nearestAnimal, Point oldPosition, MovingType movingType)
        {
            _animalSpeed = _field.Animals[oldPosition.Y, oldPosition.X].Speed;
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
                    Point desiredPosition = _pathHandler.GetAnimalNextWaypoint(oldPosition, nearestAnimal, movingType);
                    newPosition = GetSuitableNewPosition(oldPosition, desiredPosition, animal.Type);
                }
            }
            else
            {
                newPosition = GetRandomNewPosition(oldPosition);
            }

            return newPosition;
        }

        public List<Point> GetAllPositionsToMove(Point position)
        {
            _animalSpeed = _field.Animals[position.Y, position.X].Speed;

            List<Point> PositionsToMove = new List<Point>();

            for (int i = position.Y - _animalSpeed; i < position.Y + _animalSpeed + 1; i++)
            {
                for (int j = position.X - _animalSpeed; j < position.X + _animalSpeed + 1; j++)
                {
                    Point pointToAdd = new Point(j, i);
                    if (_positionChecker.CheckFieldBorders(pointToAdd) && _positionChecker.CheckEmpty(pointToAdd) && (pointToAdd != new Point(position.X, position.Y)))
                    {
                        PositionsToMove.Add(pointToAdd);
                    }
                }
            }
            return PositionsToMove;
        }

    }
}
