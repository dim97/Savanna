using Savanna.Interfaces;
using Savanna.Interfaces.Services;
using System;
using System.Drawing;

namespace Savanna.Services
{
    public class AnimalPlacer : IAnimalPlacer
    {
        private IFieldHandler _fieldHandler;

        public AnimalPlacer(IFieldHandler fieldHandler)
        {
            _fieldHandler = fieldHandler;
        }

        public void PlaceAnimalInRandomPlace(IAnimal animalToAdd)
        {
            Random random = new Random();

            int randomX = random.Next(_fieldHandler.GameField.Width);
            int randomY = random.Next(_fieldHandler.GameField.Heigth);
            if (!_fieldHandler.IsFull)
            {
                while ((_fieldHandler.GameField.Animals[randomY, randomX] != null))
                {
                    randomX = random.Next(_fieldHandler.GameField.Width);
                    randomY = random.Next(_fieldHandler.GameField.Heigth);
                }

                _fieldHandler.GameField.Animals[randomY, randomX] = animalToAdd;
            }
        }

        public void PlaceAnimalInField(IAnimal animalToAdd, Point position)
        {
            _fieldHandler.GameField.Animals[position.Y, position.X] = animalToAdd;
        }
    }
}
