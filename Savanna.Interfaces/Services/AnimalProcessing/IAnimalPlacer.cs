using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IAnimalPlacer
    {
        void PlaceAnimalInRandomPlace(IAnimal animalToAdd);
        void PlaceAnimalInField(IAnimal animalToAdd, Point position);
    }
}
