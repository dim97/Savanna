using Savanna.Interfaces.Models;
using System.Collections.Generic;

namespace Savanna.Interfaces.Services
{
    public interface IPointsMonitor
    {
        IField PreviousField { get; set; }
        List<IDrawingPoint> GetPointsToRedraw();
    }
}
