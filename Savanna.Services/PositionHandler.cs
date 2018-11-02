using Savanna.Enums;
using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public class PositionHandler
    {
        int seed = 1;

        PositionChecker positionChecker = new PositionChecker();

        public Point GetRandomNewPosition(Field field, Point position, int animalSpeed)
        {
            Random random = new Random(seed);
            seed++;
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

        public Point SelectNearestAnimalByType(Field field, Point position, int visionRange, AnimalType searchingAnimalType)
        {
            List<Point> animals = FindNearestAnimals(field, position, visionRange);
            Point nearestAnimal = new Point(-1, -1);
            DistanceHandler distanceHandler = new DistanceHandler();

            foreach (Point animalLocation in animals)
            {
                if (field.Animals[animalLocation.Y,animalLocation.X].Type==searchingAnimalType)
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

        //public Point SelectNearestHerbivore(Field field, Point position, int visionRange)
        //{
        //    List<Point> animals = FindHerbivores(field, position, visionRange);
        //    Point nearestAnimal = new Point(-1, -1);
        //    DistanceHandler distanceHandler = new DistanceHandler();

        //    foreach (Point animalLocation in animals)
        //    {
        //        if (nearestAnimal.X == -1)
        //        {
        //            nearestAnimal = animalLocation;
        //        }
        //        else if (distanceHandler.GetDistance(position, animalLocation) < distanceHandler.GetDistance(position, nearestAnimal))
        //        {
        //            nearestAnimal = animalLocation;
        //        }
        //    }

        //    return nearestAnimal;

        //}

        //public Point SelectNearestCarnivore(Field field, Point position, int visionRange)
        //{
        //    List<Point> animals = FindCarnivores(field, position, visionRange);
        //    Point nearestAnimal = new Point(-1, -1);
        //    DistanceHandler distanceHandler = new DistanceHandler();

        //    foreach (Point animalLocation in animals)
        //    {
        //        if (nearestAnimal.X == -1)
        //        {
        //            nearestAnimal = animalLocation;
        //        }
        //        else if (distanceHandler.GetDistance(position, animalLocation) < distanceHandler.GetDistance(position, nearestAnimal))
        //        {
        //            nearestAnimal = animalLocation;
        //        }
        //    }

        //    return nearestAnimal;

        //}

        //List<Point> FindHerbivores(Field field, Point position, int visionRange)
        //{
        //    List<Point> animals = FindNearestAnimals(field, position, visionRange);
        //    List<Point> herbivores = new List<Point>();

        //    foreach (Point animalLocation in animals)
        //    {
        //        if (field.Animals[animalLocation.Y, animalLocation.X].Type == AnimalType.Herbivore)
        //        {
        //            herbivores.Add(animalLocation);
        //        }
        //    }

        //    return herbivores;
        //}

        //List<Point> FindCarnivores(Field field, Point position, int visionRange)
        //{
        //    List<Point> animals = FindNearestAnimals(field, position, visionRange);
        //    List<Point> carnivores = new List<Point>();

        //    foreach (Point animalLocation in animals)
        //    {
        //        if (field.Animals[animalLocation.Y, animalLocation.X].Type == AnimalType.Carnivore)
        //        {
        //            carnivores.Add(animalLocation);
        //        }
        //    }

        //    return carnivores;
        //}

        List<Point> FindNearestAnimals(Field field, Point position, int visionRange)
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

        List<Point> GetAllPositionsToMove(Field field, Point position, int animalSpeed)
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
