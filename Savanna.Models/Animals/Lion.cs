using Savanna.Enums;
using Savanna.Interfaces;

namespace Savanna.Models.Animals
{
    public class Lion : IAnimal
    {
        public int Health { get { return 3; } set { } }
        public int Speed { get { return 2; } set { } }
        public int VisionRange { get { return 40; } set { } }
        public char Sign { get { return 'L'; } set { } }
        public AnimalType Type { get { return AnimalType.Carnivore; } set { } }

    }
}
