using Savanna.Interfaces;
using Savanna.Interfaces.Services;
using System;
using System.Drawing;

namespace Savanna.Services
{
    public class AnimalPlacer : IAnimalPlacer
    {
        public void PlaceAnimalInRandomPlace(IAnimal animalToAdd, IFieldHandler fieldHandler)
        {
            Random random = new Random();

            int randomX = random.Next(fieldHandler.GameField.Width);
            int randomY = random.Next(fieldHandler.GameField.Heigth);
            if (!fieldHandler.IsFull)
            {
                while ((fieldHandler.GameField.Animals[randomY, randomX] != null))
                {
                    randomX = random.Next(fieldHandler.GameField.Width);
                    randomY = random.Next(fieldHandler.GameField.Heigth);
                }

                fieldHandler.GameField.Animals[randomY, randomX] = animalToAdd;
            }
        }

        public void PlaceAnimalInField(IAnimal animalToAdd, IFieldHandler fieldHandler, Point position)
        {
            fieldHandler.GameField.Animals[position.Y, position.X] = animalToAdd;
        }
    }
}
