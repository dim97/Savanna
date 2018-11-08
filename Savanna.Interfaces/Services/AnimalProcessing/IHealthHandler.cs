using Savanna.Interfaces.Models;

namespace Savanna.Interfaces.Services
{
    public interface IHealthHandler
    {
        void HandleAllAnimalHealthDecrease(IField field);
        void DecreaseHealth(IAnimal animal, double value);
        void IncreaseHealth(IAnimal animal, double value);
    }
}
