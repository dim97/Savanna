﻿using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;

namespace Savanna.Services
{
    public class HealthHandler : IHealthHandler
    {
        private IField _field;

        public HealthHandler(IField field)
        {
            _field = field;
        }

        public void HandleAllAnimalHealthDecrease()
        {
            for (int i = 0; i < _field.Heigth; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    IAnimal animal = _field.Animals[i, j];
                    if (animal != null)
                    {
                        if (animal.Health <= 0)
                        {
                            _field.Animals[i, j] = null;
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
