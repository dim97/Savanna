using Savanna.Interfaces;
using Savanna.Models;
using System;
using System.Drawing;

namespace Savanna.Services
{
    public class AnimalPlacer
    {
        public Point NewAnimalPosition { get; private set; }

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
                NewAnimalPosition = new Point(randomX,randomY);
          }
        }

        public void PlaceAnimalInField(IAnimal animalToAdd, FieldHandler fieldHandler, Point position)
        {
            fieldHandler.field.Animals[position.Y, position.X] = animalToAdd;
            NewAnimalPosition = new Point(position.X, position.Y);
        }
    }
}
