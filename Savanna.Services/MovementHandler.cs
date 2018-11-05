using Savanna.Enums;
using Savanna.Interfaces;
using Savanna.Models;

using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Savanna.Services
{
    public class MovementHandler
    {
        List<Point> MovedAnimals { get; set; }
        public int FullIterationDuration { get; set; } = 500;

        public FieldHandler fieldHandler = new FieldHandler();
        PositionHandler positionHandler = new PositionHandler();
        PositionChecker positionChecker = new PositionChecker();
        AnimalFinder animalFinder = new AnimalFinder();
        public ConsoleWriter consoleWriter = new ConsoleWriter(true);

        public void HandleMovement()
        {
            MoveAnimals(fieldHandler.field, AnimalType.Carnivore);
            Thread.Sleep(FullIterationDuration / 2);
            consoleWriter.DrawPointsFromList(fieldHandler);
            MoveAnimals(fieldHandler.field, AnimalType.Herbivore);
            Thread.Sleep(FullIterationDuration / 2);
            consoleWriter.DrawPointsFromList(fieldHandler);
        }

        private void MoveAnimals(Field field, AnimalType type)
        {
            MovedAnimals = new List<Point>();

            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    IAnimal animal = field.Animals[i, j];

                    if ((animal != null) && (animal.Type == type))
                    {
                        int animalSpeed = animal.Speed;
                        Point oldPosition = new Point(j, i);
                        Point newPosition;
                        Point nearestHerbivore = animalFinder.SelectNearestAnimalByType(field, oldPosition, animal.VisionRange, AnimalType.Herbivore);
                        Point nearestCarnivore = animalFinder.SelectNearestAnimalByType(field, oldPosition, animal.VisionRange, AnimalType.Carnivore); ;

                        if (animal.Type == AnimalType.Carnivore)
                        {
                            newPosition = GetNewPositionByBehavior(field,animal,nearestHerbivore,oldPosition, MovingType.Pursuit);
                        }
                        else
                        {
                            newPosition = GetNewPositionByBehavior(field, animal, nearestCarnivore, oldPosition, MovingType.Runaway);
                        }

                        if (MoveToPoint(field, oldPosition, newPosition))
                        {
                            MovedAnimals.Add(newPosition);
                        }
                    }
                }
            }
        }

        private Point GetNewPositionByBehavior(Field field, IAnimal animal,Point nearestAnimal ,Point oldPosition ,MovingType movingType)
        {
            Point newPosition = oldPosition;

            if ((nearestAnimal.X != -1) && (new DistanceHandler().GetDistance(oldPosition, nearestAnimal) <= animal.VisionRange))
            {
                if ((new DistanceHandler().GetDistance(oldPosition, nearestAnimal) <= animal.Speed)&&(animal.Type==AnimalType.Carnivore))
                {
                    newPosition = nearestAnimal;
                }
                else
                {
                    Point desiredPosition = positionHandler.GetAnimalNextWaypoint(field, oldPosition, nearestAnimal, animal.Speed, movingType);
                    newPosition = positionHandler.GetSuitableNewPosition(field, oldPosition, desiredPosition, animal.Speed, animal.Type);
                }
            }
            else
            {
                newPosition = positionHandler.GetRandomNewPosition(field, oldPosition, animal.Speed);
            }

            return newPosition;
        }

        private bool MoveToPoint(Field field, Point oldPosition, Point newPosition)
        {
            if ((field.Animals[oldPosition.Y, oldPosition.X] != null) && (oldPosition != newPosition) && positionChecker.CheckFieldBorders(field, newPosition) && !MovedAnimals.Contains(oldPosition))
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
