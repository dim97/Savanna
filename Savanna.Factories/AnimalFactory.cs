using Savanna.Interfaces;
using Savanna.Models.Animals;

namespace Savanna.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreateAnimal<T>()
        {
            System.Type type = typeof(T);

            if (type == typeof(Antilope))
            {
                return new Antilope();
            }
            else if (type == typeof(Lion))
            {
                return new Lion();
            }
            else
            {
                return null;
            }
        }
    }
}


