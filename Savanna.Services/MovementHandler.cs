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
        static Point oldPosition, newPosition;

        public static void HandleMovement(Field field)
        {
            movedAnimals = new List<Point>();

            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.Animals[i, j] != null)
                    {
                        int animalSpeed = field.Animals[i, j].Speed;
                        oldPosition = new Point(j, i);
                        newPosition = GetRandomNewPosition(field, oldPosition, animalSpeed);

                        if (MoveToPoint(field, oldPosition, newPosition))
                        {
                            movedAnimals.Add(newPosition);
                        }
                    }
                }
            }
        }

        static Point GetRandomNewPosition(Field field, Point oldPosition, int animalSpeed)
        {

            Random random = new Random(seed);
            seed++;
            Point newPosition;

            List<Point> PositionsToMove = GetAllPositionsToMove(field, oldPosition, animalSpeed);

            if (PositionsToMove.Count > 0)
            {
                newPosition = PositionsToMove[random.Next(PositionsToMove.Count)];
            }
            else
            {
                newPosition = oldPosition;
            }
            return newPosition;
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
    }
}
