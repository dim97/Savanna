using Savanna.Interfaces.Models;
using System.Drawing;

namespace Savanna.Models
{
    public struct DrawingPoint : IDrawingPoint
    {
        public Point Position { get; set; }
        public char Sign { get; set; }

        public DrawingPoint(Point position, char sign)
        {
            Position = position;
            Sign = sign;
        }
    }
}
