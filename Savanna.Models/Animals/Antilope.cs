using Savanna.Enums;
using Savanna.Interfaces;

namespace Savanna.Models.Animals
{
    public class Antilope : IAnimal
    {
        public int Health { get { return 1; } set { } }
        public int Speed { get { return 1; } set { } }
        public int VisionRange { get { return 3; } set { } }
        public char Sign { get { return 'A'; } set { } }
        public AnimalType Type { get { return AnimalType.Herbivore; } set { } }
    }
}
