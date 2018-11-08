using Savanna.Enums;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public class AnimalFinder : IAnimalFinder
    {
        private IPositionChecker _positionChecker;
        public AnimalFinder(IPositionChecker positionChecker)
        {
            _positionChecker = positionChecker;
        }

        public List<Point> FindNearestAnimals(IField field, Point position)
        {
            int visionRange = field.Animals[position.Y, position.X].VisionRange;
            List<Point> animals = new List<Point>();

            for (int i = position.Y - visionRange; i < position.Y + visionRange; i++)
            {
                for (int j = position.X - visionRange; j < position.X + visionRange; j++)
                {
                    Point currentPoint = new Point(j, i);
                    if (_positionChecker.CheckFieldBorders(currentPoint) && !_positionChecker.CheckEmpty(currentPoint))
                    {
                        animals.Add(new Point(j, i));
                    }
                }
            }

            return animals;
        }
        public Point SelectNearestAnimalByType(IField field, Point position, AnimalType searchingAnimalType)
        {
            List<Point> animals = FindNearestAnimals(field, position);
            Point nearestAnimal = new Point(-1, -1);
            DistanceHandler distanceHandler = new DistanceHandler();

            foreach (Point animal in animals)
            {
                if (field.Animals[animal.Y, animal.X].Type == searchingAnimalType)
                {
                    if (nearestAnimal.X == -1)
                    {
                        nearestAnimal = animal;
                    }
                    else if (distanceHandler.GetDistance(position, animal) < distanceHandler.GetDistance(position, nearestAnimal))
                    {
                        nearestAnimal = animal;
                    }
                }
            }
            return nearestAnimal;
        }


    }
}
