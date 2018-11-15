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

        private IField _field;
        private IPositionHandler _positionHandler;
        private IPointReplacer _pointReplacer;
        private IAnimalFinder _animalFinder;

        public MovementHandler
            (
         IPositionHandler positionHandler,
         IPointReplacer pointReplacer,
         IAnimalFinder animalFinder,
         IField field
            )
        {
            _field = field;
            _positionHandler = positionHandler;
            _pointReplacer = pointReplacer;
            _animalFinder = animalFinder;
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
