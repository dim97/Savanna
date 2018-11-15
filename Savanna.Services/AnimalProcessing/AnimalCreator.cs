using Savanna.Factories;
using Savanna.Interfaces;
using Savanna.Interfaces.Services;
using Savanna.Models.Animals;

namespace Savanna.Services
{
    public class AnimalCreator : IAnimalCreator
    {
        AnimalFactory animalFactory;

        public IAnimal CreateAntilope()
        {
            animalFactory = new AnimalFactory();
            return animalFactory.CreateAnimal<Antilope>();
        }
        public IAnimal CreateLion()
        {
            animalFactory = new AnimalFactory();
            return animalFactory.CreateAnimal<Lion>();
        }
    }
}
