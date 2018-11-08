using Savanna.Enums;
using Savanna.Interfaces.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IAnimalFinder
    {
        List<Point> FindNearestAnimals(IField field, Point position);
        Point SelectNearestAnimalByType(IField field, Point position, AnimalType searchingAnimalType);
    }
}
