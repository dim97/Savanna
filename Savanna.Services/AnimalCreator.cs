using Savanna.Factories;
using Savanna.Interfaces;

namespace Savanna.Services
{
    public class AnimalCreator
    {
        AnimalFactory animalFactory;

        public IAnimal CreateAntilope()
        {
            animalFactory = new AntilopeFactory();
            return animalFactory.CreateAnimal();
        }
        public IAnimal CreateLion()
        {
            animalFactory = new LionFactory();
            return animalFactory.CreateAnimal();
        }
    }
}
