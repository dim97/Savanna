using Savanna.Enums;
using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public class MovementHandler : IMovementHandler
    {
        public List<Point> MovedAnimals { get; set; }

        private readonly IField _field;
        private readonly IPositionHandler _positionHandler;
        private readonly IPointReplacer _pointReplacer;
        private readonly IAnimalFinder _animalFinder;
        private readonly IHealthHandler _healthHandler;

        public MovementHandler
            (
         IPositionHandler positionHandler,
         IPointReplacer pointReplacer,
         IAnimalFinder animalFinder,
         IHealthHandler healthHandler,
         IField field
            )
        {
            _field = field;
            _positionHandler = positionHandler;
            _pointReplacer = pointReplacer;
            _animalFinder = animalFinder;
            _healthHandler = healthHandler;
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
                        Point oldPosition = new Point(j, i);
                        Point newPosition;
                        Point nearestHerbivore = _animalFinder.SelectNearestAnimalByType(oldPosition, AnimalType.Herbivore);
                        Point nearestCarnivore = _animalFinder.SelectNearestAnimalByType(oldPosition, AnimalType.Carnivore); ;

                        if (animal.Type == AnimalType.Carnivore)
                        {
                            newPosition = _positionHandler.GetNewPositionByBehavior(animal, nearestHerbivore, oldPosition, MovingType.Pursuit);
                            if (((_field.Animals[newPosition.Y, newPosition.X]!=null)&&(_field.Animals[newPosition.Y, newPosition.X].Type == AnimalType.Herbivore)))
                            {
                                _healthHandler.IncreaseHealth(animal,10);
                            }
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
