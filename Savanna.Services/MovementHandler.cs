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
        HealthHandler healthHandler = new HealthHandler();
        PointReplacer pointReplacer = new PointReplacer();
        AnimalFinder animalFinder = new AnimalFinder();
        PointsMonitor pointsMonitor = new PointsMonitor();
        public ConsoleWriter consoleWriter = new ConsoleWriter(true);

        public void HandleMovement()
        {

            MoveAnimals(fieldHandler.field, AnimalType.Carnivore);
            Thread.Sleep(FullIterationDuration / 2);
            consoleWriter.DrawPointsFromList(fieldHandler,pointsMonitor.GetPointsToRedraw(fieldHandler.field));

            MoveAnimals(fieldHandler.field, AnimalType.Herbivore);
            Thread.Sleep(FullIterationDuration / 2);
            consoleWriter.DrawPointsFromList(fieldHandler, pointsMonitor.GetPointsToRedraw(fieldHandler.field));

            healthHandler.HandleAllAnimalHealthDecrease(fieldHandler.field);
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
                            newPosition = positionHandler.GetNewPositionByBehavior(field, animal, nearestHerbivore, oldPosition, MovingType.Pursuit);
                        }
                        else
                        {
                            newPosition = positionHandler.GetNewPositionByBehavior(field, animal, nearestCarnivore, oldPosition, MovingType.Runaway);
                        }

                        if (!MovedAnimals.Contains(oldPosition))
                        {
                            pointReplacer.ReplacePoint(field, oldPosition, newPosition);
                            MovedAnimals.Add(newPosition);
                        }
                    }
                }
            }
        }

    }
}
