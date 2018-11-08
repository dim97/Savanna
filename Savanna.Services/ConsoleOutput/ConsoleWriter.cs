using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Savanna.Services
{
    public class ConsoleWriter : IConsoleWriter
    {
        private IFieldHandler _fieldHandler;
        private IField _field;

        public bool Frame { get; set; }
        public int FrameCorrection
        {
            get
            {
                if (Frame)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set { }
        }

        public ConsoleWriter(IFieldHandler fieldHandler)
        {
            Frame = true;
            _fieldHandler = fieldHandler;
            _field = fieldHandler.GameField;
        }

        public void DrawFieldToConsole()
        {
            Console.CursorVisible = false;

            if (Frame)
            {
                DrawFrame();
            }

            List<string> lines = _fieldHandler.GetFieldInStringList();
            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    Console.SetCursorPosition(j + FrameCorrection, i + FrameCorrection);
                    Console.Write(line[j]);
                }
            }
        }

        public void DrawPointsFromList(List<IDrawingPoint> listOfPoints)
        {
            List<IDrawingPoint> pointListBuffer = new List<IDrawingPoint>(listOfPoints);
            listOfPoints.Clear();

            foreach (DrawingPoint point in pointListBuffer)
            {
                RedrawCell(point.Position, point.Sign);
            }
        }

        public void DrawFrame()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write('╔');
            for (int i = 1; i < _field.Width * 2 + FrameCorrection; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('═');
            }
            Console.SetCursorPosition(_field.Width * 2 + FrameCorrection, 0);
            Console.Write('╗');
            for (int i = 1; i < _field.Heigth + FrameCorrection; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('║');
                Thread.Sleep(10);
                Console.SetCursorPosition(_field.Width * 2 + FrameCorrection, i);
                Console.Write('║');
            }
            Console.SetCursorPosition(0, _field.Heigth + FrameCorrection);
            Console.Write('╚');
            for (int i = 1; i < _field.Width * 2 + FrameCorrection; i++)
            {
                Console.SetCursorPosition(i, _field.Heigth + FrameCorrection);
                Console.Write('═');
            }
            Console.SetCursorPosition(_field.Width * 2 + FrameCorrection, _field.Heigth + FrameCorrection);
            Console.Write('╝');
        }

        public void RedrawCell(Point position, char symbol)
        {
            Console.SetCursorPosition(position.X * 2 + FrameCorrection, position.Y + FrameCorrection);
            Console.Write(symbol);
        }
    }
}
