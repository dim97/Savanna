using Savanna.Enums;
using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Savanna.Services
{
    public class MovementHandler : IMovementHandler
    {
        public List<Point> MovedAnimals { get; set; }
        public int FullIterationDuration { get; set; } = 500;

        private IFieldHandler _fieldHandler;
        private IField _field;
        private IPositionHandler _positionHandler;
        private IHealthHandler _healthHandler;
        private IPointReplacer _pointReplacer;
        private IAnimalFinder _animalFinder;
        private IPointsMonitor _pointsMonitor;
        private IConsoleWriter _consoleWriter;

        public MovementHandler
            (
         IFieldHandler fieldHandler,
         IPositionHandler positionHandler,
         IHealthHandler healthHandler,
         IPointReplacer pointReplacer,
         IAnimalFinder animalFinder,
         IPointsMonitor pointsMonitor,
         IConsoleWriter consoleWriter
            )
        {
            _fieldHandler = fieldHandler;
            _field = fieldHandler.GameField;
            _positionHandler = positionHandler;
            _healthHandler = healthHandler;
            _pointReplacer = pointReplacer;
            _animalFinder = animalFinder;
            _pointsMonitor = pointsMonitor;
            _consoleWriter = consoleWriter;
        }

        public void HandleMovement()
        {
            MoveAnimals(AnimalType.Carnivore);
            Thread.Sleep(FullIterationDuration / 2);
            _consoleWriter.DrawPointsFromList(_pointsMonitor.GetPointsToRedraw());

            MoveAnimals(AnimalType.Herbivore);
            Thread.Sleep(FullIterationDuration / 2);
            _consoleWriter.DrawPointsFromList(_pointsMonitor.GetPointsToRedraw());

            _healthHandler.HandleAllAnimalHealthDecrease(_fieldHandler.GameField);
        }

        public void MoveAnimals(AnimalType type)
        {
            MovedAnimals = new List<Point>();

            for (int i = 0; i < _field.Heigth; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    IAnimal animal = _field.Animals[i, j];

                    if ((animal != null) && (animal.Type == type))
                    {
                        int animalSpeed = animal.Speed;
                        Point oldPosition = new Point(j, i);
                        Point newPosition;
                        Point nearestHerbivore = _animalFinder.SelectNearestAnimalByType(_field, oldPosition, AnimalType.Herbivore);
                        Point nearestCarnivore = _animalFinder.SelectNearestAnimalByType(_field, oldPosition, AnimalType.Carnivore); ;

                        if (animal.Type == AnimalType.Carnivore)
                        {
                            newPosition = _positionHandler.GetNewPositionByBehavior(animal, nearestHerbivore, oldPosition, MovingType.Pursuit);
                        }
                        else
                        {
                            newPosition = _positionHandler.GetNewPositionByBehavior(animal, nearestCarnivore, oldPosition, MovingType.Runaway);
                        }
                        if (!MovedAnimals.Contains(oldPosition))
                        {
                            _pointReplacer.ReplacePoint(oldPosition, newPosition);
                            MovedAnimals.Add(newPosition);
                        }
                    }
                }
            }
        }

    }
}
