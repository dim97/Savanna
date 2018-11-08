using Savanna.Interfaces.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Interfaces.Services
{
    public interface IConsoleWriter
    {
        bool Frame { get; set; }
        int FrameCorrection { get; set; }
        void DrawFieldToConsole();
        void DrawPointsFromList(List<IDrawingPoint> listOfPoints);
        void DrawFrame();
        void RedrawCell(Point position, char symbol);
    }
}
