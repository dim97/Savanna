using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public class PointsMonitor : IPointsMonitor
    {
        private IField _field;

        public IField PreviousField { get; set; } = new Field() { Width = 0 };

        public PointsMonitor(IField field)
        {
            _field = field;
        }

        public List<IDrawingPoint> GetPointsToRedraw()
        {
            List<IDrawingPoint> pointsToRedraw = new List<IDrawingPoint>();

            if (PreviousField.Width == 0)
            {
                PreviousField = new Field()
                {
                    Width = _field.Width,
                    Heigth = _field.Heigth,
                    Animals = new IAnimal[_field.Heigth, _field.Width],
                };
                for (int i = 0; i < _field.Heigth; i++)
                {
                    for (int j = 0; j < _field.Width; j++)
                    {
                        PreviousField.Animals[i, j] = _field.Animals[i, j];
                    }
                }
            }

            for (int i = 0; i < _field.Heigth; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    if (_field.Animals[i, j] != PreviousField.Animals[i, j])
                    {
                        Point pointToDraw = new Point(j, i);
                        DrawingSymbols drawingSymbols = new DrawingSymbols();
                        if (_field.Animals[i, j] == null)
                        {
                            PreviousField.Animals[i, j] = null;
                            pointsToRedraw.Add(new DrawingPoint(pointToDraw, drawingSymbols.EmptySpace));
                        }
                        else
                        {
                            PreviousField.Animals[i, j] = _field.Animals[i, j];
                            pointsToRedraw.Add(new DrawingPoint(pointToDraw, _field.Animals[i, j].Sign));
                        }
                    }
                }
            }
            return pointsToRedraw;
        }
    }
}
