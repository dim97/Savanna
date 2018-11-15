using Savanna.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IMovementHandler
    {
        List<Point> MovedAnimals { get; set; }
        void MoveAnimals(AnimalType type);
    }
}
