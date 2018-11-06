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
    public class AnimalFinder
    {
        PositionChecker positionChecker = new PositionChecker();

        public List<Point> FindNearestAnimals(Field field, Point position, int visionRange)
        {
            List<Point> animals = new List<Point>();

            for (int i = position.Y - visionRange; i < position.Y + visionRange; i++)
            {
                for (int j = position.X - visionRange; j < position.X + visionRange; j++)
                {
                    Point currentPoint = new Point(j, i);
                    if (positionChecker.CheckFieldBorders(field, currentPoint) && !positionChecker.CheckEmpty(field, currentPoint))
                    {
                        animals.Add(new Point(j, i));
                    }
                }
            }

            return animals;
        }
        public Point SelectNearestAnimalByType(Field field, Point position, int visionRange, AnimalType searchingAnimalType)
        {
            List<Point> animals = FindNearestAnimals(field, position, visionRange);
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
