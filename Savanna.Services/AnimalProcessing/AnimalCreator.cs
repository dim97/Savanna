using Savanna.Factories;
using Savanna.Interfaces;
using Savanna.Interfaces.Services;

namespace Savanna.Services
{
    public class AnimalCreator : IAnimalCreator
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
