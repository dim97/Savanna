using Savanna.Interfaces;
using Savanna.Models;
using System.Drawing;

namespace Savanna.Services
{
    public class HealthHandler
    {
        public void HandleAllAnimalHealthDecrease(Field field)
        {
            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    IAnimal animal = field.Animals[i, j];
                    if (animal != null)
                    {
                        if (animal.Health <= 0)
                        {
                            DrawingSymbols symbols = new DrawingSymbols();
                            field.Animals[i, j] = null;
                            //ConsoleWriter.PointsToDraw.Add(new DrawingPoint {Position = new Point(j,i),Sign = symbols.EmptySpace  });
                        }
                        else
                        {
                            DecreaseHealth(animal, 0.5);
                        }
                    }
                }
            }
        }
        public void DecreaseHealth(IAnimal animal, double value)
        {
            animal.Health -= value;
        }
        public void IncreaseHealth(IAnimal animal, double value)
        {
            animal.Health += value;
        }
    }
}
