using Savanna.Models;
using System.Drawing;

namespace Savanna.Services
{
    public class PointReplacer
    {
        PositionChecker positionChecker = new PositionChecker();

        public void ReplacePoint(Field field, Point oldPosition, Point newPosition)
        {
            if ((field.Animals[oldPosition.Y, oldPosition.X] != null) && (oldPosition != newPosition))
            {
                if (positionChecker.CheckFieldBorders(field, newPosition))
                {
                    field.Animals[newPosition.Y, newPosition.X] = field.Animals[oldPosition.Y, oldPosition.X];
                    field.Animals[oldPosition.Y, oldPosition.X] = null;
                }
            }
        }

    }
}
