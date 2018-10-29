using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public static class MovementHandler
    {
        static List<Point> movedAnimals;

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

        public static Point GetRandomNewPosition(Field field, Point oldPosition, int animalSpeed)
        {
            Random random = new Random();

            Point newPosition;

            newPosition = new Point(oldPosition.X + random.Next(-animalSpeed, animalSpeed + 1), oldPosition.Y + random.Next(-animalSpeed, animalSpeed + 1));

            return newPosition;
        }

        public static bool MoveToPoint(Field field, Point oldPosition, Point newPosition)
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

        public static bool CheckFieldBorders(Field field, Point newPosition)
        {
            if ((newPosition.X < 0) || (newPosition.Y < 0) || (newPosition.X >= field.Width) || (newPosition.Y >= field.Heigth))
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
