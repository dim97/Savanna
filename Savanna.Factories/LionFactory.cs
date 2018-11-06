using Savanna.Interfaces;
using Savanna.Models.Animals;

namespace Savanna.Factories
{
    public class LionFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Lion();
        }
    }
}
