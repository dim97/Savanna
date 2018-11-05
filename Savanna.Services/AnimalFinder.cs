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
                    if (positionChecker.CheckFieldBorders(field, new Point(j, i)) && !positionChecker.CheckEmpty(field, new Point(j, i)))
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

            foreach (Point animalLocation in animals)
            {
                if (field.Animals[animalLocation.Y, animalLocation.X].Type == searchingAnimalType)
                {
                    if (nearestAnimal.X == -1)
                    {
                        nearestAnimal = animalLocation;
                    }
                    else if (distanceHandler.GetDistance(position, animalLocation) < distanceHandler.GetDistance(position, nearestAnimal))
                    {
                        nearestAnimal = animalLocation;
                    }
                }
            }
            return nearestAnimal;
        }


    }
}
