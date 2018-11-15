using Savanna.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IAnimalFinder
    {
        List<Point> FindNearestAnimals(Point position);
        Point SelectNearestAnimalByType(Point position, AnimalType searchingAnimalType);
    }
}
