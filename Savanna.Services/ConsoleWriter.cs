using Savanna.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savanna.Services
{
    public class ConsoleWriter
    {
        public bool Frame;
        public char EmptySpace = '.';

        public ConsoleWriter(bool frame)
        {
            Frame = frame;
        }

        public void DrawFieldToConsole(FieldHandler fieldHandler)
        {
            Console.CursorVisible = false;

            List<string> lines = fieldHandler.GetFieldInStringList();          
            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(line[j]);
                }
            }
        }
        public void RedrawCell(Point position, char symbol)
        {
            Console.SetCursorPosition(position.X*2, position.Y);
            Console.Write(symbol);
        }
    }
}
