using Savanna.Enums;
using Savanna.Interfaces;

namespace Savanna.Models.Animals
{
    public class Lion : IAnimal
    {
        public double Health { get; set; } = 10;
        public int Speed { get; set; } = 2;
        public int VisionRange { get; set; } = 30;
        public char Sign { get; set; } = 'L';
        public AnimalType Type { get; set; } = AnimalType.Carnivore;
    }
}
