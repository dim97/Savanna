using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Savanna.Services
{
    public class ConsoleWriter
    {
        public static List<DrawingPoint> PointsToDraw = new List<DrawingPoint>();

        public bool Frame { get; private set; }
        public static char EmptySpace = ' ';
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
        }

        public ConsoleWriter(bool frame)
        {
            Frame = frame;
        }

        public void DrawFieldToConsole(FieldHandler fieldHandler)
        {
            Console.CursorVisible = false;

            if (Frame)
            {
                DrawFrame(fieldHandler.field);
            }

            List<string> lines = fieldHandler.GetFieldInStringList();
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

        public void DrawPointsFromList(FieldHandler fieldHandler)
        {
            List<DrawingPoint> pointListBuffer = new List<DrawingPoint>(PointsToDraw);
            PointsToDraw.Clear();

            foreach (DrawingPoint point in pointListBuffer)
            {
                RedrawCell(point.Position,point.Sign);
            }
        }

        private void DrawFrame(Field field)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write('╔');
            for (int i = 1; i < field.Width * 2+ FrameCorrection; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('═');
            }
            Console.SetCursorPosition(field.Width*2+ FrameCorrection, 0);
            Console.Write('╗');
            for (int i = 1; i < field.Heigth+ FrameCorrection; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('║');
                Thread.Sleep(10);
                Console.SetCursorPosition(field.Width * 2+ FrameCorrection, i);
                Console.Write('║');
            }
            Console.SetCursorPosition(0, field.Heigth+ FrameCorrection);
            Console.Write('╚');
            for (int i = 1; i < field.Width * 2+ FrameCorrection; i++)
            {
                Console.SetCursorPosition(i, field.Heigth+ FrameCorrection);
                Console.Write('═');
            }
            Console.SetCursorPosition(field.Width * 2+ FrameCorrection, field.Heigth+FrameCorrection);
            Console.Write('╝');
        }

        public void RedrawCell(Point position, char symbol)
        {
            Console.SetCursorPosition(position.X * 2 + FrameCorrection, position.Y + FrameCorrection);
            Console.Write(symbol);
        }
    }
}
