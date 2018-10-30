using Savanna.Enums;
using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public static class MovementHandler
    {
        static List<Point> movedAnimals;
        static int seed = 1;


        public static void HandleMovement(Field field)
        {
            movedAnimals = new List<Point>();

            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.Animals[i, j] != null)
                    {
                        Point oldPosition, newPosition;
                        int animalSpeed = field.Animals[i, j].Speed;
                        oldPosition = new Point(j, i);

                        Point nearestHerbivore = SelectNearestHerbivore(field, oldPosition, field.Animals[i, j].VisionRange);

                        if ((nearestHerbivore.X != -1) && (field.Animals[i, j].Type == AnimalType.Carnivore))
                        {
                            newPosition = nearestHerbivore;
                        }
                        else
                        {
                            newPosition = GetRandomNewPosition(field, oldPosition, animalSpeed);
                        }

                        if (MoveToPoint(field, oldPosition, newPosition))
                        {
                            movedAnimals.Add(newPosition);
                        }
                    }
                }
            }
        }

        static Point GetRandomNewPosition(Field field, Point position, int animalSpeed)
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

        static Point SelectNearestHerbivore(Field field, Point position, int visionRange)
        {
            List<Point> animals = FindHerbivores(field, position, visionRange);
            Point nearestAnimal = new Point(-1, -1);

            foreach (Point animalLocation in animals)
            {
                if (nearestAnimal.X == -1)
                {
                    nearestAnimal = animalLocation;
                }
                else if (GetDistance(position, animalLocation) < GetDistance(position, nearestAnimal))
                {
                    nearestAnimal = animalLocation;
                }
            }

            return nearestAnimal;

        }

        static List<Point> FindHerbivores(Field field, Point position, int visionRange)
        {
            List<Point> animals = FindNearestAnimals(field, position, visionRange);
            List<Point> herbivores = new List<Point>();

            foreach (Point animalLocation in animals)
            {
                if (field.Animals[animalLocation.Y, animalLocation.X].Type == AnimalType.Herbivore)
                {
                    herbivores.Add(animalLocation);
                }
            }

            return herbivores;
        }

        static List<Point> FindNearestAnimals(Field field, Point position, int visionRange)
        {
            List<Point> animals = new List<Point>();

            for (int i = position.Y - visionRange; i < position.Y + visionRange; i++)
            {
                for (int j = position.X - visionRange; j < position.X + visionRange; j++)
                {
                    if (CheckFieldBorders(field, new Point(j, i)) && !CheckEmpty(field, new Point(j, i)))
                    {
                        animals.Add(new Point(j, i));
                    }
                }
            }

            return animals;
        }


        static List<Point> GetAllPositionsToMove(Field field, Point position, int animalSpeed)
        {
            List<Point> PositionsToMove = new List<Point>();

            for (int i = position.Y - animalSpeed; i < position.Y + animalSpeed + 1; i++)
            {
                for (int j = position.X - animalSpeed; j < position.X + animalSpeed + 1; j++)
                {
                    Point pointToAdd = new Point(j, i);
                    if (CheckFieldBorders(field, pointToAdd) && CheckEmpty(field, pointToAdd) && (pointToAdd != new Point(position.X, position.Y)))
                    {
                        PositionsToMove.Add(pointToAdd);
                    }
                }
            }
            return PositionsToMove;
        }

        static bool MoveToPoint(Field field, Point oldPosition, Point newPosition)
        {
            if ((oldPosition != newPosition) && CheckFieldBorders(field, newPosition) && !movedAnimals.Contains(oldPosition))
            {
                field.Animals[newPosition.Y, newPosition.X] = field.Animals[oldPosition.Y, oldPosition.X];
                field.Animals[oldPosition.Y, oldPosition.X] = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool CheckEmpty(Field field, Point position)
        {
            if (field.Animals[position.Y, position.X] != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool CheckFieldBorders(Field field, Point position)
        {
            if ((position.X < 0) || (position.Y < 0) || (position.X >= field.Width) || (position.Y >= field.Heigth))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static double GetDistance(Point A, Point B)
        {
            double result;
            result = Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));

            return result;
        }
    }
}
