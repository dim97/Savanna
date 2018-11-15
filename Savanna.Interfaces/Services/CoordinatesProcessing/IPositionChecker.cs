using Savanna.Enums;
using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IPositionChecker
    {
        bool CheckEmpty(Point position);

        bool CheckSuitability(Point position, AnimalType animalType);
       
    }
}
