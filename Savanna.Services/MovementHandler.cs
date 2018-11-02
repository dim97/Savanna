using Savanna.Enums;
using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Savanna.Services
{
    public class MovementHandler
    {

        List<Point> movedAnimals;
        int fullIterationDuration = 500;

        public FieldHandler fieldHandler = new FieldHandler();
        PositionHandler positionHandler = new PositionHandler();
        PositionChecker positionChecker = new PositionChecker();
        public ConsoleWriter consoleWriter = new ConsoleWriter(true);

        public void HandleMovement()
        {
            MoveAnimals(fieldHandler.field, AnimalType.Carnivore);
            Thread.Sleep(fullIterationDuration / 2);
            consoleWriter.DrawPointsFromList(fieldHandler);
            MoveAnimals(fieldHandler.field, AnimalType.Herbivore);
            Thread.Sleep(fullIterationDuration / 2);
            consoleWriter.DrawPointsFromList(fieldHandler);
        }

        private void MoveAnimals(Field field, AnimalType type)
        {
            movedAnimals = new List<Point>();

            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if ((field.Animals[i, j] != null) && (field.Animals[i, j].Type == type))
                    {
                        int animalSpeed = field.Animals[i, j].Speed;
                        Point oldPosition = new Point(j, i);
                        Point newPosition = positionHandler.GetRandomNewPosition(field, oldPosition, animalSpeed);
                        Point nearestHerbivore = positionHandler.SelectNearestAnimalByType(field, oldPosition, field.Animals[i, j].VisionRange, AnimalType.Herbivore);
                        Point nearestCarnivore = positionHandler.SelectNearestAnimalByType(field, oldPosition, field.Animals[i, j].VisionRange, AnimalType.Carnivore); ;
                        if (field.Animals[i, j].Type == AnimalType.Carnivore)
                        {
                            if ((nearestHerbivore.X != -1) && (new DistanceHandler().GetDistance(oldPosition, nearestHerbivore) <= field.Animals[i, j].VisionRange))
                            {
                                if (new DistanceHandler().GetDistance(oldPosition, nearestHerbivore) <= field.Animals[i, j].Speed)
                                {

                                    MoveToPoint(field, oldPosition, nearestHerbivore);
                                }
                                else
                                {
                                    newPosition = GetAnimalNextWaypoint(field, oldPosition, nearestHerbivore, field.Animals[i, j].Speed, MovingType.Pursuit);
                                }
                            }
                            else
                            {
                                newPosition = positionHandler.GetRandomNewPosition(field, oldPosition, animalSpeed);
                            }
                        }
                        if (field.Animals[i, j].Type == AnimalType.Herbivore)
                        {
                            if ((nearestCarnivore.X != -1) && (new DistanceHandler().GetDistance(oldPosition, nearestCarnivore) <= field.Animals[i, j].VisionRange))
                            {
                                if (new DistanceHandler().GetDistance(oldPosition, nearestCarnivore) <= field.Animals[i, j].Speed)
                                {
                                    MoveToPoint(field, oldPosition, nearestHerbivore);
                                }
                                else
                                {
                                    newPosition = GetAnimalNextWaypoint(field, oldPosition, nearestCarnivore, field.Animals[i, j].Speed, MovingType.Runaway);
                                }
                            }
                            else
                            {
                                newPosition = positionHandler.GetRandomNewPosition(field, oldPosition, animalSpeed);
                            }
                        }


                        if (MoveToPoint(field, oldPosition, newPosition))
                        {
                            movedAnimals.Add(newPosition);
                        }
                    }
                }
            }
        }

        private Point GetAnimalNextWaypoint(Field field, Point startPoint, Point destinationPoint, int speed,MovingType movingType)
        {
            Point result;
            int resultX=0, resultY=0, stepsCount;
            double distance;

            distance = new DistanceHandler().GetDistance(startPoint, destinationPoint);
            stepsCount = (int)Math.Ceiling(distance / speed);

            if (movingType == MovingType.Pursuit)
            {
                resultX = startPoint.X + (destinationPoint.X - startPoint.X) * speed / stepsCount;
                resultY = startPoint.Y + (destinationPoint.Y - startPoint.Y) * speed / stepsCount;
            }
            if (movingType == MovingType.Runaway)
            {
                resultX = startPoint.X - (destinationPoint.X - startPoint.X) * speed / stepsCount;
                resultY = startPoint.Y - (destinationPoint.Y - startPoint.Y) * speed / stepsCount;
            }

            result = new Point(resultX, resultY);

            return result;
        }

        private bool MoveToPoint(Field field, Point oldPosition, Point newPosition)
        {
            if ((field.Animals[oldPosition.Y, oldPosition.X]!=null) && (oldPosition != newPosition) && positionChecker.CheckFieldBorders(field, newPosition) && !movedAnimals.Contains(oldPosition))
            {
                field.Animals[newPosition.Y, newPosition.X] = field.Animals[oldPosition.Y, oldPosition.X];
                ConsoleWriter.PointsToDraw.Add(new DrawingPoint() { Position = newPosition, Sign = field.Animals[newPosition.Y, newPosition.X].Sign });
                field.Animals[oldPosition.Y, oldPosition.X] = null;
                ConsoleWriter.PointsToDraw.Add(new DrawingPoint() { Position = oldPosition, Sign = ConsoleWriter.EmptySpace });
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
