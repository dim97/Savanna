using Savanna.Interfaces.Models;

namespace Savanna.Interfaces.Services
{
    public interface IHealthHandler
    {
        void HandleAllAnimalHealthDecrease();
        void DecreaseHealth(IAnimal animal, double value);
        void IncreaseHealth(IAnimal animal, double value);
    }
}
