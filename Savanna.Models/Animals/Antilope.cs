using Savanna.Enums;
using Savanna.Interfaces;

namespace Savanna.Models.Animals
{
    public class Antilope : IAnimal
    {
        public double Health { get; set; } = 10;
        public int Speed { get; set; } = 1;
        public int VisionRange { get; set; } = 20;
        public char Sign { get; set; } = 'A';
        public AnimalType Type { get; set; } = AnimalType.Herbivore;
    }
}
