using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IPointReplacer
    {
        void ReplacePoint(Point oldPosition, Point newPosition);
    }
}
