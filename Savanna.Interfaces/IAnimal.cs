using Savanna.Enums;

namespace Savanna.Interfaces
{
    public interface IAnimal
    {
        AnimalType Type { get; set; }
        double Health { get; set; }
        char Sign { get; set; }
        int Speed { get; set; }
        int VisionRange { get; set; }
    }
}
