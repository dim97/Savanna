using Savanna.Enums;

namespace Savanna.Interfaces
{
    public interface IAnimal
    {
        AnimalType Type { get; set; }
        int Health { get; set; }
        char Sign { get; set; }
        int Speed { get; set; }
        int ViewingRadius { get; set; }
    }
}
