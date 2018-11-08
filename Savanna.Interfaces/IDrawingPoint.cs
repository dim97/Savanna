using System.Drawing;

namespace Savanna.Interfaces.Models
{
    public interface IDrawingPoint
    {
        Point Position { get; set; }
        char Sign { get; set; }
    }
}
