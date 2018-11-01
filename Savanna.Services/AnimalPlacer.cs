using Savanna.Interfaces;
using Savanna.Models;
using System;
using System.Drawing;

namespace Savanna.Services
{
    public class AnimalPlacer
    {
        public void PlaceAnimalInRandomPlace(IAnimal animalToAdd, FieldHandler fieldHandler)
        {
            Random random = new Random();

            int randomX = random.Next(fieldHandler.field.Width);
            int randomY = random.Next(fieldHandler.field.Heigth);
            if (!fieldHandler.IsFull)
            {
                while ((fieldHandler.field.Animals[randomY, randomX] != null))
                {
                    randomX = random.Next(fieldHandler.field.Width);
                    randomY = random.Next(fieldHandler.field.Heigth);
                }

                fieldHandler.field.Animals[randomY, randomX] = animalToAdd;
            }
        }

        public void PlaceAnimalInField(IAnimal animalToAdd, Field field, Point position)
        {
            field.Animals[position.Y, position.X] = animalToAdd;
        }
    }
}
