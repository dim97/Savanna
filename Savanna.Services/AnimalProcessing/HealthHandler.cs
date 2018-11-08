using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;

namespace Savanna.Services
{
    public class HealthHandler : IHealthHandler
    {
        public void HandleAllAnimalHealthDecrease(IField field)
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
                            field.Animals[i, j] = null;
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
