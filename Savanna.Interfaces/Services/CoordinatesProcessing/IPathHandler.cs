using Savanna.Enums;
using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IPathHandler
    {
        Point GetAnimalNextWaypoint(Point startPoint, Point destinationPoint, MovingType movingType);
    }
}