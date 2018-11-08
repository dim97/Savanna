using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IAnimalPlacer
    {
        void PlaceAnimalInRandomPlace(IAnimal animalToAdd, IFieldHandler fieldHandler);
        void PlaceAnimalInField(IAnimal animalToAdd, IFieldHandler fieldHandler, Point position);
    }
}
