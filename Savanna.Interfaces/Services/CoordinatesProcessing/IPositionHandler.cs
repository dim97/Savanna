using Savanna.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IPositionHandler
    {
        Point GetRandomNewPosition(Point position);

        Point GetSuitableNewPosition(Point currentPosition, Point desiredPosition, AnimalType animalType);

        Point GetNewPositionByBehavior(IAnimal animal, Point nearestAnimal, Point oldPosition, MovingType movingType);

        List<Point> GetAllPositionsToMove(Point position);

    }
}
