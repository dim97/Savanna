using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using System.Drawing;

namespace Savanna.Services
{
    public class PointReplacer : IPointReplacer
    {
        private IPositionChecker _positionChecker;
        private IField _field;

        public PointReplacer(IPositionChecker positionChecker, IField field)
        {
            _positionChecker = positionChecker;
            _field = field;
        }

        public void ReplacePoint(Point oldPosition, Point newPosition)
        {
            if ((_field.Animals[oldPosition.Y, oldPosition.X] != null) && (oldPosition != newPosition))
            {
                if ((newPosition.X >= 0) && (newPosition.Y >= 0) && (newPosition.X < _field.Width) && (newPosition.Y < _field.Heigth))
                {
                    _field.Animals[newPosition.Y, newPosition.X] = _field.Animals[oldPosition.Y, oldPosition.X];
                    _field.Animals[oldPosition.Y, oldPosition.X] = null;
                }
            }
        }

    }
}
