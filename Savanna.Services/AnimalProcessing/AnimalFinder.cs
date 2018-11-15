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
        private IField _field;
        private IDistanceHandler _distanceHandler;

        public AnimalFinder(IField field, IPositionChecker positionChecker,IDistanceHandler distanceHandler)
        {
            _positionChecker = positionChecker;
            _field = field;
            _distanceHandler = distanceHandler;
        }

        public List<Point> FindNearestAnimals(Point position)
        {
            int visionRange = _field.Animals[position.Y, position.X].VisionRange;
            List<Point> animals = new List<Point>();

            for (int i = position.Y - visionRange; i < position.Y + visionRange; i++)
            {
                for (int j = position.X - visionRange; j < position.X + visionRange; j++)
                {
                    Point currentPoint = new Point(j, i);
                    if ((position!=currentPoint)&&
                        (currentPoint.X >= 0) && (currentPoint.Y >= 0) && (currentPoint.X < _field.Width) && (currentPoint.Y < _field.Heigth) && 
                        !_positionChecker.CheckEmpty(currentPoint))
                    {
                        animals.Add(new Point(j, i));
                    }
                }
            }

            return animals;
        }
        public Point SelectNearestAnimalByType(Point position, AnimalType searchingAnimalType)
        {
            List<Point> animals = FindNearestAnimals(position);
            Point nearestAnimal = new Point(-1, -1);

            foreach (Point animal in animals)
            {
                if (_field.Animals[animal.Y, animal.X].Type == searchingAnimalType)
                {

                    if (nearestAnimal.X == -1)
                    {
                        nearestAnimal = animal;
                    }
                    else if (_distanceHandler.GetDistance(position, animal) < _distanceHandler.GetDistance(position, nearestAnimal))
                    {
                        nearestAnimal = animal;
                    }
                }
            }
            return nearestAnimal;
        }


    }
}
