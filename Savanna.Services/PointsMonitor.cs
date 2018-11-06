using Savanna.Interfaces;
using Savanna.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Savanna.Services
{
    public class PointsMonitor
    {
        public Field PreviousField { get; set; } = new Field() { Width = 0 };

        public List<DrawingPoint> GetPointsToRedraw(Field field)
        {
            List<DrawingPoint> pointsToRedraw = new List<DrawingPoint>();

            if (PreviousField.Width == 0)
            {
                PreviousField = new Field()
                {
                    Width = field.Width,
                    Heigth = field.Heigth,
                    Animals = new IAnimal[field.Heigth, field.Width],
                };
                for (int i = 0; i < field.Heigth; i++)
                {
                    for (int j = 0; j < field.Width; j++)
                    {
                        PreviousField.Animals[i, j] = field.Animals[i, j];
                    }
                }
            }

            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.Animals[i, j] != PreviousField.Animals[i, j])
                    {
                        Point pointToDraw = new Point(j, i);
                        DrawingSymbols drawingSymbols = new DrawingSymbols();
                        if (field.Animals[i, j] == null)
                        {
                            PreviousField.Animals[i, j] = null;
                            pointsToRedraw.Add(new DrawingPoint(pointToDraw, drawingSymbols.EmptySpace));
                        }
                        else
                        {
                            PreviousField.Animals[i, j] = field.Animals[i, j];
                            pointsToRedraw.Add(new DrawingPoint(pointToDraw, field.Animals[i, j].Sign));
                        }
                    }
                }
            }
            return pointsToRedraw;
        }
    }
}
